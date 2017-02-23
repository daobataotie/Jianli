﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：CustomerContactManager.autogenerated.cs
// author: peidun
// create date：2009-10-26 下午 05:56:40
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class CustomerContactManager
    {
		///<summary>
		/// Data accessor of dbo.CustomerContact
		///</summary>
		private static readonly DA.ICustomerContactAccessor accessor = (DA.ICustomerContactAccessor)Accessors.Get("CustomerContactAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.CustomerContact Get(string customerContactId)
		{
			return accessor.Get(customerContactId);
		}
		
		public bool HasRows(string customerContactId)
		{
			return accessor.HasRows(customerContactId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.CustomerContact> Select()
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
		public IList<Model.CustomerContact> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		
    }
}