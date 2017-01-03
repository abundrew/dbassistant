---------------------------------------------------------------------------------------------------
--
-- REASSESS STATUS
--
--
-- <*> Description = Reassess Status (Active)
-- <*> Parameter Client ID = @clientID int NULL 
--
---------------------------------------------------------------------------------------------------
SELECT
	RS.ReassessID AS "Reassessment ID",
	RS.CIAuditNum AS "Client ID",
	RS.Type,
	Status = CASE
		WHEN RS.Status = -1 THEN '[-1] Reassess Tickle Printed (List)'
		WHEN RS.Status = 1 THEN '[1] Merged Assigned (Printed)'
		WHEN RS.Status = 2 THEN '[2] In Data Entry'
		WHEN RS.Status = 3 THEN '[3] Ready (Waiting) To Be Approved'
		WHEN RS.Status = 4 THEN '[4] Completed (Committed)'
		WHEN RS.Status = 94 THEN '[94] Manually ...'
		WHEN RS.Status = 95 THEN '[95] Manually ...'
		WHEN RS.Status = 96 THEN '[96] Manually ...'
		WHEN RS.Status = 97 THEN '[97] Manually ...'
		WHEN RS.Status = 98 THEN '[98] Manually ...'
		WHEN RS.Status = 99 THEN '[99] Manually ...'
		WHEN RS.Status = 100 THEN '[100] Re-Printed'
		ELSE STR(RS.Status)
	END,
	RS.GATBatchStatus AS "GAT Batch Status",
	RS.DateStarted AS "Started",
	RS.DateProcessing AS "Processing",
	RS.DateReviewing AS "Reviewing",
	RS.DateCompleted AS "Completed",
	RS.AudUser,
	RS.DateUpdated AS "Updated",
	RS.AssessDate AS "Assessment Date",
	'[' + LTRIM(STR(RS.CaseMgrID)) + '] ' + E1.FirstNM + ' ' + E1.LastNM AS "Case Manager",
	'[' + LTRIM(STR(RS.ReassessMgrID)) + '] ' + E2.FirstNM + ' ' + E2.LastNM AS "Reassessment Manager",
	RS.ManualAssess AS "Manual Assessment",
	'[' + LTRIM(STR(RS.RegionID)) + '] ' + R.RegionDesc AS "Region",
	RS.MRTPrinted AS "MRT Printed",
	RS.MRTNotPrintedReason AS "MR Not Printed Reason",
	RS.DateReceived AS "Received",
	RS.MRTComment AS "MRT Comment",
	RS.MRTClientSeenDate AS "MRT Client Seen Date",
	RS.FeeForService AS "Service Fee",
	RS.FeeForServiceDate AS "Service Fee Date",
	RS.Invoice,
	RS.InvoiceDate AS "Invoice Date"
FROM
	TAGS[#SFX#]..tblReassessStatus_GN RS
	LEFT OUTER JOIN TAGS_V2[#SFX#]..tblEmployee E1 ON (E1.EmpID = RS.CaseMgrID AND E1.ActiveIND = 1)
	LEFT OUTER JOIN TAGS_V2[#SFX#]..tblEmployee E2 ON (E2.EmpID = RS.ReassessMgrID AND E2.ActiveIND = 1)
	LEFT OUTER JOIN code_MSTR[#SFX#]..codeRegion R ON (R.RegionID = RS.RegionID AND R.ActiveIND = 1)
WHERE
	(@clientID IS NULL OR RS.CIAuditNum = @clientID)
ORDER BY
	RS.ReassessID
