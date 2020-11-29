using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;

namespace Book.UI.Invoices.XO
{
    public partial class RO_New : DevExpress.XtraReports.UI.XtraReport
    {
        private BL.InvoiceXOManager invoiceXOManager = new Book.BL.InvoiceXOManager();
        private BL.InvoiceXODetailManager invoiceXODetailManager = new Book.BL.InvoiceXODetailManager();
        private Model.InvoiceXO invoice;

        public RO_New(string invoiceid)
        {
            InitializeComponent();

            this.invoice = this.invoiceXOManager.Get(invoiceid);

            if (this.invoice == null)
                return;

            this.invoice.Details = this.invoiceXODetailManager.Select(this.invoice, false);
            this.DataSource = this.invoice.Details;

            //CompanyInfo            
            this.xrLabelCompanyInfoName.Text = BL.Settings.CompanyChineseName;
            this.xrLabelData.Text = Properties.Resources.InvoiceXO;
            this.lbl_PrintDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            this.xrLabelCustomName.Text = this.invoice.Customer.CustomerShortName;
            this.lbl_Customer_Id.Text = this.invoice.Customer.Id;
            this.xrLabelInvoiceDate.Text = this.invoice.InvoiceDate.Value.ToString("yyyy-MM-dd");
            this.xrLabelInvoiceId.Text = this.invoice.InvoiceId;
            this.xrLabelEmp.Text += this.invoice.Employee0 == null ? "" : this.invoice.Employee0.EmployeeName;
            this.xrLabel25.Text += this.invoice.AuditEmp == null ? "" : this.invoice.AuditEmp.EmployeeName;
            this.xrLabelNote.Text = this.invoice.InvoiceNote;
            this.xrLabelCustomerXOId.Text = this.invoice.CustomerInvoiceXOId;
            this.xrLabelUnit.Text = this.invoice.Details[0].InvoiceProductUnit;
            this.lbl_Bibie.Text = this.invoice.Currency;

            this.xrLabelCount.Summary.FormatString = "{0:0}";
            this.xrLabelCount.Summary.Func = SummaryFunc.Sum;
            this.xrLabelCount.Summary.IgnoreNullValues = true;
            this.xrLabelCount.Summary.Running = SummaryRunning.Report;
            this.xrLabelCount.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceXODetailQuantity, "{0:0}");

            this.lblTotalJine.Summary.FormatString = "{0:0.##$}";
            this.lblTotalJine.Summary.Func = SummaryFunc.Sum;
            this.lblTotalJine.Summary.IgnoreNullValues = true;
            this.lblTotalJine.Summary.Running = SummaryRunning.Report;
            this.lblTotalJine.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceXODetailMoney, "{0:0}");

            //detail
            this.xrTableCellProductId.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_Inumber);
            this.TCProductId.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_Id);
            this.xrTableCellCustomerProductName.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_CustomerProductName);
            this.TCPrice.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceXODetailPrice, "{0:0.##}");
            this.TCUnit.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceProductUnit, "{0:0}");
            this.TCJinE.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceXODetailMoney, "{0:0.##$}");
            this.xrTableCellQuantity.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceXODetailQuantity);
            this.TCYujiaoriqi.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_YuJiaoRiqi, "{0:yyyy-MM-dd}");
            this.lbl_ProductName.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductName);
            this.lbl_ProductInternalDesc.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_InternalDescription);
            //this.lblRemark.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_Remark);
            this.lblRemark.DataBindings.Add("Rtf", this.DataSource, "Product." + Model.Product.PRO_ProductDescription);
            this.lbl_Note.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_Remark);
            this.lbl_ProductItemNo.DataBindings.Add("Text",this.DataSource,"Product." + Model.Product.PRO_ProductItemNo);
        }
    }
}
