﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：FlextimeAccessor.autogenerated.cs
// author: peidun
// create date：2010-3-15 14:33:28
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
    public partial class FlextimeAccessor
    {
		public Model.Flextime Get(string id)
		{
			return this.Get<Model.Flextime>(id);
		}
		
		public void Insert(Model.Flextime e)
		{
			this.Insert<Model.Flextime>(e);
		}
		
		public void Update(Model.Flextime e)
		{
			this.Update<Model.Flextime>(e);
		}
		
		public IList<Model.Flextime> Select()
		{
			return this.Select<Model.Flextime>();
		}
		
		public IList<Model.Flextime> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.Flextime>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.Flextime>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.Flextime>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.Flextime>();
		}
		public int Count()
		{
			return this.Count<Model.Flextime>();
		}

    }
}
