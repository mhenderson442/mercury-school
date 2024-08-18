ALTER PROCEDURE [api].[GetSchool](@id UNIQUEIDENTIFIER)
AS 

SET NOCOUNT ON;

SELECT Id, [Name], [Description]

FROM dbo.School

WHERE   Id = @id;
GO

