﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：AtSummonManager.autogenerated.cs
// author: mayanjun
// create date：2012-03-23 11:05:22
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class AtSummonManager
    {
		///<summary>
		/// Data accessor of dbo.AtSummon
		///</summary>
		private static readonly DA.IAtSummonAccessor accessor = (DA.IAtSummonAccessor)Accessors.Get("AtSummonAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.AtSummon Get(string summonId)
		{
			return accessor.Get(summonId);
		}
		
		public bool HasRows(string summonId)
		{
			return accessor.HasRows(summonId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		public bool Exists(string id)
		{
			return accessor.Exists(id);
		}
		
		public Model.AtSummon GetById(string id)
		{
			return accessor.GetById(id);
		}		
		public bool ExistsExcept(Model.AtSummon e)
		{
			return accessor.ExistsExcept(e);
		}
		
		
		public bool HasRowsBefore(Model.AtSummon e)
		{
			return accessor.HasRowsBefore(e);
		}
		
		public bool HasRowsAfter(Model.AtSummon e)
		{
			return accessor.HasRowsAfter(e);
		}
		
		public Model.AtSummon GetFirst()
		{
			return accessor.GetFirst();
		}
		
		public Model.AtSummon GetLast()
		{
			return accessor.GetLast();
		}
		
		public Model.AtSummon GetPrev(Model.AtSummon e)
		{
			return accessor.GetPrev(e);
		}
		
		public Model.AtSummon GetNext(Model.AtSummon e)
		{
			return accessor.GetNext(e);
		}
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.AtSummon> Select()
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
		public IList<Model.AtSummon> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		public bool ExistsPrimary(string id)
		{
		    return accessor.ExistsPrimary(id);	
	    }
		
    }
}