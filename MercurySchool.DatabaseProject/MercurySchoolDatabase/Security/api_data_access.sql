CREATE ROLE [api_data_access]
    AUTHORIZATION [dbo];
GO

ALTER ROLE [api_data_access] ADD MEMBER [api_user];
GO

