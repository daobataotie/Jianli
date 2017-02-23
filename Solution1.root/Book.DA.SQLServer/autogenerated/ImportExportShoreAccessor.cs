﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：ImportExportShoreAccessor.autogenerated.cs
// author: mayanjun
// create date：2013-4-6 15:35:12
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
    public partial class ImportExportShoreAccessor
    {
		public Model.ImportExportShore Get(string id)
		{
			return this.Get<Model.ImportExportShore>(id);
		}
		
		public void Insert(Model.ImportExportShore e)
		{
			this.Insert<Model.ImportExportShore>(e);
		}
		
		public void Update(Model.ImportExportShore e)
		{
			this.Update<Model.ImportExportShore>(e);
		}
		
		public IList<Model.ImportExportShore> Select()
		{
			return this.Select<Model.ImportExportShore>();
		}
		
		public IList<Model.ImportExportShore> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.ImportExportShore>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.ImportExportShore>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.ImportExportShore>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.ImportExportShore>();
		}
		public int Count()
		{
			return this.Count<Model.ImportExportShore>();
		}

		public bool Exists(string id)
		{
			return sqlmapper.QueryForObject<bool>("ImportExportShore.exists", id);
		}
		
		public Model.ImportExportShore GetById(string id)
		{
			return sqlmapper.QueryForObject<Model.ImportExportShore>("ImportExportShore.get_by_id", id);
		}
		
		public bool ExistsExcept(Model.ImportExportShore e)
		{
			Hashtable paras = new Hashtable();
			paras.Add("newId", e.Id);
            paras.Add("oldId", Get(e.ImportExportShoreId)==null?null:Get(e.ImportExportShoreId).Id);
			return sqlmapper.QueryForObject<bool>("ImportExportShore.existsexcept", paras);
		}
		
		
		
		public bool ExistsPrimary(string id)
		{			
			return sqlmapper.QueryForObject<bool>("ImportExportShore.existsPrimary", id);
		}
    }
}