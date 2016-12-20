using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;

namespace Book.UI.Invoices.CG
{
    public partial class ROLable : DevExpress.XtraReports.UI.XtraReport
    {
        public ROLable(IList<string> list)
        {
            InitializeComponent();

            this.DataSource = list;

            //this.xrBarCode1.DataBindings.Add("Rtf", this.DataSource, Model.Product.PRO_Id);
            //this.xrBarCode1.Text = list[0].Product.Id;

            this.xrSubreport1.ReportSource = new ROLableHelp();
        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ROLableHelp ro = this.xrSubreport1.ReportSource as ROLableHelp;
            ro.Id = this.GetCurrentRow() as string;
            
            this.xrSubreport1.ReportSource = new ROLableHelp(ro.Id);
        }

    }
}
