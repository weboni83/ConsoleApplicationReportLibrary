SELECT	a.U_ManageNo AS Code
		,a1.Department AS Department
		,a1.Name AS Writer
		,Convert(VARCHAR(10), a.U_MakeDate, 120) AS MakeDate
		,Convert(VARCHAR(10), a.U_EvalDate, 120) AS EvalDate
		,a.U_Model AS Model
		,a.U_ItemName AS ItemName
		,a.U_ItemCode AS ItemCode
		,a.U_IssueNo AS IssueNo
		,a.U_NewItemCode AS NewItemCode
		,a.U_NewIssueNo AS NewIssueNo
		,a2.Name AS InspType
		,a.U_EvalConclusion AS EvalConclusion
		,a.U_Inspection AS Inspection
		,case a.U_Failed	when	0	then Null	else	a.U_Failed	end AS Failed
		,case a.U_Passed	when	0	then Null	else	a.U_Passed	end AS Passed
		,a.U_EvalConclusion AS  EvalConclusion
		,a.U_FailedDesc AS FailedDesc
		,a.U_Confirmer AS Confirmer

FROM	dbo.[@ZF1705H] a
LEFT OUTER JOIN
(
	SELECT	T0.empID as [Code]
			, T0.[lastName] + T0.[firstName] + case when LEN(ISNULL(T0.[jobTitle], 0)) > 0 then ' ' +  ISNULL(T0.[jobTitle], '') else '' end AS [Name]
			, T1.[Name] AS [Department]
	FROM	OHEM T0
	LEFT OUTER JOIN	OUDP T1
		ON	T0.dept = T1.Code
) a1
	ON	a.U_Writer = a1.Code
LEFT OUTER JOIN [@ZF1702A] a2
	ON	a.U_InspType = a2.Code
WHERE	a.Code = @Code


SELECT	a.U_ManageNo AS Code
		,b.U_SeqNo As SeqNo
		,b.U_ValItem AS ValItem
		,b.U_Criteria AS Criteria
		,b.U_Method AS Method
		,case b.U_FailYN when 'Y'	then	'¡Û'	else	''	end AS 'FailYN'
		,case b.U_PassYN when 'Y'	then	'¡Û'	else	''	end AS 'PassYN'
		,b.U_Desc AS [Desc]
FROM	dbo.[@ZF1705H] a
JOIN	dbo.[@ZF1705L] b
	ON	a.Code = b.Code
WHERE	a.Code = @Code

ORDER BY b.U_SeqNo
