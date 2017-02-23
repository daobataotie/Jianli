﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：ProductProcessManager.autogenerated.cs
// author: peidun
// create date：2010-1-27 10:46:37
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class ProductProcessManager
    {
		///<summary>
		/// Data accessor of dbo.ProductProcess
		///</summary>
		private static readonly DA.IProductProcessAccessor accessor = (DA.IProductProcessAccessor)Accessors.Get("ProductProcessAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.ProductProcess Get(string productProcessId)
		{
			return accessor.Get(productProcessId);
		}
		
		public bool HasRows(string productProcessId)
		{
			return accessor.HasRows(productProcessId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		public bool HasRowsBefore(Model.ProductProcess e)
		{
			return accessor.HasRowsBefore(e);
		}
		
		public bool HasRowsAfter(Model.ProductProcess e)
		{
			return accessor.HasRowsAfter(e);
		}
		
		public Model.ProductProcess GetFirst()
		{
			return accessor.GetFirst();
		}
		
		public Model.ProductProcess GetLast()
		{
			return accessor.GetLast();
		}
		
		public Model.ProductProcess GetPrev(Model.ProductProcess e)
		{
			return accessor.GetPrev(e);
		}
		
		public Model.ProductProcess GetNext(Model.ProductProcess e)
		{
			return accessor.GetNext(e);
		}
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.ProductProcess> Select()
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
		public IList<Model.ProductProcess> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		
    }
}