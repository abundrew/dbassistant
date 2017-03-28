---------------------------------------------------------------------------------------------------
--
-- PENDING DATE IN TAGS
--
--
-- <*> Description = A - The Care Plan Start Date for this assessment is different than the Pending Date in TAGS...
-- <*> Parameter Client ID = @clientID int
--
---------------------------------------------------------------------------------------------------
SELECT
	GNPendingDate AS "Pending Date in TAGS"
FROM
	TAGS[#SFX#].dbo.tblGNPlanEnrollment
WHERE
	CIAuditNum = @clientID
