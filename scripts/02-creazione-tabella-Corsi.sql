USE [SoftwareCFP]
GO

/****** Object:  Table [dbo].[Corsi]    Script Date: 02/10/2021 12:05:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Corsi](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCorso] [nvarchar](max) NULL,
	[CodiceDipartimento] [nvarchar](max) NULL,
	[EdizioneCorso] [nvarchar](max) NULL,
	[NomeCorso] [nvarchar](max) NULL,
	[DataInizioCorso] [nvarchar](max) NULL,
	[DataFineCorso] [nvarchar](max) NULL,
	[OreCorso] [nvarchar](max) NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Corsi] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

