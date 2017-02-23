﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：ProduceOtherExitMaterialManager.autogenerated.cs
// author: mayanjun
// create date：2011-12-06 10:41:39
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class ProduceOtherExitMaterialManager
    {
		///<summary>
		/// Data accessor of dbo.ProduceOtherExitMaterial
		///</summary>
		private static readonly DA.IProduceOtherExitMaterialAccessor accessor = (DA.IProduceOtherExitMaterialAccessor)Accessors.Get("ProduceOtherExitMaterialAccessor");
		
		/// <summary>
		/// Select by primary key.
		/// </summary>		
		public Model.ProduceOtherExitMaterial Get(string produceOtherExitMaterialId)
		{
			return accessor.Get(produceOtherExitMaterialId);
		}
		
		public bool HasRows(string produceOtherExitMaterialId)
		{
			return accessor.HasRows(produceOtherExitMaterialId);
		}
		
		public bool HasRows()
		{
			return accessor.HasRows();
		}
		
		
		public bool HasRowsBefore(Model.ProduceOtherExitMaterial e)
		{
			return accessor.HasRowsBefore(e);
		}
		
		public bool HasRowsAfter(Model.ProduceOtherExitMaterial e)
		{
			return accessor.HasRowsAfter(e);
		}
		
		public Model.ProduceOtherExitMaterial GetFirst()
		{
			return accessor.GetFirst();
		}
		
		public Model.ProduceOtherExitMaterial GetLast()
		{
			return accessor.GetLast();
		}
		
		public Model.ProduceOtherExitMaterial GetPrev(Model.ProduceOtherExitMaterial e)
		{
			return accessor.GetPrev(e);
		}
		
		public Model.ProduceOtherExitMaterial GetNext(Model.ProduceOtherExitMaterial e)
		{
			return accessor.GetNext(e);
		}
		/// <summary>
		/// Select all.
		/// </summary>
		public IList<Model.ProduceOtherExitMaterial> Select()
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
		public IList<Model.ProduceOtherExitMaterial> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return accessor.Select(orderDescription, pagingDescription);
		}
		public bool ExistsPrimary(string id)
		{
		    return accessor.ExistsPrimary(id);	
	    }
		
    }
}