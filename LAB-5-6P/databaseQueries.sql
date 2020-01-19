
-- https://docs.microsoft.com/en-us/sql/t-sql/functions/openquery-transact-sql?view=sql-server-ver15 ---

-- Select Queries --
SELECT * FROM OPENQUERY(LINKEDSV, 'SELECT * FROM Student');

-- UPDATE Queries --
UPDATE OPENQUERY(LINKEDSV, 'SELECT firstName FROM Student WHERE ID=10')
SET firstName = 'Abdul Qayyum';

-- INSERT Queries --
INSERT OPENQUERY(LINKEDSV, 'SELECT firstName FROM Student')
VALUES ('Furqan Sheikh')

-- DELETE Queries --
DELETE OPENQUERY(LINKEDSV, 'SELECT firstName FROM Student WHERE firstName = ''Furqan Sheikh''');
