---------------------------------------------------------------------------------------------------
--
-- T PERMISSIONS
--
--
-- <*> Description = T - Permissions (Active Screens)
-- <*> Parameter Application ID = @appID int NULL 
-- <*> Parameter Screen ID = @screenID int NULL
-- <*> Parameter Screen Name = @screenName string NULL
--
---------------------------------------------------------------------------------------------------
SELECT
	'[' + CAST(S.ApplicationID AS varchar) + '] ' + ISNULL(A.ApplicationDesc, '') AS [Application],
	'[' + CAST(O.ScreenID AS varchar) + '] ' + ISNULL(S.ScreenDesc, '') AS [Screen],
	'[' + CAST(P.ObjectID AS varchar) + '] ' + ISNULL(O.ObjectDesc, '') AS [Object],
	'[' + CAST(O.ParentObjectID AS varchar) + '] ' + ISNULL(PO.ObjectDesc, '') AS [Parent Object],
	'[' + CAST(P.RoleID AS varchar) + '] ' + ISNULL(R.RoleDesc, '') AS [Role],
	'[' + CAST(P.PermTypeID AS varchar) + ']' + ISNULL(PT.PermTypeDesc, '') AS [Permission]
FROM
	TAGS_V2[#SFX#].dbo.tblPermissions P
	LEFT OUTER JOIN TAGS_V2[#SFX#].dbo.tblRole R ON (R.RoleID = P.RoleID)
	LEFT OUTER JOIN TAGS_V2[#SFX#].dbo.codePermissionType PT ON (PT.PermTypeID = P.PermTypeID)
	LEFT OUTER JOIN TAGS_V2[#SFX#].dbo.tblObject O ON (O.ObjectID = P.ObjectID)
	LEFT OUTER JOIN TAGS_V2[#SFX#].dbo.tblObject PO ON (PO.ObjectID = O.ParentObjectID)
	LEFT OUTER JOIN TAGS_V2[#SFX#].dbo.codeScreen S ON (S.ScreenID = O.ScreenID)
	LEFT OUTER JOIN TAGS[#SFX#].dbo.codeApplication A ON (A.ApplicationID = S.ApplicationID)
WHERE
	(@appID IS NULL OR A.ApplicationID = @appID) AND
	(@screenID IS NULL OR S.ScreenID = @screenID) AND
	(@screenName IS NULL OR S.ScreenDesc LIKE @screenName) AND
	S.ActiveIND = 1
ORDER BY
	A.ApplicationDesc,
	S.ScreenDesc,
	O.ObjectDesc,
	R.RoleDesc,
	PT.PermTypeDesc