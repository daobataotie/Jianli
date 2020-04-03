using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Book.UI.Invoices.IP
{
    public partial class ChooseInvoiceForm : DevExpress.XtraEditors.XtraForm
    {
        BL.PackingInvoiceHeaderManager headerManager = new Book.BL.PackingInvoiceHeaderManager();
        BL.PackingInvoiceDetailManager detailManager = new Book.BL.PackingInvoiceDetailManager();

        public ChooseInvoiceForm()
        {
            InitializeComponent();

            this.date_Start.EditValue = DateTime.Now.AddMonths(-1);
            this.date_End.EditValue = DateTime.Now;
            this.ncc_Customer.Choose = new Settings.BasicData.Customs.ChooseCustoms();
            this.bindingSourcePort.DataSource = new BL.PortManager().Select();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public Model.PackingInvoiceHeader SelectItem { get; set; }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetDetailInfo();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            GetDetailInfo();
        }

        private void GetDetailInfo()
        {
            Model.PackingInvoiceHeader model = this.bindingSourceHeader.Current as Model.PackingInvoiceHeader;

            if (model != null)
            {
                model.Details = detailManager.SelectByHeader(model.InvoiceNo);

                if (model.Details != null && model.Details.Count > 0)
                {
                    string currency = new BL.InvoiceXOManager().GetCurrencyByInvoiceId(model.Details[0].InvoiceXODetail.InvoiceId);
                    string currencyENName = Model.ExchangeRate.GetCurrencyENName(currency);
                    string currencySign = Model.ExchangeRate.GetCurrencySign(currency);

                    //model.Currency = currencySign;

                    foreach (var detail in model.Details)
                    {
                        detail.Currency = currencySign;
                    }
                }

                this.bindingSourceDetail.DataSource = model.Details;
            }
            else
                this.bindingSourceDetail.DataSource = null;

            this.gridControl3.RefreshDataSource();

            this.SelectItem = model;
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (date_Start.EditValue == null || date_End.EditValue == null)
            {
                MessageBox.Show("日期區間不完整", this.Text, MessageBoxButtons.OK);
                return;
            }

            this.bindingSourceHeader.DataSource = headerManager.SelectByCondition(date_Start.DateTime, date_End.DateTime, (this.ncc_Customer.EditValue == null ? null : (this.ncc_Customer.EditValue as Model.Customer).CustomerId));

            this.gridControl1.RefreshDataSource();

            gridView1_RowClick(null, null);
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}