USE [SoftwareCFP]
GO

/****** Object:  Table [dbo].[Lezioni]    Script Date: 02/10/2021 12:06:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Lezioni](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CorsoId] [int] NOT NULL,
	[IdLezione] [nvarchar](max) NULL,
	[CodiceCorso] [nvarchar](max) NULL,
	[CodiceDocente] [nvarchar](max) NULL,
	[CodiceAula] [nvarchar](max) NULL,
	[DataInizioLezione] [nvarchar](max) NULL,
	[DataFineLezione] [nvarchar](max) NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Lezioni] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Lezioni]  WITH CHECK ADD  CONSTRAINT [FK_Lezioni_Corsi_CorsoId] FOREIGN KEY([CorsoId])
REFERENCES [dbo].[Corsi] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Lezioni] CHECK CONSTRAINT [FK_Lezioni_Corsi_CorsoId]
GO

