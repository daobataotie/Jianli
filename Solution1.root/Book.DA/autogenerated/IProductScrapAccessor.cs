﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：IProductScrapAccessor.autogenerated.cs
// author: mayanjun
// create date：2018-01-14 22:36:49
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    public partial interface IProductScrapAccessor
    {
        bool HasRows();
		
        bool HasRows(string id);
		
		Model.ProductScrap Get(string id);
		
		void Delete(string id);
		
		int Count();
		
		void Insert(Model.ProductScrap e);
		
		void Update(Model.ProductScrap e);
		
		IList<Model.ProductScrap> Select();
		
		IList<Model.ProductScrap> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription);
		
		bool ExistsPrimary(string id);
		bool HasRowsBefore(Model.ProductScrap e);
		
		bool HasRowsAfter(Model.ProductScrap e);
		
		Model.ProductScrap GetFirst();
		
		Model.ProductScrap GetLast();
		
		Model.ProductScrap GetPrev(Model.ProductScrap e);
		
		Model.ProductScrap GetNext(Model.ProductScrap e);

	}
}
