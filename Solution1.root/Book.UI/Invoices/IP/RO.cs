﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;

namespace Book.UI.Invoices.IP
{
    public partial class RO : DevExpress.XtraReports.UI.XtraReport
    {
        public RO(Model.PackingListHeader packingList)
        {
            InitializeComponent();

            this.DataSource = packingList.Details;

            this.lbl_PackingNo.Text = packingList.PackingNo;
            this.lbl_PackingDate.Text = packingList.PackingDate.Value.ToString("yyyy-MM-dd");
            this.lbl_CustomerFullName.Text = packingList.Customer.CustomerFullName;
            this.lbl_address.Text = packingList.Customer.CustomerAddress;
            this.lbl_PerSS.Text = packingList.PerSS;
            this.lbl_SailingDate.Text = packingList.SailingOnOrAbout.Value.ToString("yyyy-MM-dd");
            this.lbl_From.Text = packingList.FromPort.PortName;
            this.lbl_TO.Text = packingList.ToPort.PortName;
            this.lbl_marks.Text = packingList.MarkNos;

            this.lbl_TotalQTY.Text = packingList.Details.Sum(P => P.Quantity).Value.ToString("0.##") + " PCS";
            this.lbl_TotalNetWeight.Text = packingList.Details.Sum(P => P.NetWeight).Value.ToString("0.##") + " KGS";
            this.lbl_TotalGrossWeight.Text = packingList.Details.Sum(P => P.GrossWeight).Value.ToString("0.##") + " KGS";

            TC_PLTNo.DataBindings.Add("Text", this.DataSource, Model.PackingListDetail.PRO_PLTNo);
            TC_CartonNo.DataBindings.Add("Text", this.DataSource, Model.PackingListDetail.PRO_CartonNo);
            TC_PONO.DataBindings.Add("Text", this.DataSource, Model.PackingListDetail.PRO_PONo);
            TC_CUSTNO.DataBindings.Add("Text", this.DataSource, Model.PackingListDetail.PRO_CUSTNO);
            TC_ProductName.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductName);
            TCQTY.DataBindings.Add("Text", this.DataSource, Model.PackingListDetail.PRO_ShowQty);
            TC_NetWeight.DataBindings.Add("Text", this.DataSource, Model.PackingListDetail.PRO_ShowNetWeight);
            TC_GrossWeight.DataBindings.Add("Text", this.DataSource, Model.PackingListDetail.PRO_ShowGrossWeight);

        }

    }
}