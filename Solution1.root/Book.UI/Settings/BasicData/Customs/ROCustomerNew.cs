using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Book.UI.Settings.BasicData.Customs
{
    public partial class ROCustomerNew : DevExpress.XtraReports.UI.XtraReport
    {
        public ROCustomerNew(Model.Customer customer)
        {
            InitializeComponent();

            this.TCCustomerId.Text = customer.Id;
            this.TCArea.Text = customer.AreaCategory == null ? "" : customer.AreaCategory.AreaCategoryName;
            this.TCShotName.Text = customer.CustomerShortName;
            this.TCFullName.Text = customer.CustomerFullName;
            this.TCTongyibianhao.Text = customer.CustomerNumber;
            this.TCCustomerManager.Text = customer.CustomerManager;
            this.TCTel.Text = customer.CustomerPhone;
            this.TCFax.Text = customer.CustomerFax;
            this.TCAddress.Text = customer.CustomerAddress;
            this.TCDeliveryAddress.Text = customer.CustomerJinChuAddress;
            this.TCPayDate.Text = customer.CustomerPayDate.HasValue ? customer.CustomerPayDate.ToString() : "";
            this.TCTradingCondition.Text = customer.TradingCondition;
            this.TCPayCondition.Text = customer.PayCondition;
            this.TCCustomerContact.Text = customer.CustomerContact;
            this.TCEmail.Text = customer.CustomerEMail;
            this.TCWebSite.Text = customer.CustomerWebSiteAddress;

            if (customer.CustomerDescription != null)
                this.xrRichTextDesc.Rtf = customer.CustomerDescription;
            if (customer.Marks1 != null)
                this.xrRichTextMark1.Rtf = customer.Marks1;
            if (customer.Marks2 != null)
                this.xrRichTextMark2.Rtf = customer.Marks2;
            if (customer.Marks3 != null)
                this.xrRichTextMark3.Rtf = customer.Marks3;
        }
    }
}
