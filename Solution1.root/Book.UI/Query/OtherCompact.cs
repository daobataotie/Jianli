using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;

namespace Book.UI.Query
{
    public partial class OtherCompact : DevExpress.XtraReports.UI.XtraReport
    {
        BL.ProduceOtherCompactDetailManager manager = new Book.BL.ProduceOtherCompactDetailManager();
        public OtherCompact()
        {
            InitializeComponent();
        }

        public OtherCompact(ConditionOtherCompact condition)
            : this()
        {
            IList<Model.ProduceOtherCompactDetail> list = this.manager.SelectByDateAndCondition(condition.ProduceOtherCompactId1, condition.ProduceOtherCompactId2, condition.StartDate, condition.EndDate, condition.SupplierId1, condition.SupplierId2, condition.ProductId1, condition.ProductId2, condition.StartJQ, condition.EndJQ, condition.IsCloesd);

            if (list == null || list.Count <= 0)
                throw new global::Helper.InvalidValueException("ŸoÓ›ä›");

            this.DataSource = list;
            //CompanyInfo
            this.ReportName.Text = BL.Settings.CompanyChineseName;
            this.ReportTitle.Text = Properties.Resources.ProduceOtherCompactDetail;
            this.lblPrintDate.Text += DateTime.Now.ToString("yyyy-MM-dd");
            this.lblInvoiceDate.Text = condition.StartDate.ToString("yyyy-MM-dd") + " ~ " + condition.EndDate.ToString("yyyy-MM-dd");

            this.TCSupplier.DataBindings.Add("Text", this.DataSource, Model.ProduceOtherCompactDetail.PRO_SupplierFullName);
            this.TCProduceOtherCompactId.DataBindings.Add("Text", this.DataSource, Model.ProduceOtherCompactDetail.PRO_ProduceOtherCompactId);
            this.TCProductName.DataBindings.Add("Text", this.DataSource, Model.ProduceOtherCompactDetail.PRO_RPProductName);
            this.TCCustomerProduct.DataBindings.Add("Text", this.DataSource, Model.ProduceOtherCompactDetail.PRO_RPCustomerProductName);
            this.TCProductDesc.DataBindings.Add("Rtf", this.DataSource, Model.ProduceOtherCompactDetail.PRO_ProductDescription);
            this.TCQuantity.DataBindings.Add("Text", this.DataSource, Model.ProduceOtherCompactDetail.PRO_OtherCompactCount);
            this.TCInDepotCount.DataBindings.Add("Text", this.DataSource, Model.ProduceOtherCompactDetail.PRO_InDepotCount);
            this.TCCancelQuantity.DataBindings.Add("Text", this.DataSource, Model.ProduceOtherCompactDetail.PRO_CancelQuantity);
            this.TCUnit.DataBindings.Add("Text", this.DataSource, Model.ProduceOtherCompactDetail.PRO_ProductUnit);
            this.TCNote.DataBindings.Add("Text", this.DataSource, Model.ProduceOtherCompactDetail.PRO_Description);
            this.TCCloesd.DataBindings.Add("Text", this.DataSource, Model.ProduceOtherCompactDetail.PRO_IsClosedHelp);
            this.TCJQ.DataBindings.Add("Text", this.DataSource, Model.ProduceOtherCompactDetail.PRO_JiaoQi,"{0:yyyy-MM-dd}");
        }
    }
}
