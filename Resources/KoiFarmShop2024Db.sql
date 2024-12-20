USE [master]
GO
/****** Object:  Database [KoiFarmShop2024Db]    Script Date: 17/11/2024 10:30:20 SA ******/
CREATE DATABASE [KoiFarmShop2024Db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KoiFarmShop2024Db', FILENAME = N'E:\CNPM\KoiFarmShop2024Db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'KoiFarmShop2024Db_log', FILENAME = N'E:\CNPM\KoiFarmShop2024Db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [KoiFarmShop2024Db] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KoiFarmShop2024Db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KoiFarmShop2024Db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET ARITHABORT OFF 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET  MULTI_USER 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KoiFarmShop2024Db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [KoiFarmShop2024Db] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [KoiFarmShop2024Db] SET QUERY_STORE = ON
GO
ALTER DATABASE [KoiFarmShop2024Db] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [KoiFarmShop2024Db]
GO
/****** Object:  Table [dbo].[About]    Script Date: 17/11/2024 10:30:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[About](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[Detail] [ntext] NULL,
	[Status] [bit] NULL,
	[MetaKeywords] [nvarchar](250) NULL,
	[MetaDescriptioins] [nvarchar](250) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_tb_About] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AddressID]    Script Date: 17/11/2024 10:30:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddressID](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Number] [nvarchar](15) NULL,
	[Company] [nvarchar](50) NULL,
	[Isdefault] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blog]    Script Date: 17/11/2024 10:30:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog](
	[BlogId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Content] [nvarchar](max) NULL,
	[PublishedDate] [datetime] NULL,
	[Author] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Config]    Script Date: 17/11/2024 10:30:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Config](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Value] [nvarchar](50) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tb_Config] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Consignments]    Script Date: 17/11/2024 10:30:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consignments](
	[Consignment_id] [int] IDENTITY(1,1) NOT NULL,
	[Customer_id] [int] NULL,
	[Koi_id] [int] NULL,
	[Consignment_date] [datetime] NULL,
	[Status] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Consignment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 17/11/2024 10:30:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Detail] [ntext] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tb_Contact] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 17/11/2024 10:30:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[Detail] [nvarchar](500) NULL,
 CONSTRAINT [PK_tb_Feedback] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Footer]    Script Date: 17/11/2024 10:30:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Footer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Detail] [ntext] NULL,
	[Status] [bit] NULL,
	[CreateBy] [int] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_tb_Footer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 17/11/2024 10:30:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[InvoiceID] [int] NOT NULL,
	[Status] [bit] NULL,
	[SupplierID] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeleteDate] [datetime] NULL,
 CONSTRAINT [PK_tb_Invoice] PRIMARY KEY CLUSTERED 
(
	[InvoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceDetail]    Script Date: 17/11/2024 10:30:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetail](
	[InvoiceID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[Price] [decimal](18, 0) NULL,
 CONSTRAINT [PK_tb_InvoiceDetail] PRIMARY KEY CLUSTERED 
(
	[InvoiceID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Koi]    Script Date: 17/11/2024 10:30:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Koi](
	[Koi_id] [int] NULL,
	[Name] [varchar](100) NULL,
	[Breed] [varchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[Age] [int] NULL,
	[Size] [decimal](5, 2) NULL,
	[Origin] [varchar](100) NULL,
	[Character] [text] NOT NULL,
	[Feedling_amount] [int] NULL,
	[Screen_rate] [decimal](5, 2) NULL,
	[Health_status] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoyaltyPoint]    Script Date: 17/11/2024 10:30:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoyaltyPoint](
	[LoyaltyPointId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[Points] [int] NULL,
	[EarnedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[LoyaltyPointId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 17/11/2024 10:30:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Link] [nvarchar](250) NULL,
	[Target] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[Status] [bit] NULL,
	[Position] [int] NOT NULL,
 CONSTRAINT [PK_tb_Menu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 17/11/2024 10:30:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[Price] [decimal](18, 0) NULL,
 CONSTRAINT [PK_tb_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 17/11/2024 10:30:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime] NULL,
	[Status] [bit] NULL,
	[Delivered] [bit] NULL,
	[DeliveryDate] [datetime] NULL,
	[CustomerID] [int] NULL,
	[DisCount] [int] NULL,
 CONSTRAINT [PK_tb_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 17/11/2024 10:30:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] NOT NULL,
	[Sort] [int] NULL,
	[Name] [nvarchar](250) NULL,
	[Loai] [nvarchar](250) NULL,
	[Seo Title] [nvarchar](250) NULL,
	[Status] [bit] NULL,
	[image] [nvarchar](250) NULL,
	[ListsImage] [xml] NULL,
	[Price] [decimal](18, 0) NULL,
	[PromotionPrice] [decimal](18, 0) NULL,
	[Hot] [datetime] NULL,
	[YeuThich] [bit] NULL,
	[Desiption] [nvarchar](500) NULL,
	[Detail] [ntext] NULL,
	[ViewCount] [int] NULL,
	[CateID] [int] NULL,
	[SupplierID] [int] NULL,
	[MateKeywords] [nvarchar](250) NULL,
	[MetaDescriptioins] [nvarchar](250) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[UpdateDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 17/11/2024 10:30:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[CateID] [int] NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Seo Title] [nvarchar](250) NULL,
	[Status] [bit] NULL,
	[Sort] [int] NULL,
	[ParentID] [int] NULL,
	[MateKeywords] [nvarchar](250) NULL,
	[MetaDescriptioins] [nvarchar](250) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[UpdateDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductComment]    Script Date: 17/11/2024 10:30:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductComment](
	[CommentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Email] [nvarchar](150) NULL,
	[Detail] [nvarchar](500) NULL,
	[Status] [bit] NULL,
	[ProductID] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_tb_ProductComment] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promotion]    Script Date: 17/11/2024 10:30:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promotion](
	[PromotionId] [int] IDENTITY(1,1) NOT NULL,
	[PromotionName] [nvarchar](100) NULL,
	[image] [nvarchar](250) NULL,
	[Price] [decimal](18, 0) NULL,
	[PromotionPrice] [decimal](18, 0) NULL,
	[Description] [nvarchar](255) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[DiscountPercentage] [float] NULL,
 CONSTRAINT [PK__Promotio__52C42FCF7CB88F57] PRIMARY KEY CLUSTERED 
(
	[PromotionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rating]    Script Date: 17/11/2024 10:30:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rating](
	[RatingId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[KoiId] [int] NULL,
	[RatingValue] [int] NULL,
	[Feedback] [nvarchar](255) NULL,
	[RatingDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[RatingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Report]    Script Date: 17/11/2024 10:30:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[ReportId] [int] IDENTITY(1,1) NOT NULL,
	[ReportName] [nvarchar](100) NULL,
	[GeneratedDate] [datetime] NULL,
	[ReportData] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ReportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slide]    Script Date: 17/11/2024 10:30:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slide](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Image] [nvarchar](50) NULL,
	[Sort] [int] NULL,
	[Link] [nvarchar](50) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tb_Slide] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 17/11/2024 10:30:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Address] [nchar](50) NULL,
 CONSTRAINT [PK_tb_Supplier] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 17/11/2024 10:30:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](500) NULL,
 CONSTRAINT [PK_tb_Tag] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 17/11/2024 10:30:20 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[FullName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](15) NULL,
	[Address] [nvarchar](250) NULL,
	[Image] [nvarchar](50) NULL,
	[Status] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[Role] [nvarchar](50) NULL, -- Add this line
 CONSTRAINT [PK_tb_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[About] ADD  CONSTRAINT [DF_tb_About_CreatedDate_1]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Consignments] ADD  DEFAULT (getdate()) FOR [Consignment_date]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_tb_Invoice_CreatedDate_1]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_tb_Product_Status_1]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_tb_Product_Price_1]  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_tb_Product_PromotionPrice_1]  DEFAULT ((0)) FOR [PromotionPrice]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_tb_Product_CreatedDate_1]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[ProductCategory] ADD  CONSTRAINT [DF_tb_ProductCategory_Status_1]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[ProductCategory] ADD  CONSTRAINT [DF_tb_ProductCategory_CreatedDate_1]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[ProductComment] ADD  CONSTRAINT [DF_tb_ProductComment_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Promotion] ADD  CONSTRAINT [DF_Promotion_Price]  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[Promotion] ADD  CONSTRAINT [DF_Promotion_PromotionPrice]  DEFAULT ((0)) FOR [PromotionPrice]
GO
ALTER TABLE [dbo].[Consignments]  WITH CHECK ADD CHECK  (([status]='canceled' OR [status]='sold' OR [status]='active'))
GO
ALTER TABLE [dbo].[Consignments]  WITH CHECK ADD CHECK  (([status]='canceled' OR [status]='sold' OR [status]='active'))
GO
ALTER TABLE [dbo].[Consignments]  WITH CHECK ADD CHECK  (([status]='canceled' OR [status]='sold' OR [status]='active'))
GO
ALTER TABLE [dbo].[Koi]  WITH CHECK ADD  CONSTRAINT [CK_Gender] CHECK  (([gender]='unknown' OR [gender]='other' OR [gender]='female' OR [gender]='male'))
GO
ALTER TABLE [dbo].[Koi] CHECK CONSTRAINT [CK_Gender]
GO
USE [master]
GO
ALTER DATABASE [KoiFarmShop2024Db] SET  READ_WRITE 
GO
