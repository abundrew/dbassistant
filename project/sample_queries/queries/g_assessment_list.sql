---------------------------------------------------------------------------------------------------
--
-- G ASSESSMENT LIST (SEARCH PAGE)
--
-- The application code requires AssessmentID is unique for each EmpID in this query.
--
--
-- <*> Description = G - Assessment List [Search Page] (AssessmentID has to be unique for each EmpID)
-- <*> Database = Assessments[#SFX#]
-- <*> Parameter Employee ID = @empID int NULL 
-- <*> Parameter Client ID = @clientID int NULL
--
---------------------------------------------------------------------------------------------------
SELECT DISTINCT TI.TodoListItemID, CT.Description TaskDescription, CS.StatusDesc TaskItemStatus, TC.CIAUDITNUM [MEMBER ID], 
	[NAME] = CASE 
		WHEN TCA.AssessmentID IS NULL THEN ISNULL(TC.CILSTNAM, '') + ', ' +  ISNULL(TC.CIFSTNAM, '') 
		ELSE ISNULL(TCA.CILSTNAM, '') + ', ' +  ISNULL(TCA.CIFSTNAM, '') 
	END,
	[ADDRESS] = CASE 
		WHEN TCA.AssessmentID IS NULL THEN ISNULL(TC.CIADDR1, '') + ISNULL(' ' + TC.CIADDR2, '') + ' ' + ISNULL(TC.CICITY, '') + ', ' + ISNULL(TC.CISTATEABBREV, '') + ' ' + ISNULL(TC.CIZIP, '') 
		ELSE ISNULL(TCA.CIADDR1, '') + ISNULL(' ' + TCA.CIADDR2, '') + ' ' + ISNULL(TCA.CICITY, '') + ', ' + ISNULL(TCA.CISTATEABBREV, '') + ' ' + ISNULL(TCA.CIZIP, '') 
	END,
	[SSN #] = CASE WHEN TCA.AssessmentID IS NULL THEN ISNULL(TC.CISSNUM, '') ELSE ISNULL(TCA.CISSNUM, '') END, 
	-1 BATCHNO, -1 FORMNO,		
	[ASSESSMENT TYPE] = CASE 
		WHEN PE.EnrollmentDisenrollmentTypeID = 1 THEN 'Start of Enrollment'
		WHEN PE.EnrollmentDisenrollmentTypeID = 2 AND PE.GNPlanID = 2 THEN 'MLTC to GOLD Switch'
		WHEN PE.EnrollmentDisenrollmentTypeID = 2 AND PE.GNPlanID = 1 THEN 'GOLD to MLTC Switch'
		WHEN PE.EnrollmentDisenrollmentTypeID = 3 THEN 'County Swwitch'
		ELSE 'Reassessment' 
	END, 
	'GATE' [FORM TYPE], 
	
	[ASSESSOR NAME] = CASE
		WHEN PE.GNIntakeManagerID IS NOT NULL THEN ISNULL(TE.FIRSTNM + ' ' + TE.LASTNM, '')
		WHEN PE.GNIntakeManagerID IS NULL THEN ISNULL(TE2.FIRSTNM + ' ' + TE2.LASTNM, '')			
	END, 
	
	dbo.IsNULLDate(ISNULL(GNInitAssessDat, GNPendingTBSDate)) AS [CLIENT SEEN DATE],
	dbo.IsNULLDate(GNPendingDate) AS [ASSESSMENT DATE], 
	LIE.EmpID NurseID, 

	[LAST WORKED ON BY] = CASE
		WHEN PE.GNIntakeManagerID IS NOT NULL THEN TE.LogOnNM
		WHEN PE.GNIntakeManagerID IS NULL THEN TE2.LogOnNM
	END, 

	IsNull(TI.KeyValue, -1) ASSESSMENTID, 
	0 ImportedFromTAGS, 
	GNPLAN = CASE GNPlanID 
		WHEN 1 THEN 'GuildNet MLTC' 
		WHEN 2 THEN 'GuildNet GOLD' 
		WHEN 3 THEN 'GuildNet Health Advantage' 
		ELSE '' 
	END,
	CT.TypeID TodoListItemType, CT.ApplicationID, CT.UniqueKey, CT.FormName, TI.TodoListItemID, TI.CIAuditNum, TI.TaskTitle, 
	TI.StatusID TaskStatus, TI.KeyColumnNM, TI.KeyValue, LIE.EmpID,
	
	[AssessmentType] = CASE 
		WHEN PE.EnrollmentDisenrollmentTypeID = 1 THEN 100
		WHEN PE.EnrollmentDisenrollmentTypeID = 2 AND PE.GNPlanID = 2 THEN 300
		WHEN PE.EnrollmentDisenrollmentTypeID = 2 AND PE.GNPlanID = 1 THEN 400
		WHEN PE.EnrollmentDisenrollmentTypeID = 3 THEN 500
		ELSE 200 
	END
	
FROM JGBTodoList[#SFX#]..tblTodoListItems AS TI 
	INNER JOIN TAGS[#SFX#]..tblClientInfo TC ON TC.CIAuditNum = TI.CIAuditNum
	INNER JOIN JGBTodoList[#SFX#]..tblTodoListTypes AS CT ON CT.TypeID = TI.TaskTypeID 
	INNER JOIN JGBTodoList[#SFX#]..lnkTodoListItemToEmployee AS LIE ON TI.TodoListItemID = LIE.TodoListItemID
	INNER JOIN JGBTodoList[#SFX#]..codeTodoItemStatus CS ON CS.StatusID = TI.StatusID
	LEFT JOIN TAGS[#SFX#]..tblGNPlanEnrollment PE ON PE.CIAuditNum = TC.CIAuditNum AND GNPlanEnrollmentStatusID = 10		
	LEFT JOIN TAGS[#SFX#]..tblReassessStatus_GN RS ON RS.CIAuditNum = TC.CIAuditNum AND Status IN(1,2,3)			
	LEFT JOIN tblEmployee TE ON TE.EmpID = PE.GNIntakeManagerID
	LEFT JOIN tblEmployee TE2 ON TE2.EmpID = RS.ReassessMgrID
	LEFT JOIN tblExp_tblAssessments_GN TA ON TA.AssessmentID = IsNull(TI.KeyValue, -1) 	
	LEFT JOIN tblExp_tblClientInfo TCA ON IsNull(TCA.AssessmentID, -1) = IsNull(TA.AssessmentID, -1) 
WHERE
     (CT.ApplicationID = 6) AND
     (@empID IS NULL OR LIE.EmpID = @empID) AND
     (@clientID IS NULL OR TI.CIAuditNum = @clientID) AND
     TI.StatusID IN(2,3,4)
