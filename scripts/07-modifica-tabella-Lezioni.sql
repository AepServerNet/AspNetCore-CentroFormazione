USE [SoftwareCFP]
GO

ALTER TABLE [dbo].[Lezioni] DROP CONSTRAINT [FK_Lezioni_Docenti_DocenteId]
GO

ALTER TABLE [dbo].[Lezioni] DROP CONSTRAINT [FK_Lezioni_Corsi_CorsoId]
GO

ALTER TABLE [dbo].[Lezioni] DROP CONSTRAINT [DF__Lezioni__Docente__534D60F1]
GO

/****** Object:  Table [dbo].[Lezioni]    Script Date: 18/10/2021 21:36:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Lezioni]') AND type in (N'U'))
DROP TABLE [dbo].[Lezioni]
GO

/****** Object:  Table [dbo].[Lezioni]    Script Date: 18/10/2021 21:36:40 ******/
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
	[DocenteId] [int] NOT NULL,
	[NomeLezione] [nvarchar](max) NULL,
 CONSTRAINT [PK_Lezioni] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Lezioni] ADD  DEFAULT ((0)) FOR [DocenteId]
GO

ALTER TABLE [dbo].[Lezioni]  WITH CHECK ADD  CONSTRAINT [FK_Lezioni_Corsi_CorsoId] FOREIGN KEY([CorsoId])
REFERENCES [dbo].[Corsi] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Lezioni] CHECK CONSTRAINT [FK_Lezioni_Corsi_CorsoId]
GO

ALTER TABLE [dbo].[Lezioni]  WITH CHECK ADD  CONSTRAINT [FK_Lezioni_Docenti_DocenteId] FOREIGN KEY([DocenteId])
REFERENCES [dbo].[Docenti] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Lezioni] CHECK CONSTRAINT [FK_Lezioni_Docenti_DocenteId]
GO