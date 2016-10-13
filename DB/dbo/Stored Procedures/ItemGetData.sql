-- =============================================
-- =============================================
CREATE PROCEDURE [dbo].[ItemGetData] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
	SELECT ItemId,Price,Description FROM Item 
END
