﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PortManager.autogenerated.cs
// author: mayanjun
// create date：2018/11/11 17:33:41
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class PortManager
    {
		///<summary>
		/// Data accessor of dbo.Port
		///</summary>
		private static readonly DA.IPortAccessor accessor = (DA.IPortAccessor)Accessors.Get("PortAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.Port Get(string portId)
		{
			return accessor.Get(portId);
		}
		
		public bool HasRows(string portId)
		{
			return accessor.HasRows(portId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		public bool Exists(string id)
		{
			return accessor.Exists(id);
		}
		
		public Model.Port GetById(string id)
		{
			return accessor.GetById(id);
		}		
		public bool ExistsExcept(Model.Port e)
		{
			return accessor.ExistsExcept(e);
		}
		
		
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.Port> Select()
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
		public IList<Model.Port> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		public bool ExistsPrimary(string id)
		{
		    return accessor.ExistsPrimary(id);	
	    }
		
    }
}