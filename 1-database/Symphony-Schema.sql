USE [Symphony]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Exams]') AND type in (N'U'))
ALTER TABLE [dbo].[Exams] DROP CONSTRAINT IF EXISTS [FK_Exams_Courses]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExamDetails]') AND type in (N'U'))
ALTER TABLE [dbo].[ExamDetails] DROP CONSTRAINT IF EXISTS [FK_ExamDetails_Students]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExamDetails]') AND type in (N'U'))
ALTER TABLE [dbo].[ExamDetails] DROP CONSTRAINT IF EXISTS [FK_ExamDetails_Payments]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExamDetails]') AND type in (N'U'))
ALTER TABLE [dbo].[ExamDetails] DROP CONSTRAINT IF EXISTS [FK_ExamDetails_Exams]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Classes]') AND type in (N'U'))
ALTER TABLE [dbo].[Classes] DROP CONSTRAINT IF EXISTS [FK_Classes_Teachers]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Classes]') AND type in (N'U'))
ALTER TABLE [dbo].[Classes] DROP CONSTRAINT IF EXISTS [FK_Classes_Courses]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Classes]') AND type in (N'U'))
ALTER TABLE [dbo].[Classes] DROP CONSTRAINT IF EXISTS [FK_Classes_Classes]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClassDetails]') AND type in (N'U'))
ALTER TABLE [dbo].[ClassDetails] DROP CONSTRAINT IF EXISTS [FK_ClassDetails_Students]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClassDetails]') AND type in (N'U'))
ALTER TABLE [dbo].[ClassDetails] DROP CONSTRAINT IF EXISTS [FK_ClassDetails_Payments]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClassDetails]') AND type in (N'U'))
ALTER TABLE [dbo].[ClassDetails] DROP CONSTRAINT IF EXISTS [FK_ClassDetails_Classes]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 1/2/2023 8:37:37 PM ******/
DROP TABLE IF EXISTS [dbo].[Teachers]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 1/2/2023 8:37:37 PM ******/
DROP TABLE IF EXISTS [dbo].[Students]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 1/2/2023 8:37:37 PM ******/
DROP TABLE IF EXISTS [dbo].[Payments]
GO
/****** Object:  Table [dbo].[FAQs]    Script Date: 1/2/2023 8:37:37 PM ******/
DROP TABLE IF EXISTS [dbo].[FAQs]
GO
/****** Object:  Table [dbo].[Exams]    Script Date: 1/2/2023 8:37:37 PM ******/
DROP TABLE IF EXISTS [dbo].[Exams]
GO
/****** Object:  Table [dbo].[ExamDetails]    Script Date: 1/2/2023 8:37:37 PM ******/
DROP TABLE IF EXISTS [dbo].[ExamDetails]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 1/2/2023 8:37:37 PM ******/
DROP TABLE IF EXISTS [dbo].[Courses]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 1/2/2023 8:37:37 PM ******/
DROP TABLE IF EXISTS [dbo].[Classes]
GO
/****** Object:  Table [dbo].[ClassDetails]    Script Date: 1/2/2023 8:37:37 PM ******/
DROP TABLE IF EXISTS [dbo].[ClassDetails]
GO
/****** Object:  Table [dbo].[Centres]    Script Date: 1/2/2023 8:37:37 PM ******/
DROP TABLE IF EXISTS [dbo].[Centres]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 1/2/2023 8:37:37 PM ******/
DROP TABLE IF EXISTS [dbo].[Admins]
GO
/****** Object:  Table [dbo].[AboutUs]    Script Date: 1/2/2023 8:37:37 PM ******/
DROP TABLE IF EXISTS [dbo].[AboutUs]
GO
/****** Object:  Table [dbo].[AboutUs]    Script Date: 1/2/2023 8:37:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AboutUs](
	[Number] [int] NOT NULL,
	[Description] [text] NULL,
 CONSTRAINT [PK_AboutUs] PRIMARY KEY CLUSTERED 
(
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 1/2/2023 8:37:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[PasswordSalt] [varbinary](500) NOT NULL,
	[PasswordHash] [varbinary](500) NOT NULL,
	[Role] [varchar](20) NULL,
	[Details] [text] NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Centres]    Script Date: 1/2/2023 8:37:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Centres](
	[Id] [varchar](20) NOT NULL,
	[Name] [varchar](20) NULL,
	[Address] [nvarchar](200) NULL,
	[Phone] [varchar](20) NULL,
	[Details] [text] NULL,
 CONSTRAINT [PK_Centres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassDetails]    Script Date: 1/2/2023 8:37:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassDetails](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[RollNumber] [varchar](20) NOT NULL,
	[ClassId] [varchar](20) NOT NULL,
	[PaymentId] [bigint] NULL,
	[Details] [text] NULL,
	[IsPass] [bit] NULL,
	[IsLabSession] [bit] NULL,
 CONSTRAINT [PK_ClassDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 1/2/2023 8:37:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[Id] [varchar](20) NOT NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[Room] [varchar](20) NULL,
	[IsBasic] [bit] NULL,
	[Fee] [decimal](18, 2) NULL,
	[TeacherId] [varchar](20) NULL,
	[CourseId] [varchar](20) NOT NULL,
	[CentreId] [varchar](20) NULL,
 CONSTRAINT [PK_Classes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 1/2/2023 8:37:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [varchar](20) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Description] [text] NULL,
	[IsNew] [bit] NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExamDetails]    Script Date: 1/2/2023 8:37:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamDetails](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[RollNumber] [varchar](20) NOT NULL,
	[ExamId] [varchar](20) NOT NULL,
	[PaymentId] [bigint] NULL,
	[Mark] [float] NULL,
 CONSTRAINT [PK_ExamDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exams]    Script Date: 1/2/2023 8:37:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exams](
	[Id] [varchar](20) NOT NULL,
	[CourseId] [varchar](20) NULL,
	[Date] [date] NULL,
	[Details] [text] NULL,
	[Fee] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Exams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FAQs]    Script Date: 1/2/2023 8:37:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FAQs](
	[Number] [int] NOT NULL,
	[Question] [nvarchar](100) NULL,
	[Answer] [text] NULL,
 CONSTRAINT [PK_FAQs] PRIMARY KEY CLUSTERED 
(
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 1/2/2023 8:37:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ReceiptNumber] [varchar](40) NULL,
	[FromAccount] [nvarchar](50) NULL,
	[Amount] [decimal](18, 2) NULL,
	[Date] [date] NULL,
	[Details] [text] NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 1/2/2023 8:37:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[RollNumber] [varchar](20) NOT NULL,
	[FullName] [nvarchar](200) NOT NULL,
	[Address] [nvarchar](200) NULL,
	[Phone] [varchar](20) NULL,
	[Image] [varchar](100) NULL,
	[Email] [varchar](100) NOT NULL,
	[Gender] [varchar](10) NULL,
	[BirthDate] [date] NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[RollNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 1/2/2023 8:37:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[Id] [varchar](20) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Gender] [varchar](10) NULL,
	[BirthDate] [date] NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ClassDetails]  WITH CHECK ADD  CONSTRAINT [FK_ClassDetails_Classes] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Classes] ([Id])
GO
ALTER TABLE [dbo].[ClassDetails] CHECK CONSTRAINT [FK_ClassDetails_Classes]
GO
ALTER TABLE [dbo].[ClassDetails]  WITH CHECK ADD  CONSTRAINT [FK_ClassDetails_Payments] FOREIGN KEY([PaymentId])
REFERENCES [dbo].[Payments] ([Id])
GO
ALTER TABLE [dbo].[ClassDetails] CHECK CONSTRAINT [FK_ClassDetails_Payments]
GO
ALTER TABLE [dbo].[ClassDetails]  WITH CHECK ADD  CONSTRAINT [FK_ClassDetails_Students] FOREIGN KEY([RollNumber])
REFERENCES [dbo].[Students] ([RollNumber])
GO
ALTER TABLE [dbo].[ClassDetails] CHECK CONSTRAINT [FK_ClassDetails_Students]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_Classes] FOREIGN KEY([CentreId])
REFERENCES [dbo].[Centres] ([Id])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_Classes]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_Courses]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_Teachers] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_Teachers]
GO
ALTER TABLE [dbo].[ExamDetails]  WITH CHECK ADD  CONSTRAINT [FK_ExamDetails_Exams] FOREIGN KEY([ExamId])
REFERENCES [dbo].[Exams] ([Id])
GO
ALTER TABLE [dbo].[ExamDetails] CHECK CONSTRAINT [FK_ExamDetails_Exams]
GO
ALTER TABLE [dbo].[ExamDetails]  WITH CHECK ADD  CONSTRAINT [FK_ExamDetails_Payments] FOREIGN KEY([PaymentId])
REFERENCES [dbo].[Payments] ([Id])
GO
ALTER TABLE [dbo].[ExamDetails] CHECK CONSTRAINT [FK_ExamDetails_Payments]
GO
ALTER TABLE [dbo].[ExamDetails]  WITH CHECK ADD  CONSTRAINT [FK_ExamDetails_Students] FOREIGN KEY([RollNumber])
REFERENCES [dbo].[Students] ([RollNumber])
GO
ALTER TABLE [dbo].[ExamDetails] CHECK CONSTRAINT [FK_ExamDetails_Students]
GO
ALTER TABLE [dbo].[Exams]  WITH CHECK ADD  CONSTRAINT [FK_Exams_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[Exams] CHECK CONSTRAINT [FK_Exams_Courses]
GO
