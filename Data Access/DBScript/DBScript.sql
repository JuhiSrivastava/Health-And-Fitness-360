USE [master]
GO
/****** Object:  Database [HealthAndFitnessDB]    Script Date: 12/02/2021 17:39:18 ******/
CREATE DATABASE [HealthAndFitnessDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HealthAndFitnessDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\HealthAndFitnessDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HealthAndFitnessDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\HealthAndFitnessDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [HealthAndFitnessDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HealthAndFitnessDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HealthAndFitnessDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HealthAndFitnessDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HealthAndFitnessDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HealthAndFitnessDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HealthAndFitnessDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [HealthAndFitnessDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HealthAndFitnessDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HealthAndFitnessDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HealthAndFitnessDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HealthAndFitnessDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HealthAndFitnessDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HealthAndFitnessDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HealthAndFitnessDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HealthAndFitnessDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HealthAndFitnessDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HealthAndFitnessDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HealthAndFitnessDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HealthAndFitnessDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HealthAndFitnessDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HealthAndFitnessDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HealthAndFitnessDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HealthAndFitnessDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HealthAndFitnessDB] SET RECOVERY FULL 
GO
ALTER DATABASE [HealthAndFitnessDB] SET  MULTI_USER 
GO
ALTER DATABASE [HealthAndFitnessDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HealthAndFitnessDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HealthAndFitnessDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HealthAndFitnessDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HealthAndFitnessDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HealthAndFitnessDB', N'ON'
GO
ALTER DATABASE [HealthAndFitnessDB] SET QUERY_STORE = OFF
GO
USE [HealthAndFitnessDB]
GO
/****** Object:  Table [dbo].[AgeGrpWorkout]    Script Date: 12/02/2021 17:39:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgeGrpWorkout](
	[Start Age] [int] NOT NULL,
	[End Age] [int] NOT NULL,
	[Workout Plan] [nvarchar](50) NOT NULL,
	[Calories] [nchar](10) NOT NULL,
 CONSTRAINT [PK_AgeGrpWorkout] PRIMARY KEY CLUSTERED 
(
	[Start Age] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodItems]    Script Date: 12/02/2021 17:39:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodItems](
	[FoodItems] [nvarchar](50) NOT NULL,
	[Calories] [int] NOT NULL,
	[Nutrients] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_FoodItems] PRIMARY KEY CLUSTERED 
(
	[FoodItems] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SymptomsOrDisease]    Script Date: 12/02/2021 17:39:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SymptomsOrDisease](
	[SymptomsOrDiseaseName] [nvarchar](50) NOT NULL,
	[Medication] [nvarchar](50) NOT NULL,
	[Tests] [nvarchar](50) NOT NULL,
	[Cure] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SymptomsOrDisease] PRIMARY KEY CLUSTERED 
(
	[SymptomsOrDiseaseName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserHealthInfo]    Script Date: 12/02/2021 17:39:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserHealthInfo](
	[EmailId] [nvarchar](50) NOT NULL,
	[Calories Day 1] [int] NULL,
	[Calories Day 2] [int] NULL,
	[Calories Day 3] [int] NULL,
	[Calories Day 4] [int] NULL,
	[Calories Day 5] [int] NULL,
	[Calories Day 6] [int] NULL,
	[Calories Day 7] [int] NULL,
	[CurrentCalories] [int] NULL,
	[PeriodDate] [datetime] NULL,
	[FertilityDate] [datetime] NULL,
	[Medication1] [nvarchar](50) NULL,
	[StartDateM1] [datetime] NULL,
	[DurationM1] [int] NULL,
	[Medication2] [nvarchar](50) NULL,
	[StartDateM2] [datetime] NULL,
	[DurationM2] [int] NULL,
	[MenstrualCycleDuration] [int] NULL,
	[PregnancyDate] [datetime] NULL,
 CONSTRAINT [PK_UserHealthInfo] PRIMARY KEY CLUSTERED 
(
	[EmailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 12/02/2021 17:39:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[UserName] [nvarchar](50) NOT NULL,
	[UserAge] [int] NOT NULL,
	[UserHeight] [nchar](10) NOT NULL,
	[UserWeight] [nchar](10) NOT NULL,
	[UserMobile] [nvarchar](50) NOT NULL,
	[EmailId] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[EmailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSymptoms]    Script Date: 12/02/2021 17:39:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSymptoms](
	[EmailAddress] [nvarchar](50) NOT NULL,
	[Symptoms] [nvarchar](50) NOT NULL,
	[UserId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_UserSymptoms_1] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserSymptoms]    Script Date: 12/02/2021 17:39:19 ******/
CREATE NONCLUSTERED INDEX [IX_UserSymptoms] ON [dbo].[UserSymptoms]
(
	[EmailAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserHealthInfo]  WITH CHECK ADD  CONSTRAINT [FK_UserHealthInfo_UserInfo] FOREIGN KEY([EmailId])
REFERENCES [dbo].[UserInfo] ([EmailId])
GO
ALTER TABLE [dbo].[UserHealthInfo] CHECK CONSTRAINT [FK_UserHealthInfo_UserInfo]
GO
ALTER TABLE [dbo].[UserSymptoms]  WITH CHECK ADD  CONSTRAINT [FK_Email_Address] FOREIGN KEY([EmailAddress])
REFERENCES [dbo].[UserInfo] ([EmailId])
GO
ALTER TABLE [dbo].[UserSymptoms] CHECK CONSTRAINT [FK_Email_Address]
GO
ALTER TABLE [dbo].[UserSymptoms]  WITH CHECK ADD  CONSTRAINT [FK_SymptomsOrDisease] FOREIGN KEY([Symptoms])
REFERENCES [dbo].[SymptomsOrDisease] ([SymptomsOrDiseaseName])
GO
ALTER TABLE [dbo].[UserSymptoms] CHECK CONSTRAINT [FK_SymptomsOrDisease]
GO
USE [master]
GO
ALTER DATABASE [HealthAndFitnessDB] SET  READ_WRITE 
GO
