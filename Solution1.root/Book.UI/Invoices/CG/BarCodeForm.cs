using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Book.UI.Invoices.CG
{
    public partial class BarCodeForm : DevExpress.XtraEditors.XtraForm
    {
        public BarCodeForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public BarCodeForm(IList<Model.Product> list)
            : this()
        {
            this.bindingSource1.DataSource = list;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            IList<Model.Product> list = this.bindingSource1.DataSource as List<Model.Product>;
            IList<string> str = new List<string>();
            foreach (var item in list)
            {
                if (item.BarCodePrintQuantity == null || item.BarCodePrintQuantity == 0)
                {
                    str.Add(item.ProductBarCode);
                }
                else
                {
                    for (int i = 0; i < item.BarCodePrintQuantity; i++)
                    {
                        str.Add(item.ProductBarCode);
                    }
                }
            }
            if (str.Count < 1)
            {
                MessageBox.Show("無數據！", this.Text, MessageBoxButtons.OK);
                return;
            }
            ROLable r = new ROLable(str);
            r.ShowPreviewDialog();
        }
    }
}