USE [SoftwareCFP]
GO

/****** Object:  Table [dbo].[Docenti]    Script Date: 18/10/2021 22:07:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Docenti]') AND type in (N'U'))
DROP TABLE [dbo].[Docenti]
GO

/****** Object:  Table [dbo].[Docenti]    Script Date: 18/10/2021 22:07:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Docenti](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdDocente] [nvarchar](max) NULL,
	[NominativoDocente] [nvarchar](max) NULL,
	[MateriaInsegnata] [nvarchar](max) NULL,
	[Telefono] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Residenza] [nvarchar](max) NULL,
	[CostoOrario_Amount] [real] NULL,
	[CostoOrario_Currency] [nvarchar](max) NULL,
 CONSTRAINT [PK_Docenti] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

