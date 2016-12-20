using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Book.UI.Invoices.CO
{
    public partial class ROenZYD : DevExpress.XtraReports.UI.XtraReport
    {
        private BL.InvoiceCOManager invoiceCGManager = new Book.BL.InvoiceCOManager();
        private BL.InvoiceCODetailManager invoiceCGDetailManager = new Book.BL.InvoiceCODetailManager();
        private BL.InvoiceXOManager invoiceXoManager = new BL.InvoiceXOManager();
        private Model.InvoiceCO invoice;
        int pp = 0;
        public ROenZYD(string invoiceid)
        {
            InitializeComponent();

            this.invoice = this.invoiceCGManager.Get(invoiceid);


            if (this.invoice == null)
                return;

            this.DataSource = this.invoice.Details;

            this.xrBarCode1.Text = this.invoice.InvoiceId;
            this.xrLabelData.Text = "Purchase Order";

            this.xrLabelCustomName.Text = this.invoice.Supplier.SupplierShortName;
            this.xrLabelLianluoName.Text = this.invoice.Supplier.SupplierContact;
            //this.xrLabelCustomTel.Text = string.IsNullOrEmpty(this.invoice.Supplier.SupplierPhone1) ? this.invoice.Supplier.SupplierPhone2 : this.invoice.Supplier.SupplierPhone1;
            this.xrLabelCustomTel.Text = this.invoice.Supplier.Email;  //改Email
            this.lblAddress.Text = this.invoice.Supplier.CompanyAddress;
            //单据信息
            this.xrLabelInvoiceDate.Text = this.invoice.InvoiceDate.Value.ToString("yyyy-MM-dd");
            this.xrLabelYJDate.Text = this.invoice.InvoiceYjrq == null ? "" : this.invoice.InvoiceYjrq.Value.ToString("yyyy-MM-dd");
            this.xrLabel25.Text += this.invoice.AuditEmp == null ? "" : this.invoice.AuditEmp.EmployeeName;
            this.xrLabelYeWuName.Text = this.invoice.Employee0 == null ? "" : this.invoice.Employee0.EmployeeName;
            Model.InvoiceXO temp = this.invoiceXoManager.Get(this.invoice.InvoiceXOId);
            if (temp != null)
            {
                this.xrLabelInvoiceXOId.Text = temp.CustomerInvoiceXOId;

            }

            this.lblTaxrate.Text = this.invoice.InvoiceTaxrate.HasValue ? this.invoice.InvoiceTaxrate.Value.ToString() : "";
            this.lblTax.Text = this.invoice.PrintTax;
            //this.lbl_Total.Text = this.invoice.InvoiceTotal.HasValue ? this.invoice.InvoiceTotal.Value.ToString() : "0";
            this.lbl_Total.Text = this.invoice.PrintAmount;
            this.lblNote.Text = this.invoice.InvoiceNote;
            this.lblShipAddress.Text = BL.Settings.CompanyAddress3;


            //明细信息
            this.xrTableCellProductId.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_Inumber);
            this.xrTableCellProductName.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductName);
            //this.xrTableCellProductGuige.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductSpecification);
            this.xrTableCellQuantity.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_InvoiceProductUnit);
            this.xrTableCellProductUnit.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_OrderQuantity);
            //this.xrTableCellUintPrice.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_InvoiceCODetailPrice, global::Helper.DateTimeParse.GetFormatA(BL.V.SetDataFormat.CGDJXiao.Value));
            this.xrTableCellUintPrice.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_PrintPrice);
            //this.xrTableCellMoney.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_InvoiceCODetailMoney, global::Helper.DateTimeParse.GetFormatA(BL.V.SetDataFormat.CGJEXiao.Value));
            this.xrTableCellMoney.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_PrintMoney);

            this.xrRichTextProductDescription.DataBindings.Add("Rtf", this.DataSource, "Product." + Model.Product.PRO_ProductDescription);
        }

    }
}
