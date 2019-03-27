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

                this.lbl_CompanyName.Text = BL.Settings.CompanyChineseName;
                this.lbl_ReportName.Text = "銷售表 sales report";
                this.lbl_ReportDate.Text = con.StartDate.ToString("yyyy-MM-dd") + " ~ " + con.EndDate.ToString("yyyy-MM-dd");

                this.DataSource = listDetail;
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
                this.TCTaibiAmount.DataBindings.Add("Text", this.DataSource, "TaibiAmount", "NT${0:N2}");
                this.TCPayTerm.DataBindings.Add("Text", this.DataSource, "Invoice.XSCustomer." + Model.Customer.PRO_PayCondition);
                this.TCCusXOId.DataBindings.Add("Text", this.DataSource, "InvoiceXO." + Model.InvoiceXO.PRO_CustomerInvoiceXOId);

                this.TCTotalAmount.Text = currenty + listDetail.Sum(D => D.InvoiceXSDetailMoney).Value.ToString("N2");
                this.TCTotalTaibiAmount.Text = "NT$" + listDetail.Sum(D => D.TaibiAmount).Value.ToString("N2");
            }
            else
                throw new Exception();
        }

    }
}
