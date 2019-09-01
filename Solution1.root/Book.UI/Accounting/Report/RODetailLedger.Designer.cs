namespace Book.UI.Accounting.Report
{
    partial class RODetailLedger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RODetailLedger));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrSubreport1 = new DevExpress.XtraReports.UI.XRSubreport();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.lbl_CompanyName = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.lbl_SubRange = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_DataRange = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_ReportDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreport1});
            resources.ApplyResources(this.Detail, "Detail");
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            // 
            // xrSubreport1
            // 
            resources.ApplyResources(this.xrSubreport1, "xrSubreport1");
            this.xrSubreport1.Name = "xrSubreport1";
            this.xrSubreport1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrSubreport1_BeforePrint);
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
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbl_CompanyName});
            resources.ApplyResources(this.ReportHeader, "ReportHeader");
            this.ReportHeader.Name = "ReportHeader";
            // 
            // lbl_CompanyName
            // 
            resources.ApplyResources(this.lbl_CompanyName, "lbl_CompanyName");
            this.lbl_CompanyName.Name = "lbl_CompanyName";
            this.lbl_CompanyName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lbl_CompanyName.StylePriority.UseFont = false;
            this.lbl_CompanyName.StylePriority.UseTextAlignment = false;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbl_SubRange,
            this.lbl_DataRange,
            this.lbl_ReportDate,
            this.xrLabel1});
            resources.ApplyResources(this.PageHeader, "PageHeader");
            this.PageHeader.Name = "PageHeader";
            // 
            // lbl_SubRange
            // 
            resources.ApplyResources(this.lbl_SubRange, "lbl_SubRange");
            this.lbl_SubRange.Name = "lbl_SubRange";
            this.lbl_SubRange.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lbl_SubRange.StylePriority.UseTextAlignment = false;
            // 
            // lbl_DataRange
            // 
            resources.ApplyResources(this.lbl_DataRange, "lbl_DataRange");
            this.lbl_DataRange.Name = "lbl_DataRange";
            this.lbl_DataRange.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lbl_DataRange.StylePriority.UseTextAlignment = false;
            // 
            // lbl_ReportDate
            // 
            resources.ApplyResources(this.lbl_ReportDate, "lbl_ReportDate");
            this.lbl_ReportDate.Name = "lbl_ReportDate";
            this.lbl_ReportDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lbl_ReportDate.StylePriority.UseTextAlignment = false;
            // 
            // xrLabel1
            // 
            resources.ApplyResources(this.xrLabel1, "xrLabel1");
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1});
            resources.ApplyResources(this.PageFooter, "PageFooter");
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo1
            // 
            resources.ApplyResources(this.xrPageInfo1, "xrPageInfo1");
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            // 
            // RODetailLedger
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.PageFooter});
            resources.ApplyResources(this, "$this");
            this.Margins = new System.Drawing.Printing.Margins(76, 76, 80, 80);
            this.PageHeight = 1400;
            this.PageWidth = 2149;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Version = "10.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRSubreport xrSubreport1;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel lbl_CompanyName;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel lbl_ReportDate;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel lbl_DataRange;
        private DevExpress.XtraReports.UI.XRLabel lbl_SubRange;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
    }
}
