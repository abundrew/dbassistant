---------------------------------------------------------------------------------------------------
--
-- TODO LIST TASKS
--
--
-- <*> Description = Todo List Tasks
-- <*> Parameter Employee ID = @empID int NULL 
-- <*> Parameter Employee Logon Name = @LogOnNM string NULL
-- <*> Parameter Employee Name = @name string NULL
-- <*> Parameter CI Audit Num = @clientID int NULL
-- <*> Parameter Days (default 7) = @days int NULL
--
---------------------------------------------------------------------------------------------------
SELECT --TOP 10000
	I.TodoListItemID AS "Todo List Item ID",
	'[' + CAST(E.EmpID AS varchar(20)) + '] ' + E.FirstNM + ' ' + E.LastNM AS "Employee",
	L.AlertType AS [Alert Type],
	'[' + CAST(E2.EmpID AS varchar(20)) + '] ' + E2.FirstNM + ' ' + E2.LastNM AS "Escalated From",
	I.CIAuditNum,
	'[' + CAST(I.TaskTypeID AS varchar(20)) + ' ' + CASE WHEN T.ActiveIND = 1 THEN 'A' ELSE 'N' END + '] ' + T.Description AS "Task Type",
	I.TaskTitle AS "Task Title",
	I.Description,
	'[' + CAST(I.StatusID AS varchar(20)) + '] ' + C.StatusDesc AS Status,
	I.KeyColumnNM AS "Key Column Name",
	I.KeyValue AS "Key Value",
	I.CreateDate AS "Create Date",
	I.DueDate AS "Due Date",
	I.CompletedDate AS "Completed Date",
	I.EscalationDate AS "Escalation Date",
	'[' + CAST(U.EmpID AS varchar(20)) + '] ' + U.FirstNM + ' ' + U.LastNM AS "Updated By",
	I.UpdatedDT AS "Updated Date"
FROM
	JGBTodoList[#SFX#]..tblTodoListItems I
	INNER JOIN JGBTodoList[#SFX#]..lnkTodoListItemToEmployee L ON (L.TodoListItemID = I.TodoListItemID)
	LEFT OUTER JOIN TAGS_V2[#SFX#]..tblEmployee E ON (E.EmpID = L.EmpID)
	LEFT OUTER JOIN TAGS_V2[#SFX#]..tblEmployee E2 ON (E2.EmpID = L.EscalatedFromEmpID)
	LEFT OUTER JOIN TAGS_V2[#SFX#]..tblEmployee U ON (U.EmpID = I.UpdatedEmpID)
	LEFT OUTER JOIN JGBTodoList[#SFX#]..tblTodoListTypes T ON (T.TypeID = I.TaskTypeID)
	LEFT OUTER JOIN JGBTodoList[#SFX#]..codeTodoItemStatus C ON (C.StatusID = I.StatusID)
WHERE
	(@empID IS NULL OR E.EmpID = @empID) AND
	(@LogOnNM IS NULL OR E.LogOnNM LIKE @LogOnNM) AND
	(@name IS NULL OR E.FirstNM LIKE '%' + @name + '%' OR E.LastNM LIKE '%' + @name + '%') AND
	(@clientID IS NULL OR I.CIAuditNum = @clientID) AND
	(@days IS NULL AND I.CreateDate >= DATEADD(day, -7, GETDATE()) OR NOT @days IS NULL AND I.CreateDate >= DATEADD(day, -@days, GETDATE()))
--ORDER BY
--	I.TodoListItemID DESC
