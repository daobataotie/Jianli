﻿//------------------------------------------------------------------------------
//
// file name：InvoiceLHDetail.cs
// author: mayanjun
// create date：2018/10/20 11:17:54
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class InvoiceLHDetail
    {
        public string ProductShortId
        {
            get
            {
                if (Product != null)
                {
                    if (Product.Id.Contains("{"))
                        return Product.Id.Substring(0, (Product.Id.IndexOf('{')));
                    else
                        return Product.Id;
                }
                else
                    return "";
            }
        }

        public string InvoiceXOCusId
        {
            get
            {
                return InvoiceXODetail.Invoice.CustomerInvoiceXOId;
            }
        }
    }
}