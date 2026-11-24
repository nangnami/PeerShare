using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using PeerShare.Data;

namespace PeerShare.Services
{
    public static class ResourceService
    {
        private const long MaxFileSize = 20 * 1024 * 1024;

        private static readonly string[] AllowedExtensions =
        {
            ".pdf",
            ".doc",
            ".docx",
            ".ppt",
            ".pptx"
        };

        // GET ACTIVE SUBJECTS
        public static List<Subject> GetSubjects()
        {
            using (var db = new PeerShareDataContext())
            {
                return db.usp_Subject_GetAll()
                    .Select(s => new Subject
                    {
                        SubjectId = s.SubjectId,
                        SubjectName = s.SubjectName,
                        IsActive = s.IsActive
                    })
                    .ToList();
            }
        }
        // DASHBOARD STATISTICS
        public static int[] GetDashboardStatistics()
        {
            using (var db = new PeerShareDataContext())
            {
                var result = db.usp_Dashboard_GetStatistics(
                    SessionService.UserId).SingleOrDefault();

                if (result == null)
                    return new int[] { 0, 0, 0 };

                return new int[]
                {
                    Convert.ToInt32(result.TotalUploads),
                    Convert.ToInt32(result.MyUploads),
                    Convert.ToInt32(result.AvailableResources)
                };
            }
        }

        // RECENT UPLOADS
        public static List<string[]> GetRecentUploads()
        {
            using (var db = new PeerShareDataContext())
            {
                return db.usp_Dashboard_GetRecentUploads()
                    .Select(r => new string[]
                    {
                        r.Title,
                        r.SubjectName,
                        r.Username,
                        r.UploadedAt.ToString("MMM dd, yyyy")
                    }).ToList();
            }
        }

        public static List<string[]> GetAvailableResources()
        {
            if (!SessionService.IsLoggedIn)
                return new List<string[]>();

            using (var db = new PeerShareDataContext())
            {
                return db.usp_Resource_Search(
                    SessionService.UserId, null, null)
                    .Select(r => new string[]
                    {
                        r.Title,
                        r.SubjectName,
                        r.Username,
                        r.UploadedAt.ToString("MMMM dd, yyyy"),
                        r.Description,
                        r.ResourceId.ToString(),
                        r.FileName
                    }).ToList();
            }
        }

        public static byte[] GetResourceFile(int resourceId)
        {
            if (!SessionService.IsLoggedIn)
                throw new InvalidOperationException("Please log in first.");

            using (var db = new PeerShareDataContext())
            {
                var result = db.usp_Resource_GetFile(resourceId)
                    .SingleOrDefault();

                if (result == null || result.FileData == null)
                    throw new InvalidOperationException(
                        "The resource is no longer available.");

                return result.FileData.ToArray();
            }
        }

        public static void RecordDownload(int resourceId)
        {
            if (!SessionService.IsLoggedIn)
                throw new InvalidOperationException("Please log in first.");

            using (var db = new PeerShareDataContext())
            {
                db.usp_Download_Create(resourceId, SessionService.UserId);
            }
        }

        public static List<string[]> GetMyUploads()
        {
            if (!SessionService.IsLoggedIn)
                return new List<string[]>();

            using (var db = new PeerShareDataContext())
            {
                return db.usp_Resource_GetMyUploads(SessionService.UserId)
                    .Select(r => new string[]
                    {
                        r.Title,
                        r.SubjectName,
                        r.UploadedAt.ToString("MMM dd, yyyy"),
                        "Available",
                        r.ResourceId.ToString(),
                        r.Description,
                        r.FileName,
                        r.FileSize.ToString()
                    }).ToList();
            }
        }

        public static string DeleteResource(int resourceId)
        {
            if (!SessionService.IsLoggedIn)
                return "Please log in first.";

            using (var db = new PeerShareDataContext())
            {
                try
                {
                    db.usp_Resource_Delete(resourceId, SessionService.UserId);
                    return "SUCCESS";
                }
                catch (SqlException ex) when (ex.Number == 50006)
                {
                    return "Resource not found or access denied.";
                }
            }
        }

        public static string UpdateResource(
            int resourceId,
            string title,
            int subjectId,
            string description)
        {
            if (!SessionService.IsLoggedIn)
                return "Please log in first.";

            title = (title ?? "").Trim();
            description = (description ?? "").Trim();

            if (title.Length == 0 || title.Length > 200)
                return "Title must contain 1 to 200 characters.";

            if (description.Length == 0 || description.Length > 2000)
                return "Description must contain 1 to 2000 characters.";

            using (var db = new PeerShareDataContext())
            {
                try
                {
                    db.usp_Resource_Update(resourceId, SessionService.UserId,
                        title, subjectId, description);
                    return "SUCCESS";
                }
                catch (SqlException ex) when (ex.Number == 50004)
                {
                    return "Please select a valid subject.";
                }
                catch (SqlException ex) when (ex.Number == 50006)
                {
                    return "Resource not found or access denied.";
                }
            }
        }

        public static string UploadResource(string title, int subjectId,
            string description, string filePath)
        {
            return UploadResources(title, subjectId, description,
                new[] { filePath });
        }

        public static string UploadResources(string title, int subjectId,
            string description, IEnumerable<string> filePaths)
        {
            if (!SessionService.IsLoggedIn) return "Please log in first.";
            title = (title ?? "").Trim();
            description = (description ?? "").Trim();
            if (title.Length == 0 || title.Length > 200)
                return "Title must contain 1 to 200 characters.";
            if (description.Length == 0 || description.Length > 2000)
                return "Description must contain 1 to 2000 characters.";
            var paths = (filePaths ?? Enumerable.Empty<string>())
                .Distinct(StringComparer.OrdinalIgnoreCase).ToList();
            if (paths.Count == 0) return "Please select files.";
            foreach (string path in paths)
            {
                if (!File.Exists(path)) return "File not found: " + path;
                var info = new FileInfo(path);
                if (!AllowedExtensions.Contains(info.Extension.ToLowerInvariant()))
                    return "Unsupported format: " + info.Name;
                if (info.Name.Length > 255 || info.Length <= 0 || info.Length > MaxFileSize)
                    return "Invalid filename or size (maximum 20 MB): " + info.Name;
            }
            using (var db = new PeerShareDataContext())
            {
                db.Connection.Open();
                using (var transaction = db.Connection.BeginTransaction())
                {
                    db.Transaction = transaction;
                    try
                    {
                        foreach (string path in paths)
                        {
                            var info = new FileInfo(path);
                            byte[] bytes = File.ReadAllBytes(path);
                            if (bytes.LongLength == 0 || bytes.LongLength > MaxFileSize)
                                throw new InvalidDataException("Invalid file size: " + info.Name);
                            db.usp_Resource_Create(SessionService.UserId, subjectId,
                                title, description, info.Name, info.Extension.ToLowerInvariant(),
                                bytes.LongLength, new Binary(bytes));
                        }
                        transaction.Commit();
                        return "SUCCESS";
                    }
                    catch
                    {
                        try { transaction.Rollback(); } catch (InvalidOperationException) { }
                        throw;
                    }
                    finally { db.Transaction = null; }
                }
            }
        }
    }
}