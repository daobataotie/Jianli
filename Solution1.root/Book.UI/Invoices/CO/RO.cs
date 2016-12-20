using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Book.UI.Invoices.CO
{
    public partial class RO : DevExpress.XtraReports.UI.XtraReport
    {
        private Model.InvoiceCO invoice;
        private BL.InvoiceCOManager invoiceCOManager = new Book.BL.InvoiceCOManager();
        private BL.InvoiceXOManager invoiceXOManager = new BL.InvoiceXOManager();
        public RO()
        {
            InitializeComponent();
        }

        public RO(string invoiceid)
            : this()
        {
            this.invoice = this.invoiceCOManager.Get(invoiceid);

            if (this.invoice == null)
                return;

            this.DataSource = this.invoice.Details;
            this.lblSupplierName.Text = this.invoice.Supplier.SupplierFullName;
            this.lblContactperson.Text = this.invoice.Supplier.SupplierContact;
            this.lblContactphone.Text = this.invoice.Supplier.SupplierPhone1;
            this.lblFax.Text = this.invoice.Supplier.SupplierFax;
            this.lblOrderDate.Text = this.invoice.InvoiceDate.HasValue ? this.invoice.InvoiceDate.Value.ToString("yyyy-MM-dd") : "";
            this.lblInvoiceCusXOId.Text = invoice.InvoiceCustomXOId;
            this.lblDeliverydate.Text = invoice.InvoiceYjrq.HasValue ? invoice.InvoiceYjrq.Value.ToString("yyyy-MM-dd") : "";

            //foreach (var item in this.invoice.Details)
            //{
            //    richTextBox1.Rtf = item.Product.ProductDescription;
            //    item.RtfHelp = richTextBox1.Text;
            //}


            this.TCNo.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_Inumber);
            //this.TCProduct.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductName);
            this.lblProductName.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductName);
            this.lblProductDesc.DataBindings.Add("Rtf", this.DataSource, "Product." + Model.Product.PRO_ProductDescription);
            //this.lblProductDesc.DataBindings.Add("Rtf", this.DataSource, Model.InvoiceCODetail.PRO_RtfHelp);
            this.TCQuantity.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_OrderQuantity);
            this.TCUnit.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_InvoiceProductUnit);
            this.TCPrice.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_InvoiceCODetailPrice, "{0:0.00}");
            this.TCAmount.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_InvoiceCODetailMoney, "{0:0.000}");

            this.lblHeji.Text = this.invoice.InvoiceHeji.HasValue ? this.invoice.InvoiceHeji.Value.ToString("0.000") : "0.000";
            this.lblTax.Text = this.invoice.InvoiceTax.HasValue ? this.invoice.InvoiceTax.Value.ToString("0.000") : "0.000";
            this.lblTotal.Text = this.invoice.InvoiceTotal.HasValue ? this.invoice.InvoiceTotal.Value.ToString("0.000") : "0.000";

            this.lblNote.Text = this.invoice.InvoiceNote;
            this.lblEmoloyee.Text = this.invoice.Employee0 == null ? "" : this.invoice.Employee0.EmployeeName;
        }

    }
}
