using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
namespace Book.UI.Accounting.Report
{
    public partial class XRBankSaveUp : DevExpress.XtraReports.UI.XtraReport
    {
        BL.AtBankSaveUpManager detailManager = new Book.BL.AtBankSaveUpManager();
        IList<Model.AtBankSaveUp> oList = new List<Model.AtBankSaveUp>();
        public XRBankSaveUp(ConditionBankSaveUp condition)
        {
            InitializeComponent();
            this.xrLabelCompanyInfoName.Text = BL.Settings.CompanyChineseName;
            this.xrLabelDataName.Text = Properties.Resources.BankSaveUp;
            decimal? e = 0;
            decimal? f = 0;
            decimal? k = 0;
            if (condition.BankAccountId != null)
            {
                IList<Model.AtBankSaveUp> list = detailManager.Select(condition.StartDate, condition.EndDate, condition.BankAccountId);
                this.xrLabel2.Text = DateTime.Now.ToShortDateString();
                this.xrLabel1.Text = "Date range：" + condition.StartDate.ToShortDateString() + "To" + condition.EndDate.ToShortDateString();
                Model.AtBankAccount aTbank = new BL.AtBankAccountManager().Get(condition.BankAccountId);
                if (aTbank != null)
                {
                    this.xrLabel3.Text = "Bank Name：  " + aTbank.Bank.BankName + "      initial balance：" + aTbank.TheirBalance.ToString();
                    e = aTbank.TheirBalance;
                }
                if (list != null)
                {
                    foreach (Model.AtBankSaveUp at in list)
                    {
                        if (at.SaveUpCategory == "Cash Deposit")
                        {
                            at.A = at.SaveUpMoney;
                            at.B = 0;
                            at.C = e + at.A;
                            e = e + at.A;
                            f += at.A;
                        }
                        else
                        {
                            at.A = 0;
                            at.B = at.SaveUpMoney;
                            at.C = e - at.B;
                            e = e - at.B;
                            k += at.B;
                        }
                        oList.Add(at);
                    }
                    this.DataSource = oList;
                }
                this.xrLabel4.Text = "Total deposit：    " + f.ToString();
                this.xrLabel5.Text = "Total raise：    " + k.ToString();
                this.xrTableCellTheOpenDate.DataBindings.Add("Text", this.DataSource, Model.AtBankSaveUp.PRO_SaveUpdate, "{0:yyyy-MM-dd}");
                this.xrTableCellBillsId.DataBindings.Add("Text", this.DataSource, "BankAccount." + Model.AtBankAccount.PRO_BankAccountName);
                this.xrTableCellTheJpy.DataBindings.Add("Text", this.DataSource, Model.AtBankSaveUp.PRO_SaveUpCategory);
                this.xrTableCell12.DataBindings.Add("Text", this.DataSource, Model.AtBankSaveUp.PRO_CheckNumber);

                this.xrTableCell14.DataBindings.Add("Text", this.DataSource, "A", "{0:0}");
                this.xrTableCell15.DataBindings.Add("Text", this.DataSource, "B", "{0:0}");
                this.xrTableCell16.DataBindings.Add("Text", this.DataSource, "C", "{0:0}");
                this.xrTableCell10.DataBindings.Add("Text", this.DataSource, Model.AtBankSaveUp.PRO_Mark);
            }
        }

    }
}
