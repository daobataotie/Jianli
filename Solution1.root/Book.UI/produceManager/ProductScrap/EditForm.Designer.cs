namespace Book.UI.produceManager.ProductScrap
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txt_ProductScrapID = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txt_Note = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ncc_Employee = new Book.UI.Invoices.NewChooseContorl();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.nccDepot = new Book.UI.Invoices.NewChooseContorl();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.bindingSourceDepotPosition = new System.Windows.Forms.BindingSource(this.components);
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ProductScrapID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Note.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDepotPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // bar1
            // 
            this.bar1.OptionsBar.UseWholeRow = true;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.nccDepot);
            this.layoutControl1.Controls.Add(this.ncc_Employee);
            this.layoutControl1.Controls.Add(this.dateEdit1);
            this.layoutControl1.Controls.Add(this.txt_ProductScrapID);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.txt_Note);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 47);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(890, 521);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(890, 521);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 62);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEdit1,
            this.repositoryItemLookUpEdit1});
            this.gridControl1.Size = new System.Drawing.Size(866, 447);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(870, 451);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // txt_ProductScrapID
            // 
            this.txt_ProductScrapID.Location = new System.Drawing.Point(76, 12);
            this.txt_ProductScrapID.MenuManager = this.barManager1;
            this.txt_ProductScrapID.Name = "txt_ProductScrapID";
            this.txt_ProductScrapID.Properties.ReadOnly = true;
            this.txt_ProductScrapID.Size = new System.Drawing.Size(221, 21);
            this.txt_ProductScrapID.StyleController = this.layoutControl1;
            this.txt_ProductScrapID.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txt_ProductScrapID;
            this.layoutControlItem2.CustomizationFormText = "編號：";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(289, 25);
            this.layoutControlItem2.Text = "編號：";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(60, 14);
            // 
            // txt_Note
            // 
            this.txt_Note.Location = new System.Drawing.Point(365, 37);
            this.txt_Note.MenuManager = this.barManager1;
            this.txt_Note.Name = "txt_Note";
            this.txt_Note.Size = new System.Drawing.Size(513, 21);
            this.txt_Note.StyleController = this.layoutControl1;
            this.txt_Note.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txt_Note;
            this.layoutControlItem3.CustomizationFormText = "备注：";
            this.layoutControlItem3.Location = new System.Drawing.Point(289, 25);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(581, 25);
            this.layoutControlItem3.Text = "备注：";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(60, 14);
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(365, 12);
            this.dateEdit1.MenuManager = this.barManager1;
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(214, 21);
            this.dateEdit1.StyleController = this.layoutControl1;
            this.dateEdit1.TabIndex = 7;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.dateEdit1;
            this.layoutControlItem4.CustomizationFormText = "報廢日期：";
            this.layoutControlItem4.Location = new System.Drawing.Point(289, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(282, 25);
            this.layoutControlItem4.Text = "報廢日期：";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(60, 14);
            // 
            // ncc_Employee
            // 
            this.ncc_Employee.EditValue = null;
            this.ncc_Employee.Location = new System.Drawing.Point(647, 12);
            this.ncc_Employee.Name = "ncc_Employee";
            this.ncc_Employee.Size = new System.Drawing.Size(231, 21);
            this.ncc_Employee.TabIndex = 8;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.ncc_Employee;
            this.layoutControlItem5.CustomizationFormText = "操作員：";
            this.layoutControlItem5.Location = new System.Drawing.Point(571, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(299, 25);
            this.layoutControlItem5.Text = "操作員：";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(60, 14);
            // 
            // nccDepot
            // 
            this.nccDepot.EditValue = null;
            this.nccDepot.Location = new System.Drawing.Point(76, 37);
            this.nccDepot.Name = "nccDepot";
            this.nccDepot.Size = new System.Drawing.Size(221, 21);
            this.nccDepot.TabIndex = 9;
            this.nccDepot.EditValueChanged += new System.EventHandler(this.nccDepot_EditValueChanged);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.nccDepot;
            this.layoutControlItem6.CustomizationFormText = "庫房：";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(289, 25);
            this.layoutControlItem6.Text = "庫房：";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(60, 14);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "商品編號";
            this.gridColumn1.FieldName = "Product.Id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "商品名稱";
            this.gridColumn2.FieldName = "Product.ProductName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "報廢數量";
            this.gridColumn3.ColumnEdit = this.repositoryItemSpinEdit1;
            this.gridColumn3.FieldName = "ScrapQuantity";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "貨位";
            this.gridColumn4.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.gridColumn4.FieldName = "DepotPositionId";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 123;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "報廢事由";
            this.gridColumn5.FieldName = "Note";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 163;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "編號")});
            this.repositoryItemLookUpEdit1.DataSource = this.bindingSourceDepotPosition;
            this.repositoryItemLookUpEdit1.DisplayMember = "Id";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            this.repositoryItemLookUpEdit1.ValueMember = "DepotPositionId";
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 568);
            this.Controls.Add(this.layoutControl1);
            this.Name = "EditForm";
            this.Text = "商品報廢單";
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ProductScrapID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Note.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDepotPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txt_Note;
        private DevExpress.XtraEditors.TextEdit txt_ProductScrapID;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private Book.UI.Invoices.NewChooseContorl ncc_Employee;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private Book.UI.Invoices.NewChooseContorl nccDepot;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.BindingSource bindingSourceDepotPosition;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
    }
}