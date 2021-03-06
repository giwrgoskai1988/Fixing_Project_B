USE [master]
GO
/****** Object:  Database [George_Nikolakeas_PROJECT_B]    Script Date: 18/9/2020 5:31:23 μμ ******/
CREATE DATABASE [George_Nikolakeas_PROJECT_B]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'George_Nikolakeas_PROJECT_B', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\George_Nikolakeas_PROJECT_B' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'George_Nikolakeas_PROJECT_B_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\George_Nikolakeas_PROJECT_B_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [George_Nikolakeas_PROJECT_B].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET ARITHABORT OFF 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET  DISABLE_BROKER 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET RECOVERY FULL 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET  MULTI_USER 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET DB_CHAINING OFF 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'George_Nikolakeas_PROJECT_B', N'ON'
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET QUERY_STORE = OFF
GO
USE [George_Nikolakeas_PROJECT_B]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 18/9/2020 5:31:24 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[TuitionFee] [decimal](8, 2) NOT NULL,
 CONSTRAINT [PK__Students__32C52A79EF4D857E] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[StudentList]    Script Date: 18/9/2020 5:31:24 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[StudentList]
as
select * from Students
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 18/9/2020 5:31:24 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Stream] [nvarchar](50) NOT NULL,
	[Type] [bit] NOT NULL,
	[Start_date] [datetime] NOT NULL,
	[End_date] [datetime] NOT NULL,
 CONSTRAINT [PK__Courses__C92D71874E3B6DA4] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[CourseList]    Script Date: 18/9/2020 5:31:24 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[CourseList]
as
select * from Courses
GO
/****** Object:  Table [dbo].[Trainers]    Script Date: 18/9/2020 5:31:24 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainers](
	[TrainerID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Subject] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Trainers__366A1B9C438E108A] PRIMARY KEY CLUSTERED 
(
	[TrainerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[TrainerList]    Script Date: 18/9/2020 5:31:24 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[TrainerList]
as
select * from Trainers
GO
/****** Object:  Table [dbo].[Assignments]    Script Date: 18/9/2020 5:31:24 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assignments](
	[AssID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[SubDateTime] [datetime] NOT NULL,
	[OralMark] [int] NOT NULL,
	[TotalMark] [int] NOT NULL,
 CONSTRAINT [PK__Assignme__44ABB03EDDD0F817] PRIMARY KEY CLUSTERED 
(
	[AssID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[AssignmentList]    Script Date: 18/9/2020 5:31:24 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[AssignmentList]
as
select * from Assignments
GO
/****** Object:  Table [dbo].[Course_Students]    Script Date: 18/9/2020 5:31:24 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course_Students](
	[CourseID] [int] NOT NULL,
	[StudentID] [int] NOT NULL,
 CONSTRAINT [PK_Course_Students] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC,
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[StudentsPerCourse]    Script Date: 18/9/2020 5:31:24 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[StudentsPerCourse]
as
select c.*,s.* from Courses as c,Course_Students as cs,Students as s
where c.CourseID = cs.CourseID and cs.StudentID = s.StudentID
GO
/****** Object:  Table [dbo].[Course_Trainers]    Script Date: 18/9/2020 5:31:24 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course_Trainers](
	[CourseID] [int] NOT NULL,
	[TrainerID] [int] NOT NULL,
 CONSTRAINT [PK_Course_Trainers] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC,
	[TrainerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[TrainersPerCourse]    Script Date: 18/9/2020 5:31:24 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[TrainersPerCourse]
as
select c.*,t.* from Courses as c,Course_Trainers as ct,Trainers as t
where c.CourseID = ct.CourseID and ct.TrainerID = t.TrainerID
GO
/****** Object:  Table [dbo].[Course_Assignments]    Script Date: 18/9/2020 5:31:24 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course_Assignments](
	[CourseID] [int] NOT NULL,
	[AssID] [int] NOT NULL,
 CONSTRAINT [PK_Course_Assignments] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC,
	[AssID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[WeirdView_AssPerCourse]    Script Date: 18/9/2020 5:31:24 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view  [dbo].[WeirdView_AssPerCourse]
as
select c.*,a.AssID,a.Title as 'Assignment Title',a.Description,a.SubDateTime,
a.OralMark,a.TotalMark from Courses as c,Course_Assignments as ca,Assignments as a
where c.CourseID = ca.CourseID and ca.AssID = a.AssID
GO
SET IDENTITY_INSERT [dbo].[Assignments] ON 

INSERT [dbo].[Assignments] ([AssID], [Title], [Description], [SubDateTime], [OralMark], [TotalMark]) VALUES (1, N'Ass 1', N'Description1', CAST(N'2020-07-14T00:00:00.000' AS DateTime), 40, 100)
INSERT [dbo].[Assignments] ([AssID], [Title], [Description], [SubDateTime], [OralMark], [TotalMark]) VALUES (2, N'Ass 2', N'Description2', CAST(N'2020-10-18T00:00:00.000' AS DateTime), 30, 150)
INSERT [dbo].[Assignments] ([AssID], [Title], [Description], [SubDateTime], [OralMark], [TotalMark]) VALUES (3, N'Ass 3', N'Description3', CAST(N'2021-01-02T00:00:00.000' AS DateTime), 80, 100)
INSERT [dbo].[Assignments] ([AssID], [Title], [Description], [SubDateTime], [OralMark], [TotalMark]) VALUES (4, N'Ass 4', N'Description4', CAST(N'2020-09-12T00:00:00.000' AS DateTime), 20, 140)
INSERT [dbo].[Assignments] ([AssID], [Title], [Description], [SubDateTime], [OralMark], [TotalMark]) VALUES (5, N'Ass 5', N'Description5', CAST(N'2020-08-18T00:00:00.000' AS DateTime), 60, 180)
INSERT [dbo].[Assignments] ([AssID], [Title], [Description], [SubDateTime], [OralMark], [TotalMark]) VALUES (6, N'Ass 6', N'Description6', CAST(N'2020-09-14T00:00:00.000' AS DateTime), 50, 120)
SET IDENTITY_INSERT [dbo].[Assignments] OFF
GO
INSERT [dbo].[Course_Assignments] ([CourseID], [AssID]) VALUES (1, 1)
INSERT [dbo].[Course_Assignments] ([CourseID], [AssID]) VALUES (1, 2)
INSERT [dbo].[Course_Assignments] ([CourseID], [AssID]) VALUES (2, 3)
INSERT [dbo].[Course_Assignments] ([CourseID], [AssID]) VALUES (2, 6)
INSERT [dbo].[Course_Assignments] ([CourseID], [AssID]) VALUES (3, 3)
INSERT [dbo].[Course_Assignments] ([CourseID], [AssID]) VALUES (4, 4)
INSERT [dbo].[Course_Assignments] ([CourseID], [AssID]) VALUES (4, 5)
INSERT [dbo].[Course_Assignments] ([CourseID], [AssID]) VALUES (5, 5)
INSERT [dbo].[Course_Assignments] ([CourseID], [AssID]) VALUES (5, 6)
INSERT [dbo].[Course_Assignments] ([CourseID], [AssID]) VALUES (6, 4)
INSERT [dbo].[Course_Assignments] ([CourseID], [AssID]) VALUES (6, 5)
GO
INSERT [dbo].[Course_Students] ([CourseID], [StudentID]) VALUES (1, 1)
INSERT [dbo].[Course_Students] ([CourseID], [StudentID]) VALUES (1, 3)
INSERT [dbo].[Course_Students] ([CourseID], [StudentID]) VALUES (1, 4)
INSERT [dbo].[Course_Students] ([CourseID], [StudentID]) VALUES (2, 2)
INSERT [dbo].[Course_Students] ([CourseID], [StudentID]) VALUES (2, 3)
INSERT [dbo].[Course_Students] ([CourseID], [StudentID]) VALUES (3, 5)
INSERT [dbo].[Course_Students] ([CourseID], [StudentID]) VALUES (3, 6)
INSERT [dbo].[Course_Students] ([CourseID], [StudentID]) VALUES (4, 1)
INSERT [dbo].[Course_Students] ([CourseID], [StudentID]) VALUES (4, 2)
INSERT [dbo].[Course_Students] ([CourseID], [StudentID]) VALUES (5, 5)
INSERT [dbo].[Course_Students] ([CourseID], [StudentID]) VALUES (5, 6)
INSERT [dbo].[Course_Students] ([CourseID], [StudentID]) VALUES (6, 4)
GO
INSERT [dbo].[Course_Trainers] ([CourseID], [TrainerID]) VALUES (1, 1)
INSERT [dbo].[Course_Trainers] ([CourseID], [TrainerID]) VALUES (1, 2)
INSERT [dbo].[Course_Trainers] ([CourseID], [TrainerID]) VALUES (2, 2)
INSERT [dbo].[Course_Trainers] ([CourseID], [TrainerID]) VALUES (2, 4)
INSERT [dbo].[Course_Trainers] ([CourseID], [TrainerID]) VALUES (3, 1)
INSERT [dbo].[Course_Trainers] ([CourseID], [TrainerID]) VALUES (3, 3)
INSERT [dbo].[Course_Trainers] ([CourseID], [TrainerID]) VALUES (4, 2)
INSERT [dbo].[Course_Trainers] ([CourseID], [TrainerID]) VALUES (4, 5)
INSERT [dbo].[Course_Trainers] ([CourseID], [TrainerID]) VALUES (5, 3)
INSERT [dbo].[Course_Trainers] ([CourseID], [TrainerID]) VALUES (5, 6)
INSERT [dbo].[Course_Trainers] ([CourseID], [TrainerID]) VALUES (6, 2)
INSERT [dbo].[Course_Trainers] ([CourseID], [TrainerID]) VALUES (6, 4)
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([CourseID], [Title], [Stream], [Type], [Start_date], [End_date]) VALUES (1, N'CB19', N'C#', 1, CAST(N'2020-07-13T00:00:00.000' AS DateTime), CAST(N'2020-10-13T00:00:00.000' AS DateTime))
INSERT [dbo].[Courses] ([CourseID], [Title], [Stream], [Type], [Start_date], [End_date]) VALUES (2, N'CB19', N'Python', 1, CAST(N'2020-07-13T00:00:00.000' AS DateTime), CAST(N'2021-04-04T00:00:00.000' AS DateTime))
INSERT [dbo].[Courses] ([CourseID], [Title], [Stream], [Type], [Start_date], [End_date]) VALUES (3, N'CB19', N'Python', 0, CAST(N'2020-07-13T00:00:00.000' AS DateTime), CAST(N'2020-10-21T00:00:00.000' AS DateTime))
INSERT [dbo].[Courses] ([CourseID], [Title], [Stream], [Type], [Start_date], [End_date]) VALUES (4, N'CB19', N'Java', 0, CAST(N'2020-07-13T00:00:00.000' AS DateTime), CAST(N'2020-10-21T00:00:00.000' AS DateTime))
INSERT [dbo].[Courses] ([CourseID], [Title], [Stream], [Type], [Start_date], [End_date]) VALUES (5, N'CB20', N'JavaScript', 1, CAST(N'2021-07-13T00:00:00.000' AS DateTime), CAST(N'2021-10-21T00:00:00.000' AS DateTime))
INSERT [dbo].[Courses] ([CourseID], [Title], [Stream], [Type], [Start_date], [End_date]) VALUES (6, N'CB20', N'C#', 1, CAST(N'2020-07-13T00:00:00.000' AS DateTime), CAST(N'2020-10-14T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentID], [FirstName], [LastName], [DateOfBirth], [TuitionFee]) VALUES (1, N'Student1', N'ST1 LastName', CAST(N'1999-05-06T00:00:00.000' AS DateTime), CAST(1500.00 AS Decimal(8, 2)))
INSERT [dbo].[Students] ([StudentID], [FirstName], [LastName], [DateOfBirth], [TuitionFee]) VALUES (2, N'Student2', N'St2 LastName', CAST(N'1988-08-15T00:00:00.000' AS DateTime), CAST(2000.00 AS Decimal(8, 2)))
INSERT [dbo].[Students] ([StudentID], [FirstName], [LastName], [DateOfBirth], [TuitionFee]) VALUES (3, N'Student3', N'St3 LastName', CAST(N'1993-07-03T00:00:00.000' AS DateTime), CAST(2500.00 AS Decimal(8, 2)))
INSERT [dbo].[Students] ([StudentID], [FirstName], [LastName], [DateOfBirth], [TuitionFee]) VALUES (4, N'Student4', N'St4 LastName', CAST(N'1999-10-22T00:00:00.000' AS DateTime), CAST(1800.00 AS Decimal(8, 2)))
INSERT [dbo].[Students] ([StudentID], [FirstName], [LastName], [DateOfBirth], [TuitionFee]) VALUES (5, N'Student5', N'St5 LastName', CAST(N'2001-05-08T00:00:00.000' AS DateTime), CAST(2000.00 AS Decimal(8, 2)))
INSERT [dbo].[Students] ([StudentID], [FirstName], [LastName], [DateOfBirth], [TuitionFee]) VALUES (6, N'Student6', N'St6 LastName', CAST(N'1998-07-19T00:00:00.000' AS DateTime), CAST(2500.00 AS Decimal(8, 2)))
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
SET IDENTITY_INSERT [dbo].[Trainers] ON 

INSERT [dbo].[Trainers] ([TrainerID], [FirstName], [LastName], [Subject]) VALUES (1, N'Trainer1', N'T1 LastName', N'Helper')
INSERT [dbo].[Trainers] ([TrainerID], [FirstName], [LastName], [Subject]) VALUES (2, N'Trainer2', N'T2 LastName', N'Main Teacher')
INSERT [dbo].[Trainers] ([TrainerID], [FirstName], [LastName], [Subject]) VALUES (3, N'Trainer3', N'T3 LastName', N'Main Teacher')
INSERT [dbo].[Trainers] ([TrainerID], [FirstName], [LastName], [Subject]) VALUES (4, N'Trainer4 ', N'T4 LastName', N'Assistant')
INSERT [dbo].[Trainers] ([TrainerID], [FirstName], [LastName], [Subject]) VALUES (5, N'Trainer5', N'T5 LastName', N'Assistant')
INSERT [dbo].[Trainers] ([TrainerID], [FirstName], [LastName], [Subject]) VALUES (6, N'Trainer6', N'T6 LastName', N'Helper')
SET IDENTITY_INSERT [dbo].[Trainers] OFF
GO
ALTER TABLE [dbo].[Course_Assignments]  WITH CHECK ADD  CONSTRAINT [FK_Course_Assignments_Assignments] FOREIGN KEY([AssID])
REFERENCES [dbo].[Assignments] ([AssID])
GO
ALTER TABLE [dbo].[Course_Assignments] CHECK CONSTRAINT [FK_Course_Assignments_Assignments]
GO
ALTER TABLE [dbo].[Course_Assignments]  WITH CHECK ADD  CONSTRAINT [FK_Course_Assignments_Courses] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([CourseID])
GO
ALTER TABLE [dbo].[Course_Assignments] CHECK CONSTRAINT [FK_Course_Assignments_Courses]
GO
ALTER TABLE [dbo].[Course_Students]  WITH CHECK ADD  CONSTRAINT [FK_Course_Students_Courses] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([CourseID])
GO
ALTER TABLE [dbo].[Course_Students] CHECK CONSTRAINT [FK_Course_Students_Courses]
GO
ALTER TABLE [dbo].[Course_Students]  WITH CHECK ADD  CONSTRAINT [FK_Course_Students_Students] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([StudentID])
GO
ALTER TABLE [dbo].[Course_Students] CHECK CONSTRAINT [FK_Course_Students_Students]
GO
ALTER TABLE [dbo].[Course_Trainers]  WITH CHECK ADD  CONSTRAINT [FK_Course_Trainers_Courses] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([CourseID])
GO
ALTER TABLE [dbo].[Course_Trainers] CHECK CONSTRAINT [FK_Course_Trainers_Courses]
GO
ALTER TABLE [dbo].[Course_Trainers]  WITH CHECK ADD  CONSTRAINT [FK_Course_Trainers_Trainers] FOREIGN KEY([TrainerID])
REFERENCES [dbo].[Trainers] ([TrainerID])
GO
ALTER TABLE [dbo].[Course_Trainers] CHECK CONSTRAINT [FK_Course_Trainers_Trainers]
GO
USE [master]
GO
ALTER DATABASE [George_Nikolakeas_PROJECT_B] SET  READ_WRITE 
GO
