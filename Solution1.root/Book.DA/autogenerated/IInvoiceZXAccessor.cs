﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：IInvoiceZXAccessor.autogenerated.cs
// author: mayanjun
// create date：2012-10-29 14:32:21
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    public partial interface IInvoiceZXAccessor
    {
        bool HasRows();
		
        bool HasRows(string id);
		
		Model.InvoiceZX Get(string id);
		
		void Delete(string id);
		
		int Count();
		
		void Insert(Model.InvoiceZX e);
		
		void Update(Model.InvoiceZX e);
		
		IList<Model.InvoiceZX> Select();
		
		IList<Model.InvoiceZX> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription);
		
		bool ExistsPrimary(string id);
		bool HasRowsBefore(Model.InvoiceZX e);
		
		bool HasRowsAfter(Model.InvoiceZX e);
		
		Model.InvoiceZX GetFirst();
		
		Model.InvoiceZX GetLast();
		
		Model.InvoiceZX GetPrev(Model.InvoiceZX e);
		
		Model.InvoiceZX GetNext(Model.InvoiceZX e);

	}
}
