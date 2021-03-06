﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：IDepartmentAccessor.autogenerated.cs
// author: peidun
// create date：2010-4-20 17:21:46
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    public partial interface IDepartmentAccessor
    {
        bool HasRows();
		
        bool HasRows(string id);
		
		Model.Department Get(string id);
		
		void Delete(string id);
		
		int Count();
		
		void Insert(Model.Department e);
		
		void Update(Model.Department e);
		
		IList<Model.Department> Select();
		
		IList<Model.Department> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription);
		
		bool ExistsPrimary(string id);
		bool HasRowsBefore(Model.Department e);
		
		bool HasRowsAfter(Model.Department e);
		
		Model.Department GetFirst();
		
		Model.Department GetLast();
		
		Model.Department GetPrev(Model.Department e);
		
		Model.Department GetNext(Model.Department e);

		bool Exists(string id);
		
		Model.Department GetById(string id);
		
		bool ExistsExcept(Model.Department e);
		
	}
}

