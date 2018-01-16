using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Book.UI.produceManager.ProductScrap
{
    public partial class RO : DevExpress.XtraReports.UI.XtraReport
    {
        public RO()
        {
            InitializeComponent();
        }

        public RO(Model.ProductScrap model)
            : this()
        {
            this.lbl_Company.Text = BL.Settings.CompanyChineseName;
            this.lbl_ReportName.Text = "商品報廢單";
            this.lbl_ReportDate.Text += DateTime.Now.Date.ToString("yyyy-MM-dd");

            this.lbl_ProductScrapId.Text = model.ProductScrapId;
            this.lbl_Date.Text = model.ProductScrapDate.Value.ToString("yyyy-MM-dd");
            this.lbl_Employee.Text = (model.Employee == null ? "" : model.Employee.EmployeeName);
            this.lbl_Depot.Text = (model.Depot == null ? "" : model.Depot.DepotName);
            this.lbl_Note.Text = model.Note;

            this.DataSource = model.Details;

            this.TCProductId.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_Id);
            this.TCProductName.DataBindings.Add("Text", this.DataSource, "Product." + Model.Product.PRO_ProductName);
            this.TXQTY.DataBindings.Add("Text", this.DataSource, Model.ProductScrapDetail.PRO_ScrapQuantity, "{0:0.##}");
            this.TCDepotPosition.DataBindings.Add("Text", this.DataSource, "DepotPosition." + Model.DepotPosition.PROPERTY_ID);
            this.TCNote.DataBindings.Add("Text", this.DataSource, Model.ProductScrapDetail.PRO_Note);
        }
    }
}
