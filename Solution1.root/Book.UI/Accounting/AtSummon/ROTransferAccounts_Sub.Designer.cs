namespace Book.UI.Accounting.AtSummon
{
    partial class ROTransferAccounts_Sub
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
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.TC_Jiedai = new DevExpress.XtraReports.UI.XRTableCell();
            this.TCSubId = new DevExpress.XtraReports.UI.XRTableCell();
            this.TC_SubName = new DevExpress.XtraReports.UI.XRTableCell();
            this.TC_Note = new DevExpress.XtraReports.UI.XRTableCell();
            this.TC_JMoney = new DevExpress.XtraReports.UI.XRTableCell();
            this.TC_DMoney = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.Detail.Dpi = 254F;
            this.Detail.HeightF = 64F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Dpi = 254F;
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 254F);
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(1971.146F, 64F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UsePadding = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.TC_Jiedai,
            this.TCSubId,
            this.TC_SubName,
            this.TC_Note,
            this.TC_JMoney,
            this.TC_DMoney});
            this.xrTableRow2.Dpi = 254F;
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1;
            // 
            // TC_Jiedai
            // 
            this.TC_Jiedai.Dpi = 254F;
            this.TC_Jiedai.Name = "TC_Jiedai";
            this.TC_Jiedai.StylePriority.UseTextAlignment = false;
            this.TC_Jiedai.Text = "借貸";
            this.TC_Jiedai.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.TC_Jiedai.Weight = 0.153691274575515;
            // 
            // TCSubId
            // 
            this.TCSubId.Dpi = 254F;
            this.TCSubId.Name = "TCSubId";
            this.TCSubId.StylePriority.UseTextAlignment = false;
            this.TCSubId.Text = "科目編號";
            this.TCSubId.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.TCSubId.Weight = 0.30637581066865116;
            // 
            // TC_SubName
            // 
            this.TC_SubName.Dpi = 254F;
            this.TC_SubName.Name = "TC_SubName";
            this.TC_SubName.StylePriority.UseTextAlignment = false;
            this.TC_SubName.Text = "科目名稱";
            this.TC_SubName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.TC_SubName.Weight = 0.4565871750595763;
            // 
            // TC_Note
            // 
            this.TC_Note.Dpi = 254F;
            this.TC_Note.Name = "TC_Note";
            this.TC_Note.StylePriority.UseTextAlignment = false;
            this.TC_Note.Text = "摘要";
            this.TC_Note.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.TC_Note.Weight = 1.3893861039757149;
            // 
            // TC_JMoney
            // 
            this.TC_JMoney.Dpi = 254F;
            this.TC_JMoney.Name = "TC_JMoney";
            this.TC_JMoney.StylePriority.UseTextAlignment = false;
            this.TC_JMoney.Text = "借方金額";
            this.TC_JMoney.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.TC_JMoney.Weight = 0.35100698142225445;
            // 
            // TC_DMoney
            // 
            this.TC_DMoney.Dpi = 254F;
            this.TC_DMoney.Name = "TC_DMoney";
            this.TC_DMoney.StylePriority.UseTextAlignment = false;
            this.TC_DMoney.Text = "貸方金額";
            this.TC_DMoney.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.TC_DMoney.Weight = 0.342952654298288;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 51F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 51F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ROTransferAccounts_Sub
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Dpi = 254F;
            this.Margins = new System.Drawing.Printing.Margins(79, 79, 51, 51);
            this.PageHeight = 1400;
            this.PageWidth = 2159;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.SnapGridSize = 31.75F;
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
        private DevExpress.XtraReports.UI.XRTableCell TC_Jiedai;
        private DevExpress.XtraReports.UI.XRTableCell TCSubId;
        private DevExpress.XtraReports.UI.XRTableCell TC_SubName;
        private DevExpress.XtraReports.UI.XRTableCell TC_Note;
        private DevExpress.XtraReports.UI.XRTableCell TC_JMoney;
        private DevExpress.XtraReports.UI.XRTableCell TC_DMoney;
    }
}
