﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：ILunchDetailAccessor.autogenerated.cs
// author: peidun
// create date：2010-3-26 11:08:16
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    public partial interface ILunchDetailAccessor
    {
        bool HasRows();
		
        bool HasRows(string id);
		
		Model.LunchDetail Get(string id);
		
		void Delete(string id);
		
		int Count();
		
		void Insert(Model.LunchDetail e);
		
		void Update(Model.LunchDetail e);
		
		IList<Model.LunchDetail> Select();
		
		IList<Model.LunchDetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription);
		bool HasRowsBefore(Model.LunchDetail e);
		
		bool HasRowsAfter(Model.LunchDetail e);
		
		Model.LunchDetail GetFirst();
		
		Model.LunchDetail GetLast();
		
		Model.LunchDetail GetPrev(Model.LunchDetail e);
		
		Model.LunchDetail GetNext(Model.LunchDetail e);

	}
}
