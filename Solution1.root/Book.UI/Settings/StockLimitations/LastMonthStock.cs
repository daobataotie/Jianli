using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using Microsoft.Office.Interop.Excel;

namespace Book.UI.Settings.StockLimitations
{
    public partial class LastMonthStock : DevExpress.XtraEditors.XtraForm
    {
        List<Model.Product> ProList { get; set; }
        private BL.StockManager stockManager = new Book.BL.StockManager();

        public LastMonthStock()
        {
            InitializeComponent();

            this.ncc_Customer.Choose = new Settings.BasicData.Customs.ChooseCustoms();
        }

        private void btn_checkProduct_Click(object sender, EventArgs e)
        {
            SearchProductForm search = new SearchProductForm(ProList);
            if (search.ShowDialog(this) == DialogResult.OK)
            {
                ProList = search.CheckedProductList;
            }
        }

        private void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            if (ProList == null || ProList.Count == 0)
            {
                MessageBox.Show("請先選擇商品", this.Text, MessageBoxButtons.OK);
                return;
            }

            Dictionary<Model.Product, List<double>> dic = new Dictionary<Model.Product, List<double>>();
            DateTime lastMonth = DateTime.Now.AddMonths(-1);
            int totalDays = DateTime.DaysInMonth(lastMonth.Year, lastMonth.Month);

            foreach (var item in ProList)
            {
                List<double> stockQuantityList = new List<double>();
                for (int i = 1; i <= totalDays; i++)
                {
                    DateTime date = DateTime.Parse(lastMonth.Year.ToString() + "-" + lastMonth.Month.ToString() + "-" + i.ToString()).AddDays(1).AddSeconds(-1);
                    var stockList = this.stockManager.SelectJiShi(item.ProductId, date, DateTime.Now);
                    double quantity = item.StocksQuantity.Value;

                    if (stockList != null && stockList.Count > 0)
                    {
                        foreach (Model.StockSeach stock in stockList.ToList<Model.StockSeach>())
                        {
                            if (stock.InvoiceTypeIndex == 0)
                            {
                                quantity += stock.InvoiceQuantity.Value;
                            }
                            if (stock.InvoiceTypeIndex == 1)
                            {
                                quantity -= stock.InvoiceQuantity.Value;
                            }
                            if (stock.InvoiceTypeIndex == 3)
                            {
                                quantity += stock.StockCheckBookQuantity.Value;
                            }
                        }
                    }
                    stockQuantityList.Add(quantity);
                }

                dic.Add(item, stockQuantityList);
            }

            //Export Excel

            Type objClassType = null;
            objClassType = Type.GetTypeFromProgID("Excel.Application");
            if (objClassType == null)
            {
                MessageBox.Show("本機沒有安裝Excel", "提示！", MessageBoxButtons.OK);
                return;
            }

            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(true);
                excel.Cells.ColumnWidth = 12;
                excel.Rows.RowHeight = 20;

                #region Header
                excel.get_Range(excel.Cells[1, 2], excel.Cells[1, 1 + dic.Count]).ColumnWidth = 30;
                excel.Cells[1, 1] = lastMonth.Month.ToString() + "月份寄倉明細";
                excel.Cells[1, 1 + dic.Count] = "製表日期：" + DateTime.Now.ToString("yyyy/MM/dd");
                excel.get_Range(excel.Cells[2, 1], excel.Cells[2, 3]).MergeCells = true;
                excel.get_Range(excel.Cells[2, 4], excel.Cells[2, 6]).MergeCells = true;
                excel.Cells[2, 1] = "客戶名稱：" + (ncc_Customer.EditValue == null ? "" : (ncc_Customer.EditValue as Model.Customer).ToString());
                excel.Cells[2, 4] = "統一編號：" + (ncc_Customer.EditValue == null ? "" : (ncc_Customer.EditValue as Model.Customer).CustomerNumber);
                excel.Cells[3, 1] = "日期/料號";

                int rowIndex = 4;

                int colIndex = 1;
                foreach (var pro in dic)
                {
                    excel.Cells[3, 1 + colIndex] = pro.Key.ProductName;

                    rowIndex = 4;
                    foreach (var stock in pro.Value)
                    {
                        excel.Cells[rowIndex, 1 + colIndex] = stock.ToString();
                        rowIndex++;
                    }

                    colIndex++;
                }
                excel.Cells[3, 1 + colIndex] = "每日庫存";

                rowIndex = 4;
                for (int i = 1; i <= totalDays; i++)
                {
                    excel.Cells[rowIndex, 1] = string.Format("{0}月{1}日", lastMonth.Month, i);
                    //excel.Cells[rowIndex, 2 + dic.Count] = dic.Values.Sum(v => v.Where(d => v.IndexOf(d) == i - 1).Sum());
                    double sum = 0;
                    foreach (var item in dic.Values)
                    {
                        sum += item[i - 1];
                    }
                    excel.Cells[rowIndex, 2 + dic.Count] = sum;

                    rowIndex++;
                }


                excel.Visible = true;

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel未生成完畢，請勿操作，并重新點擊按鈕生成數據！", "提示！", MessageBoxButtons.OK);
                return;
            }
        }
    }


}