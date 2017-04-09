using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;

namespace Book.UI.Settings.StockLimitations
{
    public partial class SearchProductForm : DevExpress.XtraEditors.XtraForm
    {
        BL.ProductManager productManager = new Book.BL.ProductManager();
        IList<Model.Product> ProductList;
        public List<Model.Product> CheckedProductList { get; set; }

        public SearchProductForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;
        }

        public SearchProductForm(List<Model.Product> proList)
            : this()
        {
            this.bindingSource1.DataSource = ProductList = productManager.SelectAll();
            if (proList != null && proList.Count > 0)
            {
                ProductList.Where(p => proList.Any(pro => pro.ProductId == p.ProductId)).ToList().ForEach(pp => pp.Checked = true);
            }

            this.gridControl1.RefreshDataSource();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            CheckedProductList = ProductList.Where(p => p.Checked == true).ToList();
        }
    }
}