---------------------------------------------------------------------------------------------------
--
-- T IT LOGS
--
--
-- <*> Description = T - IT Logs
--
---------------------------------------------------------------------------------------------------
SELECT
	'[' + CAST(P.ProjectID AS varchar(20)) + '] ' + P.ProjectTitle AS Project,
	'[' + CAST(T.TaskID AS varchar(20)) + '] ' + T.TaskTitle AS Task,
	'[' + CAST(T.AssignedToEmpID AS varchar(20)) + '] ' + E.FirstNM + ' ' + E.LastNM AS Assigned,
	'[' + CAST(T.StatusID AS varchar(20)) + '] ' + S.StatusDesc AS Status,
	'[' + CAST(O.ObjectID AS varchar(20)) + '] ' + C.ObjectDesc AS Object,
	O.Comment,
	'[' + CAST(O.UpdateEmpID AS varchar(20)) + '] ' + E1.FirstNM + ' ' + E1.LastNM AS Updated
FROM
	ITLogs.dbo.tblProject P
	LEFT OUTER JOIN ITLogs.dbo.tblTask T ON (T.ProjectID = P.ProjectID)
	LEFT OUTER JOIN ITLogs.dbo.codeStatus S ON (S.StatusID = T.StatusID)
	LEFT OUTER JOIN ITLogs.dbo.tblTaskObject O ON (O.TaskID = T.TaskId)
	LEFT OUTER JOIN ITLogs.dbo.codeObject C ON (C.ObjectID = O.ObjectID)
	LEFT OUTER JOIN TAGS_V2.dbo.tblEmployee E ON (E.EmpID = T.AssignedToEmpID)
	LEFT OUTER JOIN TAGS_V2.dbo.tblEmployee E1 ON (E1.EmpID = O.UpdateEmpID)
ORDER BY
	P.ProjectID, T.TaskID
