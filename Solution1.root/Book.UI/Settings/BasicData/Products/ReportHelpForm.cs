using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Book.UI.Settings.BasicData.Products
{
    public partial class ReportHelpForm : DevExpress.XtraEditors.XtraForm
    {
        public ReportHelpForm()
        {
            InitializeComponent();
        }

        public string pihao;
        public decimal num;

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            pihao = txt_Pihao.Text;
            num = spe_Num.Value;
            this.DialogResult = DialogResult.OK;
        }
    }
}