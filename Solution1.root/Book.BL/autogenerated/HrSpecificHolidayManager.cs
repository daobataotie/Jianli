﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：HrSpecificHolidayManager.autogenerated.cs
// author: mayanjun
// create date：2010-5-28 14:21:43
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class HrSpecificHolidayManager
    {
		///<summary>
		/// Data accessor of dbo.HrSpecificHoliday
		///</summary>
		private static readonly DA.IHrSpecificHolidayAccessor accessor = (DA.IHrSpecificHolidayAccessor)Accessors.Get("HrSpecificHolidayAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.HrSpecificHoliday Get(string hrSpecificHoliday)
		{
			return accessor.Get(hrSpecificHoliday);
		}
		
		public bool HasRows(string hrSpecificHoliday)
		{
			return accessor.HasRows(hrSpecificHoliday);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		
		public bool HasRowsBefore(Model.HrSpecificHoliday e)
		{
			return accessor.HasRowsBefore(e);
		}
		
		public bool HasRowsAfter(Model.HrSpecificHoliday e)
		{
			return accessor.HasRowsAfter(e);
		}
		
		public Model.HrSpecificHoliday GetFirst()
		{
			return accessor.GetFirst();
		}
		
		public Model.HrSpecificHoliday GetLast()
		{
			return accessor.GetLast();
		}
		
		public Model.HrSpecificHoliday GetPrev(Model.HrSpecificHoliday e)
		{
			return accessor.GetPrev(e);
		}
		
		public Model.HrSpecificHoliday GetNext(Model.HrSpecificHoliday e)
		{
			return accessor.GetNext(e);
		}
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.HrSpecificHoliday> Select()
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
		public IList<Model.HrSpecificHoliday> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		public bool ExistsPrimary(string id)
		{
		    return accessor.ExistsPrimary(id);	
	    }
		
    }
}