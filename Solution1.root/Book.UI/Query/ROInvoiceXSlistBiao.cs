using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using System.Data;

namespace Book.UI.Query
{
    public partial class ROInvoiceXSlistBiao : BaseReport
    {
        protected BL.InvoiceXSDetailManager detailManager = new Book.BL.InvoiceXSDetailManager();

        public ROInvoiceXSlistBiao()
        {
            InitializeComponent();
        }

        public ROInvoiceXSlistBiao(ConditionX condition)
            : this()
        {
            this.xrLabelReportName.Text = "�����~��������";
            this.lblCustomerName.Text = condition.Customer1 == null ? "" : condition.Customer1.ToString();
            this.lblDateRange.Text = "  �r�g�^�g:" + condition.StartDate.ToString("yyyy-MM-dd") + " ~ " + condition.EndDate.ToString("yyyy-MM-dd");
            //bind
            //this.DataSource = this.detailManager.SelectbyConditionX(condition.StartDate, condition.EndDate, condition.Yjri1, condition.Yjri2, condition.Customer1, condition.Customer2, condition.XOId1, condition.XOId2, condition.Product, condition.Product2, condition.CusXOId, condition.OrderColumn, condition.OrderType);
            //if ((bool)condition.Special)
            //{
            //    this.DataSource = this.detailManager.SelectbyConditionXBiao(condition.StartDate, condition.EndDate, condition.Yjri1, condition.Yjri2, condition.Customer1, condition.Customer2, condition.XOId1, condition.XOId2, condition.Product, condition.Product2, condition.CusXOId, condition.OrderColumn, condition.OrderType, false, condition.Product_Id,condition.ProductCategoryId);
            //    dt = this.detailManager.SelectbyConditionXBiao(condition.StartDate, condition.EndDate, condition.Yjri1, condition.Yjri2, condition.Customer1, condition.Customer2, condition.XOId1, condition.XOId2, condition.Product, condition.Product2, condition.CusXOId, condition.OrderColumn, condition.OrderType, condition.Special, condition.Product_Id, condition.ProductCategoryId);
            //}
            //else
            this.DataSource = this.detailManager.SelectbyConditionXBiao(condition.StartDate, condition.EndDate, condition.Yjri1, condition.Yjri2, condition.Customer1, condition.Customer2, condition.Employee1, condition.Employee2, condition.XOId1, condition.XOId2, condition.Product, condition.Product2, condition.CusXOId, condition.OrderColumn, condition.OrderType, null, condition.Product_Id, condition.ProductCategoryId, condition.Currency);

            //if (this.DataSource == null || (this.DataSource as IList<Model.InvoiceXSDetail>).Count == 0)
            if ((this.DataSource == null || (this.DataSource as System.Data.DataTable).Rows.Count == 0))
                throw new global::Helper.InvalidValueException("�oӛ�");

            this.tcCHDH.DataBindings.Add("Text", this.DataSource, "CHDH");
            this.tcCHRQ.DataBindings.Add("Text", this.DataSource, "CHRQ", "{0:yyyy-MM-dd}");
            this.tcProductName.DataBindings.Add("Text", this.DataSource, "ProductName");
            this.tcKHDDBH.DataBindings.Add("Text", this.DataSource, "KHDDBH");
            //this.tcDDSL.DataBindings.Add("Text", this.DataSource, "");
            this.tcBCCHSL.DataBindings.Add("Text", this.DataSource, "BCCHSL", global::Helper.DateTimeParse.GetFormatA(BL.V.SetDataFormat.XSSLXiao.Value));
            this.tcDW.DataBindings.Add("Text", this.DataSource, "DanWei");
            this.tcDJ.DataBindings.Add("Text", this.DataSource, "DanJia", global::Helper.DateTimeParse.GetFormatA(BL.V.SetDataFormat.CGDJXiao.Value));
            this.tcZheRang.DataBindings.Add("Text", this.DataSource, "ZheRang", global::Helper.DateTimeParse.GetFormatA(BL.V.SetDataFormat.CGJEXiao.Value));
            this.tcJinE.DataBindings.Add("Text", this.DataSource, "JinE");
            this.tcShuiE.DataBindings.Add("Text", this.DataSource, "ShuiE", "{0:0}");
            this.tcYingShou.DataBindings.Add("Text", this.DataSource, "YingShou", global::Helper.DateTimeParse.GetFormatA(BL.V.SetDataFormat.CGDJXiao.Value));

            this.TCCurrency.DataBindings.Add("Text", this.DataSource, "Currency");
            this.TCCurrencyTotal.DataBindings.Add("Text", this.DataSource, "TaibiTotal", global::Helper.DateTimeParse.GetFormatA(BL.V.SetDataFormat.CGDJXiao.Value));


            this.TCZHeJi.Summary.FormatString = "{0:0}";
            this.TCZHeJi.Summary.Func = SummaryFunc.Sum;
            this.TCZHeJi.Summary.IgnoreNullValues = true;
            this.TCZHeJi.Summary.Running = SummaryRunning.Report;
            this.TCZHeJi.DataBindings.Add("Text", this.DataSource, "JinE");

            this.TCZShuiE.Summary.FormatString = "{0:0}";
            this.TCZShuiE.Summary.Func = SummaryFunc.Sum;
            this.TCZShuiE.Summary.IgnoreNullValues = true;
            this.TCZShuiE.Summary.Running = SummaryRunning.Report;
            this.TCZShuiE.DataBindings.Add("Text", this.DataSource, "ShuiE");

            this.TCZZongJi.Summary.FormatString = "{0:0}";
            this.TCZZongJi.Summary.Func = SummaryFunc.Sum;
            this.TCZZongJi.Summary.IgnoreNullValues = true;
            this.TCZZongJi.Summary.Running = SummaryRunning.Report;
            this.TCZZongJi.DataBindings.Add("Text", this.DataSource, "YingShou");


            this.lbTaibiTotal.Summary.FormatString = "{0:0}";
            this.lbTaibiTotal.Summary.Func = SummaryFunc.Sum;
            this.lbTaibiTotal.Summary.IgnoreNullValues = true;
            this.lbTaibiTotal.Summary.Running = SummaryRunning.Report;
            this.lbTaibiTotal.DataBindings.Add("Text", this.DataSource, "TaibiTotal");
        }
    }
}
