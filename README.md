# B9IS123_10612366_10622824_10612648_10605157_InformationSystems

Team No - D
------------
Student ID: 10612366, Name: Navin Kumar Singupuram
Student ID: 10605157, Name: Atul Krishna Sulli Radhakrishna
Student ID: 10612648, Name: Snehal Rajendrakumar Baviskar
Student ID: 10622824, Name: Sonavva Nandagaon

Git Hub Link
--------------
https://github.com/sonunandagaon/B9IS123_10612366_10622824_10612648_10605157_InformationSystems.git

Overview:
---------
   Ecommerce is simply the act of buying and selling goods or services online without requiring people to physically come to your business. Millions of people      worldwide enjoy playing musical instruments, thus they search for the finest offers that will enable them to purchase their preferred instruments. The advent of internet technology has altered how people purchase for musical instruments, and many now choose to do their shopping online to save time and money. Here, we quickly examine the reasons why you should purchase musical instruments from our store online.
1. Easy and Convenient:
   It is simpler and more practical to purchase musical instruments from our store.
2. Reasonable Price :
   You can always find affordable rates at our music store. On a variety of musical instruments, we are always pleased to offer discounts.
3. Variety:
   With our music store, you can quickly select the brand you want and compare it to others without having to put in a lot of effort.

Technologies Used: 
----------------
1.	Project is implemented in .net 6 using asp.net core and sql server with web services
2.	Few Concepts such as repository, scoped patterns, dependency injection, css isolation, migrations with code first approach and database approach, razor pages’ concepts in .net 6, few ajax and json
3.	CRUD operations using web api and sql server tested in postman and also implemented in the application
4.	Bootstrap 5, Pagination concepts and Oops Concepts, css3

Sql Scripts:
------------
Cart
USE [MusicEquipmentStore]
GO

/****** Object:  Table [dbo].[Carts]    Script Date: 16-12-2022 1.21.22 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Carts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[ProductPrice] [nvarchar](max) NOT NULL,
	[ProductId] [int] NOT NULL,
	[ProductQuantity] [nvarchar](max) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


Categories:
USE [MusicEquipmentStore]
GO

/****** Object:  Table [dbo].[Categories]    Script Date: 16-12-2022 1.21.51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Categories](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Slug] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



Products:
USE [MusicEquipmentStore]
GO

/****** Object:  Table [dbo].[Products]    Script Date: 16-12-2022 1.23.15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Slug] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Price] [decimal](8, 2) NOT NULL,
	[CategoryId] [bigint] NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO


Users
USE [MusicEquipmentStore]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 16-12-2022 1.24.16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Mobile] [bigint] NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsRemember] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO




