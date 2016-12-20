using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Book.UI.produceManager.PCExportReportANSI
{
    public partial class CSARO : DevExpress.XtraReports.UI.XtraReport
    {
        public CSARO()
        {
            InitializeComponent();
        }

        public CSARO(Model.PCExportReportANSI _PCExportReportANSI, int tag)
            : this()
        {
            if (tag == 1)
            {
                this.xrLabel1.Text = "ALAN    SAFETY    INC.";
            }
            else if (tag == 2)
            {
                this.xrLabel1.Text = "PPE   SAFETY   INC.";
            }
            this.LbCustomer.Text = _PCExportReportANSI.Customer == null ? null : _PCExportReportANSI.Customer.ToString();
            this.LbOrderId.Text = _PCExportReportANSI.InvoiceCusXOId == null ? null : _PCExportReportANSI.InvoiceCusXOId.ToString();
            this.LbProduct.Text = _PCExportReportANSI.Product.CustomerProductName == null ? null : _PCExportReportANSI.Product.CustomerProductName.ToString();
            this.LbOrderAmount.Text = _PCExportReportANSI.Amount.HasValue ? _PCExportReportANSI.Amount.ToString() : "0";
            this.LbTestAmount.Text = _PCExportReportANSI.AmountTest.HasValue ? _PCExportReportANSI.AmountTest.ToString() : "0";
            this.LbTesrPerson.Text = _PCExportReportANSI.Employee == null ? null : _PCExportReportANSI.Employee.ToString();
            this.LbReportDate.Text = _PCExportReportANSI.ReportDate == null ? null : _PCExportReportANSI.ReportDate.Value.ToShortDateString();
            this.LbMirrorlens.Text = _PCExportReportANSI.Mirrorlens == null ? null : _PCExportReportANSI.Mirrorlens.ToString();

            this.LbOpticsTestAmount.Text = _PCExportReportANSI.ShouCeShu1.HasValue ? _PCExportReportANSI.ShouCeShu1.ToString() : "0";
            this.LbClearTestAmount.Text = _PCExportReportANSI.ShouCeShu2.HasValue ? _PCExportReportANSI.ShouCeShu2.ToString() : "0";
            this.LbPolarizedTestAmount.Text = _PCExportReportANSI.ShouCeShu3.HasValue ? _PCExportReportANSI.ShouCeShu3.ToString() : "0";
            this.LbFogTestAmount.Text = _PCExportReportANSI.ShouCeShu4.HasValue ? _PCExportReportANSI.ShouCeShu4.ToString() : "0";
            this.LbLightTestAmount.Text = _PCExportReportANSI.ShouCeShu5.HasValue ? _PCExportReportANSI.ShouCeShu5.ToString() : "0";
            this.LbImpaceTestAmount.Text = _PCExportReportANSI.ShouCeShu6.HasValue ? _PCExportReportANSI.ShouCeShu6.ToString() : "0";

            this.LbOpticsJudge.Text = _PCExportReportANSI.PanDing0.HasValue ? _PCExportReportANSI.PanDing0.ToString() : "0";
            this.LbClearJudge.Text = _PCExportReportANSI.PanDing1.HasValue ? _PCExportReportANSI.PanDing1.ToString() : "0";
            this.LbPolarizedJudge.Text = _PCExportReportANSI.PanDing2.HasValue ? _PCExportReportANSI.PanDing2.ToString() : "0";
            this.LbFogJudge.Text = _PCExportReportANSI.PanDing3.HasValue ? _PCExportReportANSI.PanDing3.ToString() : "0";
            this.LbLightJudge.Text = _PCExportReportANSI.PanDing4.HasValue ? _PCExportReportANSI.PanDing4.ToString() : "0";
            this.LbImpactJudge.Text = _PCExportReportANSI.PanDing5.HasValue ? _PCExportReportANSI.PanDing5.ToString() : "0";
        }
    }
}
