//------------------------------------------------------------------------------
//
// file name：ProductScrapManager.cs
// author: mayanjun
// create date：2018-01-14 22:36:48
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    /// <summary>
    /// Business logic for dbo.ProductScrap.
    /// </summary>
    public partial class ProductScrapManager
    {
		
		/// <summary>
		/// Delete ProductScrap by primary key.
		/// </summary>
		public void Delete(string productScrapId)
		{
			//
			// todo:add other logic here
			//
			accessor.Delete(productScrapId);
		}

		/// <summary>
		/// Insert a ProductScrap.
		/// </summary>
        public void Insert(Model.ProductScrap productScrap)
        {
			//
			// todo:add other logic here
			//
            accessor.Insert(productScrap);
        }
		
		/// <summary>
		/// Update a ProductScrap.
		/// </summary>
        public void Update(Model.ProductScrap productScrap)
        {
			//
			// todo: add other logic here.
			//
            accessor.Update(productScrap);
        }
    }
}
