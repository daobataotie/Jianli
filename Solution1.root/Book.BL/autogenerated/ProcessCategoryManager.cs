﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：ProcessCategoryManager.autogenerated.cs
// author: peidun
// create date：2010-4-20 11:36:18
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class ProcessCategoryManager
    {
		///<summary>
		/// Data accessor of dbo.ProcessCategory
		///</summary>
		private static readonly DA.IProcessCategoryAccessor accessor = (DA.IProcessCategoryAccessor)Accessors.Get("ProcessCategoryAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.ProcessCategory Get(string processCategoryId)
		{
			return accessor.Get(processCategoryId);
		}
		
		public bool HasRows(string processCategoryId)
		{
			return accessor.HasRows(processCategoryId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		public bool Exists(string id)
		{
			return accessor.Exists(id);
		}
		
		public Model.ProcessCategory GetById(string id)
		{
			return accessor.GetById(id);
		}		
		public bool ExistsExcept(Model.ProcessCategory e)
		{
			return accessor.ExistsExcept(e);
		}
		
		
		public bool HasRowsBefore(Model.ProcessCategory e)
		{
			return accessor.HasRowsBefore(e);
		}
		
		public bool HasRowsAfter(Model.ProcessCategory e)
		{
			return accessor.HasRowsAfter(e);
		}
		
		public Model.ProcessCategory GetFirst()
		{
			return accessor.GetFirst();
		}
		
		public Model.ProcessCategory GetLast()
		{
			return accessor.GetLast();
		}
		
		public Model.ProcessCategory GetPrev(Model.ProcessCategory e)
		{
			return accessor.GetPrev(e);
		}
		
		public Model.ProcessCategory GetNext(Model.ProcessCategory e)
		{
			return accessor.GetNext(e);
		}
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.ProcessCategory> Select()
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
		public IList<Model.ProcessCategory> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		public bool ExistsPrimary(string id)
		{
		    return accessor.ExistsPrimary(id);	
	    }
		
    }
}