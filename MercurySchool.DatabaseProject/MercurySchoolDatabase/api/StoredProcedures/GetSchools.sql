CREATE PROCEDURE [api].[GetSchools]
AS 

SET NOCOUNT ON;

SELECT  Id, [Name], [Description]

FROM    dbo.School;
GO

