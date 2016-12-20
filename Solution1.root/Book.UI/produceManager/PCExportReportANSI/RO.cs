using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Book.UI.produceManager.PCExportReportANSI
{
    public partial class RO : DevExpress.XtraReports.UI.XtraReport
    {
        public RO()
        {
            InitializeComponent();
        }

        public RO(Model.PCExportReportANSI _PCExpANSI, int tag)
            : this()
        {
            if (tag == 1)
            {
                this.lblCompanyName.Text = "ALAN    SAFETY    INC.";
            }
            else if (tag == 2)
            {
                this.lblCompanyName.Text = "PPE   SAFETY   INC.";
            }
            this.lblCeShiBaoGaoRiQi.Text = _PCExpANSI.ReportDate.Value.ToShortDateString();           
            this.lblCeShiShuLiang.Text = _PCExpANSI.AmountTest.HasValue ? _PCExpANSI.AmountTest.ToString() : "0";
            this.lblChanpingpingming.Text = _PCExpANSI.Product.CustomerProductName == null ? "" : _PCExpANSI.Product.CustomerProductName.ToString();
            this.lblDingDanBianHao.Text = _PCExpANSI.InvoiceCusXOId;
            this.lblDingDanShuLiang.Text = _PCExpANSI.Amount.HasValue ? _PCExpANSI.Amount.ToString() : "0";
            this.lblKehu.Text = _PCExpANSI.Customer == null ? "" : _PCExpANSI.Customer.ToString();
            this.lblZhiXingCeShiYuan.Text = _PCExpANSI.Employee == null ? "" : _PCExpANSI.Employee.ToString();

            this.xrTableCell6.Text = _PCExpANSI.Criteria3;

            this.lblPanDing0.Text = _PCExpANSI.PanDing0.HasValue ? _PCExpANSI.PanDing0.ToString() : "0";
            this.lblPanDing1.Text = _PCExpANSI.PanDing1.HasValue ? _PCExpANSI.PanDing1.ToString() : "0";
            this.lblPanDing2.Text = _PCExpANSI.PanDing2.HasValue ? _PCExpANSI.PanDing2.ToString() : "0";
            this.lblPanDing3.Text = _PCExpANSI.PanDing3.HasValue ? _PCExpANSI.PanDing3.ToString() : "0";
            this.lblPanDing4.Text = _PCExpANSI.PanDing4.HasValue ? _PCExpANSI.PanDing4.ToString() : "0";
            this.lblPanDing5.Text = _PCExpANSI.PanDing5.HasValue ? _PCExpANSI.PanDing5.ToString() : "0";
            this.lblPanDing6.Text = _PCExpANSI.PanDing6.HasValue ? _PCExpANSI.PanDing6.ToString() : "0";
            this.lblPanDing7.Text = _PCExpANSI.PanDing7.HasValue ? _PCExpANSI.PanDing7.ToString() : "0";
            this.lblPanDing8.Text = _PCExpANSI.PanDing8.HasValue ? _PCExpANSI.PanDing8.ToString() : "0";
            this.lblPanDing9.Text = _PCExpANSI.PanDing9.HasValue ? _PCExpANSI.PanDing9.ToString() : "0";
            this.lblPanDing10.Text = _PCExpANSI.PanDing10.HasValue ? _PCExpANSI.PanDing10.ToString() : "0";
            this.lblPanDing11.Text = _PCExpANSI.PanDing11.HasValue ? _PCExpANSI.PanDing11.ToString() : "0";


            this.lblQuYangShu1.Text = _PCExpANSI.QuYangShu1.HasValue ? _PCExpANSI.QuYangShu1.ToString() : "0";
            this.lblQuYangShu2.Text = _PCExpANSI.QuYangShu2.HasValue ? _PCExpANSI.QuYangShu2.ToString() : "0";
            this.lblQuYangShu3.Text = _PCExpANSI.QuYangShu3.HasValue ? _PCExpANSI.QuYangShu3.ToString() : "0";
            this.lblQuYangShu4.Text = _PCExpANSI.QuYangShu4.HasValue ? _PCExpANSI.QuYangShu4.ToString() : "0";
            this.lblQuYangShu5.Text = _PCExpANSI.QuYangShu5.HasValue ? _PCExpANSI.QuYangShu5.ToString() : "0";
            this.lblQuYangShu6.Text = _PCExpANSI.QuYangShu6.HasValue ? _PCExpANSI.QuYangShu6.ToString() : "0";
            this.lblQuYangShu7.Text = _PCExpANSI.QuYangShu7.HasValue ? _PCExpANSI.QuYangShu7.ToString() : "0";
            this.lblQuYangShu8.Text = _PCExpANSI.QuYangShu8.HasValue ? _PCExpANSI.QuYangShu8.ToString() : "0";
            this.lblQuYangShu9.Text = _PCExpANSI.QuYangShu9.HasValue ? _PCExpANSI.QuYangShu9.ToString() : "0";
            this.lblQuYangShu10.Text = _PCExpANSI.QuYangShu10.HasValue ? _PCExpANSI.QuYangShu10.ToString() : "0";
            this.lblQuYangShu11.Text = _PCExpANSI.QuYangShu11.HasValue ? _PCExpANSI.QuYangShu11.ToString() : "0";

            this.lblShouCeShu1.Text = _PCExpANSI.ShouCeShu1.HasValue ? _PCExpANSI.ShouCeShu1.ToString() : "0";
            this.lblShouCeShu2.Text = _PCExpANSI.ShouCeShu2.HasValue ? _PCExpANSI.ShouCeShu2.ToString() : "0";
            this.lblShouCeShu3.Text = _PCExpANSI.ShouCeShu3.HasValue ? _PCExpANSI.ShouCeShu3.ToString() : "0";
            this.lblShouCeShu4.Text = _PCExpANSI.ShouCeShu4.HasValue ? _PCExpANSI.ShouCeShu4.ToString() : "0";
            this.lblShouCeShu5.Text = _PCExpANSI.ShouCeShu5.HasValue ? _PCExpANSI.ShouCeShu5.ToString() : "0";
            this.lblShouCeShu6.Text = _PCExpANSI.ShouCeShu6.HasValue ? _PCExpANSI.ShouCeShu6.ToString() : "0";
            this.lblShouCeShu7.Text = _PCExpANSI.ShouCeShu7.HasValue ? _PCExpANSI.ShouCeShu7.ToString() : "0";
            this.lblShouCeShu8.Text = _PCExpANSI.ShouCeShu8.HasValue ? _PCExpANSI.ShouCeShu8.ToString() : "0";
            this.lblShouCeShu9.Text = _PCExpANSI.ShouCeShu9.HasValue ? _PCExpANSI.ShouCeShu9.ToString() : "0";
            this.lblShouCeShu10.Text = _PCExpANSI.ShouCeShu10.HasValue ? _PCExpANSI.ShouCeShu10.ToString() : "0";
            this.lblShouCeShu11.Text = _PCExpANSI.ShouCeShu11.HasValue ? _PCExpANSI.ShouCeShu11.ToString() : "0";
        }
    }
}
