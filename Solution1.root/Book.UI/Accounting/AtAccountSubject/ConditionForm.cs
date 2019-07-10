using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Book.UI.Accounting.AtAccountSubject
{
    public partial class ConditionForm : DevExpress.XtraEditors.XtraForm
    {
        public ConditionForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            this.ncc_Start.Choose = new Accounting.AccountingCategory.ChooseAccountingCategory();
            this.ncc_End.Choose = new Accounting.AccountingCategory.ChooseAccountingCategory();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string StartCategoryId { get; set; }

        public string EndCategoryId { get; set; }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (this.ncc_Start.EditValue != null)
                StartCategoryId = (this.ncc_Start.EditValue as Model.AtAccountingCategory).Id;
            if (this.ncc_End.EditValue != null)
                EndCategoryId = (this.ncc_End.EditValue as Model.AtAccountingCategory).Id;

            this.DialogResult = DialogResult.OK;
        }
    }
}