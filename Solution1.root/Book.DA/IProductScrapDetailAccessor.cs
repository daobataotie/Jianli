//------------------------------------------------------------------------------
//
// file name：IProductScrapDetailAccessor.cs
// author: mayanjun
// create date：2018-01-14 22:36:49
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    /// <summary>
    /// Interface of data accessor of dbo.ProductScrapDetail
    /// </summary>
    public partial interface IProductScrapDetailAccessor : IAccessor
    {
        IList<Model.ProductScrapDetail> SelectByPrimaryId(string id);

        void DeleteByPrimaryId(string id);

        IList<Model.ProductScrapDetail> SelectByCondition(DateTime dateTime, DateTime dateTime_2, string productId);
    }
}
