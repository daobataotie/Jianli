using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace Book.UI.Query
{
    public partial class ROInvoiceXSlistBiaoNewSub : DevExpress.XtraReports.UI.XtraReport
    {
        public DataTable dt = null;

        public ROInvoiceXSlistBiaoNewSub()
        {
            InitializeComponent();

            this.tcCHDH.DataBindings.Add("Text", this.DataSource, "CHDH");
            this.tcCHRQ.DataBindings.Add("Text", this.DataSource, "CHRQ", "{0:yyyy-MM-dd}");
            this.tcProductName.DataBindings.Add("Text", this.DataSource, "ProductName");
            this.tcKHDDBH.DataBindings.Add("Text", this.DataSource, "KHDDBH");
            this.tcBCCHSL.DataBindings.Add("Text", this.DataSource, "BCCHSL", global::Helper.DateTimeParse.GetFormatA(BL.V.SetDataFormat.XSSLXiao.Value));
            this.tcDW.DataBindings.Add("Text", this.DataSource, "DanWei");
            this.tcDJ.DataBindings.Add("Text", this.DataSource, "DanJia", global::Helper.DateTimeParse.GetFormatA(BL.V.SetDataFormat.CGDJXiao.Value));
            this.tcZheRang.DataBindings.Add("Text", this.DataSource, "ZheRang", global::Helper.DateTimeParse.GetFormatA(BL.V.SetDataFormat.CGJEXiao.Value));
            this.tcJinE.DataBindings.Add("Text", this.DataSource, "JinE");
            this.tcShuiE.DataBindings.Add("Text", this.DataSource, "ShuiE", "{0:0}");
            this.tcYingShou.DataBindings.Add("Text", this.DataSource, "YingShou", global::Helper.DateTimeParse.GetFormatA(BL.V.SetDataFormat.CGDJXiao.Value));

            this.TCCurrency.DataBindings.Add("Text", this.DataSource, "Currency");
            this.TCCurrencyTotal.DataBindings.Add("Text", this.DataSource, "TaibiTotal", global::Helper.DateTimeParse.GetFormatA(BL.V.SetDataFormat.CGDJXiao.Value));


            this.TCZHeJi.Summary.FormatString = "{0:0}";
            this.TCZHeJi.Summary.Func = SummaryFunc.Sum;
            this.TCZHeJi.Summary.IgnoreNullValues = true;
            this.TCZHeJi.Summary.Running = SummaryRunning.Report;
            this.TCZHeJi.DataBindings.Add("Text", this.DataSource, "JinE");

            this.TCZShuiE.Summary.FormatString = "{0:0}";
            this.TCZShuiE.Summary.Func = SummaryFunc.Sum;
            this.TCZShuiE.Summary.IgnoreNullValues = true;
            this.TCZShuiE.Summary.Running = SummaryRunning.Report;
            this.TCZShuiE.DataBindings.Add("Text", this.DataSource, "ShuiE");

            this.TCZZongJi.Summary.FormatString = "{0:0}";
            this.TCZZongJi.Summary.Func = SummaryFunc.Sum;
            this.TCZZongJi.Summary.IgnoreNullValues = true;
            this.TCZZongJi.Summary.Running = SummaryRunning.Report;
            this.TCZZongJi.DataBindings.Add("Text", this.DataSource, "YingShou");


            this.lbTaibiTotal.Summary.FormatString = "{0:0}";
            this.lbTaibiTotal.Summary.Func = SummaryFunc.Sum;
            this.lbTaibiTotal.Summary.IgnoreNullValues = true;
            this.lbTaibiTotal.Summary.Running = SummaryRunning.Report;
            this.lbTaibiTotal.DataBindings.Add("Text", this.DataSource, "TaibiTotal");
        }

        private void ROInvoiceXSlistBiaoNewSub_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.DataSource = dt;
            this.lblCustomerName.Text = dt.Rows[0]["CustomerFullName"].ToString();
        }

    }
}
