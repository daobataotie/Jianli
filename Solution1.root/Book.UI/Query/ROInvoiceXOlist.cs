using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;

namespace Book.UI.Query
{
    public partial class ROInvoiceXOlist : DevExpress.XtraReports.UI.XtraReport
    {
        private BL.InvoiceXODetailManager invoicexoDetailManager = new Book.BL.InvoiceXODetailManager();

        public ROInvoiceXOlist()
        {
            InitializeComponent();
        }

        public ROInvoiceXOlist(ConditionX condition)
            : this()
        {
            DateTime start = condition.StartDate;
            DateTime end = condition.EndDate;

            this.lblCompanyName.Text = BL.Settings.CompanyChineseName;
            this.lbl_ReportName.Text = "客戶訂單明細表";

            this.lbl_ReportDate.Text += string.Format("{0} ~ {1}", start.ToString("yyyy-MM-dd"), end.ToString("yyyy/MM/dd"));

            IList<Model.InvoiceXODetail> Details = invoicexoDetailManager.Select(condition.Customer1, condition.Customer2, condition.StartDate, condition.EndDate, condition.Yjri1, condition.Yjri2, condition.Employee1, condition.Employee2, condition.XOId1, condition.XOId2, condition.CusXOId, condition.Product, condition.Product2, condition.IsClose, false, condition.OrderColumn, condition.OrderType, condition.DetailFlag, condition.Product_Id);

            if (Details == null || Details.Count == 0)
                throw new Helper.InvalidValueException("無記錄");

            this.DataSource = Details;

            this.TCdingdanbianhao.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceId);
            this.TCkhddbh.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_CustomerInvoiceXOId);
            this.TCkh.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_CustomerName);
            this.TCcpxh.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_ProductName);
            this.TCkhxh.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_CustomerProductName);
            this.TCriqi.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceDate, "{0:yy/MM/dd}");
            this.TCshuliang.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceXODetailQuantity);
            this.TCjinge.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceXODetailMoney, "{0:0.##}");
            this.TC_TaibiMoney.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_TaibiMoney, "{0:0.##}");

            this.TotalQty.Summary.FormatString = "{0:0.#}";
            this.TotalQty.Summary.Func = SummaryFunc.Sum;
            this.TotalQty.Summary.IgnoreNullValues = true;
            this.TotalQty.Summary.Running = SummaryRunning.Report;
            this.TotalQty.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceXODetailQuantity);

            this.lbl_TotalMoney.Summary.FormatString = "{0:0.#}";
            this.lbl_TotalMoney.Summary.Func = SummaryFunc.Sum;
            this.lbl_TotalMoney.Summary.IgnoreNullValues = true;
            this.lbl_TotalMoney.Summary.Running = SummaryRunning.Report;
            this.lbl_TotalMoney.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_InvoiceXODetailMoney);

            this.lbl_TotalTaibiMoney.Summary.FormatString = "{0:0.#}";
            this.lbl_TotalTaibiMoney.Summary.Func = SummaryFunc.Sum;
            this.lbl_TotalTaibiMoney.Summary.IgnoreNullValues = true;
            this.lbl_TotalTaibiMoney.Summary.Running = SummaryRunning.Report;
            this.lbl_TotalTaibiMoney.DataBindings.Add("Text", this.DataSource, Model.InvoiceXODetail.PRO_TaibiMoney);
        }
    }
}
