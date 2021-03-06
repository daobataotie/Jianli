﻿//------------------------------------------------------------------------------
//
// file name:InvoiceXSDetail.cs
// author: peidun
// create date:2008/6/6 10:00:37
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
    /// <summary>
    /// 出货单詳細
    /// </summary>
    [Serializable]
    public partial class InvoiceXSDetail
    {
        private string kind;

        public string Kind
        {
            get
            {
                switch (this.kind)
                {
                    case "xs":
                        return Properties.Resource.XS;
                    case "xt":
                        return Properties.Resource.XT;
                    default:
                        return this.kind;
                }
            }
            set { kind = value; }
        }

        public readonly static string PROPERTY_KIND = "Kind";

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is InvoiceXSDetail)
            {
                if ((obj as InvoiceXSDetail)._invoiceXSDetailId == _invoiceXSDetailId)
                    return true;
            }
            return false;
        }
        private double? _invoiceXSDetailQuantity0;
        /// <summary>
        /// 未出货
        /// </summary>
        public double? InvoiceXSDetailQuantity0
        {

            get { return this.InvoiceXODetail == null ? 0 : this.InvoiceXODetail.InvoiceXODetailQuantity0; }
            set { _invoiceXSDetailQuantity0 = value; }
        }

        private double? _invoiceXODetailBeenQuantity;
        /// <summary>
        /// 已出货
        /// </summary>
        public double? InvoiceXODetailBeenQuantity
        {
            get { return this.InvoiceXODetail == null ? 0 : this.InvoiceXODetail.InvoiceXODetailBeenQuantity; }
            set { _invoiceXODetailBeenQuantity = value; }
        }
        private double? _invoiceXODetailQuantity;
        /// <summary>
        ///订购数量
        /// </summary>
        public double? InvoiceXODetailQuantity
        {
            get
            {
                return this.InvoiceXODetail == null ? 0 : this.InvoiceXODetail.InvoiceXODetailQuantity;
            }
            set { _invoiceXODetailQuantity = value; }
        }
        private string _Id;
        public string Id
        {
            //get { return this.PrimaryKey.CustomerProductId; }
            get { return this.Product == null ? null : this.Product.ProductId; }
            set { _Id = value; }
        }


        private double? _xiaoji;
        public double? xiaoji
        {
            get { return this._invoiceXSDetailQuantity * Convert.ToDouble(InvoiceXSDetailPrice); }
            set { _xiaoji = value; }
        }
        private bool? _checked;
        public bool? Checked
        {
            get { return _checked; }
            set { _checked = value; }
        }

        public string CurrencyEN
        {
            get
            {
                return Model.ExchangeRate.GetCurrencyENName(this.Currency);
            }
        }

        public string Product_Id { get; set; }
        public string ProductName { get; set; }
        public string ProductSpecification { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public double? InvoiceXODetailQuantity1 { get; set; }
        public double? InvoiceXODetailQuantity0 { get; set; }
        public string CustomerInvoiceXOId { get; set; }

        public decimal? TaibiAmount { get { return this.InvoiceXSDetailMoney * this.ExchangeRate; } }

        public decimal? TaibiAmountForGroup { get; set; }

        public string CusXOIdForGroup { get; set; }

        public static readonly string PRO_xiaoji = "xiaoji";
        public static readonly string PRO_CurrencyEN = "CurrencyEN";
    }
}
