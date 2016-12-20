using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;

namespace Book.UI.Invoices.CO
{
    public partial class ROSub : DevExpress.XtraReports.UI.XtraReport
    {
        public ROSub()
        {
            InitializeComponent();
        }

        public ROSub(IList<Model.InvoiceCODetail> list)
            : this()
        {
            this.DataSource = list;

            this.TCNo.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_Inumber);
            //this.TCProduct.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductName);
            this.lblProductName.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductName);
            this.lblProductDesc.DataBindings.Add("Rtf", this.DataSource, "Product." + Model.Product.PRO_ProductDescription);
            this.TCQuantity.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_OrderQuantity);
            this.TCUnit.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_InvoiceProductUnit);
            this.TCPrice.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_InvoiceCODetailPrice, "{0:0.00}");
            this.TCAmount.DataBindings.Add("Text", this.DataSource, Model.InvoiceCODetail.PRO_InvoiceCODetailMoney, "{0:0.000}");

        }
    }
}
