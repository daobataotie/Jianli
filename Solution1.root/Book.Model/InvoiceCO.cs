//------------------------------------------------------------------------------
//
// file name:InvoiceCO.cs
// author: peidun
// create date:2008/6/6 10:00:36
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
    /// <summary>
    /// 采购订单
    /// </summary>
    [Serializable]
    public partial class InvoiceCO : Invoice
    {
        private System.Collections.Generic.IList<Model.InvoiceCODetail> details;

        public System.Collections.Generic.IList<Model.InvoiceCODetail> Details
        {
            get { return details; }
            set { details = value; }
        }
        private string _supplierFullName;
        public string SupplierFullName
        {
            get { return _supplierFullName; }
            set { _supplierFullName = value; }
        }

        /// <summary>
        /// 採購訂單是否被選中
        /// </summary>
        private bool isChecked = false;
        public bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; }
        }

        public string PrintTax
        {
            get
            {
                string s = this.InvoiceTax.HasValue ? global::Helper.DateTimeParse.GetSiSheWuRu(this.InvoiceTax.Value, 2).ToString("N") : "";
                if (!string.IsNullOrEmpty(s) && this.AtCurrencyCategory != null)
                    s = AtCurrencyCategory.EnglishName + s;
                return s;
            }
        }

        public string PrintAmount
        {
            get
            {
                string s = this.InvoiceTotal.HasValue ? global::Helper.DateTimeParse.GetSiSheWuRu(this.InvoiceTotal.Value, 2).ToString("N") : "";
                if (!string.IsNullOrEmpty(s) && this.AtCurrencyCategory != null)
                    s = AtCurrencyCategory.EnglishName + s;
                return s;
            }
        }

        public readonly static string PRO_PrintTax = "PrintTax";
        public readonly static string PRO_PrintAmount = "PrintAmount";
    }
}
