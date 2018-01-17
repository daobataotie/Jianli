using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Book.UI.produceManager.ProductScrap
{
    public partial class ConditionForm : DevExpress.XtraEditors.XtraForm
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ProductId { get; set; }

        public ConditionForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            this.date_Start.EditValue = DateTime.Now.AddMonths(-1);
            this.date_End.EditValue = DateTime.Now;
        }

        private void btn_Product_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Invoices.ChooseProductForm f = new Book.UI.Invoices.ChooseProductForm();
            if (f.ShowDialog(this) == DialogResult.OK)
                this.btn_Product.EditValue = f.SelectedItem as Model.Product;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.StartDate = this.date_Start.EditValue == null ? global::Helper.DateTimeParse.NullDate : this.date_Start.DateTime;
            this.EndDate = this.date_End.EditValue == null ? global::Helper.DateTimeParse.EndDate : this.date_End.DateTime;
            if (this.btn_Product.EditValue != null)
                this.ProductId = (this.btn_Product.EditValue as Model.Product).ProductId;

            this.DialogResult = DialogResult.OK;
        }
    }
}