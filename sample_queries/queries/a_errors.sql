---------------------------------------------------------------------------------------------------
--
-- A ERRORS
--
--
-- <*> Description = A - Error Log (last 30 days)
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
	Assessments[#SFX#].dbo.tblErrorLog EL
	LEFT OUTER JOIN Assessments[#SFX#].dbo.tblEmployee E ON (E.EmpID = EL.EmpID)
WHERE
	(DATEDIFF(day, EL.ErrDT, GETDATE()) < 30)
