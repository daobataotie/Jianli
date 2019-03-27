namespace Book.UI.Invoices.XS
{
    partial class ROHistoryXS
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
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.lbl_CompanyName = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_ReportName = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_ReportDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.TCInvoiceDate = new DevExpress.XtraReports.UI.XRTableCell();
            this.TCDeclareDate = new DevExpress.XtraReports.UI.XRTableCell();
            this.TCShipMethod = new DevExpress.XtraReports.UI.XRTableCell();
            this.TCXSCustomer = new DevExpress.XtraReports.UI.XRTableCell();
            this.TCInvoiceNO = new DevExpress.XtraReports.UI.XRTableCell();
            this.TCAmount = new DevExpress.XtraReports.UI.XRTableCell();
            this.TCRealAmount = new DevExpress.XtraReports.UI.XRTableCell();
            this.TCExchangeRate = new DevExpress.XtraReports.UI.XRTableCell();
            this.TCTaibiAmount = new DevExpress.XtraReports.UI.XRTableCell();
            this.TCPayTerm = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TCTotalAmount = new DevExpress.XtraReports.UI.XRTableCell();
            this.TCTotalTaibiAmount = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TCCusXOId = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.Detail.Dpi = 254F;
            this.Detail.HeightF = 60F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 79F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 79F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbl_CompanyName});
            this.ReportHeader.Dpi = 254F;
            this.ReportHeader.HeightF = 84.87834F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1,
            this.lbl_ReportDate,
            this.lbl_ReportName});
            this.PageHeader.Dpi = 254F;
            this.PageHeader.HeightF = 265.5F;
            this.PageHeader.Name = "PageHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
            this.ReportFooter.Dpi = 254F;
            this.ReportFooter.HeightF = 60F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // lbl_CompanyName
            // 
            this.lbl_CompanyName.Dpi = 254F;
            this.lbl_CompanyName.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CompanyName.LocationFloat = new DevExpress.Utils.PointFloat(25.00001F, 0F);
            this.lbl_CompanyName.Name = "lbl_CompanyName";
            this.lbl_CompanyName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.lbl_CompanyName.SizeF = new System.Drawing.SizeF(2584F, 84.87834F);
            this.lbl_CompanyName.StylePriority.UseFont = false;
            this.lbl_CompanyName.StylePriority.UseTextAlignment = false;
            this.lbl_CompanyName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbl_ReportName
            // 
            this.lbl_ReportName.Dpi = 254F;
            this.lbl_ReportName.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ReportName.LocationFloat = new DevExpress.Utils.PointFloat(31.75F, 0F);
            this.lbl_ReportName.Name = "lbl_ReportName";
            this.lbl_ReportName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lbl_ReportName.SizeF = new System.Drawing.SizeF(2584F, 69.00334F);
            this.lbl_ReportName.StylePriority.UseFont = false;
            this.lbl_ReportName.StylePriority.UseTextAlignment = false;
            this.lbl_ReportName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbl_ReportDate
            // 
            this.lbl_ReportDate.Dpi = 254F;
            this.lbl_ReportDate.LocationFloat = new DevExpress.Utils.PointFloat(986.2289F, 69.00338F);
            this.lbl_ReportDate.Name = "lbl_ReportDate";
            this.lbl_ReportDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.lbl_ReportDate.SizeF = new System.Drawing.SizeF(677.3338F, 58.42001F);
            this.lbl_ReportDate.StylePriority.UseTextAlignment = false;
            this.lbl_ReportDate.Text = "lbl_ReportDate";
            this.lbl_ReportDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Dpi = 254F;
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 165.5F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(2615.75F, 100F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell5,
            this.xrTableCell4,
            this.xrTableCell1,
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell2,
            this.xrTableCell9,
            this.xrTableCell8,
            this.xrTableCell10,
            this.xrTableCell3,
            this.xrTableCell12});
            this.xrTableRow1.Dpi = 254F;
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Dpi = 254F;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "貨運方式";
            this.xrTableCell1.Weight = 0.26796225371137622;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Dpi = 254F;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "Sales                                         (出貨金額) ";
            this.xrTableCell2.Weight = 0.2138379908908459;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Dpi = 254F;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "Payment Term";
            this.xrTableCell3.Weight = 0.376625564173721;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Dpi = 254F;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "報關日期";
            this.xrTableCell4.Weight = 0.21383828665137844;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Dpi = 254F;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "日期";
            this.xrTableCell5.Weight = 0.22017367329029086;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Dpi = 254F;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "出貨客戶";
            this.xrTableCell6.Weight = 0.44575747241142272;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Dpi = 254F;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "Invoice No";
            this.xrTableCell7.Weight = 0.3223234623242307;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Dpi = 254F;
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "報關匯率";
            this.xrTableCell8.Weight = 0.16863624383391551;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Dpi = 254F;
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Text = "實際請款";
            this.xrTableCell9.Weight = 0.21082502298479139;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Dpi = 254F;
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Text = "請款總金額                            (NT$)";
            this.xrTableCell10.Weight = 0.25301338478595548;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Dpi = 254F;
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(2615.75F, 60F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.TCInvoiceDate,
            this.TCDeclareDate,
            this.TCShipMethod,
            this.TCXSCustomer,
            this.TCInvoiceNO,
            this.TCAmount,
            this.TCRealAmount,
            this.TCExchangeRate,
            this.TCTaibiAmount,
            this.TCPayTerm,
            this.TCCusXOId});
            this.xrTableRow2.Dpi = 254F;
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1.2;
            // 
            // TCInvoiceDate
            // 
            this.TCInvoiceDate.Dpi = 254F;
            this.TCInvoiceDate.Name = "TCInvoiceDate";
            this.TCInvoiceDate.Text = "日期";
            this.TCInvoiceDate.Weight = 0.22017367321968986;
            // 
            // TCDeclareDate
            // 
            this.TCDeclareDate.Dpi = 254F;
            this.TCDeclareDate.Name = "TCDeclareDate";
            this.TCDeclareDate.Weight = 0.21383828659842757;
            // 
            // TCShipMethod
            // 
            this.TCShipMethod.Dpi = 254F;
            this.TCShipMethod.Name = "TCShipMethod";
            this.TCShipMethod.Text = "貨運方式";
            this.TCShipMethod.Weight = 0.267962340588879;
            // 
            // TCXSCustomer
            // 
            this.TCXSCustomer.Dpi = 254F;
            this.TCXSCustomer.Name = "TCXSCustomer";
            this.TCXSCustomer.Text = "出貨客戶";
            this.TCXSCustomer.Weight = 0.4457576811009939;
            // 
            // TCInvoiceNO
            // 
            this.TCInvoiceNO.Dpi = 254F;
            this.TCInvoiceNO.Name = "TCInvoiceNO";
            this.TCInvoiceNO.Text = "Invoice No";
            this.TCInvoiceNO.Weight = 0.32232325377586213;
            // 
            // TCAmount
            // 
            this.TCAmount.Dpi = 254F;
            this.TCAmount.Name = "TCAmount";
            this.TCAmount.Weight = 0.21383785185860013;
            // 
            // TCRealAmount
            // 
            this.TCRealAmount.Dpi = 254F;
            this.TCRealAmount.Name = "TCRealAmount";
            this.TCRealAmount.Text = "實際請款";
            this.TCRealAmount.Weight = 0.21082502298479144;
            // 
            // TCExchangeRate
            // 
            this.TCExchangeRate.Dpi = 254F;
            this.TCExchangeRate.Name = "TCExchangeRate";
            this.TCExchangeRate.Text = "報關匯率";
            this.TCExchangeRate.Weight = 0.16863624383391548;
            // 
            // TCTaibiAmount
            // 
            this.TCTaibiAmount.Dpi = 254F;
            this.TCTaibiAmount.Name = "TCTaibiAmount";
            this.TCTaibiAmount.Weight = 0.25301366285044691;
            // 
            // TCPayTerm
            // 
            this.TCPayTerm.Dpi = 254F;
            this.TCPayTerm.Name = "TCPayTerm";
            this.TCPayTerm.Weight = 0.37662542514147529;
            // 
            // xrTable3
            // 
            this.xrTable3.Dpi = 254F;
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(2615.75F, 60F);
            this.xrTable3.StylePriority.UseTextAlignment = false;
            this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell11,
            this.xrTableCell16,
            this.TCTotalAmount,
            this.TCTotalTaibiAmount,
            this.xrTableCell20});
            this.xrTableRow3.Dpi = 254F;
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1.2;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Dpi = 254F;
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Text = "TOTAL：";
            this.xrTableCell11.Weight = 0.23222757754502651;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Dpi = 254F;
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Weight = 1.3703018755543657;
            // 
            // TCTotalAmount
            // 
            this.TCTotalAmount.Dpi = 254F;
            this.TCTotalAmount.Name = "TCTotalAmount";
            this.TCTotalAmount.Weight = 0.37656605830396128;
            // 
            // TCTotalTaibiAmount
            // 
            this.TCTotalTaibiAmount.Dpi = 254F;
            this.TCTotalTaibiAmount.Name = "TCTotalTaibiAmount";
            this.TCTotalTaibiAmount.Weight = 0.43735763077689171;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Dpi = 254F;
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Weight = 0.56276096296240918;
            // 
            // TCCusXOId
            // 
            this.TCCusXOId.Dpi = 254F;
            this.TCCusXOId.Name = "TCCusXOId";
            this.TCCusXOId.Weight = 0.28622061084067874;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Dpi = 254F;
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Text = "客戶訂單號";
            this.xrTableCell12.Weight = 0.28622068028620085;
            // 
            // ROHistoryXS
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter});
            this.Dpi = 254F;
            this.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margins = new System.Drawing.Printing.Margins(79, 79, 79, 79);
            this.PageHeight = 2159;
            this.PageWidth = 2794;
            this.PaperKind = System.Drawing.Printing.PaperKind.LetterRotated;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.SnapGridSize = 31.75F;
            this.Version = "10.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel lbl_CompanyName;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel lbl_ReportName;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRLabel lbl_ReportDate;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell10;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell TCInvoiceDate;
        private DevExpress.XtraReports.UI.XRTableCell TCDeclareDate;
        private DevExpress.XtraReports.UI.XRTableCell TCShipMethod;
        private DevExpress.XtraReports.UI.XRTableCell TCXSCustomer;
        private DevExpress.XtraReports.UI.XRTableCell TCInvoiceNO;
        private DevExpress.XtraReports.UI.XRTableCell TCAmount;
        private DevExpress.XtraReports.UI.XRTableCell TCRealAmount;
        private DevExpress.XtraReports.UI.XRTableCell TCExchangeRate;
        private DevExpress.XtraReports.UI.XRTableCell TCTaibiAmount;
        private DevExpress.XtraReports.UI.XRTableCell TCPayTerm;
        private DevExpress.XtraReports.UI.XRTable xrTable3;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell11;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell16;
        private DevExpress.XtraReports.UI.XRTableCell TCTotalAmount;
        private DevExpress.XtraReports.UI.XRTableCell TCTotalTaibiAmount;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell20;
        private DevExpress.XtraReports.UI.XRTableCell TCCusXOId;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell12;
    }
}
