﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：ProductScrapAccessor.autogenerated.cs
// author: mayanjun
// create date：2018-01-14 22:36:50
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
    public partial class ProductScrapAccessor
    {
		public Model.ProductScrap Get(string id)
		{
			return this.Get<Model.ProductScrap>(id);
		}
		
		public void Insert(Model.ProductScrap e)
		{
			this.Insert<Model.ProductScrap>(e);
		}
		
		public void Update(Model.ProductScrap e)
		{
			this.Update<Model.ProductScrap>(e);
		}
		
		public IList<Model.ProductScrap> Select()
		{
			return this.Select<Model.ProductScrap>();
		}
		
		public IList<Model.ProductScrap> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.ProductScrap>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.ProductScrap>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.ProductScrap>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.ProductScrap>();
		}
		public int Count()
		{
			return this.Count<Model.ProductScrap>();
		}
		public bool HasRowsBefore(Model.ProductScrap e)
		{
			return sqlmapper.QueryForObject<bool>("ProductScrap.has_rows_before", e);
		}
		public bool HasRowsAfter(Model.ProductScrap e)
		{
			return sqlmapper.QueryForObject<bool>("ProductScrap.has_rows_after", e);
		}
		public Model.ProductScrap GetFirst()
		{
			return sqlmapper.QueryForObject<Model.ProductScrap>("ProductScrap.get_first", null);
		}
		public Model.ProductScrap GetLast()
		{
			return sqlmapper.QueryForObject<Model.ProductScrap>("ProductScrap.get_last", null);
		}
		public Model.ProductScrap GetNext(Model.ProductScrap e)
		{
			return sqlmapper.QueryForObject<Model.ProductScrap>("ProductScrap.get_next", e);
		}
		public Model.ProductScrap GetPrev(Model.ProductScrap e)
		{
			return sqlmapper.QueryForObject<Model.ProductScrap>("ProductScrap.get_prev", e);
		}
		

		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("ProductScrap.existsPrimary", id);
		}
    }
}
