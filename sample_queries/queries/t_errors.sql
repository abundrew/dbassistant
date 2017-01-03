---------------------------------------------------------------------------------------------------
--
-- T ERRORS
--
--
-- <*> Description = T - Error Log
-- <*> Parameter Days (def. 3) = @days int NULL
-- <*> Parameter Employee ID = @empID int NULL 
-- <*> Parameter Employee Logon Name = @LogOnNM string NULL
-- <*> Parameter Employee Name = @name string NULL
--
---------------------------------------------------------------------------------------------------
SELECT
	EL.ErrID AS [Error ID],
	EL.ErrDesc AS [Error Description],
	EL.ClientID AS [Client ID],
	EL.Class_SPNM AS [Class],
	EL.FunctionNM AS [Function],
	EL.ErrDT AS [Error Date],
	'[' + CAST(EL.EmpID AS varchar) + '] ' + ISNULL(E.LogOnNM, '') AS [Employee]
FROM
	TAGS_V2[#SFX#].dbo.tblErrorLog EL
	LEFT OUTER JOIN TAGS_V2[#SFX#].dbo.tblEmployee E ON (E.EmpID = EL.EmpID)
WHERE
	(@days IS NULL AND EL.ErrDT >= DATEADD(day, -3, GETDATE()) OR NOT @days IS NULL AND EL.ErrDT >= DATEADD(day, -@days, GETDATE())) AND
	(@empID IS NULL OR E.EmpID = @empID) AND
	(@LogOnNM IS NULL OR E.LogOnNM LIKE @LogOnNM) AND
	(@name IS NULL OR E.FirstNM LIKE '%' + @name + '%' OR E.LastNM LIKE '%' + @name + '%')	