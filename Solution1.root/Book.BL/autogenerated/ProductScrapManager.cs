﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：ProductScrapManager.autogenerated.cs
// author: mayanjun
// create date：2018-01-14 22:36:49
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class ProductScrapManager : BaseManager
    {
        ///<summary>
        /// Data accessor of dbo.ProductScrap
        ///</summary>
        private static readonly DA.IProductScrapAccessor accessor = (DA.IProductScrapAccessor)Accessors.Get("ProductScrapAccessor");
        private static readonly DA.IProductScrapDetailAccessor accessorDetail = (DA.IProductScrapDetailAccessor)Accessors.Get("ProductScrapDetailAccessor");
        private static readonly DA.IProductAccessor accessorProduct = (DA.IProductAccessor)Accessors.Get("ProductAccessor");
        private static readonly DA.IStockAccessor accessorStock = (DA.IStockAccessor)Accessors.Get("StockAccessor");

        /// <summary>
        /// Select by primary key.
        /// </summary>		
        public Model.ProductScrap Get(string productScrapId)
        {
            return accessor.Get(productScrapId);
        }

        public bool HasRows(string productScrapId)
        {
            return accessor.HasRows(productScrapId);
        }

        public bool HasRows()
        {
            return accessor.HasRows();
        }


        public bool HasRowsBefore(Model.ProductScrap e)
        {
            return accessor.HasRowsBefore(e);
        }

        public bool HasRowsAfter(Model.ProductScrap e)
        {
            return accessor.HasRowsAfter(e);
        }

        public Model.ProductScrap GetFirst()
        {
            return accessor.GetFirst();
        }

        public Model.ProductScrap GetLast()
        {
            return accessor.GetLast();
        }

        public Model.ProductScrap GetPrev(Model.ProductScrap e)
        {
            return accessor.GetPrev(e);
        }

        public Model.ProductScrap GetNext(Model.ProductScrap e)
        {
            return accessor.GetNext(e);
        }
        /// <summary>
        /// Select all.
        /// </summary>
        public IList<Model.ProductScrap> Select()
        {
            return accessor.Select();
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int Count()
        {
            return accessor.Count();
        }

        /// <summary>
        /// 获取指定状态、指定分页，并按指定要求排序的记录
        /// </summary>
        public IList<Model.ProductScrap> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
        {
            return accessor.Select(orderDescription, pagingDescription);
        }
        public bool ExistsPrimary(string id)
        {
            return accessor.ExistsPrimary(id);
        }

    }
}