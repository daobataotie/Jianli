using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Book.UI.Settings.BasicData.Customs
{
    public partial class ROCustomer : DevExpress.XtraReports.UI.XtraReport
    {
        protected BL.CompanyLevelManager companyLevelManager = new Book.BL.CompanyLevelManager();
        public ROCustomer()
        {
            InitializeComponent();
        }

        public ROCustomer(Model.Customer customer)
            : this()
        {
            this.lblCompanyName.Text = BL.Settings.CompanyChineseName;
            this.lblReportName.Text = "客戶基本資料";

            this.lblCustomerNumber.Text = customer.CustomerNumber;
            this.lblId.Text = customer.Id;
            this.lblCustomerFullName.Text = customer.CustomerFullName;
            this.lblCustomerShortName.Text = customer.CustomerShortName;

            Model.CompanyLevel level = this.companyLevelManager.Get(customer.CompanyLevelId);
            if (level != null)
            {
                this.lblCustomerLevel.Text = level.CompanyLevelId + @"-" + level.CompanyLevelName;
            }
            this.lblCustomerPhone.Text = customer.CustomerPhone;
            this.lblCustomerPhone1.Text = customer.CustomerPhone1;
            this.lblCustomerFax.Text = customer.CustomerFax;
            this.lblCustomerMobile.Text = customer.CustomerMobile;
            this.lblCustomerPayDate.Text = customer.CustomerPayDate.HasValue ? customer.CustomerPayDate.ToString() : "";
            this.lblCustomerContact.Text = customer.CustomerContact;
            this.lblCustomerManager.Text = customer.CustomerManager;
            this.lblCustomerEMail.Text = customer.CustomerEMail;
            this.lblLastTransactionDate.Text = customer.LastTransactionDate.HasValue ? customer.LastTransactionDate.Value.ToString("yyyy-MM-dd") : "";
            this.lblCustomerAddress.Text = customer.CustomerAddress;
            this.lblCustomerJinChuAddress.Text = customer.CustomerJinChuAddress;
            this.lblCustomerWebSiteAddress.Text = customer.CustomerWebSiteAddress;
            this.lblCheckedStandard.Text=customer.CheckedStandard;
            this.lblCustomerFP.Text = customer.CustomerFP;
            this.lblCustomerDescription.Rtf = customer.CustomerDescription;
        }

    }
}
