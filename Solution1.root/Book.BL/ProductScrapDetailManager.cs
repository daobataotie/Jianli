//------------------------------------------------------------------------------
//
// file name：ProductScrapDetailManager.cs
// author: mayanjun
// create date：2018-01-14 22:36:48
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    /// <summary>
    /// Business logic for dbo.ProductScrapDetail.
    /// </summary>
    public partial class ProductScrapDetailManager
    {
		
		/// <summary>
		/// Delete ProductScrapDetail by primary key.
		/// </summary>
		public void Delete(string productScrapDetailId)
		{
			//
			// todo:add other logic here
			//
			accessor.Delete(productScrapDetailId);
		}

		/// <summary>
		/// Insert a ProductScrapDetail.
		/// </summary>
        public void Insert(Model.ProductScrapDetail productScrapDetail)
        {
			//
			// todo:add other logic here
			//
            accessor.Insert(productScrapDetail);
        }
		
		/// <summary>
		/// Update a ProductScrapDetail.
		/// </summary>
        public void Update(Model.ProductScrapDetail productScrapDetail)
        {
			//
			// todo: add other logic here.
			//
            accessor.Update(productScrapDetail);
        }
    }
}
