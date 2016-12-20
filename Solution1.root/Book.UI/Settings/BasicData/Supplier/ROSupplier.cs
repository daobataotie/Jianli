using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Book.UI.Settings.BasicData.Supplier
{
    public partial class ROSupplier : DevExpress.XtraReports.UI.XtraReport
    {
        public ROSupplier()
        {
            InitializeComponent();
        }

        public ROSupplier(Model.Supplier supplier)
            : this()
        {
            this.lblCompanyName.Text = BL.Settings.CompanyChineseName;
            this.lblReportName.Text = "供應商基本資料";
            this.lblSupplierCategory.Text = supplier.SupplierCategory == null ? "" : supplier.SupplierCategory.SupplierCategoryName;
            this.lblSupplierId.Text = supplier.Id;
            this.lblSupplierFullName.Text = supplier.SupplierFullName;
            this.lblSupplierShortName.Text = supplier.SupplierShortName;
            this.lblAreaCategory.Text = supplier.AreaCategory == null ? "" : supplier.AreaCategory.AreaCategoryName;
            this.lblSupplierNumber.Text = supplier.SupplierNumber;
            this.lblSupplierManager.Text = supplier.SupplierManager;
            this.lblSupplierContact.Text = supplier.SupplierContact;
            this.lblSupplierMobile.Text = supplier.SupplierMobile;
            this.lblSupplierPhone1.Text = supplier.SupplierPhone1;
            this.lblSupplierPhone2.Text = supplier.SupplierPhone2;
            this.lblSupplierFax.Text = supplier.SupplierFax;
            this.lblPostCode.Text = supplier.PostCode;
            this.lblSupplierEmail.Text = supplier.Email;
            this.lblCompanyAddress.Text = supplier.CompanyAddress;
            this.lblFactoryAddress.Text = supplier.FactoryAddress;
            this.lblPayAddress.Text = supplier.PayAddress;
            this.lblPayMethod.Text = supplier.PayMethod == null ? "" : supplier.PayMethod.PayMethodName;
            this.lblPayDay.Text = supplier.PayDay.HasValue ? supplier.PayDay.Value.ToString() : "";
            this.lblAdvancePatment.Text = supplier.AdvancePatment.HasValue ? supplier.AdvancePatment.Value.ToString() : "";
            this.lblNetAddress.Text = supplier.NetAddress;
            this.lblNoId.Text = supplier.NoId;
            this.lblSupplierRemark.Text = supplier.SupplierRemark;
        }
    }
}
