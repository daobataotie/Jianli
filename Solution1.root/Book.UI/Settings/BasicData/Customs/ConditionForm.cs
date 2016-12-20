using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Book.UI.Settings.BasicData.Customs
{
    public partial class ConditionForm : DevExpress.XtraEditors.XtraForm
    {
        public Model.Customer customer = new Book.Model.Customer();
        public Model.Customer customer2 = new Book.Model.Customer();
        public ConditionForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.newChooseContorlCustomer.Choose = new ChooseCustoms();
            this.newChooseContorl1.Choose = new ChooseCustoms();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.customer = this.newChooseContorlCustomer.EditValue as Model.Customer;
            this.customer2 = this.newChooseContorl1.EditValue as Model.Customer;
            if (this.customer2 == null)
                this.customer2 = this.customer;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newChooseContorlCustomer_EditValueChanged(object sender, EventArgs e)
        {
            this.newChooseContorl1.EditValue = this.newChooseContorlCustomer.EditValue;
        }
    }
}