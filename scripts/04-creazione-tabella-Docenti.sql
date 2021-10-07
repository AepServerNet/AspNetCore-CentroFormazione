USE [SoftwareCFP]
GO

/****** Object:  Table [dbo].[Docenti]    Script Date: 02/10/2021 12:05:56 ******/
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
	[CodiceCorso] [nvarchar](max) NULL,
	[CodiceDipartimento] [nvarchar](max) NULL,
	[CostoOrario_Amount] [real] NULL,
	[CostoOrario_Currency] [nvarchar](max) NULL,
 CONSTRAINT [PK_Docenti] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

