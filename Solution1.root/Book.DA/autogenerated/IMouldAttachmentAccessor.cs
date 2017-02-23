﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：IMouldAttachmentAccessor.autogenerated.cs
// author: mayanjun
// create date：2010-9-29 10:57:25
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    public partial interface IMouldAttachmentAccessor
    {
        bool HasRows();
		
        bool HasRows(string id);
		
		Model.MouldAttachment Get(string id);
		
		void Delete(string id);
		
		int Count();
		
		void Insert(Model.MouldAttachment e);
		
		void Update(Model.MouldAttachment e);
		
		IList<Model.MouldAttachment> Select();
		
		IList<Model.MouldAttachment> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription);
		
		bool ExistsPrimary(string id);
		bool HasRowsBefore(Model.MouldAttachment e);
		
		bool HasRowsAfter(Model.MouldAttachment e);
		
		Model.MouldAttachment GetFirst();
		
		Model.MouldAttachment GetLast();
		
		Model.MouldAttachment GetPrev(Model.MouldAttachment e);
		
		Model.MouldAttachment GetNext(Model.MouldAttachment e);

	}
}
