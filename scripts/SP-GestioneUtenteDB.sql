USE [SoftwareCFP]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Angelo Pirola
-- Description:	Elimina utente, diritti e abilitazioni
-- =============================================
CREATE PROCEDURE [dbo].[SP_UTL_DROP_USER] 
	@username varchar(255),
	@database varchar(255)
AS
BEGIN
	DECLARE @sql nvarchar(4000)

	set @sql='USE [' + @database + '] DROP USER [' + @username + ']'
	EXECUTE sp_executesql @sql

	set @sql='USE [master] DROP LOGIN [' + @username + ']'
	EXECUTE sp_executesql @sql

END
GO

-- =============================================
-- Author:		Angelo Pirola
-- Description:	Crea utente, copia diritti e abilitazioni
-- =============================================
CREATE PROCEDURE [dbo].[SP_UTL_CREATE_USER] 
	@username varchar(255), 
	@password varchar(255),
	@database varchar(255)
AS
BEGIN
	DECLARE @sql nvarchar(4000)

	set @sql='USE [master] CREATE LOGIN [' + @username + '] WITH PASSWORD=N''' + @password + ''', DEFAULT_DATABASE=[' + @database + '], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF'
	EXECUTE sp_executesql @sql

	set @sql='USE [' + @database + '] CREATE USER [' + @username + '] FOR LOGIN [' + @username + ']'
	EXECUTE sp_executesql @sql

	set @sql='USE [' + @database + '] EXEC sp_addrolemember N''db_owner'', N''' + @username + ''''
	EXECUTE sp_executesql @sql

END
GO


-- =============================================
-- Author:		Angelo Pirola
-- Description:	Cambia password dell'utente
-- =============================================
CREATE PROCEDURE [dbo].[SP_UTL_CHANGE_PASSWORD] 
	@username varchar(255), 
	@password varchar(255)
AS
BEGIN
	DECLARE @sql nvarchar(4000)

	set @sql='USE [master] ALTER LOGIN [' + @username + '] WITH PASSWORD=N''' + @password + ''''
	EXECUTE sp_executesql @sql

END
GO