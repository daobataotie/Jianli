using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Book.UI.Accounting.Report
{
    public partial class FormJournal : DevExpress.XtraEditors.XtraForm
    {
        public FormJournal()
        {
            InitializeComponent();

            this.checkEdit_Income.Checked = true;
            this.checkEdit_Pay.Checked = true;
            this.checkEdit_Trans.Checked = true;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public ConditionDetailLedger Condition { get; set; }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            Condition = new ConditionDetailLedger();
            if (this.date_Start.EditValue == null || this.date_End.EditValue == null)
            {
                MessageBox.Show("日期區間不完整！", this.Text, MessageBoxButtons.OK);
                return;
            }
            else
            {
                Condition.DateStart = this.date_Start.DateTime;
                Condition.DateEnd = this.date_End.DateTime;
            }
            Condition.StartId = txt_StartId.Text;
            Condition.EndId = txt_EndId.Text;

            Condition.Category = "'',";
            if (checkEdit_Income.Checked)
                Condition.Category += "'現金收入傳票',";
            if (checkEdit_Pay.Checked)
                Condition.Category += "'現金支出傳票',";
            if (checkEdit_Trans.Checked)
                Condition.Category += "'轉帳傳票',";

            Condition.Category = Condition.Category.Trim(',');

            ROJournal ro = new ROJournal(this.Condition);
            ro.ShowPreviewDialog();
        }
    }
}