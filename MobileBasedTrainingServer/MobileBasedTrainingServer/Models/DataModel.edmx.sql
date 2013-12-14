
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/11/2013 12:03:22
-- Generated from EDMX file: C:\Users\mheggese\Documents\GiveCamp\mobileEmergencyTraining\MobileBasedTrainingServer\MobileBasedTrainingServer\Models\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MobileEmergencyTraining_db];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_VideoRatings_Ratings]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VideoRatings] DROP CONSTRAINT [FK_VideoRatings_Ratings];
GO
IF OBJECT_ID(N'[dbo].[FK_VideoRatings_Video]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VideoRatings] DROP CONSTRAINT [FK_VideoRatings_Video];
GO
IF OBJECT_ID(N'[dbo].[FK_VideoTags_Tags]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VideoTags] DROP CONSTRAINT [FK_VideoTags_Tags];
GO
IF OBJECT_ID(N'[dbo].[FK_VideoTags_Video]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VideoTags] DROP CONSTRAINT [FK_VideoTags_Video];
GO
IF OBJECT_ID(N'[dbo].[FK_ClusterCurriculum]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Courses] DROP CONSTRAINT [FK_ClusterCurriculum];
GO
IF OBJECT_ID(N'[dbo].[FK_VideoCourseVideo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourseVideos] DROP CONSTRAINT [FK_VideoCourseVideo];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseCourseVideo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourseVideos] DROP CONSTRAINT [FK_CourseCourseVideo];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Videos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Videos];
GO
IF OBJECT_ID(N'[dbo].[Tags]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tags];
GO
IF OBJECT_ID(N'[dbo].[Ratings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ratings];
GO
IF OBJECT_ID(N'[dbo].[Clusters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clusters];
GO
IF OBJECT_ID(N'[dbo].[Courses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Courses];
GO
IF OBJECT_ID(N'[dbo].[CourseVideos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourseVideos];
GO
IF OBJECT_ID(N'[dbo].[VideoRatings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VideoRatings];
GO
IF OBJECT_ID(N'[dbo].[VideoTags]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VideoTags];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Videos'
CREATE TABLE [dbo].[Videos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [PublicationDate] datetime  NOT NULL,
    [Language] nchar(2)  NOT NULL,
    [URL] nvarchar(max)  NOT NULL,
    [PublisherName] nvarchar(max)  NOT NULL,
    [PublisherEmail] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tags'
CREATE TABLE [dbo].[Tags] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Tag] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Ratings'
CREATE TABLE [dbo].[Ratings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Rating] tinyint  NOT NULL
);
GO

-- Creating table 'Clusters'
CREATE TABLE [dbo].[Clusters] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [IsGeneral] bit  NOT NULL
);
GO

-- Creating table 'Courses'
CREATE TABLE [dbo].[Courses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Cluster_Id] int  NOT NULL
);
GO

-- Creating table 'CourseVideos'
CREATE TABLE [dbo].[CourseVideos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Position] int  NOT NULL,
    [VideoId] int  NOT NULL,
    [CourseId] int  NOT NULL
);
GO

-- Creating table 'VideoRatings'
CREATE TABLE [dbo].[VideoRatings] (
    [Ratings_Id] int  NOT NULL,
    [Videos_Id] int  NOT NULL
);
GO

-- Creating table 'VideoTags'
CREATE TABLE [dbo].[VideoTags] (
    [Tags_Id] int  NOT NULL,
    [Videos_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Videos'
ALTER TABLE [dbo].[Videos]
ADD CONSTRAINT [PK_Videos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tags'
ALTER TABLE [dbo].[Tags]
ADD CONSTRAINT [PK_Tags]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Ratings'
ALTER TABLE [dbo].[Ratings]
ADD CONSTRAINT [PK_Ratings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Clusters'
ALTER TABLE [dbo].[Clusters]
ADD CONSTRAINT [PK_Clusters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [PK_Courses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CourseVideos'
ALTER TABLE [dbo].[CourseVideos]
ADD CONSTRAINT [PK_CourseVideos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Ratings_Id], [Videos_Id] in table 'VideoRatings'
ALTER TABLE [dbo].[VideoRatings]
ADD CONSTRAINT [PK_VideoRatings]
    PRIMARY KEY NONCLUSTERED ([Ratings_Id], [Videos_Id] ASC);
GO

-- Creating primary key on [Tags_Id], [Videos_Id] in table 'VideoTags'
ALTER TABLE [dbo].[VideoTags]
ADD CONSTRAINT [PK_VideoTags]
    PRIMARY KEY NONCLUSTERED ([Tags_Id], [Videos_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Ratings_Id] in table 'VideoRatings'
ALTER TABLE [dbo].[VideoRatings]
ADD CONSTRAINT [FK_VideoRatings_Ratings]
    FOREIGN KEY ([Ratings_Id])
    REFERENCES [dbo].[Ratings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Videos_Id] in table 'VideoRatings'
ALTER TABLE [dbo].[VideoRatings]
ADD CONSTRAINT [FK_VideoRatings_Video]
    FOREIGN KEY ([Videos_Id])
    REFERENCES [dbo].[Videos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VideoRatings_Video'
CREATE INDEX [IX_FK_VideoRatings_Video]
ON [dbo].[VideoRatings]
    ([Videos_Id]);
GO

-- Creating foreign key on [Tags_Id] in table 'VideoTags'
ALTER TABLE [dbo].[VideoTags]
ADD CONSTRAINT [FK_VideoTags_Tags]
    FOREIGN KEY ([Tags_Id])
    REFERENCES [dbo].[Tags]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Videos_Id] in table 'VideoTags'
ALTER TABLE [dbo].[VideoTags]
ADD CONSTRAINT [FK_VideoTags_Video]
    FOREIGN KEY ([Videos_Id])
    REFERENCES [dbo].[Videos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VideoTags_Video'
CREATE INDEX [IX_FK_VideoTags_Video]
ON [dbo].[VideoTags]
    ([Videos_Id]);
GO

-- Creating foreign key on [Cluster_Id] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [FK_ClusterCurriculum]
    FOREIGN KEY ([Cluster_Id])
    REFERENCES [dbo].[Clusters]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClusterCurriculum'
CREATE INDEX [IX_FK_ClusterCurriculum]
ON [dbo].[Courses]
    ([Cluster_Id]);
GO

-- Creating foreign key on [VideoId] in table 'CourseVideos'
ALTER TABLE [dbo].[CourseVideos]
ADD CONSTRAINT [FK_VideoCourseVideo]
    FOREIGN KEY ([VideoId])
    REFERENCES [dbo].[Videos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VideoCourseVideo'
CREATE INDEX [IX_FK_VideoCourseVideo]
ON [dbo].[CourseVideos]
    ([VideoId]);
GO

-- Creating foreign key on [CourseId] in table 'CourseVideos'
ALTER TABLE [dbo].[CourseVideos]
ADD CONSTRAINT [FK_CourseCourseVideo]
    FOREIGN KEY ([CourseId])
    REFERENCES [dbo].[Courses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseCourseVideo'
CREATE INDEX [IX_FK_CourseCourseVideo]
ON [dbo].[CourseVideos]
    ([CourseId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------