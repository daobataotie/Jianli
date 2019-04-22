using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace Book.UI.Invoices.XS
{
    public partial class ROHistoryXS : DevExpress.XtraReports.UI.XtraReport
    {
        BL.InvoiceXSDetailManager detailManager = new Book.BL.InvoiceXSDetailManager();
        public ROHistoryXS()
        {
            InitializeComponent();

            Query.ConditionXChooseForm f = new Query.ConditionXChooseForm();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Query.ConditionX con = f.Condition as Query.ConditionX;

                IList<Model.InvoiceXS> list = new BL.InvoiceXSManager().SelectDateRangAndWhere(con.Customer1, con.Customer2, con.StartDate, con.EndDate, con.Yjri1, con.Yjri2, con.CusXOId, con.Product, con.Product2, con.XOId1, con.XOId2, con.FreightedCompanyId, con.ConveyanceMethodId, con.Employee1, con.Employee2, con.Product_Id, con.ProductCategoryId);

                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("無數據", "提示", MessageBoxButtons.OK);
                }

                IList<Model.InvoiceXSDetail> listDetail = new List<Model.InvoiceXSDetail>();
                foreach (var item in list)
                {
                    item.Details = detailManager.Select(item);
                    foreach (var detail in item.Details)
                    {
                        detail.Invoice = item;
                        listDetail.Add(detail);
                    }
                }

                var group = listDetail.GroupBy(D => D.InvoiceNO);
                IList<Model.InvoiceXSDetail> details = new List<Model.InvoiceXSDetail>();

                if (group != null && group.Count() > 0)
                {
                    foreach (var item in group)
                    {
                        Model.InvoiceXSDetail detail = new Book.Model.InvoiceXSDetail();
                        detail = item.First();
                        //先计算台幣金額，然后加总金额，因为台幣金額=金额*汇率
                        detail.TaibiAmountForGroup = item.Sum(D => D.TaibiAmount);
                        detail.InvoiceXSDetailMoney = item.Sum(D => D.InvoiceXSDetailMoney);
                        item.Select(D => D.InvoiceXO.CustomerInvoiceXOId).Distinct().ToList().ForEach(F =>
                        {
                            detail.CusXOIdForGroup += F + "\r\n";
                        });
                        detail.CusXOIdForGroup = detail.CusXOIdForGroup.TrimEnd(new char[] { '\r', '\n' });

                        details.Add(detail);
                    }
                }

                this.DataSource = details;

                this.lbl_CompanyName.Text = BL.Settings.CompanyChineseName;
                this.lbl_ReportName.Text = "銷售表 sales report";
                this.lbl_ReportDate.Text = con.StartDate.ToString("yyyy-MM-dd") + " ~ " + con.EndDate.ToString("yyyy-MM-dd");

                string currenty = Model.ExchangeRate.GetCurrencyENNameAndSign(listDetail[0].Currency);

                this.xrTableCell9.Text = string.Format("實際請款     ({0})", currenty);

                this.TCInvoiceDate.DataBindings.Add("Text", this.DataSource, "Invoice." + Model.InvoiceXS.PROPERTY_INVOICEDATE, "{0:yyyy/MM/dd}");
                this.TCDeclareDate.DataBindings.Add("Text", this.DataSource, "Invoice." + Model.InvoiceXS.PRO_DeclareDate, "{0:yyyy/MM/dd}");
                this.TCShipMethod.DataBindings.Add("Text", this.DataSource, "Invoice.ConveyanceMethod." + Model.ConveyanceMethod.PROPERTY_CONVEYANCEMETHODNAME);
                this.TCXSCustomer.DataBindings.Add("Text", this.DataSource, "Invoice.XSCustomer." + Model.Customer.PRO_CustomerFullName);
                this.TCInvoiceNO.DataBindings.Add("Text", this.DataSource, Model.InvoiceXSDetail.PRO_InvoiceNO);
                this.TCAmount.DataBindings.Add("Text", this.DataSource, Model.InvoiceXSDetail.PRO_InvoiceXSDetailMoney, currenty + "{0:N2}");
                this.TCRealAmount.DataBindings.Add("Text", this.DataSource, Model.InvoiceXSDetail.PRO_InvoiceXSDetailMoney, currenty + "{0:N2}");
                this.TCExchangeRate.DataBindings.Add("Text", this.DataSource, Model.InvoiceXSDetail.PRO_ExchangeRate);
                //this.TCTaibiAmount.DataBindings.Add("Text", this.DataSource, "TaibiAmount", "NT${0:N2}");
                this.TCTaibiAmount.DataBindings.Add("Text", this.DataSource, "TaibiAmountForGroup", "NT${0:N2}");
                this.TCPayTerm.DataBindings.Add("Text", this.DataSource, "Invoice.XSCustomer." + Model.Customer.PRO_PayCondition);
                //this.TCCusXOId.DataBindings.Add("Text", this.DataSource, "InvoiceXO." + Model.InvoiceXO.PRO_CustomerInvoiceXOId);
                //this.TCCusXOId.DataBindings.Add("Text", this.DataSource, "CusXOIdForGroup");
                this.xrRichText1.DataBindings.Add("Text", this.DataSource, "CusXOIdForGroup");

                this.TCTotalAmount.Text = currenty + details.Sum(D => D.InvoiceXSDetailMoney).Value.ToString("N2");
                this.TCTotalTaibiAmount.Text = "NT$" + details.Sum(D => D.TaibiAmountForGroup).Value.ToString("N2");
            }
            else
                throw new Exception();
        }

    }
}
