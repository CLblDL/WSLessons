USE [PataoDodik]
GO
/****** Object:  Table [dbo].[Contract]    Script Date: 23.09.2022 1:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContractNumber] [nvarchar](50) NOT NULL,
	[DateConclusionContract] [date] NOT NULL,
	[SupplierCompany] [nvarchar](50) NOT NULL,
	[RecipientCoumpany] [nvarchar](50) NOT NULL,
	[Sum] [money] NOT NULL,
	[RawCode] [int] NOT NULL,
	[CountryCode] [int] NOT NULL,
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 23.09.2022 1:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameCountry] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Raw]    Script Date: 23.09.2022 1:03:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Raw](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameRaw] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Raw] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Contract] ON 

INSERT [dbo].[Contract] ([Id], [ContractNumber], [DateConclusionContract], [SupplierCompany], [RecipientCoumpany], [Sum], [RawCode], [CountryCode]) VALUES (1, N'111-111-111', CAST(N'2022-08-22' AS Date), N'ООО "Мегалюль"', N'ООО "Ничер"', 10000.0000, 1, 3)
INSERT [dbo].[Contract] ([Id], [ContractNumber], [DateConclusionContract], [SupplierCompany], [RecipientCoumpany], [Sum], [RawCode], [CountryCode]) VALUES (2, N'112-111-111', CAST(N'2022-09-21' AS Date), N'ООО "Мегалюль"', N'ООО "Ничер"', 125000.0000, 2, 5)
INSERT [dbo].[Contract] ([Id], [ContractNumber], [DateConclusionContract], [SupplierCompany], [RecipientCoumpany], [Sum], [RawCode], [CountryCode]) VALUES (3, N'111-110-333', CAST(N'2022-09-06' AS Date), N'ООО "Пакасть"', N'ООО "НААССС"', 1566854.0000, 3, 3)
SET IDENTITY_INSERT [dbo].[Contract] OFF
GO
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([Id], [NameCountry]) VALUES (1, N'Россия')
INSERT [dbo].[Country] ([Id], [NameCountry]) VALUES (2, N'Белоруссия')
INSERT [dbo].[Country] ([Id], [NameCountry]) VALUES (3, N'Казахстан')
INSERT [dbo].[Country] ([Id], [NameCountry]) VALUES (4, N'Нигерия')
INSERT [dbo].[Country] ([Id], [NameCountry]) VALUES (5, N'Турция')
INSERT [dbo].[Country] ([Id], [NameCountry]) VALUES (6, N'Алжир')
SET IDENTITY_INSERT [dbo].[Country] OFF
GO
SET IDENTITY_INSERT [dbo].[Raw] ON 

INSERT [dbo].[Raw] ([Id], [NameRaw]) VALUES (1, N'Медь')
INSERT [dbo].[Raw] ([Id], [NameRaw]) VALUES (2, N'Никель')
INSERT [dbo].[Raw] ([Id], [NameRaw]) VALUES (3, N'Золото')
INSERT [dbo].[Raw] ([Id], [NameRaw]) VALUES (4, N'Ртуть')
INSERT [dbo].[Raw] ([Id], [NameRaw]) VALUES (5, N'Серебро')
SET IDENTITY_INSERT [dbo].[Raw] OFF
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD  CONSTRAINT [FK_Contract_Country] FOREIGN KEY([CountryCode])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Contract] CHECK CONSTRAINT [FK_Contract_Country]
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD  CONSTRAINT [FK_Contract_Raw] FOREIGN KEY([RawCode])
REFERENCES [dbo].[Raw] ([Id])
GO
ALTER TABLE [dbo].[Contract] CHECK CONSTRAINT [FK_Contract_Raw]
GO
