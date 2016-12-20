using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;

namespace Book.UI.Settings.BasicData.Products
{
    public partial class BarCodeSearchForm : DevExpress.XtraEditors.XtraForm
    {
        BL.ProductManager productManager = new Book.BL.ProductManager();
        BL.StockManager stockManager = new Book.BL.StockManager();
        BL.ProductBarCodeSetManager productBarCodeSetManager = new Book.BL.ProductBarCodeSetManager();

        public BarCodeSearchForm()
        {
            InitializeComponent();

            if (Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")).Hour > 18)
                this.layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            else
                this.layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.textEdit1.Text))
            {
                Model.Product product = productManager.SelectByBarCode(this.textEdit1.Text);
                if (product != null)
                {
                    this.textEdit2.EditValue = product.Id;
                    this.textEdit3.EditValue = product.ProductName;

                    DateTime dateStart = this.dateEdit1.EditValue == null ? global::Helper.DateTimeParse.NullDate : this.dateEdit1.DateTime;
                    DateTime dateEnd = this.dateEdit2.EditValue == null ? global::Helper.DateTimeParse.EndDate : this.dateEdit2.DateTime;
                    IList<Model.StockSeach> list = this.stockManager.SelectReaderByPro(product.ProductId, dateStart, dateEnd);
                    list = list.OrderBy(s => s.InvoiceDate).ToList<Model.StockSeach>();
                    this.bindingSource1.DataSource = list;
                }
                else
                {
                    this.textEdit2.EditValue = null;
                    this.textEdit3.EditValue = null;
                    this.bindingSource1.DataSource = null;
                    MessageBox.Show("根據輸入條碼未查詢到商品！", "提示！", MessageBoxButtons.OK);
                    return;
                }
            }
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            Model.StockSeach m = this.bindingSource1.Current as Model.StockSeach;
            if (m != null)
            {
                if (m.InvoiceType == "出倉單")
                {
                    Settings.StockLimitations.OutStockEditForm f = new Book.UI.Settings.StockLimitations.OutStockEditForm(m.InvoiceNO);
                    f.ShowDialog(this);
                }
                else if (m.InvoiceType == "入倉單")
                {
                    Settings.StockLimitations.DepotInForm f = new Book.UI.Settings.StockLimitations.DepotInForm(m.InvoiceNO);
                    f.ShowDialog(this);
                }
                else if (m.InvoiceType == "盤點核准單")
                {
                    Settings.StockLimitations.StockCheckForm f = new Book.UI.Settings.StockLimitations.StockCheckForm(m.InvoiceNO);
                    f.ShowDialog(this);
                }
                else if (m.InvoiceType == "庫存調撥單")
                {
                    Invoices.PT.EditForm f = new Book.UI.Invoices.PT.EditForm(m.InvoiceNO);
                    f.ShowDialog(this);
                }
                else if (m.InvoiceType == "生產入庫單")
                {
                    produceManager.ProduceInDepot.EditForm f = new Book.UI.produceManager.ProduceInDepot.EditForm(m.InvoiceNO);
                    f.ShowDialog(this);
                }
                else if (m.InvoiceType == "委外入庫單")
                {
                    produceManager.ProduceOtherInDepot.Editform f = new Book.UI.produceManager.ProduceOtherInDepot.Editform(m.InvoiceNO, "view");
                    f.ShowDialog(this);
                }
                else if (m.InvoiceType == "銷售出貨單")
                {
                    Invoices.XS.EditForm f = new Book.UI.Invoices.XS.EditForm(m.InvoiceNO);
                    f.ShowDialog(this);
                }
                else if (m.InvoiceType == "採購入庫單")
                {
                    Invoices.CG.EditForm f = new Book.UI.Invoices.CG.EditForm(m.InvoiceNO);
                    f.ShowDialog(this);
                }
                else if (m.InvoiceType == "銷售退貨")
                {
                    Invoices.XT.EditForm f = new Book.UI.Invoices.XT.EditForm(m.InvoiceNO);
                    f.ShowDialog(this);
                }
                else if (m.InvoiceType == "採購退貨")
                {
                    Invoices.CT.EditForm f = new Book.UI.Invoices.CT.EditForm(m.InvoiceNO, "view");
                    f.ShowDialog(this);
                }
                else if (m.InvoiceType == "生产退料")
                {
                    produceManager.ProduceMaterialExit.EditForm f = new Book.UI.produceManager.ProduceMaterialExit.EditForm(m.InvoiceNO);
                    f.ShowDialog(this);
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string sql = "select ProductId from Product where ProductBarCode is null";
            IList<Model.Product> list = this.productManager.DataReaderBind<Model.Product>(sql, null, CommandType.Text);

            string update;
            foreach (var item in list)
            {
                try
                {
                    BL.V.BeginTransaction();

                    item.ProductBarCode = new BL.ProductBarCodeSetManager().RandomBarCode();
                    productManager.BarCodeRecursion(item);

                    update = "update Product set ProductBarCode='" + item.ProductBarCode + "' where ProductId='" + item.ProductId + "'";
                    this.productManager.UpdateSql(update);
                    productBarCodeSetManager.Increment();

                    BL.V.CommitTransaction();
                }
                catch (Exception ex)
                {
                    BL.V.RollbackTransaction();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select ProductId from Product where ProductBarCode is null";
            IList<Model.Product> list = this.productManager.DataReaderBind<Model.Product>(sql, null, CommandType.Text);

            string update;
            foreach (var item in list)
            {
                try
                {
                    BL.V.BeginTransaction();

                    item.ProductBarCode = new BL.ProductBarCodeSetManager().RandomBarCode();
                    productManager.BarCodeRecursion(item);

                    update = "update Product set ProductBarCode='" + item.ProductBarCode + "' where ProductId='" + item.ProductId + "'";
                    this.productManager.UpdateSql(update);
                    productBarCodeSetManager.Increment();

                    BL.V.CommitTransaction();
                }
                catch (Exception ex)
                {
                    BL.V.RollbackTransaction();
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}