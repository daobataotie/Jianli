﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：ProduceMaterialdetailsAccessor.autogenerated.cs
// author: peidun
// create date：2009-12-30 16:37:29
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
    public partial class ProduceMaterialdetailsAccessor
    {
		public Model.ProduceMaterialdetails Get(string id)
		{
			return this.Get<Model.ProduceMaterialdetails>(id);
		}
		
		public void Insert(Model.ProduceMaterialdetails e)
		{
			this.Insert<Model.ProduceMaterialdetails>(e);
		}
		
		public void Update(Model.ProduceMaterialdetails e)
		{
			this.Update<Model.ProduceMaterialdetails>(e);
		}
		
		public IList<Model.ProduceMaterialdetails> Select()
		{
			return this.Select<Model.ProduceMaterialdetails>();
		}
		
		public IList<Model.ProduceMaterialdetails> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
		{
			return this.Select<Model.ProduceMaterialdetails>(orderDescription,pagingDescription);
		}
		public void Delete(string id)
		{
			this.Delete<Model.ProduceMaterialdetails>(id);
		}
		public bool HasRows(string id)
		{
			return this.HasRows<Model.ProduceMaterialdetails>(id);
		}
		public bool HasRows()
		{
			return this.HasRows<Model.ProduceMaterialdetails>();
		}
		public int Count()
		{
			return this.Count<Model.ProduceMaterialdetails>();
		}

    }
}