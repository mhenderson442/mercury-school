CREATE PROCEDURE api.InsertSchools(@Id UNIQUEIDENTIFIER, @Name NVARCHAR(32), @Description NVARCHAR(256))
AS 

SET NOCOUNT OFF;

INSERT INTO dbo.School(Id,[Name],[Description]) VALUES (@Id,@Name,@Description);
GO

