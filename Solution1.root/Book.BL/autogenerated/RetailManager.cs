﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：RetailManager.autogenerated.cs
// author: peidun
// create date：2009-10-13 上午 11:45:02
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class RetailManager
    {
		///<summary>
		/// Data accessor of dbo.Retail
		///</summary>
		private static readonly DA.IRetailAccessor accessor = (DA.IRetailAccessor)Accessors.Get("RetailAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.Retail Get(string retailId)
		{
			return accessor.Get(retailId);
		}
		
		public bool HasRows(string retailId)
		{
			return accessor.HasRows(retailId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.Retail> Select()
		{
			return accessor.Select();
		}
		
		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int Count()
		{
			return accessor.Count();
		}
		
		/// <summary>
		/// 获取指定状态、指定分页，并按指定要求排序的记录
		/// </summary>
		public IList<Model.Retail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		
    }
}