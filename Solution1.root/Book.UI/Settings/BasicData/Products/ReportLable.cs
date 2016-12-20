using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Book.UI.Settings.BasicData.Products
{
    public partial class ReportLable : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportLable()
        {
            InitializeComponent();
        }

        public ReportLable(string pihao,decimal num,string id,string name)
            : this()
        {
            this.lblId.Text = id;
            this.lblName1.Text = name;
            this.lblPihao.Text = pihao;
            this.lblNum.Text = num.ToString(); 
        }
    }
}
