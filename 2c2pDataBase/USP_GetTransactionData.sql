CREATE PROC USP_GetTransactionData
(
@Currency VARCHAR(10)=null,
@Status VARCHAR(10) = null,
@Start_Date NVARCHAR(50) = null,
@End_Date NVARCHAR(50) = null,
@Operation VARCHAR(50)
)
As
BEGIN

DECLARE @SQL NVARCHAR(MAX)



 IF @Operation='FilterData'
BEGIN
SET @SQL = 'SELECT [Transaction id] AS ID, CAST(Amount AS NVARCHAR) +'' ''+ [Currency Code] AS Payment,CASE WHEN [Status]=''Rejected''  OR [Status]=''Failed'' THEN ''R'' WHEN [Status]=''Approved'' THEN ''A'' WHEN [status]=''Done''  OR [Status]=''Finished'' THEN ''D''
	END AS [Status] FROM TransactionData WHERE 1=1 '
	IF @Currency IS NOT NULL AND @Currency<>'--Select--'
		SET @SQL+= ' AND [Currency Code]='''+@Currency+''''
	IF @Status IS NOT NULL AND @Status<>'--Select--'
		SET @SQL+= ' AND [Status] IN(Select ms.Name FROM tbl_MetaStatus ms INNER JOIN tbl_MetaStatusMapping mp on ms.StatusID = mp.SourceID WHERE ms.Short='''+@Status+''' )'
	IF @Start_Date IS NOT NULL AND @End_Date IS NOT NULL
		SET @SQL+=' AND [Transaction Date] BETWEEN CAST('''+@Start_Date+''' AS DATETIME) AND CAST('''+@End_Date+''' AS DATETIME)'
	ELSE IF @Start_Date IS NOT NULL
		SET @SQL+=' AND  [Transaction Date]>= CAST('''+@Start_Date+''' AS DATETIME)'
	ELSE IF @End_Date IS NOT NULL
		SET @SQL+=' AND  [Transaction Date]<= CAST('''+@End_Date+''' AS DATETIME)'
		PRINT @SQL
		EXEC(@SQL)
	END

	ELSE IF @Operation='All'
	BEGIN
	SELECT Distinct [Currency Code] AS Currency FROM TransactionData
	SELECT Distinct Short AS Status FROM tbl_MetaStatus where IsGlobal=1

	SET @SQL = 'SELECT [Transaction id] AS ID, CAST(Amount AS NVARCHAR) +'' ''+ [Currency Code] AS Payment,CASE WHEN [Status]=''Rejected''  OR [Status]=''Failed'' THEN ''R'' WHEN [Status]=''Approved'' THEN ''A'' WHEN [status]=''Done''  OR [Status]=''Finished'' THEN ''D''
	END AS [Status] FROM TransactionData WHERE 1=1'
	IF @Currency IS NOT NULL AND @Currency <> '--Select--'
		SET @SQL+= ' AND [Currency Code]='''+@Currency+''''
	IF @Status IS NOT NULL AND @Status <> '--Select--'
		SET @SQL+= ' AND [Status] IN(Select ms.Name FROM tbl_MetaStatus ms INNER JOIN tbl_MetaStatusMapping mp on ms.StatusID = mp.SourceID WHERE ms.Short='''+@Status+''' )'
	IF @Start_Date IS NOT NULL AND @End_Date IS NOT NULL
		SET @SQL+=' AND [Transaction Date] BETWEEN CAST('''+@Start_Date+''' AS DATETIME) AND CAST('''+@End_Date+''' AS DATETIME)'
	ELSE IF @Start_Date IS NOT NULL
		SET @SQL+=' AND  [Transaction Date]>= CAST('''+@Start_Date+'''AS DATETIME)'
	ELSE IF @End_Date IS NOT NULL
		SET @SQL+=' AND  [Transaction Date]<= CAST('''+@End_Date+'''AS DATETIME)'
		PRINT @SQL
		EXEC(@SQL)
	END
END

