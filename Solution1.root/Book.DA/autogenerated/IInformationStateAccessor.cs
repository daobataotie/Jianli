﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：IInformationStateAccessor.autogenerated.cs
// author: mayanjun
// create date：2015/8/20 16:34:49
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    public partial interface IInformationStateAccessor
    {
        bool HasRows();
		
        bool HasRows(string id);
		
		Model.InformationState Get(string id);
		
		void Delete(string id);
		
		int Count();
		
		void Insert(Model.InformationState e);
		
		void Update(Model.InformationState e);
		
		IList<Model.InformationState> Select();
		
		IList<Model.InformationState> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription);
		
		bool ExistsPrimary(string id);

	}
}