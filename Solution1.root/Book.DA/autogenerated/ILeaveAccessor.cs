﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：ILeaveAccessor.autogenerated.cs
// author: peidun
// create date：2010-3-16 16:05:47
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    public partial interface ILeaveAccessor
    {
        bool HasRows();
		
        bool HasRows(string id);
		
		Model.Leave Get(string id);
		
		void Delete(string id);
		
		int Count();
		
		void Insert(Model.Leave e);
		
		void Update(Model.Leave e);
		
		IList<Model.Leave> Select();
		
		IList<Model.Leave> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription);


    }
}
