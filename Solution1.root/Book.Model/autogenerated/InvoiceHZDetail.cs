﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：InvoiceHZDetail.autogenerated.cs
// author: peidun
// create date：2009-10-13 上午 11:45:14
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
	public partial class InvoiceHZDetail
	{
		#region Data

		/// <summary>
		/// 获赠单货品编号
		/// </summary>
		private string _invoiceHZDetailId;
		
		/// <summary>
		/// 位置编号
		/// </summary>
		private string _depotPositionId;
		
		/// <summary>
		/// 商品编号
		/// </summary>
		private string _productId;
		
		/// <summary>
		/// 单据编号
		/// </summary>
		private string _invoiceId;
		
		/// <summary>
		/// 获赠单货品单价
		/// </summary>
		private decimal? _invoiceHZDetailPrice;
		
		/// <summary>
		/// 获赠单货品数量
		/// </summary>
		private double? _invoiceHZDetailQuantity;
		
		/// <summary>
		/// 获赠单货品金额
		/// </summary>
		private decimal? _invoiceHZDetailMoney;
		
		/// <summary>
		/// 获赠单货品备注
		/// </summary>
		private string _invoiceHZDetailNote;
		
		/// <summary>
		/// 单位
		/// </summary>
		private string _invoiceProductUnit;
		
		/// <summary>
		/// 获赠单
		/// </summary>
		private InvoiceHZ invoice;
		/// <summary>
		/// 库库货位
		/// </summary>
		private DepotPosition depotPosition;
		/// <summary>
		/// 产品
		/// </summary>
		private Product product;
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 获赠单货品编号
		/// </summary>
		public string InvoiceHZDetailId
		{
			get 
			{
				return this._invoiceHZDetailId;
			}
			set 
			{
				this._invoiceHZDetailId = value;
			}
		}

		/// <summary>
		/// 位置编号
		/// </summary>
		public string DepotPositionId
		{
			get 
			{
				return this._depotPositionId;
			}
			set 
			{
				this._depotPositionId = value;
			}
		}

		/// <summary>
		/// 商品编号
		/// </summary>
		public string ProductId
		{
			get 
			{
				return this._productId;
			}
			set 
			{
				this._productId = value;
			}
		}

		/// <summary>
		/// 单据编号
		/// </summary>
		public string InvoiceId
		{
			get 
			{
				return this._invoiceId;
			}
			set 
			{
				this._invoiceId = value;
			}
		}

		/// <summary>
		/// 获赠单货品单价
		/// </summary>
		public decimal? InvoiceHZDetailPrice
		{
			get 
			{
				return this._invoiceHZDetailPrice;
			}
			set 
			{
				this._invoiceHZDetailPrice = value;
			}
		}

		/// <summary>
		/// 获赠单货品数量
		/// </summary>
		public double? InvoiceHZDetailQuantity
		{
			get 
			{
				return this._invoiceHZDetailQuantity;
			}
			set 
			{
				this._invoiceHZDetailQuantity = value;
			}
		}

		/// <summary>
		/// 获赠单货品金额
		/// </summary>
		public decimal? InvoiceHZDetailMoney
		{
			get 
			{
				return this._invoiceHZDetailMoney;
			}
			set 
			{
				this._invoiceHZDetailMoney = value;
			}
		}

		/// <summary>
		/// 获赠单货品备注
		/// </summary>
		public string InvoiceHZDetailNote
		{
			get 
			{
				return this._invoiceHZDetailNote;
			}
			set 
			{
				this._invoiceHZDetailNote = value;
			}
		}

		/// <summary>
		/// 单位
		/// </summary>
		public string InvoiceProductUnit
		{
			get 
			{
				return this._invoiceProductUnit;
			}
			set 
			{
				this._invoiceProductUnit = value;
			}
		}
	
		/// <summary>
		/// 获赠单
		/// </summary>
		public virtual InvoiceHZ Invoice
		{
			get
			{
				return this.invoice;
			}
			set
			{
				this.invoice = value;
			}
			
		}
		/// <summary>
		/// 库库货位
		/// </summary>
		public virtual DepotPosition DepotPosition
		{
			get
			{
				return this.depotPosition;
			}
			set
			{
				this.depotPosition = value;
			}
			
		}
		/// <summary>
		/// 产品
		/// </summary>
		public virtual Product Product
		{
			get
			{
				return this.product;
			}
			set
			{
				this.product = value;
			}
			
		}
		/// <summary>
		/// 获赠单货品编号
		/// </summary>
		public readonly static string PROPERTY_INVOICEHZDETAILID = "InvoiceHZDetailId";
		
		/// <summary>
		/// 位置编号
		/// </summary>
		public readonly static string PROPERTY_DEPOTPOSITIONID = "DepotPositionId";
		
		/// <summary>
		/// 商品编号
		/// </summary>
		public readonly static string PROPERTY_PRODUCTID = "ProductId";
		
		/// <summary>
		/// 单据编号
		/// </summary>
		public readonly static string PROPERTY_INVOICEID = "InvoiceId";
		
		/// <summary>
		/// 获赠单货品单价
		/// </summary>
		public readonly static string PROPERTY_INVOICEHZDETAILPRICE = "InvoiceHZDetailPrice";
		
		/// <summary>
		/// 获赠单货品数量
		/// </summary>
		public readonly static string PROPERTY_INVOICEHZDETAILQUANTITY = "InvoiceHZDetailQuantity";
		
		/// <summary>
		/// 获赠单货品金额
		/// </summary>
		public readonly static string PROPERTY_INVOICEHZDETAILMONEY = "InvoiceHZDetailMoney";
		
		/// <summary>
		/// 获赠单货品备注
		/// </summary>
		public readonly static string PROPERTY_INVOICEHZDETAILNOTE = "InvoiceHZDetailNote";
		
		/// <summary>
		/// 单位
		/// </summary>
		public readonly static string PROPERTY_INVOICEPRODUCTUNIT = "InvoiceProductUnit";
		

		#endregion
	}
}