using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Book.UI.Invoices.XS
{
    public partial class R0_ZZD_NoPrice : DevExpress.XtraReports.UI.XtraReport
    {
        private BL.InvoiceXSManager InvoiceXSManager = new Book.BL.InvoiceXSManager();
        private BL.InvoiceXSDetailManager InvoiceXSDetailManager = new Book.BL.InvoiceXSDetailManager();

        private Model.InvoiceXS invoice;

        public R0_ZZD_NoPrice(string invoiceid)
        {
            InitializeComponent();

            this.invoice = this.InvoiceXSManager.Get(invoiceid);
            if (invoice == null)
                return;

            this.invoice.Details = this.InvoiceXSDetailManager.Select(this.invoice);

            this.DataSource = this.invoice.Details;

            //CompanyInfo
            this.xrLabelCompanyInfoName.Text = BL.Settings.CompanyChineseName;
            this.xrLabelData.Text = Properties.Resources.InvoiceXS;
            //客户信息
            this.xrLabelCustomer.Text = this.invoice.Customer.CustomerShortName + "(" + this.invoice.Customer.Id + ")";
            this.xrLabelCustomName.Text = this.invoice.XSCustomer == null ? "" : (this.invoice.XSCustomer.CustomerShortName + "(" + this.invoice.XSCustomer.Id + ")");
            this.xrLabelCustomFax.Text = this.invoice.XSCustomer == null ? "" : this.invoice.XSCustomer.CustomerFax;
            this.xrLabelCustomTel.Text = this.invoice.XSCustomer == null ? "" : string.IsNullOrEmpty(this.invoice.XSCustomer.CustomerPhone) ? this.invoice.Customer.CustomerPhone1 : this.invoice.Customer.CustomerPhone;
            this.xrLabelTongYiNo.Text = this.invoice.XSCustomer == null ? "" : this.invoice.XSCustomer.CustomerNumber;
            this.xrLabelSongHuoAddress.Text = this.invoice.XSCustomer == null ? "" : this.invoice.XSCustomer.CustomerJinChuAddress;
            this.xrLabelLianluoName.Text = this.invoice.XSCustomer == null ? "" : this.invoice.XSCustomer.CustomerContact;

            //单据信息
            this.xrLabelInvoiceDate.Text = this.invoice.InvoiceDate.Value.ToString("yyyy-MM-dd");
            this.xrLabelInvoiceId.Text = this.invoice.InvoiceId;
            this.xrLabelYeWuName.Text = this.invoice.Employee0.EmployeeName;
            this.xrLabel25.Text += this.invoice.AuditEmp == null ? "" : this.invoice.AuditEmp.EmployeeName;
            this.xrLabelNote.Text = this.invoice.InvoiceNote;
            this.xrLabelFreightWay.Text = this.invoice.ConveyanceMethod == null ? null : this.invoice.ConveyanceMethod.ToString();

            this.lbl_FapiaoFangshi.Text = this.invoice.FapiaoFangshi;
            this.lbl_FapiaoLianshi.Text = this.invoice.FapiaoLianshi;
            if (this.invoice.TaxCaluType.HasValue)
            {
                if (this.invoice.TaxCaluType.Value == 0)
                    this.lbl_TaxType.Text += "免稅";
                else if (this.invoice.TaxCaluType.Value == 1)
                    this.lbl_TaxType.Text += "外加";
                else
                    this.lbl_TaxType.Text += "內含";
            }
            this.lbl_TaxRate.Text += this.invoice.InvoiceTaxrate.HasValue ? this.invoice.InvoiceTaxrate.Value.ToString() + "%" : "";

            //明细信息
            this.xrTableCellProductId.DataBindings.Add("Text", this.DataSource, Model.InvoiceXSDetail.PRO_Inumber);
            this.TCProductId.DataBindings.Add("Text", this.dataBrowser, "Product." + Model.Product.PRO_Id);
            this.xrTableCellCusPro.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_CustomerProductName);
            this.xrTableQuantity.DataBindings.Add("Text", this.DataSource, Model.InvoiceXSDetail.PRO_InvoiceXSDetailQuantity);
            this.xrTableUnit.DataBindings.Add("Text", this.DataSource, Model.InvoiceXSDetail.PRO_InvoiceProductUnit);
            //this.xrTableDesc.DataBindings.Add("Text", this.DataSource, Model.InvoiceXSDetail.PRO_InvoiceXSDetailNote);

            this.TCCurrency.DataBindings.Add("Text", this.DataSource, Model.InvoiceXSDetail.PRO_CurrencyEN);
            this.lblDetailNote.DataBindings.Add("Text", this.DataSource, Model.InvoiceXSDetail.PRO_InvoiceXSDetailNote);
        }
    }
}
