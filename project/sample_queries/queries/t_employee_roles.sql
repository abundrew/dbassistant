---------------------------------------------------------------------------------------------------
--
-- EMPLOYEE ROLES
--
--
-- <*> Description = Employee Roles (Active)
-- <*> Parameter Employee ID = @empID int NULL 
-- <*> Parameter Employee Logon Name = @LogOnNM string NULL
-- <*> Parameter Employee Name = @name string NULL
--
---------------------------------------------------------------------------------------------------
SELECT
	E.EmpID AS "Employee ID",
	E.LogOnNM AS "Logon Name",
	RTRIM(LTRIM((ISNULL(E.FirstNM, '') + ' ' + ISNULL(E.LastNM, '')))) AS "Full Name",
	'[' + LTRIM(STR(ER.RoleID)) + '] ' + R.RoleDesc AS Role
FROM
	TAGS_V2[#SFX#].dbo.linkEmployeeRole ER
	INNER JOIN TAGS_V2[#SFX#]..tblEmployee E ON (E.EmpID = ER.EmpID)
	INNER JOIN TAGS_V2[#SFX#].dbo.tblRole R ON (R.RoleID = ER.RoleID AND R.ActiveIND = 1)
WHERE
	(@empID IS NULL OR E.EmpID = @empID) AND
	(@LogOnNM IS NULL OR E.LogOnNM LIKE @LogOnNM) AND
	(@name IS NULL OR E.FirstNM LIKE '%' + @name + '%' OR E.LastNM LIKE '%' + @name + '%') AND
	E.ActiveIND = 1
