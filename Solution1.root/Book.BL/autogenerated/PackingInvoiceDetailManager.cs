﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PackingInvoiceDetailManager.autogenerated.cs
// author: mayanjun
// create date：2018/12/2 16:05:25
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class PackingInvoiceDetailManager
    {
		///<summary>
		/// Data accessor of dbo.PackingInvoiceDetail
		///</summary>
		private static readonly DA.IPackingInvoiceDetailAccessor accessor = (DA.IPackingInvoiceDetailAccessor)Accessors.Get("PackingInvoiceDetailAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.PackingInvoiceDetail Get(string packingInvoiceDetailId)
		{
			return accessor.Get(packingInvoiceDetailId);
		}
		
		public bool HasRows(string packingInvoiceDetailId)
		{
			return accessor.HasRows(packingInvoiceDetailId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.PackingInvoiceDetail> Select()
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
		public IList<Model.PackingInvoiceDetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		public bool ExistsPrimary(string id)
		{
		    return accessor.ExistsPrimary(id);	
	    }
		
    }
}
