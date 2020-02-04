using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Book.UI.Accounting.AtSummon
{
    public partial class CopyChooseDateForm : DevExpress.XtraEditors.XtraForm
    {
        public DateTime InvoiceDate { get; set; }

        public CopyChooseDateForm()
        {
            InitializeComponent();

            this.dateEdit1.DateTime = DateTime.Now;

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (this.dateEdit1.EditValue == null)
            {
                MessageBox.Show("請選擇傳票日期", "錯誤", MessageBoxButtons.OK);
                return;
            }
            this.InvoiceDate = this.dateEdit1.DateTime;

            this.DialogResult = DialogResult.OK;
        }
    }
}