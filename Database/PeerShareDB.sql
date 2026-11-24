-- PeerShare database provisioning. SQL Server 2016 SP1 or later.
-- Run with sqlcmd -b or SSMS. Existing data is preserved.
USE [master];
GO
IF DB_ID(N'PeerShareDB') IS NULL
    CREATE DATABASE [PeerShareDB];
GO
USE [PeerShareDB];
GO
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

IF OBJECT_ID(N'dbo.Downloads', N'U') IS NULL
BEGIN
CREATE TABLE [dbo].[Downloads](
	[DownloadId] [int] IDENTITY(1,1) NOT NULL,
	[ResourceId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[DownloadedAt] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DownloadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END;
GO

IF OBJECT_ID(N'dbo.Resources', N'U') IS NULL
BEGIN
CREATE TABLE [dbo].[Resources](
	[ResourceId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](2000) NOT NULL,
	[FileName] [nvarchar](255) NOT NULL,
	[FileExtension] [nvarchar](10) NOT NULL,
	[FileSize] [bigint] NOT NULL,
	[FileData] [varbinary](max) NOT NULL,
	[UploadedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[ResourceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END;
GO

IF OBJECT_ID(N'dbo.Subjects', N'U') IS NULL
BEGIN
CREATE TABLE [dbo].[Subjects](
	[SubjectId] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[SubjectName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END;
GO

IF OBJECT_ID(N'dbo.Users', N'U') IS NULL
BEGIN
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[PasswordHash] [nvarchar](255) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END;
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.Downloads') AND name = N'IX_Downloads_ResourceId')
BEGIN
CREATE NONCLUSTERED INDEX [IX_Downloads_ResourceId] ON [dbo].[Downloads]
(
	[ResourceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
END;
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.Downloads') AND name = N'IX_Downloads_UserId')
BEGIN
CREATE NONCLUSTERED INDEX [IX_Downloads_UserId] ON [dbo].[Downloads]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
END;
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.Resources') AND name = N'IX_Resources_SubjectId')
BEGIN
CREATE NONCLUSTERED INDEX [IX_Resources_SubjectId] ON [dbo].[Resources]
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
END;
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.Resources') AND name = N'IX_Resources_UserId')
BEGIN
CREATE NONCLUSTERED INDEX [IX_Resources_UserId] ON [dbo].[Resources]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
END;
GO

IF NOT EXISTS (SELECT 1 FROM sys.default_constraints WHERE parent_object_id = OBJECT_ID(N'dbo.Downloads') AND parent_column_id = COLUMNPROPERTY(OBJECT_ID(N'dbo.Downloads'), N'DownloadedAt', 'ColumnId'))
BEGIN
ALTER TABLE [dbo].[Downloads] ADD  DEFAULT (sysdatetime()) FOR [DownloadedAt]
END;
GO

IF NOT EXISTS (SELECT 1 FROM sys.default_constraints WHERE parent_object_id = OBJECT_ID(N'dbo.Resources') AND parent_column_id = COLUMNPROPERTY(OBJECT_ID(N'dbo.Resources'), N'UploadedAt', 'ColumnId'))
BEGIN
ALTER TABLE [dbo].[Resources] ADD  DEFAULT (sysdatetime()) FOR [UploadedAt]
END;
GO

IF NOT EXISTS (SELECT 1 FROM sys.default_constraints WHERE parent_object_id = OBJECT_ID(N'dbo.Subjects') AND parent_column_id = COLUMNPROPERTY(OBJECT_ID(N'dbo.Subjects'), N'IsActive', 'ColumnId'))
BEGIN
ALTER TABLE [dbo].[Subjects] ADD  DEFAULT ((1)) FOR [IsActive]
END;
GO

IF NOT EXISTS (SELECT 1 FROM sys.default_constraints WHERE parent_object_id = OBJECT_ID(N'dbo.Users') AND parent_column_id = COLUMNPROPERTY(OBJECT_ID(N'dbo.Users'), N'CreatedAt', 'ColumnId'))
BEGIN
ALTER TABLE [dbo].[Users] ADD  DEFAULT (sysdatetime()) FOR [CreatedAt]
END;
GO

IF OBJECT_ID(N'dbo.FK_Downloads_Resources') IS NULL
BEGIN
ALTER TABLE [dbo].[Downloads]  WITH CHECK ADD  CONSTRAINT [FK_Downloads_Resources] FOREIGN KEY([ResourceId])
REFERENCES [dbo].[Resources] ([ResourceId])
ON DELETE CASCADE
END;
GO

ALTER TABLE [dbo].[Downloads] CHECK CONSTRAINT [FK_Downloads_Resources]
GO

IF OBJECT_ID(N'dbo.FK_Downloads_Users') IS NULL
BEGIN
ALTER TABLE [dbo].[Downloads]  WITH CHECK ADD  CONSTRAINT [FK_Downloads_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
END;
GO

ALTER TABLE [dbo].[Downloads] CHECK CONSTRAINT [FK_Downloads_Users]
GO

IF OBJECT_ID(N'dbo.FK_Resources_Subjects') IS NULL
BEGIN
ALTER TABLE [dbo].[Resources]  WITH CHECK ADD  CONSTRAINT [FK_Resources_Subjects] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([SubjectId])
END;
GO

ALTER TABLE [dbo].[Resources] CHECK CONSTRAINT [FK_Resources_Subjects]
GO

IF OBJECT_ID(N'dbo.FK_Resources_Users') IS NULL
BEGIN
ALTER TABLE [dbo].[Resources]  WITH CHECK ADD  CONSTRAINT [FK_Resources_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
END;
GO

ALTER TABLE [dbo].[Resources] CHECK CONSTRAINT [FK_Resources_Users]
GO

IF OBJECT_ID(N'dbo.CK_Resources_Description') IS NULL
BEGIN
ALTER TABLE [dbo].[Resources]  WITH CHECK ADD  CONSTRAINT [CK_Resources_Description] CHECK  ((len(ltrim(rtrim([Description])))>(0)))
END;
GO

ALTER TABLE [dbo].[Resources] CHECK CONSTRAINT [CK_Resources_Description]
GO

IF OBJECT_ID(N'dbo.CK_Resources_FileExtension') IS NULL
BEGIN
ALTER TABLE [dbo].[Resources]  WITH CHECK ADD  CONSTRAINT [CK_Resources_FileExtension] CHECK  (([FileExtension]='.pptx' OR [FileExtension]='.ppt' OR [FileExtension]='.docx' OR [FileExtension]='.doc' OR [FileExtension]='.pdf'))
END;
GO

ALTER TABLE [dbo].[Resources] CHECK CONSTRAINT [CK_Resources_FileExtension]
GO

IF OBJECT_ID(N'dbo.CK_Resources_FileSize') IS NULL
BEGIN
ALTER TABLE [dbo].[Resources]  WITH CHECK ADD  CONSTRAINT [CK_Resources_FileSize] CHECK  (([FileSize]>(0) AND [FileSize]<=(20971520) AND [FileSize]=datalength([FileData])))
END;
GO

ALTER TABLE [dbo].[Resources] CHECK CONSTRAINT [CK_Resources_FileSize]
GO

IF OBJECT_ID(N'dbo.CK_Resources_Title') IS NULL
BEGIN
ALTER TABLE [dbo].[Resources]  WITH CHECK ADD  CONSTRAINT [CK_Resources_Title] CHECK  ((len(ltrim(rtrim([Title])))>(0)))
END;
GO

ALTER TABLE [dbo].[Resources] CHECK CONSTRAINT [CK_Resources_Title]
GO

CREATE OR ALTER PROCEDURE [dbo].[usp_Dashboard_GetRecentUploads]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP (10)
        r.ResourceId,
        r.Title,
        s.SubjectName,
        u.Username,
        r.UploadedAt
    FROM dbo.Resources r
    INNER JOIN dbo.Users u
        ON r.UserId = u.UserId
    INNER JOIN dbo.Subjects s
        ON r.SubjectId = s.SubjectId
    ORDER BY
        r.UploadedAt DESC,
        r.ResourceId DESC;
END;
GO

CREATE OR ALTER PROCEDURE [dbo].[usp_Dashboard_GetStatistics]
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        COUNT(*) AS TotalUploads,

        COUNT(
            CASE WHEN UserId = @UserId THEN 1 END
        ) AS MyUploads,

        COUNT(*) AS AvailableResources

    FROM dbo.Resources;
END;
GO

CREATE OR ALTER PROCEDURE [dbo].[usp_Download_Create]
    @ResourceId INT,
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1 FROM dbo.Resources
        WHERE ResourceId = @ResourceId
    )
    BEGIN
        THROW 50007, 'Resource is no longer available.', 1;
    END;

    IF NOT EXISTS (
        SELECT 1 FROM dbo.Users
        WHERE UserId = @UserId
    )
    BEGIN
        THROW 50003, 'User does not exist.', 1;
    END;

    INSERT INTO dbo.Downloads
    (
        ResourceId,
        UserId,
        DownloadedAt
    )
    VALUES
    (
        @ResourceId,
        @UserId,
        SYSDATETIME()
    );
END;
GO

CREATE OR ALTER PROCEDURE [dbo].[usp_Resource_Create]
    @UserId INT,
    @SubjectId INT,
    @Title NVARCHAR(200),
    @Description NVARCHAR(2000),
    @FileName NVARCHAR(255),
    @FileExtension NVARCHAR(10),
    @FileSize BIGINT,
    @FileData VARBINARY(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    -- Validate user
    IF NOT EXISTS (
        SELECT 1 FROM dbo.Users
        WHERE UserId = @UserId
    )
    BEGIN
        THROW 50003, 'User does not exist.', 1;
    END;

    -- Validate subject
    IF NOT EXISTS (
        SELECT 1 FROM dbo.Subjects
        WHERE SubjectId = @SubjectId
          AND IsActive = 1
    )
    BEGIN
        THROW 50004, 'Invalid or inactive subject.', 1;
    END;

    -- Validate file size
    IF @FileData IS NULL
       OR @FileSize IS NULL
       OR @FileSize <= 0
       OR @FileSize > 20971520
       OR @FileSize <> DATALENGTH(@FileData)
    BEGIN
        THROW 50005, 'Invalid file size.', 1;
    END;

    -- Insert resource
    INSERT INTO dbo.Resources
    (
        UserId,
        SubjectId,
        Title,
        Description,
        FileName,
        FileExtension,
        FileSize,
        FileData,
        UploadedAt,
        UpdatedAt
    )
    VALUES
    (
        @UserId,
        @SubjectId,
        @Title,
        @Description,
        @FileName,
        @FileExtension,
        @FileSize,
        @FileData,
        SYSDATETIME(),
        NULL
    );
END;
GO

CREATE OR ALTER PROCEDURE [dbo].[usp_Resource_Delete]
    @ResourceId INT,
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.Resources
    WHERE ResourceId = @ResourceId
      AND UserId = @UserId;

    IF @@ROWCOUNT = 0
    BEGIN
        THROW 50006, 'Resource not found or access denied.', 1;
    END;
END;
GO

CREATE OR ALTER PROCEDURE [dbo].[usp_Resource_GetFile]
    @ResourceId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT FileData
    FROM dbo.Resources
    WHERE ResourceId = @ResourceId;
END;
GO

CREATE OR ALTER PROCEDURE [dbo].[usp_Resource_GetMyUploads]
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        r.ResourceId,
        r.Title,
        s.SubjectName,
        r.UploadedAt,
        r.Description,
        r.FileName,
        r.FileSize
    FROM dbo.Resources r
    INNER JOIN dbo.Subjects s
        ON r.SubjectId = s.SubjectId
    WHERE r.UserId = @UserId
    ORDER BY r.UploadedAt DESC,
             r.ResourceId DESC;
END;
GO

CREATE OR ALTER PROCEDURE [dbo].[usp_Resource_Search]
    @UserId INT,
    @Keyword NVARCHAR(200) = NULL,
    @SubjectId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        r.ResourceId,
        r.Title,
        s.SubjectName,
        u.Username,
        r.UploadedAt,
        r.Description,
        r.FileName
    FROM dbo.Resources r
    INNER JOIN dbo.Users u
        ON r.UserId = u.UserId
    INNER JOIN dbo.Subjects s
        ON r.SubjectId = s.SubjectId
    WHERE
        (
            @SubjectId IS NULL
            OR r.SubjectId = @SubjectId
        )
        AND
        (
            @Keyword IS NULL
            OR @Keyword = ''
            OR r.Title LIKE '%' + @Keyword + '%'
            OR r.Description LIKE '%' + @Keyword + '%'
            OR s.SubjectName LIKE '%' + @Keyword + '%'
            OR u.Username LIKE '%' + @Keyword + '%'
            OR r.FileName LIKE '%' + @Keyword + '%'
        )
    ORDER BY
        r.UploadedAt DESC,
        r.ResourceId DESC;
END;
GO

CREATE OR ALTER PROCEDURE [dbo].[usp_Resource_Update]
    @ResourceId INT,
    @UserId INT,
    @Title NVARCHAR(200),
    @SubjectId INT,
    @Description NVARCHAR(2000)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1 FROM dbo.Subjects
        WHERE SubjectId = @SubjectId
          AND IsActive = 1
    )
    BEGIN
        THROW 50004, 'Invalid or inactive subject.', 1;
    END;

    UPDATE dbo.Resources
    SET
        Title = @Title,
        SubjectId = @SubjectId,
        Description = @Description,
        UpdatedAt = SYSDATETIME()
    WHERE ResourceId = @ResourceId
      AND UserId = @UserId;

    IF @@ROWCOUNT = 0
    BEGIN
        THROW 50006, 'Resource not found or access denied.', 1;
    END;
END;
GO

CREATE OR ALTER PROCEDURE [dbo].[usp_Subject_GetAll]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        SubjectId,
        SubjectName,
        IsActive
    FROM dbo.Subjects
    WHERE IsActive = 1
    ORDER BY SubjectName ASC;
END;
GO

-- 5. CHANGE PASSWORD

CREATE OR ALTER PROCEDURE [dbo].[usp_User_ChangePassword]
    @UserId INT,
    @CurrentPasswordHash NVARCHAR(255),
    @NewPasswordHash NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Users
    SET PasswordHash = @NewPasswordHash
    WHERE UserId = @UserId
      AND PasswordHash = @CurrentPasswordHash;

    IF @@ROWCOUNT = 0
    BEGIN
        THROW 50008, 'Password update failed.', 1;
    END;
END;
GO

CREATE OR ALTER PROCEDURE [dbo].[usp_User_GetByLogin]
    @Login NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        UserId,
        Username,
        Email,
        PasswordHash,
        CreatedAt
    FROM dbo.Users
    WHERE Username = @Login
       OR Email = @Login;
END;
GO

-- 4. GET CURRENT PASSWORD HASH

CREATE OR ALTER PROCEDURE [dbo].[usp_User_GetPasswordHash]
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT PasswordHash
    FROM dbo.Users
    WHERE UserId = @UserId;
END;
GO

CREATE OR ALTER PROCEDURE [dbo].[usp_User_GetProfile]
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        UserId,
        Username,
        Email,
        CreatedAt
    FROM dbo.Users
    WHERE UserId = @UserId;
END;
GO

CREATE OR ALTER PROCEDURE [dbo].[usp_User_Register]
    @Username NVARCHAR(50),
    @Email NVARCHAR(100),
    @PasswordHash NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1 FROM dbo.Users
        WHERE Username = @Username
    )
    BEGIN
        THROW 50001, 'Username already exists.', 1;
    END;

    IF EXISTS (
        SELECT 1 FROM dbo.Users
        WHERE Email = @Email
    )
    BEGIN
        THROW 50002, 'Email already exists.', 1;
    END;

    INSERT INTO dbo.Users
    (
        Username,
        Email,
        PasswordHash,
        CreatedAt
    )
    VALUES
    (
        @Username,
        @Email,
        @PasswordHash,
        SYSDATETIME()
    );
END;
GO

CREATE OR ALTER PROCEDURE [dbo].[usp_User_UpdateProfile]
    @UserId INT,
    @Username NVARCHAR(50),
    @Email NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM dbo.Users
        WHERE Username = @Username
          AND UserId <> @UserId
    )
    BEGIN
        THROW 50001, 'Username already exists.', 1;
    END;

    IF EXISTS (
        SELECT 1
        FROM dbo.Users
        WHERE Email = @Email
          AND UserId <> @UserId
    )
    BEGIN
        THROW 50002, 'Email already exists.', 1;
    END;

    UPDATE dbo.Users
    SET
        Username = @Username,
        Email = @Email
    WHERE UserId = @UserId;

    IF @@ROWCOUNT = 0
    BEGIN
        THROW 50003, 'User not found.', 1;
    END;
END;
GO

-- Seed missing categories only; preserve existing category IDs and status.
INSERT INTO dbo.Subjects (SubjectName, IsActive)
SELECT v.SubjectName, 1
FROM (VALUES (N'Programming'), (N'Database Management'), (N'Networking'), (N'Web Development'), (N'Information Management'), (N'Other')) AS v(SubjectName)
WHERE NOT EXISTS (SELECT 1 FROM dbo.Subjects s WHERE s.SubjectName = v.SubjectName);
GO
