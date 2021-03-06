﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PCFinishCheckAccessor.autogenerated.cs
// author: mayanjun
// create date：2011-11-12 15:10:07
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Book.DA.SQLServer
{
    public partial class PCFinishCheckAccessor
    {
		public Model.PCFinishCheck Get(string id)
		{
			return this.Get<Model.PCFinishCheck>(id);
		}
		
		public void Insert(Model.PCFinishCheck e)
		{
			this.Insert<Model.PCFinishCheck>(e);
		}
		
		public void Update(Model.PCFinishCheck e)
		{
			this.Update<Model.PCFinishCheck>(e);
		}
		
		public IList<Model.PCFinishCheck> Select()
		{
			return this.Select<Model.PCFinishCheck>();
		}
		
		public IList<Model.PCFinishCheck> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.PCFinishCheck>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.PCFinishCheck>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.PCFinishCheck>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.PCFinishCheck>();
		}
		public int Count()
		{
			return this.Count<Model.PCFinishCheck>();
		}
		public bool HasRowsBefore(Model.PCFinishCheck e)
		{
			return sqlmapper.QueryForObject<bool>("PCFinishCheck.has_rows_before", e);
		}
		public bool HasRowsAfter(Model.PCFinishCheck e)
		{
			return sqlmapper.QueryForObject<bool>("PCFinishCheck.has_rows_after", e);
		}
		public Model.PCFinishCheck GetFirst()
		{
			return sqlmapper.QueryForObject<Model.PCFinishCheck>("PCFinishCheck.get_first", null);
		}
		public Model.PCFinishCheck GetLast()
		{
			return sqlmapper.QueryForObject<Model.PCFinishCheck>("PCFinishCheck.get_last", null);
		}
		public Model.PCFinishCheck GetNext(Model.PCFinishCheck e)
		{
			return sqlmapper.QueryForObject<Model.PCFinishCheck>("PCFinishCheck.get_next", e);
		}
		public Model.PCFinishCheck GetPrev(Model.PCFinishCheck e)
		{
			return sqlmapper.QueryForObject<Model.PCFinishCheck>("PCFinishCheck.get_prev", e);
		}
		

		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("PCFinishCheck.existsPrimary", id);
		}
    }
}
