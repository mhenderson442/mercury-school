CREATE TABLE dbo.School
(
    Id UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_School_Id PRIMARY KEY NONCLUSTERED,
    [Name] NVARCHAR (32) NOT NULL,
    [Description] NVARCHAR (256) NULL,
    CreateDate DATETIME2 (7) NULL,
    ValidFrom DATETIME2 (7) GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
    ValidTo DATETIME2 (7) GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
    PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo)
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=dbo.SchoolHistory));
GO

ALTER TABLE dbo.School
    ADD CONSTRAINT DF_School_Id DEFAULT (newid()) FOR Id;
GO

CREATE CLUSTERED INDEX CIX_School ON dbo.School (ValidFrom);
