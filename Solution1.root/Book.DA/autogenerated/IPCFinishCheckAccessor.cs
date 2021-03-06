﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：IPCFinishCheckAccessor.autogenerated.cs
// author: mayanjun
// create date：2011-11-12 15:10:07
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    public partial interface IPCFinishCheckAccessor
    {
        bool HasRows();
		
        bool HasRows(string id);
		
		Model.PCFinishCheck Get(string id);
		
		void Delete(string id);
		
		int Count();
		
		void Insert(Model.PCFinishCheck e);
		
		void Update(Model.PCFinishCheck e);
		
		IList<Model.PCFinishCheck> Select();
		
		IList<Model.PCFinishCheck> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription);
		
		bool ExistsPrimary(string id);
		bool HasRowsBefore(Model.PCFinishCheck e);
		
		bool HasRowsAfter(Model.PCFinishCheck e);
		
		Model.PCFinishCheck GetFirst();
		
		Model.PCFinishCheck GetLast();
		
		Model.PCFinishCheck GetPrev(Model.PCFinishCheck e);
		
		Model.PCFinishCheck GetNext(Model.PCFinishCheck e);

	}
}

