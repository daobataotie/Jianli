﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：IExchangeRateAccessor.autogenerated.cs
// author: mayanjun
// create date：2018/11/15 23:30:48
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    public partial interface IExchangeRateAccessor
    {
        bool HasRows();
		
        bool HasRows(string id);
		
		Model.ExchangeRate Get(string id);
		
		void Delete(string id);
		
		int Count();
		
		void Insert(Model.ExchangeRate e);
		
		void Update(Model.ExchangeRate e);
		
		IList<Model.ExchangeRate> Select();
		
		IList<Model.ExchangeRate> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription);
		
		bool ExistsPrimary(string id);

		bool Exists(string id);
		
		Model.ExchangeRate GetById(string id);
		
		bool ExistsExcept(Model.ExchangeRate e);
		
	}
}