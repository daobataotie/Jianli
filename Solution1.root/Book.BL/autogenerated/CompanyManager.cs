﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：CompanyManager.autogenerated.cs
// author: peidun
// create date：2009-10-13 上午 11:45:01
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class CompanyManager
    {
		///<summary>
		/// Data accessor of dbo.Company
		///</summary>
		private static readonly DA.ICompanyAccessor accessor = (DA.ICompanyAccessor)Accessors.Get("CompanyAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.Company Get(string companyId)
		{
			return accessor.Get(companyId);
		}
		
		public bool HasRows(string companyId)
		{
			return accessor.HasRows(companyId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		public bool HasRowsBefore(Model.Company e)
		{
			return accessor.HasRowsBefore(e);
		}
		
		public bool HasRowsAfter(Model.Company e)
		{
			return accessor.HasRowsAfter(e);
		}
		
		public Model.Company GetFirst()
		{
			return accessor.GetFirst();
		}
		
		public Model.Company GetLast()
		{
			return accessor.GetLast();
		}
		
		public Model.Company GetPrev(Model.Company e)
		{
			return accessor.GetPrev(e);
		}
		
		public Model.Company GetNext(Model.Company e)
		{
			return accessor.GetNext(e);
		}
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.Company> Select()
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
		public IList<Model.Company> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		
    }
}
