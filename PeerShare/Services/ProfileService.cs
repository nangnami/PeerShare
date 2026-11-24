using System;
using System.Linq;
using System.Net.Mail;
using System.Data.SqlClient;
using PeerShare.Data;

namespace PeerShare.Services
{
    public static class ProfileService
    {
        // 1 - GET PROFILE
        public static string[] GetProfile()
        {
            if (!SessionService.IsLoggedIn)
                throw new InvalidOperationException(
                    "Please log in first.");

            using (var db = new PeerShareDataContext())
            {
                var user = db.usp_User_GetProfile(
                    SessionService.UserId
                ).SingleOrDefault();

                if (user == null)
                    throw new InvalidOperationException(
                        "User not found.");

                return new string[]
                {
                    user.Username,
                    user.Email
                };
            }
        }

        // 2 - UPDATE PROFILE
        public static string UpdateProfile(
            string username, string email)
        {
            if (!SessionService.IsLoggedIn)
                return "Please log in first.";

            username = (username ?? "").Trim();
            email = (email ?? "").Trim();

            if (username.Length < 3 || username.Length > 50)
                return "Username must contain 3 to 50 characters.";

            if (username.Contains("@"))
                return "Username cannot contain @.";

            if (string.IsNullOrWhiteSpace(email))
                return "Please enter your email address.";

            if (email.Length > 100)
                return "Email cannot exceed 100 characters.";

            try
            {
                MailAddress address = new MailAddress(email);

                if (address.Address != email)
                    return "Please enter a valid email address.";
            }
            catch (FormatException)
            {
                return "Please enter a valid email address.";
            }

            try
            {
                using (var db = new PeerShareDataContext())
                {
                    db.usp_User_UpdateProfile(
                        SessionService.UserId,
                        username,
                        email
                    );
                }

                SessionService.UpdateProfile(username, email);

                return "SUCCESS";
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50001)
                    return "Username is already taken.";

                if (ex.Number == 50002)
                    return "Email is already registered.";

                if (ex.Number == 50003)
                    return "User not found.";

                if (ex.Number == 2601 || ex.Number == 2627)
                    return "Username or email already exists.";

                throw;
            }
        }

        // 3 - CHANGE PASSWORD
        public static string ChangePassword(
            string currentPassword,
            string newPassword,
            string confirmPassword)
        {
            if (!SessionService.IsLoggedIn)
                return "Please log in first.";

            if (string.IsNullOrWhiteSpace(currentPassword))
                return "Please enter your current password.";

            if (currentPassword.Length > 128)
                return "Invalid current password.";

            if (string.IsNullOrWhiteSpace(newPassword))
                return "Please enter a new password.";

            if (newPassword.Length < 12 ||
                newPassword.Length > 128)
            {
                return "New password must contain 12 to 128 characters.";
            }

            if (newPassword != confirmPassword)
                return "New passwords do not match.";

            if (currentPassword == newPassword)
                return "New password must differ from your current password.";

            try
            {
                using (var db = new PeerShareDataContext())
                {
                    var user = db.usp_User_GetPasswordHash(
                        SessionService.UserId
                    ).SingleOrDefault();

                    if (user == null)
                        return "User not found.";

                    if (!PasswordHasher.VerifyPassword(
                        currentPassword,
                        user.PasswordHash))
                    {
                        return "Current password is incorrect.";
                    }

                    string newHash =
                        PasswordHasher.HashPassword(newPassword);

                    db.usp_User_ChangePassword(
                        SessionService.UserId,
                        user.PasswordHash,
                        newHash
                    );

                    return "SUCCESS";
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50008)
                    return "Password update failed. Please try again.";

                throw;
            }
        }
    }
}