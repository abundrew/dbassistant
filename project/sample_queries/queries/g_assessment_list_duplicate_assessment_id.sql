---------------------------------------------------------------------------------------------------
--
-- G SEARCH FOR EmpID WITH DUPLICATE AssessmentID in ASSESSMENT LIST
--
-- <*> Description = G - Duplicate AssessmentID in Assessment List
--
---------------------------------------------------------------------------------------------------
SELECT
	COUNT(A.CIAuditNum), A.CIAuditNum, B.EmpID
FROM
	JGBTodoList[#SFX#]..tblTodoListItems A
	INNER JOIN JGBTodoList[#SFX#]..lnkTodoListItemToEmployee B ON (B.TodoListItemID = A.TodoListItemID)
WHERE
	A.StatusID IN (2,3,4) AND
	A.TaskTypeID IN (58, 59)
GROUP BY
	A.CIAuditNum, B.EmpID
HAVING
	COUNT(A.CIAuditNum) > 1
---------------------------------------------------------------------------------------------------
