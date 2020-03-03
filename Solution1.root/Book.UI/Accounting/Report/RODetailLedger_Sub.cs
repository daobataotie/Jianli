using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using System.Linq;

namespace Book.UI.Accounting.Report
{
    public partial class RODetailLedger_Sub : DevExpress.XtraReports.UI.XtraReport
    {
        public List<Model.DetailLedger> list = null;
        public RODetailLedger_Sub()
        {
            InitializeComponent();

            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(RODetailLedger_Sub_BeforePrint);


            this.TC_Date.DataBindings.Add("Text", this.DataSource, "SummonDate", "{0:yyyy/MM/dd}");
            this.TC_Id.DataBindings.Add("Text", this.DataSource, "Id");
            this.TC_Note.DataBindings.Add("Text", this.DataSource, "Summary");
            this.TC_JieDai.DataBindings.Add("Text", this.DataSource, "Lending");
            //this.TC_JMoney.DataBindings.Add("Text", this.DataSource, "JMoney", "{0:0.00}");
            //this.TC_DMoney.DataBindings.Add("Text", this.DataSource, "DMoney", "{0:0.00}");
            //this.TC_Total.DataBindings.Add("Text", this.DataSource, "Total", "{0:0.00}");
            this.TC_JMoney.DataBindings.Add("Text", this.DataSource, "JMoney", "{0:N0}");
            this.TC_DMoney.DataBindings.Add("Text", this.DataSource, "DMoney", "{0:###,###}");
            this.TC_Total.DataBindings.Add("Text", this.DataSource, "Total", "{0:N0}");
        }

        void RODetailLedger_Sub_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.DataSource = list;

            Model.DetailLedger detail = list[0];
            this.TC_Subject_Id.Text = detail.Subject_Id;
            this.TC_SubjectName.Text = detail.SubjectName;
            //this.TC_QichuBalance.Text = detail.TheBalance.ToString("F2");
            //this.TC_JTotal.Text = list.Sum(D => D.JMoney).ToString("F2");
            //this.TC_DTotal.Text = list.Sum(D => D.DMoney).ToString("F2");
            //this.TC_AllTotal.Text = list.Last().Total.ToString("F2");

            this.TC_QianqiBalance.Text = detail.TheBalance.ToString("N0");
            this.TC_JTotal.Text = list.Sum(D => D.JMoney).ToString("N0");
            this.TC_DTotal.Text = list.Sum(D => D.DMoney).ToString("N0");
            this.TC_AllTotal.Text = list.Last().Total.ToString("N0");

        }
    }
}
