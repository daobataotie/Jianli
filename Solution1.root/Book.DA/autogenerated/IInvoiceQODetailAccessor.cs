﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：IInvoiceQODetailAccessor.autogenerated.cs
// author: peidun
// create date：2009-10-13 上午 11:45:02
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    public partial interface IInvoiceQODetailAccessor
    {
        bool HasRows();
		
        bool HasRows(string id);
		
		Model.InvoiceQODetail Get(string id);
		
		void Delete(string id);
		
		int Count();
		
		void Insert(Model.InvoiceQODetail e);
		
		void Update(Model.InvoiceQODetail e);
		
		IList<Model.InvoiceQODetail> Select();
		
		IList<Model.InvoiceQODetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription);

	}
}
