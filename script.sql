USE [HangKenhApp]
GO
/****** Object:  Table [dbo].[NhapDetails]    Script Date: 09/17/2022 3:58:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhapDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NhapId] [int] NULL,
	[MaHang] [varchar](20) NULL,
	[Soluong] [int] NULL,
	[Trongluong] [float] NULL,
 CONSTRAINT [PK_NhapDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nhapinfoes]    Script Date: 09/17/2022 3:58:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nhapinfoes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieu] [varchar](10) NULL,
	[DateCreate] [datetime] NULL,
	[UserNhan] [nvarchar](50) NULL,
	[UserTra] [nvarchar](50) NULL,
 CONSTRAINT [PK_Nhapinfoes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogins]    Script Date: 09/17/2022 3:58:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](150) NULL,
	[FullName] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserLogins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XuatDetails]    Script Date: 09/17/2022 3:58:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XuatDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[XuatId] [int] NULL,
	[PhieuYc] [varchar](10) NULL,
	[MaHang] [varchar](20) NULL,
	[Soluong] [int] NULL,
	[Trongluong] [float] NULL,
 CONSTRAINT [PK_XuatDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XuatInfoes]    Script Date: 09/17/2022 3:58:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XuatInfoes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieu] [varchar](10) NULL,
	[DateCreate] [datetime] NULL,
	[UserNhan] [nvarchar](50) NULL,
	[UserXuat] [nvarchar](50) NULL,
 CONSTRAINT [PK_InfoXuats] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
