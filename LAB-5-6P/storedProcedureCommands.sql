-- =====================================
-- Add Linked Server Simplet template
-- =====================================

EXEC sp_addlinkedserver
	
	@server = anotherLinkedSV,
	@provider ='Microsoft Office 12.0 Access Database Engine OLEDB provider',
	@srvproduct ='MSAccess',
	@datasrc ='F:\7th Semester\DC\PRACTICE-LABS\LAB-5-6P\Database1.accdb';	
GO
