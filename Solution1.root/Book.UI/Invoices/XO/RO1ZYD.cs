using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Book.UI.Invoices.XO
{
    public partial class RO1ZYD : DevExpress.XtraReports.UI.XtraReport
    {
        private BL.InvoiceXOManager invoiceXOManager = new Book.BL.InvoiceXOManager();
        private BL.InvoiceXODetailManager invoiceXODetailManager = new Book.BL.InvoiceXODetailManager();
        private Model.InvoiceXO invoice;
        int pp = 0;
        public RO1ZYD(string invoiceid)
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
            this.xrLabelPrintDate.Text += DateTime.Now.ToShortDateString();

            //客户信息
            this.xrLabelCustomName.Text = this.invoice.Customer.CustomerShortName;
            this.lbl_Customer_Id.Text = this.invoice.Customer.Id;
            this.xrLabelCustomerXOId.Text = this.invoice.CustomerInvoiceXOId;
            this.lbl_XOCustomer_Id.Text = this.invoice.xocustomer.Id;
            this.xrLabelXScustomer.Text = this.invoice.xocustomer.CustomerShortName;
            //this.xrLabelCustomFax.Text = this.invoice.Customer.CustomerFax;
            //this.xrLabelCustomTel.Text = string.IsNullOrEmpty(this.invoice.Customer.CustomerPhone) ? this.invoice.Customer.CustomerPhone1 : this.invoice.Customer.CustomerPhone;
            //this.xrLabelTongYiNo.Text = this.invoice.Customer.CustomerNumber;
            //this.xrLabelPiHao.Text = this.invoice.CustomerLotNumber;

            //单据信息
            this.xrLabelInvoiceDate.Text = this.invoice.InvoiceDate.Value.ToString("yyyy-MM-dd");
            this.xrLabelInvoiceId.Text = this.invoice.InvoiceId;
            //this.xrLabelEmp.Text += this.invoice.Employee0 == null ? "" : this.invoice.Employee0.EmployeeName;
            //this.xrLabel25.Text += this.invoice.AuditEmp == null ? "" : this.invoice.AuditEmp.EmployeeName;
            this.xrLabelNote.Text = this.invoice.InvoiceNote;
            this.xrLabelYJRQ.Text = this.invoice.InvoiceYjrq.Value.ToString("yyyy-MM-dd");
            this.xrLabelUnit.Text = this.invoice.Details[0].InvoiceProductUnit;
            this.lbl_Employee.Text = this.invoice.Employee0.ToString();
            //this.xrLabeJianCe.Text = this.invoice.xocustomer.CheckedStandard;
            //foreach (Model.InvoiceXODetail invoicedetail in invoice.Details)
            //{
            //    this.lblRemark.Text = invoicedetail.Remark;
            //}

            this.xrLabelCount.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceXODetailQuantity);
            //明细信息
            //this.xrTableCellCustomerProductId.DataBindings.Add("Text", this.DataSource, "PrimaryKey." + Model.CustomerProducts.PROPERTY_CUSTOMERPRODUCTID);
            //this.xrTableCellProductName.DataBindings.Add("Text", this.DataSource, "PrimaryKey." + Model.CustomerProducts.PROPERTY_CUSTOMERPRODUCTNAME);
            // this.xrTableCellXinghao.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductSpecification);
            //this.xrTableCellCustomerProductName.DataBindings.Add("Text", this.DataSource, "PrimaryKey.Product." + Model.Product.PRO_Id);
            //this.xrTableCellProductUnit.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PROPERTY_INVOICEPRODUCTUNIT);
            //this.xrTableCellQuantity.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PROPERTY_INVOICEXODETAILQUANTITY);  
            this.TCYujiaoRiqi.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_YuJiaoRiqi, "{0:yyyy-MM-dd}");
            this.TCNumber.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_Inumber);
            this.xrTableCellProductName.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductName);
            this.TCProductId.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_Id);
            //this.xrTableCellXinghao.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductSpecification);
            this.xrTableCellCustomerProductName.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_CustomerProductName);
            this.xrTableCellQuantity.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceProductUnit);
            this.xrTableCellProductUnit.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceXODetailQuantity);

            //this.lblRemark.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_Remark);
            this.lblRemark.DataBindings.Add("Rtf", this.DataSource, "Product." + Model.Product.PRO_ProductDescription);
            this.lbl_Note.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_Remark);
            this.lbl_ProductInternalDesc.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_InternalDescription);
        }

    }
}
