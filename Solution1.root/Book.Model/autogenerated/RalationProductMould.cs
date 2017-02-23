﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：RalationProductMould.autogenerated.cs
// author: peidun
// create date：2009-08-03 10:49:37
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
	public partial class RalationProductMould
	{
		#region Data

		/// <summary>
		/// 主键
		/// </summary>
		private string _primaryKeyId;
		
		/// <summary>
		/// 模板编号
		/// </summary>
		private string _mouldId;
		
		/// <summary>
		/// 商品编号
		/// </summary>
		private string _productId;
		
		/// <summary>
		/// 商品
		/// </summary>
		private Product product;
		/// <summary>
		/// 产品模具
		/// </summary>
		private ProductMould mould;
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 主键
		/// </summary>
		public string PrimaryKeyId
		{
			get 
			{
				return this._primaryKeyId;
			}
			set 
			{
				this._primaryKeyId = value;
			}
		}

		/// <summary>
		/// 模板编号
		/// </summary>
		public string MouldId
		{
			get 
			{
				return this._mouldId;
			}
			set 
			{
				this._mouldId = value;
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
		/// 商品
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
		/// 产品模具
		/// </summary>
		public virtual ProductMould Mould
		{
			get
			{
				return this.mould;
			}
			set
			{
				this.mould = value;
			}
			
		}
		/// <summary>
		/// 主键
		/// </summary>
		public readonly static string PROPERTY_PRIMARYKEYID = "PrimaryKeyId";
		
		/// <summary>
		/// 模板编号
		/// </summary>
		public readonly static string PROPERTY_MOULDID = "MouldId";
		
		/// <summary>
		/// 商品编号
		/// </summary>
		public readonly static string PROPERTY_PRODUCTID = "ProductId";
		

		#endregion
	}
}