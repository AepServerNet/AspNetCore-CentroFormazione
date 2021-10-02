USE [SoftwareCFP]
GO

/****** Object:  Table [dbo].[Edifici]    Script Date: 02/10/2021 12:06:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Edifici](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdEdificio] [nvarchar](max) NULL,
	[CodiceDipartimento] [nvarchar](max) NULL,
	[Aula] [nvarchar](max) NULL,
	[Indirizzo] [nvarchar](max) NULL,
	[Piano] [nvarchar](max) NULL,
	[Mq] [nvarchar](max) NULL,
	[Laboratorio] [nvarchar](max) NULL,
	[Posti] [nvarchar](max) NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Edifici] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

