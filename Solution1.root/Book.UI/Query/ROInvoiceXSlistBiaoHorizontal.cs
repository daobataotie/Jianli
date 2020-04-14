using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Linq;

namespace Book.UI.Query
{
    public partial class ROInvoiceXSlistBiaoHorizontal : DevExpress.XtraReports.UI.XtraReport
    {
        protected BL.InvoiceXSDetailManager detailManager = new Book.BL.InvoiceXSDetailManager();
        DataTable dt = new DataTable();
        public ROInvoiceXSlistBiaoHorizontal(ConditionX condition)
        {
            InitializeComponent();

            this.lbl_CompanyName.Text = BL.Settings.CompanyChineseName;
            this.lbl_ReportName.Text = "應收賬款明細表";
            this.lbl_ReportDate.Text += DateTime.Now.ToString("yyyy-MM-dd");
            this.lbl_DataRange.Text += condition.StartDate.ToString("yyyy-MM-dd") + " ~ " + condition.EndDate.ToString("yyyy-MM-dd");

            dt = this.detailManager.SelectbyConditionXBiao(condition.StartDate, condition.EndDate, condition.Yjri1, condition.Yjri2, condition.Customer1, condition.Customer2, condition.Employee1, condition.Employee2, condition.XOId1, condition.XOId2, condition.Product, condition.Product2, condition.CusXOId, condition.OrderColumn, condition.OrderType, null, condition.Product_Id, condition.ProductCategoryId, condition.Currency);

            if (dt == null || dt.Rows.Count == 0)
                throw new global::Helper.InvalidValueException("無記錄");

            var group = dt.AsEnumerable().GroupBy(r => r.Field<string>("CustomerFullName")).Select(S => S.Key).ToList<string>();
            this.DataSource = group;

            this.xrSubreport1.ReportSource = new ROInvoiceXSlistBiaoHorizontalSub();
        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ROInvoiceXSlistBiaoHorizontalSub sub = this.xrSubreport1.ReportSource as ROInvoiceXSlistBiaoHorizontalSub;
            string customer = this.GetCurrentRow().ToString();

            DataTable newDt = dt.Clone();
            DataRow[] drs = dt.Select("CustomerFullName='" + customer + "'");
            foreach (var item in drs)
            {
                newDt.Rows.Add(item.ItemArray);
            }

            sub.dt = newDt;
        }

    }
}
