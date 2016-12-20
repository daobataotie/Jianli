using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Book.UI.Invoices.CG
{
    public partial class ROLableHelp : DevExpress.XtraReports.UI.XtraReport
    {
        public ROLableHelp()
        {
            InitializeComponent();
        }

        public ROLableHelp(string Id)
            : this()
        {
            xrBarCode1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            this.xrBarCode1.Text = Id;
        }

        public string Id { get; set; }

        private void ROLableHelp_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
