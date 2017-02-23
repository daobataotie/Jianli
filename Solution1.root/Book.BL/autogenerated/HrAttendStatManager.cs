﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：HrAttendStatManager.autogenerated.cs
// author: mayanjun
// create date：2010-7-6 11:09:54
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class HrAttendStatManager
    {
		///<summary>
		/// Data accessor of dbo.HrAttendStat
		///</summary>
		private static readonly DA.IHrAttendStatAccessor accessor = (DA.IHrAttendStatAccessor)Accessors.Get("HrAttendStatAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.HrAttendStat Get(string hrAttendStatId)
		{
			return accessor.Get(hrAttendStatId);
		}
		
		public bool HasRows(string hrAttendStatId)
		{
			return accessor.HasRows(hrAttendStatId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.HrAttendStat> Select()
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
		public IList<Model.HrAttendStat> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		public bool ExistsPrimary(string id)
		{
		    return accessor.ExistsPrimary(id);	
	    }
		
    }
}