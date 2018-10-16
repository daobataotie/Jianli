using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;

namespace Book.UI.Invoices.XO
{
    public partial class ROInvoiceXOlist : DevExpress.XtraReports.UI.XtraReport
    {
        private BL.InvoiceXODetailManager invoicexoDetailManager = new Book.BL.InvoiceXODetailManager();

        public ROInvoiceXOlist()
        {
            InitializeComponent();
        }

        public ROInvoiceXOlist(IList<Model.InvoiceXODetail> Details, DateTime StartDate, DateTime EndDate)
            : this()
        {
            DateTime start = StartDate;
            DateTime end = EndDate;

            this.lblCompanyName.Text = BL.Settings.CompanyChineseName;
            this.lbl_ReportName.Text = "客戶訂單明細表";
            this.lbl_ReportDate.Text += string.Format("{0} ~ {1}", start.ToString("yyyy-MM-dd"), end.ToString("yyyy/MM/dd"));

            this.DataSource = Details;

            this.TCdingdanbianhao.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceId);
            this.TCkhddbh.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_CustomerInvoiceXOId);
            this.TCkh.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_CustomerName);
            this.TCcpxh.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_ProductName);
            this.TCkhxh.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_CustomerProductName);
            this.TCriqi.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceDate, "{0:yy/MM/dd}");
            this.TCyjrq.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceYjrq, "{0:yy/MM/dd}");
            this.TCshuliang.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceXODetailQuantity);
            this.TCInvoiceXODetailBeenQuantity.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceXODetailBeenQuantity);
            this.TCWeichu.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_WeichuQty);

            this.TotalQty.Summary.FormatString = "{0:0.#}";
            this.TotalQty.Summary.Func = SummaryFunc.Sum;
            this.TotalQty.Summary.IgnoreNullValues = true;
            this.TotalQty.Summary.Running = SummaryRunning.Report;
            this.TotalQty.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceXODetailQuantity);

        }
    }
}
