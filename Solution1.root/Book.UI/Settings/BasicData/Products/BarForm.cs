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
    public partial class BarForm : DevExpress.XtraEditors.XtraForm
    {
        Model.ProductBarCodeSet _productBarCodeSet;
        BL.ProductBarCodeSetManager productBarCodeSetManager = new Book.BL.ProductBarCodeSetManager();
        int tag = 0;


        public BarForm()
        {
            InitializeComponent();

            if (productBarCodeSetManager.HasRows())
            {
                this._productBarCodeSet = productBarCodeSetManager.SelectFirst();
            }
            else
            {
                this._productBarCodeSet = new Book.Model.ProductBarCodeSet();
                this._productBarCodeSet.ProductBarCodeSetId = Guid.NewGuid().ToString();
                this._productBarCodeSet.NationalCode = "471";
                this._productBarCodeSet.CompanyCode = "00000";
                this.tag = 1;
            }
            this.textEdit1.Text = this._productBarCodeSet.NationalCode;
            this.textEdit2.Text = this._productBarCodeSet.CompanyCode;
        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //char.IsDigit(e.KeyChar) 这种方式不严谨，可输入全角数字
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
                e.Handled = true;
            if (this.textEdit1.Text.Length >= 3 && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void textEdit2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
                e.Handled = true;
            if (this.textEdit2.Text.Length >= 5 && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textEdit1.Text))
                this._productBarCodeSet.NationalCode = "471";
            else
                this._productBarCodeSet.NationalCode = this.textEdit1.Text;
            if (string.IsNullOrEmpty(this.textEdit2.Text))
                this._productBarCodeSet.CompanyCode = "00000";
            else
                this._productBarCodeSet.CompanyCode = this.textEdit2.Text;

            if (this.tag == 0)
                productBarCodeSetManager.Update(this._productBarCodeSet);
            else
            {
                productBarCodeSetManager.Insert(this._productBarCodeSet);
                this.tag = 0;
            }
            MessageBox.Show("設定成功！", this.Text, MessageBoxButtons.OK);
        }

        /// <summary>
        /// 生成商品條碼
        /// </summary>
        /// <returns></returns>
        public string RandomBarCode()
        {
            int a = this._productBarCodeSet.ValueKey.HasValue ? this._productBarCodeSet.ValueKey.Value : 0;
            string s = string.Empty;
            if (a < 100000)
            {
                s = a.ToString("00000");
                return this._productBarCodeSet.NationalCode + this._productBarCodeSet.CompanyCode + s;
            }
            else
            {
                MessageBox.Show("條碼編號超出使用範圍，請聯繫管理員！", "錯誤！", MessageBoxButtons.OK);
                return "";
            }
        }
    }
}