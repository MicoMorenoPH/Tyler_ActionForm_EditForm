//MAIN FORM - MODEL CLASS
[Label("Cash and Protested Tax Masking")]
[RecalculateAllOnChange]
[InputType(InputTypeAttribute.Button)]
[RecalculateMethod(nameof(ID_MaskingClick))]
public bool? ID_Masking {get; set;}
public void ID_MaskingClick()
{
	if (MTPFCntyWideMasks == null)
	{
		MTPFCntyWideMasks = new MTPFCntyWideMasks();
		MTPFCntyWideMasks.PromptForm_ShowPromptForm(true);
	}
	MetadataAction action = MetadataAction.CreateActionWithValidate("", MTPFCntyWideMasksFormMetadata.CreateView());
	bool response = VerificationQuestionHelper.ShowAction(nameof(MTPFCntyWideMasks), action, new Dictionary<string, object>(){{nameof(MTPFCntyWideMasks), MTPFCntyWideMasks}},true);
	if (response)
	{
		MTPFCntyWideMasks.cmdOK_Click();

	}
	MTPFCntyWideMasks = null;
}

//ACTION FORM - FORM METADATA CLASS

public static IViewMetadata CreateView()
{
	List<IViewMetadata> CreateView = new List<IViewMetadata>();
	CreateView.Add(CreateHeaderView());
	CreateView.Add(CreateActionActionMTPFCntyWideMasksView());
	return new CombinedViewMetadata("", CreateView.ToArray()) {CantSave = false, ImmediateDelete = true, SingleCard = true};
}

public static IViewMetadata CreateHeaderView()
{
	var CreateView = new ViewMetadata("County Wide Account Masking Listing", new PropertyAugmentor<MTMtCountyWideSchoolFundsFormFp6bMenuItem>()
	{   
	}.GenerateMetadata());
	CreateView.SubPropertyName = nameof(MTPFCntyWideMasks);
	CreateView.HelpId = "frmMTPFCntyWideMasks";
	return CreateView;
}
public static IViewMetadata CreateActionActionMTPFCntyWideMasksView()
{
	var CreateActionActionMTPFCntyWideMasksView = new GridViewMetadata("County Wide Account Masking Listing")
	{
		GridProperties = new GridMetadata()
		{
			ClassMetadata = new PropertyAugmentor<MTPFCntyWideMasksGhGridMain>()
			{
				{nameof(MTPFCntyWideMasksGhGridMain.MaskType), 33},
				{nameof(MTPFCntyWideMasksGhGridMain.AcctMask), 33},
				{nameof(MTPFCntyWideMasksGhGridMain.AcctDesc), 33},
			}.GenerateMetadata(),
			MaxRowLimit = true,
			MaxRowMessage = $"{{{nameof(BaseIVMenuItem.MaxResultMessage)}}}",
			CanAdd = AccessMgr.HasAccess(MenuItem.MTMtCountyWideSchoolFundsFormFp6b, AccessMgr.Edit) && Context.FYModel.GLGlobalParms.Any(x => x.DistrictState == "MT"),
			CanEdit = AccessMgr.HasAccess(MenuItem.MTMtCountyWideSchoolFundsFormFp6b, AccessMgr.Edit) && Context.FYModel.GLGlobalParms.Any(x => x.DistrictState == "MT"),
			CanDelete = AccessMgr.HasAccess(MenuItem.MTMtCountyWideSchoolFundsFormFp6b, AccessMgr.Edit) && Context.FYModel.GLGlobalParms.Any(x => x.DistrictState == "MT"),
			Sort = SortProperty.IgnoreSort(),
		},
		SubPropertyName = $"{nameof(MTPFCntyWideMasks)}.{nameof(MTPFCntyWideMasks.ghGridMain)}",
		EditAction = new MetadataAction
		{
			ModelPath = MetadataAction.ModelPath_this,
			ViewToShow = MTMFCntyWideMasksFormMetadata.CreateMTCountyWideSchoolFundsFormFP6bView()
		}
	};
	CreateActionActionMTPFCntyWideMasksView.ParentColumnName = nameof(MTPFCntyWideMasks.MenuId);
	CreateActionActionMTPFCntyWideMasksView.ChildColumnName = nameof(MTPFCntyWideMasksGhGridMain.MenuId);
	CreateActionActionMTPFCntyWideMasksView.HelpId = "frmMTPFCntyWideMasks";
	return CreateActionActionMTPFCntyWideMasksView;
}


//EDIT FORM - FORM METADATA CLASS
public static IViewMetadata CreateMTCountyWideSchoolFundsFormFP6bView()
{
	var CreateMTCountyWideSchoolFundsFormFP6bView = new ViewMetadata("", new PropertyAugmentor<MTMFCntyWideMasks>()
	{
		{PropertyAugmentor.CreateHeader("Setup"), 100},
		{nameof(MTMFCntyWideMasks.gcbType), 100},
		{nameof(MTMFCntyWideMasks.chkFormatAccount), 100},
		{nameof(MTMFCntyWideMasks.fptMask), 100},
		{nameof(MTMFCntyWideMasks.abxAccount), 100},
		{nameof(MTMFCntyWideMasks.fptDescription), 100},
	}.GenerateMetadata());
	CreateMTCountyWideSchoolFundsFormFP6bView.ParentColumnName = nameof(MTPFCntyWideMasksGhGridMain.ID);
	CreateMTCountyWideSchoolFundsFormFP6bView.ChildColumnName = nameof(MTMFCntyWideMasks.MenuId);
	CreateMTCountyWideSchoolFundsFormFP6bView.HelpId = "frmMTMFCntyWideMasks";
	CreateMTCountyWideSchoolFundsFormFP6bView.TitleProperty = nameof(MTMFCntyWideMasks.TitleProperty);
	CreateMTCountyWideSchoolFundsFormFP6bView.DrawWidth = 40;
	return CreateMTCountyWideSchoolFundsFormFP6bView;
}


