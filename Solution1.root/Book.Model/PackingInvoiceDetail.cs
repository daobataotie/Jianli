//------------------------------------------------------------------------------
//
// file name：PackingInvoiceDetail.cs
// author: mayanjun
// create date：2018/12/2 16:05:25
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class PackingInvoiceDetail
    {

        /// <summary>
        /// 客户编号
        /// </summary>
        public string CUSTNO
        {
            get
            {
                string str = "";
                if (this.PackingInvoiceHeader != null && this.PackingInvoiceHeader.Customer != null)
                    str = this.PackingInvoiceHeader.Customer.Id;
                return str;
            }
        }

        public string ShowQty
        {

            get
            {
                return string.Format("{0} {1}", this.Quantity, (string.IsNullOrEmpty(this.PackingInvoiceHeader.Unit) ? "PCS" : this.PackingInvoiceHeader.Unit));
            }
        }

        public string Currency { get; set; }

        public string ShowUnitPrice
        {
            get
            {
                if (string.IsNullOrEmpty(Currency))
                    return this.UnitPrice.Value.ToString("0.##");
                else
                    return string.Format("{0} {1}", this.UnitPrice, Currency);
            }
        }

        public string ShowAmount
        {
            get
            {
                if (string.IsNullOrEmpty(Currency))
                    return this.Amount.Value.ToString("0.##");
                else
                    return string.Format("{0} {1}", this.Amount, Currency);
            }
        }

        public readonly static string PRO_CUSTNO = "CUSTNO";

        public readonly static string PRO_ShowQty = "ShowQty";
    }
}