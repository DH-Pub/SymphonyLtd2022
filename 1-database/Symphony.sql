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
/****** Object:  Index [UQ_Email]    Script Date: 1/2/2023 8:35:55 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Admins]') AND type in (N'U'))
ALTER TABLE [dbo].[Admins] DROP CONSTRAINT IF EXISTS [UQ_Email]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 1/2/2023 8:35:55 PM ******/
DROP TABLE IF EXISTS [dbo].[Teachers]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 1/2/2023 8:35:55 PM ******/
DROP TABLE IF EXISTS [dbo].[Students]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 1/2/2023 8:35:55 PM ******/
DROP TABLE IF EXISTS [dbo].[Payments]
GO
/****** Object:  Table [dbo].[FAQs]    Script Date: 1/2/2023 8:35:55 PM ******/
DROP TABLE IF EXISTS [dbo].[FAQs]
GO
/****** Object:  Table [dbo].[Exams]    Script Date: 1/2/2023 8:35:55 PM ******/
DROP TABLE IF EXISTS [dbo].[Exams]
GO
/****** Object:  Table [dbo].[ExamDetails]    Script Date: 1/2/2023 8:35:55 PM ******/
DROP TABLE IF EXISTS [dbo].[ExamDetails]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 1/2/2023 8:35:55 PM ******/
DROP TABLE IF EXISTS [dbo].[Courses]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 1/2/2023 8:35:55 PM ******/
DROP TABLE IF EXISTS [dbo].[Classes]
GO
/****** Object:  Table [dbo].[ClassDetails]    Script Date: 1/2/2023 8:35:55 PM ******/
DROP TABLE IF EXISTS [dbo].[ClassDetails]
GO
/****** Object:  Table [dbo].[Centres]    Script Date: 1/2/2023 8:35:55 PM ******/
DROP TABLE IF EXISTS [dbo].[Centres]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 1/2/2023 8:35:55 PM ******/
DROP TABLE IF EXISTS [dbo].[Admins]
GO
/****** Object:  Table [dbo].[AboutUs]    Script Date: 1/2/2023 8:35:55 PM ******/
DROP TABLE IF EXISTS [dbo].[AboutUs]
GO
/****** Object:  Table [dbo].[AboutUs]    Script Date: 1/2/2023 8:35:55 PM ******/
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
/****** Object:  Table [dbo].[Admins]    Script Date: 1/2/2023 8:35:55 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Centres]    Script Date: 1/2/2023 8:35:55 PM ******/
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
/****** Object:  Table [dbo].[ClassDetails]    Script Date: 1/2/2023 8:35:55 PM ******/
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
/****** Object:  Table [dbo].[Classes]    Script Date: 1/2/2023 8:35:55 PM ******/
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
/****** Object:  Table [dbo].[Courses]    Script Date: 1/2/2023 8:35:55 PM ******/
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
/****** Object:  Table [dbo].[ExamDetails]    Script Date: 1/2/2023 8:35:55 PM ******/
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
/****** Object:  Table [dbo].[Exams]    Script Date: 1/2/2023 8:35:55 PM ******/
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
/****** Object:  Table [dbo].[FAQs]    Script Date: 1/2/2023 8:35:55 PM ******/
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
/****** Object:  Table [dbo].[Payments]    Script Date: 1/2/2023 8:35:55 PM ******/
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
/****** Object:  Table [dbo].[Students]    Script Date: 1/2/2023 8:35:55 PM ******/
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
/****** Object:  Table [dbo].[Teachers]    Script Date: 1/2/2023 8:35:55 PM ******/
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
INSERT [dbo].[AboutUs] ([Number], [Description]) VALUES (1, N'Symphony Ltd. is private institute, which generally conducts the classes and training materials for the various certifications that are related to IT and Software industries like networking related, Java related, database related like for SQL Servers, oracle, etc. They are one of the famous institutions which have spread in to various branches situated at different location in the state.

They provide various resources like the preparation materials, lab facilities based on the subject, extra lab hours or sessions (offered after the course duration), 24 hours faculty guidance is provided for the lab sessions, assignments, Library facilities, etc. 
')
GO
SET IDENTITY_INSERT [dbo].[Admins] ON 

INSERT [dbo].[Admins] ([Id], [Name], [Email], [PasswordSalt], [PasswordHash], [Role], [Details]) VALUES (1, N'Main Admin', N'main@email.com', 0x5A9B17A1A9CE4680483586FD9865E489816839B44C6E5A58F65253D783137A0B0EC4A23A2A2E3F15EBAD26D04952526D8CEB411DFEFD0CD180C10FBF285D849BB8ACDC7724B0DE07EFB56DB2FF02AB559F5EF7D6133119ABA3832698710909CBC0E561C49D8F857703F515D3ECB1DF8A4048478E4DE14A77F01B461F9ABCC6BE, 0x27E99DD8A6FCD8CDFF8BB786CFD0AEE244DFAFCFF6F432414427C919ADCD7FBBD47BE1E9AAF61A97567559404B15BB0B4F563BC75E31BE1A16E0BE369C4C2CFD, N'Main', NULL)
SET IDENTITY_INSERT [dbo].[Admins] OFF
GO
INSERT [dbo].[Centres] ([Id], [Name], [Address], [Phone], [Details]) VALUES (N'001', N'Symphony Boston', N'1004 Metz Lane', N'08577280114', N'Welcome to Symphony in Boston! ')
INSERT [dbo].[Centres] ([Id], [Name], [Address], [Phone], [Details]) VALUES (N'002', N'Symphony New York', N'192 Brewery St. Rome, NY 13440', N'012064512559', N'Welcome to Symphony in New York! ')
INSERT [dbo].[Centres] ([Id], [Name], [Address], [Phone], [Details]) VALUES (N'003', N'Symphony HCM City', N'590 CMT8, Ward 11, District 3, HCM City', N'0256785785', N'Welcome to Symphony in HCM City! ')
GO
SET IDENTITY_INSERT [dbo].[ClassDetails] ON 

INSERT [dbo].[ClassDetails] ([Id], [RollNumber], [ClassId], [PaymentId], [Details], [IsPass], [IsLabSession]) VALUES (9, N'001', N'001', 3, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[ClassDetails] OFF
GO
INSERT [dbo].[Classes] ([Id], [StartDate], [EndDate], [Room], [IsBasic], [Fee], [TeacherId], [CourseId], [CentreId]) VALUES (N'001', CAST(N'2022-12-01' AS Date), CAST(N'2022-12-31' AS Date), N'101', 0, CAST(4400.00 AS Decimal(18, 2)), N'001', N'001', N'001')
INSERT [dbo].[Classes] ([Id], [StartDate], [EndDate], [Room], [IsBasic], [Fee], [TeacherId], [CourseId], [CentreId]) VALUES (N'002', CAST(N'2023-01-10' AS Date), CAST(N'2023-06-30' AS Date), N'102', 1, CAST(6100.00 AS Decimal(18, 2)), N'001', N'001', N'003')
GO
INSERT [dbo].[Courses] ([Id], [Name], [Description], [IsNew]) VALUES (N'001', N'Javascript for beginner', N'JavaScript is one of the most popular programming languages in the world, and growing faster than any other programming language. As a developer, you can use JavaScript to build web and mobile apps, real-time networking apps, command-line tools, and games.', 1)
INSERT [dbo].[Courses] ([Id], [Name], [Description], [IsNew]) VALUES (N'002', N'Becoming a .NET Developer', N'In this .NET Training, you will learn how to become a net programmer.

This course is for those who are transitioning from being an IT-professional or are moving from other technologies.

Filled with practical exercises and real world examples, you will be taken through all the major areas of .NET development.

This course is also packed with tips and tricks to ensure that you become as productive as possible, as fast as possible.', 0)
INSERT [dbo].[Courses] ([Id], [Name], [Description], [IsNew]) VALUES (N'003', N'UX/UI Design', N'Designing simple, intuitive experiences can be difficult. The topics covered in this course will provide you with the foundation for creating great experiences that focus on the user. Designing simple, intuitive experiences can be difficult. The topics covered in this course will provide you with the foundation for creating great experiences that focus on the user. experiences that focus on the user. thank you', 0)
INSERT [dbo].[Courses] ([Id], [Name], [Description], [IsNew]) VALUES (N'004', N'Beginning C++ Programming', N'Much, if not most of the software written today is still written in C++ and this has been the case for many, many years. 

Not only is C++ popular, but it is also a very relevant language. If you go to GitHub you will see that there are a huge number of active C++ repositories and C++ is also extremely active on stack overflow.

There are many, many leading software titles written entirely or partly in C++. These include the Windows, Linux, and Mac OSX operating systems!

Many of the Adobe products such as Photoshop and Illustrator,  the MySQL and MongoDB database engines, and many many more are written in C++.

Leading tech companies use C++ for many of their products and internal research and development. These include Amazon, Apple, Microsoft, PayPal, Google, Facebook, Oracle, and many more.', 1)
GO
SET IDENTITY_INSERT [dbo].[ExamDetails] ON 

INSERT [dbo].[ExamDetails] ([Id], [RollNumber], [ExamId], [PaymentId], [Mark]) VALUES (4, N'001', N'001', 3, 70)
INSERT [dbo].[ExamDetails] ([Id], [RollNumber], [ExamId], [PaymentId], [Mark]) VALUES (5, N'002', N'001', 4, 50)
SET IDENTITY_INSERT [dbo].[ExamDetails] OFF
GO
INSERT [dbo].[Exams] ([Id], [CourseId], [Date], [Details], [Fee]) VALUES (N'001', N'001', CAST(N'2022-12-19' AS Date), NULL, CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[Exams] ([Id], [CourseId], [Date], [Details], [Fee]) VALUES (N'230111', N'003', CAST(N'2023-01-11' AS Date), N'Time: 9:00am', CAST(45.00 AS Decimal(18, 2)))
INSERT [dbo].[Exams] ([Id], [CourseId], [Date], [Details], [Fee]) VALUES (N'230304', N'002', CAST(N'2023-03-04' AS Date), N'Time: 4:30pm', CAST(40.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[FAQs] ([Number], [Question], [Answer]) VALUES (1, N'Can I use the Lab facilities after my class hours? Will there be any extra hidden charges? ', N'Yes, you can use the lab sessions even after your class hours. There will be no charges during the course days (i.e., during the course period if you want to use the lab sessions after the class hours we do provide the lab session and the labs will be kept opened till 9 PM in the evening. But yes if you want to use the lab session after your course completion, then it will be charged based on the scenario (like 1000$ if opted at the time of registering and 1500$ if opted after the completion of the course')
INSERT [dbo].[FAQs] ([Number], [Question], [Answer]) VALUES (2, N'How can I apply for the entrance exam? ', N'Once the entrance exams are entitled, one need to visit the centre for applying it through paper and fill all the necessary details through online. On the application form one should chose which course he/she wanted to pursue.')
INSERT [dbo].[FAQs] ([Number], [Question], [Answer]) VALUES (3, N'Will there be any fees for the entrance exam?', N'Yes there will be and it will be available on the application form')
INSERT [dbo].[FAQs] ([Number], [Question], [Answer]) VALUES (4, N'How to make the payment? ', N'Payment can be done through draft, or through cheque or through cash. For making the payment through cash, one needs to come to one of the centre of the institute, and make the payment there itself. Once the payment is done (through cash or through DD), the student will be provided with the receipt with a receipt number. This receipt number is to be inputted in the application form. For the payments done through cheque and DD, one need to enter the DD number and the cheque number, bank details, etc. are to be entered on the application form and the cheque is to be pinned to the application form. Only once the payment is received the student’s application will be accepted. Once the application is accepted, the student is mailed with the acknowledgement form along with the details of the examination, subject chosen, date and time of exam, and the roll number')
INSERT [dbo].[FAQs] ([Number], [Question], [Answer]) VALUES (5, N'When will be Entrance Examinations Conducted? ', N'Once in 6 months, and one need to check the website for knowing when is the entrance exam entitled, the fees for the entrance exam')
INSERT [dbo].[FAQs] ([Number], [Question], [Answer]) VALUES (6, N'Why to join the institute?', N'The various benefits that the student can gain by joining the institution is to be provided')
INSERT [dbo].[FAQs] ([Number], [Question], [Answer]) VALUES (7, N'How to join the course? ', N'Please come to the institute to submit your personal information')
GO
SET IDENTITY_INSERT [dbo].[Payments] ON 

INSERT [dbo].[Payments] ([Id], [ReceiptNumber], [FromAccount], [Amount], [Date], [Details]) VALUES (3, N'001', N'001', CAST(100.00 AS Decimal(18, 2)), CAST(N'2022-12-01' AS Date), N'Payment completed')
INSERT [dbo].[Payments] ([Id], [ReceiptNumber], [FromAccount], [Amount], [Date], [Details]) VALUES (4, N'001', N'acount1', CAST(40.00 AS Decimal(18, 2)), CAST(N'2022-12-07' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[Payments] OFF
GO
INSERT [dbo].[Students] ([RollNumber], [FullName], [Address], [Phone], [Image], [Email], [Gender], [BirthDate]) VALUES (N'001', N'Harrison Spencer', N'1238 Hazelwood Avenue', N'0791235456', N'user-1.jpg', N'spencer@gmail.com', N'Male', CAST(N'2000-01-03' AS Date))
INSERT [dbo].[Students] ([RollNumber], [FullName], [Address], [Phone], [Image], [Email], [Gender], [BirthDate]) VALUES (N'002', N'Joel Taylor', N'4168 Willow Oaks Lane', N'03373154860', N'user-4.jpg', N'taylor@gmail.com', N'Female', CAST(N'1997-02-04' AS Date))
INSERT [dbo].[Students] ([RollNumber], [FullName], [Address], [Phone], [Image], [Email], [Gender], [BirthDate]) VALUES (N'003', N'Reece Howard', N'102 Wines Lane', N'02818811215', N'user-8.jpg', N'howard@gmail.com', N'Male', CAST(N'2002-08-15' AS Date))
GO
INSERT [dbo].[Teachers] ([Id], [Name], [Phone], [Email], [Gender], [BirthDate]) VALUES (N'001', N'John Doe', N'0799140798', N'john@example.com', N'Male', CAST(N'1998-07-14' AS Date))
INSERT [dbo].[Teachers] ([Id], [Name], [Phone], [Email], [Gender], [BirthDate]) VALUES (N'002', N'Mary Moe', N'0343655598', N'mary@example.com', N'Female', CAST(N'1988-04-18' AS Date))
INSERT [dbo].[Teachers] ([Id], [Name], [Phone], [Email], [Gender], [BirthDate]) VALUES (N'003', N'July Dooley', N'0791235456', N'july@example.com', N'Female', CAST(N'1990-01-21' AS Date))
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Email]    Script Date: 1/2/2023 8:35:55 PM ******/
ALTER TABLE [dbo].[Admins] ADD  CONSTRAINT [UQ_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
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
