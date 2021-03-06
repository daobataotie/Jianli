﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：MaterialManager.autogenerated.cs
// author: mayanjun
// create date：2013-5-4 16:16:51
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class MaterialManager
    {
		///<summary>
		/// Data accessor of dbo.Material
		///</summary>
		private static readonly DA.IMaterialAccessor accessor = (DA.IMaterialAccessor)Accessors.Get("MaterialAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.Material Get(string materialId)
		{
			return accessor.Get(materialId);
		}
		
		public bool HasRows(string materialId)
		{
			return accessor.HasRows(materialId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		public bool Exists(string id)
		{
			return accessor.Exists(id);
		}
		
		public Model.Material GetById(string id)
		{
			return accessor.GetById(id);
		}		
		public bool ExistsExcept(Model.Material e)
		{
			return accessor.ExistsExcept(e);
		}
		
		
		public bool HasRowsBefore(Model.Material e)
		{
			return accessor.HasRowsBefore(e);
		}
		
		public bool HasRowsAfter(Model.Material e)
		{
			return accessor.HasRowsAfter(e);
		}
		
		public Model.Material GetFirst()
		{
			return accessor.GetFirst();
		}
		
		public Model.Material GetLast()
		{
			return accessor.GetLast();
		}
		
		public Model.Material GetPrev(Model.Material e)
		{
			return accessor.GetPrev(e);
		}
		
		public Model.Material GetNext(Model.Material e)
		{
			return accessor.GetNext(e);
		}
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.Material> Select()
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
		public IList<Model.Material> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		public bool ExistsPrimary(string id)
		{
		    return accessor.ExistsPrimary(id);	
	    }
		
    }
}
