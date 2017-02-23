﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：IProcessCategoryAccessor.autogenerated.cs
// author: peidun
// create date：2010-4-20 11:36:19
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    public partial interface IProcessCategoryAccessor
    {
        bool HasRows();
		
        bool HasRows(string id);
		
		Model.ProcessCategory Get(string id);
		
		void Delete(string id);
		
		int Count();
		
		void Insert(Model.ProcessCategory e);
		
		void Update(Model.ProcessCategory e);
		
		IList<Model.ProcessCategory> Select();
		
		IList<Model.ProcessCategory> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription);
		
		bool ExistsPrimary(string id);
		bool HasRowsBefore(Model.ProcessCategory e);
		
		bool HasRowsAfter(Model.ProcessCategory e);
		
		Model.ProcessCategory GetFirst();
		
		Model.ProcessCategory GetLast();
		
		Model.ProcessCategory GetPrev(Model.ProcessCategory e);
		
		Model.ProcessCategory GetNext(Model.ProcessCategory e);

		bool Exists(string id);
		
		Model.ProcessCategory GetById(string id);
		
		bool ExistsExcept(Model.ProcessCategory e);
		
	}
}
