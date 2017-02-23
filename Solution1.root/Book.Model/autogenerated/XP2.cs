﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：XP2.autogenerated.cs
// author: peidun
// create date：2009-10-13 上午 11:45:18
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
	public partial class XP2
	{
		#region Data

		/// <summary>
		/// 冲销应付款情况2编号
		/// </summary>
		private string _xP2Id;
		
		/// <summary>
		/// 销售退货编号
		/// </summary>
		private string _invoiceXTId;
		
		/// <summary>
		/// 付款单据编号
		/// </summary>
		private string _invoiceFKId;
		
		/// <summary>
		/// 冲销应付款情况2冲销金额
		/// </summary>
		private decimal? _xP2Money;
		
		/// <summary>
		/// 出货退货单
		/// </summary>
		private InvoiceXT invoiceXT;
		/// <summary>
		/// 付款单
		/// </summary>
		private InvoiceFK invoiceFK;
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 冲销应付款情况2编号
		/// </summary>
		public string XP2Id
		{
			get 
			{
				return this._xP2Id;
			}
			set 
			{
				this._xP2Id = value;
			}
		}

		/// <summary>
		/// 销售退货编号
		/// </summary>
		public string InvoiceXTId
		{
			get 
			{
				return this._invoiceXTId;
			}
			set 
			{
				this._invoiceXTId = value;
			}
		}

		/// <summary>
		/// 付款单据编号
		/// </summary>
		public string InvoiceFKId
		{
			get 
			{
				return this._invoiceFKId;
			}
			set 
			{
				this._invoiceFKId = value;
			}
		}

		/// <summary>
		/// 冲销应付款情况2冲销金额
		/// </summary>
		public decimal? XP2Money
		{
			get 
			{
				return this._xP2Money;
			}
			set 
			{
				this._xP2Money = value;
			}
		}
	
		/// <summary>
		/// 出货退货单
		/// </summary>
		public virtual InvoiceXT InvoiceXT
		{
			get
			{
				return this.invoiceXT;
			}
			set
			{
				this.invoiceXT = value;
			}
			
		}
		/// <summary>
		/// 付款单
		/// </summary>
		public virtual InvoiceFK InvoiceFK
		{
			get
			{
				return this.invoiceFK;
			}
			set
			{
				this.invoiceFK = value;
			}
			
		}
		/// <summary>
		/// 冲销应付款情况2编号
		/// </summary>
		public readonly static string PROPERTY_XP2ID = "XP2Id";
		
		/// <summary>
		/// 销售退货编号
		/// </summary>
		public readonly static string PROPERTY_INVOICEXTID = "InvoiceXTId";
		
		/// <summary>
		/// 付款单据编号
		/// </summary>
		public readonly static string PROPERTY_INVOICEFKID = "InvoiceFKId";
		
		/// <summary>
		/// 冲销应付款情况2冲销金额
		/// </summary>
		public readonly static string PROPERTY_XP2MONEY = "XP2Money";
		

		#endregion
	}
}