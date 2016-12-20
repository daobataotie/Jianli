namespace Book.UI.Accounting.YPFP
{
    partial class EditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.spe_TotalMoney = new DevExpress.XtraEditors.SpinEdit();
            this.spe_Tax = new DevExpress.XtraEditors.SpinEdit();
            this.spe_Money = new DevExpress.XtraEditors.SpinEdit();
            this.cob_FPHeader = new DevExpress.XtraEditors.ComboBoxEdit();
            this.nccSupplier = new Book.UI.Invoices.NewChooseContorl();
            this.date_YFFP = new DevExpress.XtraEditors.DateEdit();
            this.txt_FPId = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spe_TotalMoney.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spe_Tax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spe_Money.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cob_FPHeader.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_YFFP.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_YFFP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_FPId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1});
            this.barManager1.MaxItemId = 16;
            // 
            // imageCollection1
            // 
            resources.ApplyResources(this.imageCollection1, "imageCollection1");
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // barButtonItemFirst
            // 
            this.barButtonItemFirst.AccessibleDescription = null;
            this.barButtonItemFirst.AccessibleName = null;
            resources.ApplyResources(this.barButtonItemFirst, "barButtonItemFirst");
            // 
            // barButtonItemPrint
            // 
            this.barButtonItemPrint.AccessibleDescription = null;
            this.barButtonItemPrint.AccessibleName = null;
            resources.ApplyResources(this.barButtonItemPrint, "barButtonItemPrint");
            // 
            // bar1
            // 
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            this.bar1.OptionsBar.UseWholeRow = true;
            resources.ApplyResources(this.bar1, "bar1");
            // 
            // barButtonItemNew
            // 
            this.barButtonItemNew.AccessibleDescription = null;
            this.barButtonItemNew.AccessibleName = null;
            resources.ApplyResources(this.barButtonItemNew, "barButtonItemNew");
            // 
            // layoutControl1
            // 
            this.layoutControl1.AccessibleDescription = null;
            this.layoutControl1.AccessibleName = null;
            resources.ApplyResources(this.layoutControl1, "layoutControl1");
            this.layoutControl1.BackgroundImage = null;
            this.layoutControl1.Controls.Add(this.spe_TotalMoney);
            this.layoutControl1.Controls.Add(this.spe_Tax);
            this.layoutControl1.Controls.Add(this.spe_Money);
            this.layoutControl1.Controls.Add(this.cob_FPHeader);
            this.layoutControl1.Controls.Add(this.nccSupplier);
            this.layoutControl1.Controls.Add(this.date_YFFP);
            this.layoutControl1.Controls.Add(this.txt_FPId);
            this.layoutControl1.Font = null;
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            // 
            // spe_TotalMoney
            // 
            resources.ApplyResources(this.spe_TotalMoney, "spe_TotalMoney");
            this.spe_TotalMoney.BackgroundImage = null;
            this.spe_TotalMoney.MenuManager = this.barManager1;
            this.spe_TotalMoney.Name = "spe_TotalMoney";
            this.spe_TotalMoney.Properties.AccessibleDescription = null;
            this.spe_TotalMoney.Properties.AccessibleName = null;
            this.spe_TotalMoney.Properties.AutoHeight = ((bool)(resources.GetObject("spe_TotalMoney.Properties.AutoHeight")));
            this.spe_TotalMoney.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spe_TotalMoney.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("spe_TotalMoney.Properties.Mask.AutoComplete")));
            this.spe_TotalMoney.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("spe_TotalMoney.Properties.Mask.BeepOnError")));
            this.spe_TotalMoney.Properties.Mask.EditMask = resources.GetString("spe_TotalMoney.Properties.Mask.EditMask");
            this.spe_TotalMoney.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("spe_TotalMoney.Properties.Mask.IgnoreMaskBlank")));
            this.spe_TotalMoney.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("spe_TotalMoney.Properties.Mask.MaskType")));
            this.spe_TotalMoney.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("spe_TotalMoney.Properties.Mask.PlaceHolder")));
            this.spe_TotalMoney.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("spe_TotalMoney.Properties.Mask.SaveLiteral")));
            this.spe_TotalMoney.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("spe_TotalMoney.Properties.Mask.ShowPlaceHolders")));
            this.spe_TotalMoney.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("spe_TotalMoney.Properties.Mask.UseMaskAsDisplayFormat")));
            this.spe_TotalMoney.Properties.NullValuePrompt = resources.GetString("spe_TotalMoney.Properties.NullValuePrompt");
            this.spe_TotalMoney.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("spe_TotalMoney.Properties.NullValuePromptShowForEmptyValue")));
            this.spe_TotalMoney.Properties.ReadOnly = true;
            this.spe_TotalMoney.StyleController = this.layoutControl1;
            // 
            // spe_Tax
            // 
            resources.ApplyResources(this.spe_Tax, "spe_Tax");
            this.spe_Tax.BackgroundImage = null;
            this.spe_Tax.MenuManager = this.barManager1;
            this.spe_Tax.Name = "spe_Tax";
            this.spe_Tax.Properties.AccessibleDescription = null;
            this.spe_Tax.Properties.AccessibleName = null;
            this.spe_Tax.Properties.AutoHeight = ((bool)(resources.GetObject("spe_Tax.Properties.AutoHeight")));
            this.spe_Tax.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spe_Tax.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("spe_Tax.Properties.Mask.AutoComplete")));
            this.spe_Tax.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("spe_Tax.Properties.Mask.BeepOnError")));
            this.spe_Tax.Properties.Mask.EditMask = resources.GetString("spe_Tax.Properties.Mask.EditMask");
            this.spe_Tax.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("spe_Tax.Properties.Mask.IgnoreMaskBlank")));
            this.spe_Tax.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("spe_Tax.Properties.Mask.MaskType")));
            this.spe_Tax.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("spe_Tax.Properties.Mask.PlaceHolder")));
            this.spe_Tax.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("spe_Tax.Properties.Mask.SaveLiteral")));
            this.spe_Tax.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("spe_Tax.Properties.Mask.ShowPlaceHolders")));
            this.spe_Tax.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("spe_Tax.Properties.Mask.UseMaskAsDisplayFormat")));
            this.spe_Tax.Properties.NullValuePrompt = resources.GetString("spe_Tax.Properties.NullValuePrompt");
            this.spe_Tax.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("spe_Tax.Properties.NullValuePromptShowForEmptyValue")));
            this.spe_Tax.StyleController = this.layoutControl1;
            this.spe_Tax.EditValueChanged += new System.EventHandler(this.spe_Tax_EditValueChanged);
            // 
            // spe_Money
            // 
            resources.ApplyResources(this.spe_Money, "spe_Money");
            this.spe_Money.BackgroundImage = null;
            this.spe_Money.MenuManager = this.barManager1;
            this.spe_Money.Name = "spe_Money";
            this.spe_Money.Properties.AccessibleDescription = null;
            this.spe_Money.Properties.AccessibleName = null;
            this.spe_Money.Properties.AutoHeight = ((bool)(resources.GetObject("spe_Money.Properties.AutoHeight")));
            this.spe_Money.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spe_Money.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("spe_Money.Properties.Mask.AutoComplete")));
            this.spe_Money.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("spe_Money.Properties.Mask.BeepOnError")));
            this.spe_Money.Properties.Mask.EditMask = resources.GetString("spe_Money.Properties.Mask.EditMask");
            this.spe_Money.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("spe_Money.Properties.Mask.IgnoreMaskBlank")));
            this.spe_Money.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("spe_Money.Properties.Mask.MaskType")));
            this.spe_Money.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("spe_Money.Properties.Mask.PlaceHolder")));
            this.spe_Money.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("spe_Money.Properties.Mask.SaveLiteral")));
            this.spe_Money.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("spe_Money.Properties.Mask.ShowPlaceHolders")));
            this.spe_Money.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("spe_Money.Properties.Mask.UseMaskAsDisplayFormat")));
            this.spe_Money.Properties.NullValuePrompt = resources.GetString("spe_Money.Properties.NullValuePrompt");
            this.spe_Money.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("spe_Money.Properties.NullValuePromptShowForEmptyValue")));
            this.spe_Money.StyleController = this.layoutControl1;
            this.spe_Money.EditValueChanged += new System.EventHandler(this.spe_Money_EditValueChanged);
            // 
            // cob_FPHeader
            // 
            resources.ApplyResources(this.cob_FPHeader, "cob_FPHeader");
            this.cob_FPHeader.BackgroundImage = null;
            this.cob_FPHeader.EditValue = null;
            this.cob_FPHeader.MenuManager = this.barManager1;
            this.cob_FPHeader.Name = "cob_FPHeader";
            this.cob_FPHeader.Properties.AccessibleDescription = null;
            this.cob_FPHeader.Properties.AccessibleName = null;
            this.cob_FPHeader.Properties.AutoHeight = ((bool)(resources.GetObject("cob_FPHeader.Properties.AutoHeight")));
            this.cob_FPHeader.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cob_FPHeader.Properties.Buttons"))))});
            this.cob_FPHeader.Properties.Items.AddRange(new object[] {
            resources.GetString("cob_FPHeader.Properties.Items"),
            resources.GetString("cob_FPHeader.Properties.Items1")});
            this.cob_FPHeader.Properties.NullValuePrompt = resources.GetString("cob_FPHeader.Properties.NullValuePrompt");
            this.cob_FPHeader.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cob_FPHeader.Properties.NullValuePromptShowForEmptyValue")));
            this.cob_FPHeader.StyleController = this.layoutControl1;
            // 
            // nccSupplier
            // 
            this.nccSupplier.AccessibleDescription = null;
            this.nccSupplier.AccessibleName = null;
            resources.ApplyResources(this.nccSupplier, "nccSupplier");
            this.nccSupplier.BackgroundImage = null;
            this.nccSupplier.EditValue = null;
            this.nccSupplier.Font = null;
            this.nccSupplier.Name = "nccSupplier";
            // 
            // date_YFFP
            // 
            resources.ApplyResources(this.date_YFFP, "date_YFFP");
            this.date_YFFP.BackgroundImage = null;
            this.date_YFFP.EditValue = null;
            this.date_YFFP.MenuManager = this.barManager1;
            this.date_YFFP.Name = "date_YFFP";
            this.date_YFFP.Properties.AccessibleDescription = null;
            this.date_YFFP.Properties.AccessibleName = null;
            this.date_YFFP.Properties.AutoHeight = ((bool)(resources.GetObject("date_YFFP.Properties.AutoHeight")));
            this.date_YFFP.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("date_YFFP.Properties.Buttons"))))});
            this.date_YFFP.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("date_YFFP.Properties.Mask.AutoComplete")));
            this.date_YFFP.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("date_YFFP.Properties.Mask.BeepOnError")));
            this.date_YFFP.Properties.Mask.EditMask = resources.GetString("date_YFFP.Properties.Mask.EditMask");
            this.date_YFFP.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("date_YFFP.Properties.Mask.IgnoreMaskBlank")));
            this.date_YFFP.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("date_YFFP.Properties.Mask.MaskType")));
            this.date_YFFP.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("date_YFFP.Properties.Mask.PlaceHolder")));
            this.date_YFFP.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("date_YFFP.Properties.Mask.SaveLiteral")));
            this.date_YFFP.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("date_YFFP.Properties.Mask.ShowPlaceHolders")));
            this.date_YFFP.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("date_YFFP.Properties.Mask.UseMaskAsDisplayFormat")));
            this.date_YFFP.Properties.NullValuePrompt = resources.GetString("date_YFFP.Properties.NullValuePrompt");
            this.date_YFFP.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("date_YFFP.Properties.NullValuePromptShowForEmptyValue")));
            this.date_YFFP.Properties.VistaTimeProperties.AccessibleDescription = null;
            this.date_YFFP.Properties.VistaTimeProperties.AccessibleName = null;
            this.date_YFFP.Properties.VistaTimeProperties.AutoHeight = ((bool)(resources.GetObject("date_YFFP.Properties.VistaTimeProperties.AutoHeight")));
            this.date_YFFP.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.date_YFFP.Properties.VistaTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("date_YFFP.Properties.VistaTimeProperties.Mask.AutoComplete")));
            this.date_YFFP.Properties.VistaTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("date_YFFP.Properties.VistaTimeProperties.Mask.BeepOnError")));
            this.date_YFFP.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("date_YFFP.Properties.VistaTimeProperties.Mask.EditMask");
            this.date_YFFP.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("date_YFFP.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank")));
            this.date_YFFP.Properties.VistaTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("date_YFFP.Properties.VistaTimeProperties.Mask.MaskType")));
            this.date_YFFP.Properties.VistaTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("date_YFFP.Properties.VistaTimeProperties.Mask.PlaceHolder")));
            this.date_YFFP.Properties.VistaTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("date_YFFP.Properties.VistaTimeProperties.Mask.SaveLiteral")));
            this.date_YFFP.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("date_YFFP.Properties.VistaTimeProperties.Mask.ShowPlaceHolders")));
            this.date_YFFP.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("date_YFFP.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat")));
            this.date_YFFP.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("date_YFFP.Properties.VistaTimeProperties.NullValuePrompt");
            this.date_YFFP.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("date_YFFP.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue")));
            this.date_YFFP.StyleController = this.layoutControl1;
            // 
            // txt_FPId
            // 
            resources.ApplyResources(this.txt_FPId, "txt_FPId");
            this.txt_FPId.BackgroundImage = null;
            this.txt_FPId.EditValue = null;
            this.txt_FPId.MenuManager = this.barManager1;
            this.txt_FPId.Name = "txt_FPId";
            this.txt_FPId.Properties.AccessibleDescription = null;
            this.txt_FPId.Properties.AccessibleName = null;
            this.txt_FPId.Properties.AutoHeight = ((bool)(resources.GetObject("txt_FPId.Properties.AutoHeight")));
            this.txt_FPId.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txt_FPId.Properties.Mask.AutoComplete")));
            this.txt_FPId.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txt_FPId.Properties.Mask.BeepOnError")));
            this.txt_FPId.Properties.Mask.EditMask = resources.GetString("txt_FPId.Properties.Mask.EditMask");
            this.txt_FPId.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txt_FPId.Properties.Mask.IgnoreMaskBlank")));
            this.txt_FPId.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txt_FPId.Properties.Mask.MaskType")));
            this.txt_FPId.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txt_FPId.Properties.Mask.PlaceHolder")));
            this.txt_FPId.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txt_FPId.Properties.Mask.SaveLiteral")));
            this.txt_FPId.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txt_FPId.Properties.Mask.ShowPlaceHolders")));
            this.txt_FPId.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txt_FPId.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txt_FPId.Properties.NullValuePrompt = resources.GetString("txt_FPId.Properties.NullValuePrompt");
            this.txt_FPId.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txt_FPId.Properties.NullValuePromptShowForEmptyValue")));
            this.txt_FPId.StyleController = this.layoutControl1;
            // 
            // layoutControlGroup1
            // 
            resources.ApplyResources(this.layoutControlGroup1, "layoutControlGroup1");
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.emptySpaceItem1,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(837, 130);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.date_YFFP;
            resources.ApplyResources(this.layoutControlItem2, "layoutControlItem2");
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(408, 25);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(55, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txt_FPId;
            resources.ApplyResources(this.layoutControlItem1, "layoutControlItem1");
            this.layoutControlItem1.Location = new System.Drawing.Point(408, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(409, 25);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(55, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.nccSupplier;
            resources.ApplyResources(this.layoutControlItem3, "layoutControlItem3");
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(408, 25);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(55, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.cob_FPHeader;
            resources.ApplyResources(this.layoutControlItem4, "layoutControlItem4");
            this.layoutControlItem4.Location = new System.Drawing.Point(408, 25);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(409, 25);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(55, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.spe_Money;
            resources.ApplyResources(this.layoutControlItem5, "layoutControlItem5");
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(408, 25);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(55, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.spe_Tax;
            resources.ApplyResources(this.layoutControlItem6, "layoutControlItem6");
            this.layoutControlItem6.Location = new System.Drawing.Point(408, 50);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(409, 25);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(55, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.spe_TotalMoney;
            resources.ApplyResources(this.layoutControlItem7, "layoutControlItem7");
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 75);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(408, 25);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(55, 14);
            // 
            // emptySpaceItem1
            // 
            resources.ApplyResources(this.emptySpaceItem1, "emptySpaceItem1");
            this.emptySpaceItem1.Location = new System.Drawing.Point(408, 75);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(409, 25);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            resources.ApplyResources(this.emptySpaceItem2, "emptySpaceItem2");
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 100);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(817, 10);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.AccessibleDescription = null;
            this.barButtonItem1.AccessibleName = null;
            resources.ApplyResources(this.barButtonItem1, "barButtonItem1");
            this.barButtonItem1.Id = 15;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // EditForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Icon = null;
            this.Name = "EditForm";
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spe_TotalMoney.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spe_Tax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spe_Money.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cob_FPHeader.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_YFFP.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_YFFP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_FPId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SpinEdit spe_TotalMoney;
        private DevExpress.XtraEditors.SpinEdit spe_Tax;
        private DevExpress.XtraEditors.SpinEdit spe_Money;
        private DevExpress.XtraEditors.ComboBoxEdit cob_FPHeader;
        private Book.UI.Invoices.NewChooseContorl nccSupplier;
        private DevExpress.XtraEditors.DateEdit date_YFFP;
        private DevExpress.XtraEditors.TextEdit txt_FPId;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}