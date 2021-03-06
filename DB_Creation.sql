USE [master]
GO
/****** Object:  Database [IMMEDIA]    Script Date: 2020/09/21 7:59:34 AM ******/
CREATE DATABASE [IMMEDIA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IMMEDIA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\IMMEDIA.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'IMMEDIA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\IMMEDIA_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [IMMEDIA] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IMMEDIA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IMMEDIA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IMMEDIA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IMMEDIA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IMMEDIA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IMMEDIA] SET ARITHABORT OFF 
GO
ALTER DATABASE [IMMEDIA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [IMMEDIA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IMMEDIA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IMMEDIA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IMMEDIA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IMMEDIA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IMMEDIA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IMMEDIA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IMMEDIA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IMMEDIA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [IMMEDIA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IMMEDIA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IMMEDIA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IMMEDIA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IMMEDIA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IMMEDIA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [IMMEDIA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IMMEDIA] SET RECOVERY FULL 
GO
ALTER DATABASE [IMMEDIA] SET  MULTI_USER 
GO
ALTER DATABASE [IMMEDIA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IMMEDIA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IMMEDIA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IMMEDIA] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [IMMEDIA] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'IMMEDIA', N'ON'
GO
USE [IMMEDIA]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2020/09/21 7:59:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2020/09/21 7:59:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2020/09/21 7:59:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2020/09/21 7:59:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2020/09/21 7:59:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[DrivingLicenceNumber] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FourSquarePhotoMetaData]    Script Date: 2020/09/21 7:59:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FourSquarePhotoMetaData](
	[Id] [uniqueidentifier] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[PhotoId] [varchar](50) NULL,
	[PhotoPrefix] [varchar](1000) NULL,
	[PhotoSuffix] [varchar](1000) NULL,
	[PhotoWidth] [varchar](50) NULL,
	[PhotoHeight] [varchar](50) NULL,
	[PhotoOwner] [varchar](200) NULL,
	[PhotoVisibility] [varchar](50) NULL,
	[VenueId] [varchar](50) NOT NULL,
 CONSTRAINT [PK_FourSquarePhotoMetaData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FourSquareVenueMetaData]    Script Date: 2020/09/21 7:59:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FourSquareVenueMetaData](
	[Id] [uniqueidentifier] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[VenueId] [varchar](50) NOT NULL,
	[VenueName] [varchar](500) NULL,
	[VenueAddress] [varchar](1000) NULL,
	[VenueCrossStreet] [varchar](1000) NULL,
	[VenueLatitude] [varchar](100) NULL,
	[VenueLongitude] [varchar](100) NULL,
	[VenuePostalCode] [varchar](20) NULL,
	[VenueCC] [varchar](20) NULL,
	[VenueCity] [varchar](50) NULL,
	[VenueState] [varchar](100) NULL,
	[VenueCountry] [varchar](100) NULL,
	[VenueFormattedAddress] [varchar](2000) NULL,
	[VenueCategoryName] [varchar](200) NULL,
	[VenueCategoryNamePlural] [varchar](200) NULL,
	[VenueCategoryNameShort] [varchar](200) NULL,
	[VenueCategoryPrefix] [varchar](500) NULL,
	[VenueCategorySuffix] [varchar](50) NULL,
	[SearchNameEnteredByUser] [varchar](100) NOT NULL,
 CONSTRAINT [PK_FourSquareVenueMetaData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FourSquareVenueRecommendationsMetaData]    Script Date: 2020/09/21 7:59:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FourSquareVenueRecommendationsMetaData](
	[Id] [uniqueidentifier] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DisplayString] [varchar](500) NULL,
	[HeaderLocation] [varchar](500) NULL,
	[HeaderLocationFull] [varchar](500) NULL,
	[HeaderLocationGranularity] [varchar](100) NULL,
	[Latitude] [varchar](100) NULL,
	[Longitude] [varchar](100) NULL,
	[VenueId] [varchar](50) NULL,
	[VenueName] [varchar](500) NULL,
	[VenuePostalCode] [varchar](30) NULL,
	[VenueCC] [varchar](50) NULL,
	[VenueCity] [varchar](100) NULL,
	[VenueState] [varchar](100) NULL,
	[VenueCountry] [varchar](100) NULL,
	[VenueFormattedAddress] [varchar](500) NULL,
	[CategoryId] [varchar](50) NULL,
	[CategoryName] [varchar](100) NULL,
	[CategoryPluralName] [varchar](200) NULL,
	[CategoryShortName] [varchar](100) NULL,
	[CategoryPrefix] [varchar](1000) NULL,
	[CategorySuffix] [varchar](20) NULL,
	[UserSearchString] [varchar](100) NOT NULL,
 CONSTRAINT [PK_FourSquareVenueRecommendationsMetaData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  CONSTRAINT [DF_AspNetUsers_DrivingLicenceNumber]  DEFAULT ('') FOR [DrivingLicenceNumber]
GO
ALTER TABLE [dbo].[FourSquarePhotoMetaData] ADD  CONSTRAINT [DF_FourSquarePhotoMetaData_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[FourSquarePhotoMetaData] ADD  CONSTRAINT [DF_FourSquarePhotoMetaData_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[FourSquareVenueMetaData] ADD  CONSTRAINT [DF_FourSquareVenueMetaData_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[FourSquareVenueMetaData] ADD  CONSTRAINT [DF_FourSquareVenueMetaData_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[FourSquareVenueRecommendationsMetaData] ADD  CONSTRAINT [DF_FourSquareVenueRecommendationsMetaData_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[FourSquareVenueRecommendationsMetaData] ADD  CONSTRAINT [DF_FourSquareVenueRecommendationsMetaData_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
/****** Object:  StoredProcedure [dbo].[Foursquare_PhotoDetails_GetPhotoDetailsByPhotoId]    Script Date: 2020/09/21 7:59:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Foursquare_PhotoDetails_GetPhotoDetailsByPhotoId] --'4f06cd85e4b026656c72619f'
(@PhotoId VARCHAR(100)
)
AS
     SELECT Photo.Id, 
            Venues.CategoryName, 
            Venues.HeaderLocation, 
            Venues.VenueFormattedAddress,
			Photo.DateCreated, 
            PhotoId, 
            PhotoPrefix, 
            PhotoSuffix, 
            PhotoWidth, 
            PhotoHeight, 
            PhotoOwner, 
            PhotoVisibility, 
            Photo.VenueId
     FROM FourSquarePhotoMetaData Photo
          JOIN FourSquareVenueRecommendationsMetaData Venues ON Photo.VenueId = Venues.VenueId
     WHERE PhotoId = @PhotoId;
GO
/****** Object:  StoredProcedure [dbo].[Foursquare_PhotoList_PhotoListByVenueId]    Script Date: 2020/09/21 7:59:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Foursquare_PhotoList_PhotoListByVenueId] --'4b8f62e4f964a520115333e3'
(@VenueId VARCHAR(200)
)
AS
     SELECT Id, 
            PhotoId, 
            PhotoPrefix, 
            PhotoSuffix, 
            PhotoHeight, 
            PhotoWidth
     FROM FourSquarePhotoMetaData
     WHERE VenueId = @VenueId;
GO
/****** Object:  StoredProcedure [dbo].[Foursquare_VenueDetails_ListVenuesByVenueAreaName]    Script Date: 2020/09/21 7:59:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Foursquare_VenueDetails_ListVenuesByVenueAreaName] --'Durban'
(@AreaName VARCHAR(200)
)
AS
     SELECT Id, 
            DisplayString, 
            HeaderLocation, 
            Latitude, 
            Longitude, 
            VenueId, 
            VenueName, 
            VenueCC, 
            VenueCity, 
            VenueCountry, 
            VenueFormattedAddress, 
            CategoryName, 
            CategoryPrefix, 
            CategorySuffix, 
            CategoryId
     FROM FourSquareVenueRecommendationsMetaData
     WHERE UserSearchString = @AreaName;
GO
/****** Object:  StoredProcedure [dbo].[spGetVenuePhotos]    Script Date: 2020/09/21 7:59:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spGetVenuePhotos] --4bd2c54ba8b3a593107c685f
(@venueId VARCHAR(50)
)
AS
     SELECT HeaderLocation
     FROM [dbo].[FourSquareVenueRecommendationsMetaData] a
          JOIN [dbo].[FourSquarePhotoMetaData] b ON a.VenueId = b.VenueId;
GO
USE [master]
GO
ALTER DATABASE [IMMEDIA] SET  READ_WRITE 
GO
