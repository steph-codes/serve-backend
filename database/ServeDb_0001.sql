USE [master]
GO
/****** Object:  Database [ServeDb]    Script Date: 01/07/2022 11:15:38 ******/
CREATE DATABASE [ServeDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ServeDb', FILENAME = N'C:\Users\ogund\ServeDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ServeDb_log', FILENAME = N'C:\Users\ogund\ServeDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ServeDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ServeDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ServeDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ServeDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ServeDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ServeDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ServeDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [ServeDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ServeDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ServeDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ServeDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ServeDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ServeDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ServeDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ServeDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ServeDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ServeDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ServeDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ServeDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ServeDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ServeDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ServeDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ServeDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ServeDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ServeDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ServeDb] SET  MULTI_USER 
GO
ALTER DATABASE [ServeDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ServeDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ServeDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ServeDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ServeDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ServeDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ServeDb] SET QUERY_STORE = OFF
GO
USE [ServeDb]
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 01/07/2022 11:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationId] [bigint] NULL,
	[CustomerId] [int] NULL,
	[Price] [decimal](10, 2) NULL,
	[Canceled] [bit] NULL,
	[CancelReason] [varchar](200) NULL,
	[EndDateTime] [datetime] NULL,
	[StartDateTime] [datetime] NULL,
	[Address] [nvarchar](500) NULL,
	[State] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Longitude] [nvarchar](50) NULL,
	[Latitude] [nvarchar](50) NULL,
	[Url] [nvarchar](50) NULL,
 CONSTRAINT [PK__Appointm__8E2CF7F9B2AE548C] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppointmentHandler]    Script Date: 01/07/2022 11:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppointmentHandler](
	[Id] [bigint] NOT NULL,
	[EmployeeId] [int] NULL,
	[AppointmentId] [int] NULL,
 CONSTRAINT [PK_AppointmentHandler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppointmentProduct]    Script Date: 01/07/2022 11:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppointmentProduct](
	[Id] [bigint] NOT NULL,
	[ProductId] [bigint] NULL,
 CONSTRAINT [PK_AppointmentProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppointmentServices]    Script Date: 01/07/2022 11:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppointmentServices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServiceId] [int] NULL,
	[AppointmentId] [int] NULL,
	[Cost] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CollaborativeTools]    Script Date: 01/07/2022 11:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CollaborativeTools](
	[Id] [int] NOT NULL,
	[OrganizationId] [bigint] NULL,
	[CustomerId] [int] NULL,
	[ToolName] [nvarchar](50) NULL,
	[ToolUrl] [nvarchar](200) NULL,
 CONSTRAINT [PK_CollaborativeTools] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 01/07/2022 11:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](50) NOT NULL,
	[CustomerEmail] [varchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Gender] [smallint] NULL,
 CONSTRAINT [PK__Client__E67E1A2496FDD2B3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_EMAIL] UNIQUE NONCLUSTERED 
(
	[CustomerEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeePermission]    Script Date: 01/07/2022 11:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeePermission](
	[Id] [int] NOT NULL,
	[RoleId] [int] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[OrganizationId] [bigint] NOT NULL,
 CONSTRAINT [PK_EmployeePermission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeRole]    Script Date: 01/07/2022 11:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeRole](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](100) NULL,
	[OrganizationEmployeeId] [int] NOT NULL,
	[OrganizationId] [bigint] NOT NULL,
 CONSTRAINT [PK_OrganizationEmployeeRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeUnavailableDate]    Script Date: 01/07/2022 11:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeUnavailableDate](
	[Id] [int] NOT NULL,
	[StartDateTime] [datetime] NULL,
	[EndDateTime] [datetime] NULL,
	[EmployeeId] [int] NULL,
 CONSTRAINT [PK_EmployeeUnavailableDate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Event]    Script Date: 01/07/2022 11:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[Id] [int] NOT NULL,
	[AppointmentId] [int] NULL,
	[OrganizationId] [bigint] NULL,
	[EventTypeId] [int] NULL,
	[ReminderId] [int] NULL,
	[EventUrl] [nvarchar](100) NULL,
	[ScheduledAt] [datetime] NULL,
	[TriggeredAt] [datetime] NULL,
	[EmployeeId] [int] NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventType]    Script Date: 01/07/2022 11:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventType](
	[Id] [int] NOT NULL,
	[EventName] [nvarchar](100) NULL,
	[EventDescription] [nvarchar](150) NULL,
 CONSTRAINT [PK_EventType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notifications]    Script Date: 01/07/2022 11:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[Id] [bigint] NOT NULL,
	[AppointmentId] [int] NULL,
	[EventId] [nvarchar](400) NULL,
	[OrganizationId] [bigint] NULL,
	[EmployeeId] [int] NULL,
	[Time] [datetime] NULL,
	[Status] [tinyint] NULL,
	[ReminderId] [int] NULL,
 CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organization]    Script Date: 01/07/2022 11:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organization](
	[Id] [bigint] NOT NULL,
	[BusinessName] [nvarchar](50) NULL,
	[BusinessEmail] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](20) NULL,
	[WebsiteUrl] [nvarchar](100) NULL,
	[InstagramUrl] [nvarchar](150) NULL,
	[FacebookUrl] [nvarchar](150) NULL,
	[WhatsappUrl] [nvarchar](150) NULL,
	[Creator] [bigint] NULL,
	[ProfilePicture] [nvarchar](100) NULL,
	[BusinessDescription] [nvarchar](500) NULL,
	[Industry] [nvarchar](100) NULL,
	[BusinessBio] [nvarchar](100) NULL,
 CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrganizationEmployee]    Script Date: 01/07/2022 11:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganizationEmployee](
	[Id] [int] NOT NULL,
	[OrganizationId] [bigint] NULL,
	[ProfileId] [bigint] NOT NULL,
	[RoleId] [int] NOT NULL,
	[PermissionId] [int] NOT NULL,
 CONSTRAINT [PK_OrganizationEmployee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrganizationMedia]    Script Date: 01/07/2022 11:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganizationMedia](
	[Id] [bigint] NOT NULL,
	[MediaName] [nvarchar](100) NULL,
	[MediaType] [nvarchar](50) NULL,
	[MediaDescription] [nvarchar](100) NULL,
	[MediaCaption] [nvarchar](100) NULL,
	[OrganizationId] [bigint] NULL,
 CONSTRAINT [PK_OrganizationMedia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrganizationUnavailableDate]    Script Date: 01/07/2022 11:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganizationUnavailableDate](
	[Id] [int] NOT NULL,
	[StartDateTime] [datetime] NULL,
	[EnddateTime] [datetime] NULL,
	[OrganizationId] [bigint] NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_OrganizationUnavailableDate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 01/07/2022 11:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [bigint] NOT NULL,
	[Amount] [decimal](10, 0) NULL,
	[AppointmentId] [int] NULL,
	[ProductName] [nvarchar](50) NULL,
	[Price] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reminder]    Script Date: 01/07/2022 11:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reminder](
	[Id] [int] NOT NULL,
	[EventId] [int] NULL,
	[ReminderCount] [int] NULL,
	[OrganizationId] [bigint] NULL,
	[ReminderStatusId] [int] NULL,
	[Message] [nvarchar](500) NULL,
	[ReminderType] [int] NULL,
	[ReminderUnit] [tinyint] NULL,
	[ReminderInterval] [int] NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_Reminder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReminderStatus]    Script Date: 01/07/2022 11:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReminderStatus](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_ReminderStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReminderType]    Script Date: 01/07/2022 11:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReminderType](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_ReminderType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 01/07/2022 11:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[SchId] [int] IDENTITY(1,1) NOT NULL,
	[StartFrom] [datetime] NULL,
	[FinishAT] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[SchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 01/07/2022 11:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Unit] [int] NOT NULL,
	[Price] [decimal](10, 2) NULL,
	[Value] [int] NULL,
	[ServiceName] [varchar](50) NULL,
	[BaseFee] [decimal](10, 2) NULL,
	[Currency] [nvarchar](10) NULL,
 CONSTRAINT [PK__SERVICES__C51BB00A8174A0CC] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 01/07/2022 11:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[Id] [int] NOT NULL,
	[TaskTittle] [nvarchar](100) NULL,
	[Duration] [datetime] NULL,
	[TaskDescription] [nvarchar](150) NULL,
	[EmployeeId] [int] NULL,
	[UserProfileId] [int] NULL,
	[OrganizationId] [bigint] NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Timesheet]    Script Date: 01/07/2022 11:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Timesheet](
	[Id] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[AttendanceByDay] [nvarchar](50) NULL,
	[ShiftStart] [datetime] NULL,
	[ShiftEnd] [nchar](10) NULL,
	[ApprovedTimesheet] [bit] NOT NULL,
	[ApprovedBy] [int] NULL,
	[ApprovedAt] [datetime] NULL,
	[TaskId] [int] NULL,
 CONSTRAINT [PK_Timesheet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 01/07/2022 11:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[Id] [bigint] NOT NULL,
	[UserId] [nvarchar](256) NOT NULL,
	[ProfilePicture] [nvarchar](100) NULL,
 CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF__Client__CreatedA__2C3393D0]  DEFAULT (getdate()) FOR [PhoneNumber]
GO
ALTER TABLE [dbo].[Schedule] ADD  DEFAULT (getdate()) FOR [StartFrom]
GO
ALTER TABLE [dbo].[Schedule] ADD  DEFAULT (getdate()) FOR [FinishAT]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK__Appointme__Clien__300424B4] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK__Appointme__Clien__300424B4]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_Customers]
GO
ALTER TABLE [dbo].[AppointmentHandler]  WITH CHECK ADD  CONSTRAINT [FK_AppointmentHandler_Appointment] FOREIGN KEY([AppointmentId])
REFERENCES [dbo].[Appointment] ([Id])
GO
ALTER TABLE [dbo].[AppointmentHandler] CHECK CONSTRAINT [FK_AppointmentHandler_Appointment]
GO
ALTER TABLE [dbo].[AppointmentHandler]  WITH CHECK ADD  CONSTRAINT [FK_AppointmentHandler_OrganizationEmployee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[OrganizationEmployee] ([Id])
GO
ALTER TABLE [dbo].[AppointmentHandler] CHECK CONSTRAINT [FK_AppointmentHandler_OrganizationEmployee]
GO
ALTER TABLE [dbo].[AppointmentProduct]  WITH CHECK ADD  CONSTRAINT [FK_AppointmentProduct_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[AppointmentProduct] CHECK CONSTRAINT [FK_AppointmentProduct_Product]
GO
ALTER TABLE [dbo].[AppointmentServices]  WITH CHECK ADD  CONSTRAINT [FK__ServicePr__AppId__36B12243] FOREIGN KEY([AppointmentId])
REFERENCES [dbo].[Appointment] ([Id])
GO
ALTER TABLE [dbo].[AppointmentServices] CHECK CONSTRAINT [FK__ServicePr__AppId__36B12243]
GO
ALTER TABLE [dbo].[AppointmentServices]  WITH CHECK ADD  CONSTRAINT [FK__ServicePr__Servi__35BCFE0A] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([Id])
GO
ALTER TABLE [dbo].[AppointmentServices] CHECK CONSTRAINT [FK__ServicePr__Servi__35BCFE0A]
GO
ALTER TABLE [dbo].[AppointmentServices]  WITH CHECK ADD  CONSTRAINT [FK_AppointmentServices_Appointment] FOREIGN KEY([AppointmentId])
REFERENCES [dbo].[Appointment] ([Id])
GO
ALTER TABLE [dbo].[AppointmentServices] CHECK CONSTRAINT [FK_AppointmentServices_Appointment]
GO
ALTER TABLE [dbo].[AppointmentServices]  WITH CHECK ADD  CONSTRAINT [FK_AppointmentServices_Service] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([Id])
GO
ALTER TABLE [dbo].[AppointmentServices] CHECK CONSTRAINT [FK_AppointmentServices_Service]
GO
ALTER TABLE [dbo].[EmployeePermission]  WITH CHECK ADD  CONSTRAINT [FK_EmployeePermission_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([Id])
GO
ALTER TABLE [dbo].[EmployeePermission] CHECK CONSTRAINT [FK_EmployeePermission_Organization]
GO
ALTER TABLE [dbo].[EmployeePermission]  WITH CHECK ADD  CONSTRAINT [FK_EmployeePermission_OrganizationEmployeeRole] FOREIGN KEY([RoleId])
REFERENCES [dbo].[EmployeeRole] ([Id])
GO
ALTER TABLE [dbo].[EmployeePermission] CHECK CONSTRAINT [FK_EmployeePermission_OrganizationEmployeeRole]
GO
ALTER TABLE [dbo].[EmployeePermission]  WITH CHECK ADD  CONSTRAINT [FK_EmployeePermission_OrganizationEmployeeRole1] FOREIGN KEY([RoleId])
REFERENCES [dbo].[EmployeeRole] ([Id])
GO
ALTER TABLE [dbo].[EmployeePermission] CHECK CONSTRAINT [FK_EmployeePermission_OrganizationEmployeeRole1]
GO
ALTER TABLE [dbo].[EmployeeRole]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationEmployeeRole_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([Id])
GO
ALTER TABLE [dbo].[EmployeeRole] CHECK CONSTRAINT [FK_OrganizationEmployeeRole_Organization]
GO
ALTER TABLE [dbo].[EmployeeRole]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationEmployeeRole_OrganizationEmployee] FOREIGN KEY([OrganizationEmployeeId])
REFERENCES [dbo].[OrganizationEmployee] ([Id])
GO
ALTER TABLE [dbo].[EmployeeRole] CHECK CONSTRAINT [FK_OrganizationEmployeeRole_OrganizationEmployee]
GO
ALTER TABLE [dbo].[EmployeeUnavailableDate]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeUnavailableDate_OrganizationEmployee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[OrganizationEmployee] ([Id])
GO
ALTER TABLE [dbo].[EmployeeUnavailableDate] CHECK CONSTRAINT [FK_EmployeeUnavailableDate_OrganizationEmployee]
GO
ALTER TABLE [dbo].[EmployeeUnavailableDate]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeUnavailableDate_OrganizationEmployee1] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[OrganizationEmployee] ([Id])
GO
ALTER TABLE [dbo].[EmployeeUnavailableDate] CHECK CONSTRAINT [FK_EmployeeUnavailableDate_OrganizationEmployee1]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_EventType] FOREIGN KEY([EventTypeId])
REFERENCES [dbo].[EventType] ([Id])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_EventType]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Reminder] FOREIGN KEY([ReminderId])
REFERENCES [dbo].[Reminder] ([Id])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Reminder]
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD  CONSTRAINT [FK_Notifications_Appointment] FOREIGN KEY([AppointmentId])
REFERENCES [dbo].[Appointment] ([Id])
GO
ALTER TABLE [dbo].[Notifications] CHECK CONSTRAINT [FK_Notifications_Appointment]
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD  CONSTRAINT [FK_Notifications_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([Id])
GO
ALTER TABLE [dbo].[Notifications] CHECK CONSTRAINT [FK_Notifications_Organization]
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD  CONSTRAINT [FK_Notifications_OrganizationEmployee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[OrganizationEmployee] ([Id])
GO
ALTER TABLE [dbo].[Notifications] CHECK CONSTRAINT [FK_Notifications_OrganizationEmployee]
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD  CONSTRAINT [FK_Notifications_Reminder] FOREIGN KEY([ReminderId])
REFERENCES [dbo].[Reminder] ([Id])
GO
ALTER TABLE [dbo].[Notifications] CHECK CONSTRAINT [FK_Notifications_Reminder]
GO
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD  CONSTRAINT [FK_Organization_UserProfile] FOREIGN KEY([Creator])
REFERENCES [dbo].[UserProfile] ([Id])
GO
ALTER TABLE [dbo].[Organization] CHECK CONSTRAINT [FK_Organization_UserProfile]
GO
ALTER TABLE [dbo].[OrganizationEmployee]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationEmployee_EmployeePermission] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[EmployeePermission] ([Id])
GO
ALTER TABLE [dbo].[OrganizationEmployee] CHECK CONSTRAINT [FK_OrganizationEmployee_EmployeePermission]
GO
ALTER TABLE [dbo].[OrganizationEmployee]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationEmployee_EmployeePermission1] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[EmployeePermission] ([Id])
GO
ALTER TABLE [dbo].[OrganizationEmployee] CHECK CONSTRAINT [FK_OrganizationEmployee_EmployeePermission1]
GO
ALTER TABLE [dbo].[OrganizationEmployee]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationEmployee_EmployeeRole] FOREIGN KEY([RoleId])
REFERENCES [dbo].[EmployeeRole] ([Id])
GO
ALTER TABLE [dbo].[OrganizationEmployee] CHECK CONSTRAINT [FK_OrganizationEmployee_EmployeeRole]
GO
ALTER TABLE [dbo].[OrganizationEmployee]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationEmployee_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([Id])
GO
ALTER TABLE [dbo].[OrganizationEmployee] CHECK CONSTRAINT [FK_OrganizationEmployee_Organization]
GO
ALTER TABLE [dbo].[OrganizationEmployee]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationEmployee_UserProfile] FOREIGN KEY([ProfileId])
REFERENCES [dbo].[UserProfile] ([Id])
GO
ALTER TABLE [dbo].[OrganizationEmployee] CHECK CONSTRAINT [FK_OrganizationEmployee_UserProfile]
GO
ALTER TABLE [dbo].[OrganizationMedia]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationMedia_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([Id])
GO
ALTER TABLE [dbo].[OrganizationMedia] CHECK CONSTRAINT [FK_OrganizationMedia_Organization]
GO
ALTER TABLE [dbo].[OrganizationUnavailableDate]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationUnavailableDate_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([Id])
GO
ALTER TABLE [dbo].[OrganizationUnavailableDate] CHECK CONSTRAINT [FK_OrganizationUnavailableDate_Organization]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Appointment] FOREIGN KEY([AppointmentId])
REFERENCES [dbo].[Appointment] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Appointment]
GO
ALTER TABLE [dbo].[Reminder]  WITH CHECK ADD  CONSTRAINT [FK_Reminder_Event] FOREIGN KEY([EventId])
REFERENCES [dbo].[Event] ([Id])
GO
ALTER TABLE [dbo].[Reminder] CHECK CONSTRAINT [FK_Reminder_Event]
GO
ALTER TABLE [dbo].[Reminder]  WITH CHECK ADD  CONSTRAINT [FK_Reminder_ReminderStatus] FOREIGN KEY([ReminderStatusId])
REFERENCES [dbo].[ReminderStatus] ([Id])
GO
ALTER TABLE [dbo].[Reminder] CHECK CONSTRAINT [FK_Reminder_ReminderStatus]
GO
ALTER TABLE [dbo].[Reminder]  WITH CHECK ADD  CONSTRAINT [FK_Reminder_ReminderType] FOREIGN KEY([ReminderType])
REFERENCES [dbo].[ReminderType] ([Id])
GO
ALTER TABLE [dbo].[Reminder] CHECK CONSTRAINT [FK_Reminder_ReminderType]
GO
ALTER TABLE [dbo].[Timesheet]  WITH CHECK ADD  CONSTRAINT [FK_Timesheet_Task] FOREIGN KEY([TaskId])
REFERENCES [dbo].[Task] ([Id])
GO
ALTER TABLE [dbo].[Timesheet] CHECK CONSTRAINT [FK_Timesheet_Task]
GO
USE [master]
GO
ALTER DATABASE [ServeDb] SET  READ_WRITE 
GO
