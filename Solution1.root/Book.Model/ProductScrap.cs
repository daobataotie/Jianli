//------------------------------------------------------------------------------
//
// file name：ProductScrap.cs
// author: mayanjun
// create date：2018-01-14 22:36:49
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.Model
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public partial class ProductScrap
	{
        private IList<Model.ProductScrapDetail> _details = new List<Model.ProductScrapDetail>();

        public IList<Model.ProductScrapDetail> Details
        {
            get { return _details; }
            set { _details = value; }
        }
	}
}