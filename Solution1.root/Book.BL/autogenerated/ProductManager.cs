﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：ProductManager.autogenerated.cs
// author: peidun
// create date：2009-10-13 上午 11:45:02
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class ProductManager
    {
		///<summary>
		/// Data accessor of dbo.Product
		///</summary>
		private static readonly DA.IProductAccessor accessor = (DA.IProductAccessor)Accessors.Get("ProductAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.Product Get(string productId)
		{
			return accessor.Get(productId);
		}
		
		public bool HasRows(string productId)
		{
			return accessor.HasRows(productId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		public bool Exists(string id)
		{
			return accessor.Exists(id);
		}
		
		public Model.Product GetById(string id)
		{
			return accessor.GetById(id);
		}
		
		public bool ExistsExcept(Model.Product e)
		{
			return accessor.ExistsExcept(e);
		}
		public bool HasRowsBefore(Model.Product e)
		{
			return accessor.HasRowsBefore(e);
		}
		
		public bool HasRowsAfter(Model.Product e)
		{
			return accessor.HasRowsAfter(e);
		}
		
		public Model.Product GetFirst()
		{
			return accessor.GetFirst();
		}
		
		public Model.Product GetLast()
		{
			return accessor.GetLast();
		}
		
		public Model.Product GetPrev(Model.Product e)
		{
			return accessor.GetPrev(e);
		}
		
		public Model.Product GetNext(Model.Product e)
		{
			return accessor.GetNext(e);
		}
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.Product> Select()
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
		public IList<Model.Product> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		
    }
}