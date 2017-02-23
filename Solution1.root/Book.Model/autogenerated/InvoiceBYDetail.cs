﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：InvoiceBYDetail.autogenerated.cs
// author: peidun
// create date：2009-10-13 上午 11:45:13
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
	public partial class InvoiceBYDetail
	{
		#region Data

		/// <summary>
		/// 报溢单货品编号
		/// </summary>
		private string _invoiceBYDetailId;
		
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
		/// 报溢单货品数量
		/// </summary>
		private double? _invoiceBYDetailQuantity;
		
		/// <summary>
		/// 报溢单货品备注
		/// </summary>
		private string _invoiceBYDetailNote;
		
		/// <summary>
		/// 单位
		/// </summary>
		private string _invoiceProductUnit;
		
		/// <summary>
		/// 库库货位
		/// </summary>
		private DepotPosition depotPosition;
		/// <summary>
		/// 产品
		/// </summary>
		private Product product;
		/// <summary>
		/// 报溢单
		/// </summary>
		private InvoiceBY invoice;
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 报溢单货品编号
		/// </summary>
		public string InvoiceBYDetailId
		{
			get 
			{
				return this._invoiceBYDetailId;
			}
			set 
			{
				this._invoiceBYDetailId = value;
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
		/// 报溢单货品数量
		/// </summary>
		public double? InvoiceBYDetailQuantity
		{
			get 
			{
				return this._invoiceBYDetailQuantity;
			}
			set 
			{
				this._invoiceBYDetailQuantity = value;
			}
		}

		/// <summary>
		/// 报溢单货品备注
		/// </summary>
		public string InvoiceBYDetailNote
		{
			get 
			{
				return this._invoiceBYDetailNote;
			}
			set 
			{
				this._invoiceBYDetailNote = value;
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
		/// 报溢单
		/// </summary>
		public virtual InvoiceBY Invoice
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
		/// 报溢单货品编号
		/// </summary>
		public readonly static string PROPERTY_INVOICEBYDETAILID = "InvoiceBYDetailId";
		
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
		/// 报溢单货品数量
		/// </summary>
		public readonly static string PROPERTY_INVOICEBYDETAILQUANTITY = "InvoiceBYDetailQuantity";
		
		/// <summary>
		/// 报溢单货品备注
		/// </summary>
		public readonly static string PROPERTY_INVOICEBYDETAILNOTE = "InvoiceBYDetailNote";
		
		/// <summary>
		/// 单位
		/// </summary>
		public readonly static string PROPERTY_INVOICEPRODUCTUNIT = "InvoiceProductUnit";
		

		#endregion
	}
}