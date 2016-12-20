namespace Book.UI.Invoices.CO
{
    partial class ROSub
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ROSub));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.TCNo = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblProductName = new DevExpress.XtraReports.UI.XRLabel();
            this.lblProductDesc = new DevExpress.XtraReports.UI.XRRichText();
            this.TCQuantity = new DevExpress.XtraReports.UI.XRTableCell();
            this.TCUnit = new DevExpress.XtraReports.UI.XRTableCell();
            this.TCPrice = new DevExpress.XtraReports.UI.XRTableCell();
            this.TCAmount = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProductDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.Detail.Dpi = 254F;
            this.Detail.HeightF = 110F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 80F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 80F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTable1.Dpi = 254F;
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(11, 10, 0, 0, 254F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1993.229F, 110F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UsePadding = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.TCNo,
            this.xrTableCell2,
            this.TCQuantity,
            this.TCUnit,
            this.TCPrice,
            this.TCAmount});
            this.xrTableRow1.Dpi = 254F;
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.StylePriority.UseBorders = false;
            this.xrTableRow1.Weight = 1.1;
            // 
            // TCNo
            // 
            this.TCNo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TCNo.Dpi = 254F;
            this.TCNo.Name = "TCNo";
            this.TCNo.Padding = new DevExpress.XtraPrinting.PaddingInfo(11, 11, 10, 0, 254F);
            this.TCNo.StylePriority.UseBorders = false;
            this.TCNo.StylePriority.UsePadding = false;
            this.TCNo.StylePriority.UseTextAlignment = false;
            this.TCNo.Text = "序号";
            this.TCNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.TCNo.Weight = 0.23514611058753052;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblProductName,
            this.lblProductDesc});
            this.xrTableCell2.Dpi = 254F;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseBorders = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "品名规格";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell2.Weight = 1.5430560053443552;
            // 
            // lblProductName
            // 
            this.lblProductName.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblProductName.Dpi = 254F;
            this.lblProductName.LocationFloat = new DevExpress.Utils.PointFloat(3.051758E-05F, 0F);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 254F);
            this.lblProductName.SizeF = new System.Drawing.SizeF(1022.028F, 55F);
            this.lblProductName.StylePriority.UseBorders = false;
            this.lblProductName.StylePriority.UsePadding = false;
            this.lblProductName.Text = "lblProductName";
            // 
            // lblProductDesc
            // 
            this.lblProductDesc.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblProductDesc.Dpi = 254F;
            this.lblProductDesc.LocationFloat = new DevExpress.Utils.PointFloat(0.003494263F, 55.00012F);
            this.lblProductDesc.Name = "lblProductDesc";
            this.lblProductDesc.SerializableRtfString = resources.GetString("lblProductDesc.SerializableRtfString");
            this.lblProductDesc.SizeF = new System.Drawing.SizeF(1022.025F, 54.99988F);
            this.lblProductDesc.StylePriority.UseBorders = false;
            // 
            // TCQuantity
            // 
            this.TCQuantity.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TCQuantity.Dpi = 254F;
            this.TCQuantity.Name = "TCQuantity";
            this.TCQuantity.Padding = new DevExpress.XtraPrinting.PaddingInfo(11, 11, 10, 0, 254F);
            this.TCQuantity.StylePriority.UseBorders = false;
            this.TCQuantity.StylePriority.UsePadding = false;
            this.TCQuantity.StylePriority.UseTextAlignment = false;
            this.TCQuantity.Text = "数量";
            this.TCQuantity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.TCQuantity.Weight = 0.30817990658922312;
            // 
            // TCUnit
            // 
            this.TCUnit.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TCUnit.Dpi = 254F;
            this.TCUnit.Name = "TCUnit";
            this.TCUnit.Padding = new DevExpress.XtraPrinting.PaddingInfo(11, 11, 10, 0, 254F);
            this.TCUnit.StylePriority.UseBorders = false;
            this.TCUnit.StylePriority.UsePadding = false;
            this.TCUnit.StylePriority.UseTextAlignment = false;
            this.TCUnit.Text = "单位";
            this.TCUnit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.TCUnit.Weight = 0.26875803018550426;
            // 
            // TCPrice
            // 
            this.TCPrice.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TCPrice.Dpi = 254F;
            this.TCPrice.Name = "TCPrice";
            this.TCPrice.Padding = new DevExpress.XtraPrinting.PaddingInfo(11, 11, 10, 0, 254F);
            this.TCPrice.StylePriority.UseBorders = false;
            this.TCPrice.StylePriority.UsePadding = false;
            this.TCPrice.StylePriority.UseTextAlignment = false;
            this.TCPrice.Text = "单价";
            this.TCPrice.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.TCPrice.Weight = 0.30317390230975116;
            // 
            // TCAmount
            // 
            this.TCAmount.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TCAmount.Dpi = 254F;
            this.TCAmount.Name = "TCAmount";
            this.TCAmount.Padding = new DevExpress.XtraPrinting.PaddingInfo(11, 11, 10, 0, 254F);
            this.TCAmount.StylePriority.UseBorders = false;
            this.TCAmount.StylePriority.UsePadding = false;
            this.TCAmount.StylePriority.UseTextAlignment = false;
            this.TCAmount.Text = "金额";
            this.TCAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.TCAmount.Weight = 0.35105871948727135;
            // 
            // ROSub
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Dpi = 254F;
            this.Font = new System.Drawing.Font("新細明體-ExtB", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(80, 80, 80, 80);
            this.PageHeight = 2794;
            this.PageWidth = 2159;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.SnapGridSize = 31.75F;
            this.Version = "10.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProductDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell TCNo;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRLabel lblProductName;
        private DevExpress.XtraReports.UI.XRRichText lblProductDesc;
        private DevExpress.XtraReports.UI.XRTableCell TCQuantity;
        private DevExpress.XtraReports.UI.XRTableCell TCUnit;
        private DevExpress.XtraReports.UI.XRTableCell TCPrice;
        private DevExpress.XtraReports.UI.XRTableCell TCAmount;
    }
}
