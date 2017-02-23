﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PCOpticsCheckAccessor.autogenerated.cs
// author: mayanjun
// create date：2012-3-16 17:41:46
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
    public partial class PCOpticsCheckAccessor
    {
		public Model.PCOpticsCheck Get(string id)
		{
			return this.Get<Model.PCOpticsCheck>(id);
		}
		
		public void Insert(Model.PCOpticsCheck e)
		{
			this.Insert<Model.PCOpticsCheck>(e);
		}
		
		public void Update(Model.PCOpticsCheck e)
		{
			this.Update<Model.PCOpticsCheck>(e);
		}
		
		public IList<Model.PCOpticsCheck> Select()
		{
			return this.Select<Model.PCOpticsCheck>();
		}
		
		public IList<Model.PCOpticsCheck> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.PCOpticsCheck>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.PCOpticsCheck>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.PCOpticsCheck>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.PCOpticsCheck>();
		}
		public int Count()
		{
			return this.Count<Model.PCOpticsCheck>();
		}
		public bool HasRowsBefore(Model.PCOpticsCheck e)
		{
			return sqlmapper.QueryForObject<bool>("PCOpticsCheck.has_rows_before", e);
		}
		public bool HasRowsAfter(Model.PCOpticsCheck e)
		{
			return sqlmapper.QueryForObject<bool>("PCOpticsCheck.has_rows_after", e);
		}
		public Model.PCOpticsCheck GetFirst()
		{
			return sqlmapper.QueryForObject<Model.PCOpticsCheck>("PCOpticsCheck.get_first", null);
		}
		public Model.PCOpticsCheck GetLast()
		{
			return sqlmapper.QueryForObject<Model.PCOpticsCheck>("PCOpticsCheck.get_last", null);
		}
		public Model.PCOpticsCheck GetNext(Model.PCOpticsCheck e)
		{
			return sqlmapper.QueryForObject<Model.PCOpticsCheck>("PCOpticsCheck.get_next", e);
		}
		public Model.PCOpticsCheck GetPrev(Model.PCOpticsCheck e)
		{
			return sqlmapper.QueryForObject<Model.PCOpticsCheck>("PCOpticsCheck.get_prev", e);
		}
		

		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("PCOpticsCheck.existsPrimary", id);
		}
    }
}