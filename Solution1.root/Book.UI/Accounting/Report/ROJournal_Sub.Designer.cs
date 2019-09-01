namespace Book.UI.Accounting.Report
{
    partial class ROJournal_Sub
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ROJournal_Sub));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.TCDate = new DevExpress.XtraReports.UI.XRTableCell();
            this.TCID = new DevExpress.XtraReports.UI.XRTableCell();
            this.TCCategory = new DevExpress.XtraReports.UI.XRTableCell();
            this.TCSubId = new DevExpress.XtraReports.UI.XRTableCell();
            this.TCSubName = new DevExpress.XtraReports.UI.XRTableCell();
            this.TCSummary = new DevExpress.XtraReports.UI.XRTableCell();
            this.TCJMoney = new DevExpress.XtraReports.UI.XRTableCell();
            this.TCDMoney = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            resources.ApplyResources(this.Detail, "Detail");
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            resources.ApplyResources(this.xrTable2, "xrTable2");
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 254F);
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UsePadding = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.TCDate,
            this.TCID,
            this.TCCategory,
            this.TCSubId,
            this.TCSubName,
            this.TCSummary,
            this.TCJMoney,
            this.TCDMoney});
            resources.ApplyResources(this.xrTableRow2, "xrTableRow2");
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1;
            // 
            // TCDate
            // 
            this.TCDate.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            resources.ApplyResources(this.TCDate, "TCDate");
            this.TCDate.Name = "TCDate";
            this.TCDate.StylePriority.UseBorders = false;
            this.TCDate.Weight = 0.28313253905004104;
            // 
            // TCID
            // 
            resources.ApplyResources(this.TCID, "TCID");
            this.TCID.Name = "TCID";
            this.TCID.Weight = 0.43172693894597458;
            // 
            // TCCategory
            // 
            resources.ApplyResources(this.TCCategory, "TCCategory");
            this.TCCategory.Name = "TCCategory";
            this.TCCategory.Weight = 0.37449804709550472;
            // 
            // TCSubId
            // 
            resources.ApplyResources(this.TCSubId, "TCSubId");
            this.TCSubId.Name = "TCSubId";
            this.TCSubId.Weight = 0.28965832412745779;
            // 
            // TCSubName
            // 
            resources.ApplyResources(this.TCSubName, "TCSubName");
            this.TCSubName.Name = "TCSubName";
            this.TCSubName.Weight = 0.40988997447286041;
            // 
            // TCSummary
            // 
            resources.ApplyResources(this.TCSummary, "TCSummary");
            this.TCSummary.Name = "TCSummary";
            this.TCSummary.Weight = 0.6187243300832066;
            // 
            // TCJMoney
            // 
            resources.ApplyResources(this.TCJMoney, "TCJMoney");
            this.TCJMoney.Name = "TCJMoney";
            this.TCJMoney.StylePriority.UseTextAlignment = false;
            this.TCJMoney.Weight = 0.31927721134068748;
            // 
            // TCDMoney
            // 
            resources.ApplyResources(this.TCDMoney, "TCDMoney");
            this.TCDMoney.Name = "TCDMoney";
            this.TCDMoney.StylePriority.UseTextAlignment = false;
            this.TCDMoney.Weight = 0.28514008352542453;
            // 
            // TopMargin
            // 
            resources.ApplyResources(this.TopMargin, "TopMargin");
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            // 
            // BottomMargin
            // 
            resources.ApplyResources(this.BottomMargin, "BottomMargin");
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            // 
            // ROJournal_Sub
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            resources.ApplyResources(this, "$this");
            this.Margins = new System.Drawing.Printing.Margins(77, 77, 80, 80);
            this.PageHeight = 1400;
            this.PageWidth = 2149;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Version = "10.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell TCDate;
        private DevExpress.XtraReports.UI.XRTableCell TCID;
        private DevExpress.XtraReports.UI.XRTableCell TCCategory;
        private DevExpress.XtraReports.UI.XRTableCell TCSubId;
        private DevExpress.XtraReports.UI.XRTableCell TCSubName;
        private DevExpress.XtraReports.UI.XRTableCell TCSummary;
        private DevExpress.XtraReports.UI.XRTableCell TCJMoney;
        private DevExpress.XtraReports.UI.XRTableCell TCDMoney;
    }
}
