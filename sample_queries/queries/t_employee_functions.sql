---------------------------------------------------------------------------------------------------
--
-- EMPLOYEE FUNCTIONS
--
--
-- <*> Description = Employee Functions (Active)
-- <*> Parameter Employee ID = @empID int NULL 
-- <*> Parameter Employee Logon Name = @LogOnNM string NULL
-- <*> Parameter Employee Name = @name string NULL
--
---------------------------------------------------------------------------------------------------
SELECT
	L.linkFunctionID,
	'[' + LTRIM(STR(L.EmpFunctionID)) + '] ' + C.EmpFunctionDesc AS [Function],
	L.EmpFunctionPrimary,
	L.EmpFunctionStartDT,
	L.EmpFunctionEndDT,
	L.UpdateDT,
	L.UpdateEmpID,
	L.UpdateEmpStatusID
FROM
	TAGS[#SFX#].dbo.LinkEmployeeFunction L
	INNER JOIN TAGS_V2[#SFX#]..tblEmployee E ON (E.EmpID = L.EmpID)
	INNER JOIN TAGS[#SFX#].dbo.codeEmployeeFunction C ON (C.EmpFunctionID = L.EmpFunctionID AND C.ActiveIND = 1)
WHERE
	(@empID IS NULL OR E.EmpID = @empID) AND
	(@LogOnNM IS NULL OR E.LogOnNM LIKE @LogOnNM) AND
	(@name IS NULL OR E.FirstNM LIKE '%' + @name + '%' OR E.LastNM LIKE '%' + @name + '%') AND
	E.ActiveIND = 1 AND L.ActiveIND = 1