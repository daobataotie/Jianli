﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;

namespace Book.UI.Invoices.IP
{
    public partial class ROInvoice : DevExpress.XtraReports.UI.XtraReport
    {
        public ROInvoice(Model.PackingInvoiceHeader invoiceList)
        {
            InitializeComponent();

            this.DataSource = invoiceList.Details;

            this.lbl_PackingNo.Text = invoiceList.InvoiceNo;
            this.lbl_PackingDate.Text = invoiceList.InvoiceDate.Value.ToString("yyyy-MM-dd");
            //this.lbl_CustomerFullName.Text = invoiceList.Customer.CustomerFullName;
            //this.lbl_address.Text = invoiceList.Customer.CustomerAddress;
            this.lbl_CustomerFullName.Text = invoiceList.CustomerFullName;
            this.lbl_address.Text = invoiceList.CustomerAddress;
            this.lbl_PayCondition.Text = invoiceList.TradingCondition;
            this.lbl_PerSS.Text = invoiceList.PerSS;
            this.lbl_SailingDate.Text = invoiceList.SailingOnOrAbout.Value.ToString("yyyy-MM-dd");
            this.lbl_From.Text = invoiceList.FromPort.PortName;
            this.lbl_TO.Text = invoiceList.ToPort.PortName;
            this.lbl_marks.Text = invoiceList.MarkNos;

            this.lbl_TotalQTY.Text = invoiceList.Details.Sum(P => P.Quantity).Value.ToString("0.##") + " PCS";

            if (invoiceList.Details != null && invoiceList.Details.Count > 0)
            {
                string currency = new BL.InvoiceXOManager().GetCurrencyByInvoiceId(invoiceList.Details[0].InvoiceXODetail.InvoiceId);
                this.lbl_TotalAmount.Text = Model.ExchangeRate.GetCurrencyENName(currency) + " " + invoiceList.Details.Sum(P => P.Amount).Value.ToString("0.00");
            }

            TC_No.DataBindings.Add("Text", this.DataSource, Model.PackingInvoiceDetail.PRO_Number);
            TC_PONO.DataBindings.Add("Text", this.DataSource, Model.PackingInvoiceDetail.PRO_PONo);
            //TC_CUSTNO.DataBindings.Add("Text", this.DataSource, Model.PackingInvoiceDetail.PRO_CUSTNO);
            //TC_ProductName.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductName);
            TC_CUSTNO.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_CustomerProductName);
            TC_ProductName.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductName);
            TCQTY.DataBindings.Add("Text", this.DataSource, Model.PackingInvoiceDetail.PRO_ShowQty);
            TC_UnitPrice.DataBindings.Add("Text", this.DataSource, Model.PackingInvoiceDetail.PRO_UnitPrice, "{0:0.00}");
            TC_Amount.DataBindings.Add("Text", this.DataSource, Model.PackingInvoiceDetail.PRO_Amount, "{0:0.00}");
        }
    }
}
