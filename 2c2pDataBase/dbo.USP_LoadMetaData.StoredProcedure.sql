USE [2c3pTestDatabase]
GO
/****** Object:  StoredProcedure [dbo].[USP_LoadMetaData]    Script Date: 22-11-2020 09:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_LoadMetaData]
AS
BEGIN
	
	Select MD.Message AS Message,MD.ValidationType,DS.Name AS DataSetName,MDS.Name AS TypeName,MD.FieldOrder FROM MetaValidationData MD INNER JOIN  
	DataSetMetaData DS ON MD.DataSetMetaDataID = DS.ID INNER JOIN MasterDataSet MDS ON MDS.ID = DS.DataSetID
	 WHERE MD.IsDeleted = 0 AND MDS.IsDeleted = 0
END
GO
