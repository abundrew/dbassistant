---------------------------------------------------------------------------------------------------
--
-- EMPLOYEE STATUS
--
--
-- <*> Description = Employee Status (Active)
-- <*> Parameter Employee ID = @empID int NULL 
-- <*> Parameter Employee Logon Name = @LogOnNM string NULL
-- <*> Parameter Employee Name = @name string NULL
--
---------------------------------------------------------------------------------------------------
SELECT
	E.EmpID AS "Employee ID",
	E.LogOnNM AS "Logon Name",
	RTRIM(LTRIM((ISNULL(E.FirstNM, '') + ' ' + ISNULL(E.LastNM, '')))) AS "Full Name",
	'[' + LTRIM(STR(ES.ProgID)) + '] ' + P.ProgramDesc AS Program,
	'[' + LTRIM(STR(ES.DeptID)) + '] ' + D.DeptDesc AS Department,
	'[' + LTRIM(STR(E.TAGSTreeID)) + '] ' + T.NavigationTreeDesc AS "Navigation Tree",
	ES.EmpStatusID AS "Employee Status ID"
FROM
	TAGS_V2[#SFX#]..tblEmployee E
	INNER JOIN TAGS_V2[#SFX#]..tblEmployeeStatus ES ON (ES.EmpID = E.EmpID AND ES.ActiveIND = 1)
	LEFT OUTER JOIN TAGS_V2[#SFX#]..codeProgram P ON (P.ProgramID = ES.ProgID AND P.ActiveIND = 1)
	LEFT OUTER JOIN TAGS_V2[#SFX#]..codeDepartment D ON (D.DeptID = ES.DeptID AND D.ActiveIND = 1)
	LEFT OUTER JOIN TAGS_V2[#SFX#]..codeNavigationTree T ON (T.NavigationTreeID = E.TAGSTreeID AND T.ActiveIND = 1)
WHERE
	(@empID IS NULL OR E.EmpID = @empID) AND
	(@LogOnNM IS NULL OR E.LogOnNM LIKE @LogOnNM) AND
	(@name IS NULL OR E.FirstNM LIKE '%' + @name + '%' OR E.LastNM LIKE '%' + @name + '%') AND
	E.ActiveIND = 1
