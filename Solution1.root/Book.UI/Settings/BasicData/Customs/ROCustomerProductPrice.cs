using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;

namespace Book.UI.Settings.BasicData.Customs
{
    public partial class ROCustomerProductPrice : DevExpress.XtraReports.UI.XtraReport
    {
        public ROCustomerProductPrice()
        {
            InitializeComponent();
        }

        public ROCustomerProductPrice(string CustomerName, List<Model.CustomerProductPrice> list)
            : this()
        {
            this.lblCompany.Text = BL.Settings.CompanyChineseName;
            this.lblCustomer.Text = CustomerName;
            this.lblReportDate.Text += DateTime.Now.ToString("yyyy-MM-dd");

            foreach (var item in list)
            {
                if (!string.IsNullOrEmpty(item.CustomerProductPriceRage))
                {
                    //if (item.CustomerProductPriceRage.Contains("/"))
                    //{
                    //    item.Price = item.CustomerProductPriceRage.Substring(0, item.CustomerProductPriceRage.LastIndexOf('/'));
                    //    if (!string.IsNullOrEmpty(item.Price) && item.Price.Contains("/"))
                    //        item.Price = item.Price.Substring(item.Price.LastIndexOf('/') + 1);
                    //}
                    if (item.CustomerProductPriceRage.Contains(","))
                    {
                        string[] str = item.CustomerProductPriceRage.Split(',');
                        item.Price = "";
                        foreach (var s in str)
                        {
                            if (!string.IsNullOrEmpty(s))
                            {
                                item.Price += s + "\r";
                            }
                        }
                    }
                    else
                        item.Price = item.CustomerProductPriceRage;
                    item.Price = item.Price.Replace("999999999999", "無限大");
                }
            }

            this.DataSource = list;

            this.TCProductId.DataBindings.Add("Text", this.DataSource, "ProductIDNo");
            this.TCProductName.DataBindings.Add("Text", this.DataSource, "ProductName");
            this.TCCustomerProduct.DataBindings.Add("Text", this.DataSource, "CustomerProductId");
            this.TCProductVersion.DataBindings.Add("Text", this.DataSource, "ProductVersion");
            //this.TCProductDesc.DataBindings.Add("Text", this.DataSource, "ProductDesc");
            this.TCPrice.DataBindings.Add("Text", this.DataSource, "Price");
            this.xrRichText1.DataBindings.Add("Rtf", this.DataSource, "ProductDesc");
        }
    }
}
