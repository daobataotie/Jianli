﻿//------------------------------------------------------------------------------
//
// file name：ProduceOtherInDepotDetailManager.cs
// author: peidun
// create date：2010-1-8 13:43:35
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    /// <summary>
    /// Business logic for dbo.ProduceOtherInDepotDetail.
    /// </summary>
    public partial class ProduceOtherInDepotDetailManager
    {

        /// <summary>
        /// Delete ProduceOtherInDepotDetail by primary key.
        /// </summary>
        public void Delete(string produceOtherInDepotDetailId)
        {
            //
            // todo:add other logic here
            //
            accessor.Delete(produceOtherInDepotDetailId);
        }

        /// <summary>
        /// Insert a ProduceOtherInDepotDetail.
        /// </summary>
        public void Insert(Model.ProduceOtherInDepotDetail produceOtherInDepotDetail)
        {
            //
            // todo:add other logic here
            //
            accessor.Insert(produceOtherInDepotDetail);
        }

        /// <summary>
        /// Update a ProduceOtherInDepotDetail.
        /// </summary>
        public void Update(Model.ProduceOtherInDepotDetail produceOtherInDepotDetail)
        {
            //
            // todo: add other logic here.
            //
            accessor.Update(produceOtherInDepotDetail);
        }
        public IList<Book.Model.ProduceOtherInDepotDetail> Select(Model.ProduceOtherInDepot produceOtherInDepot)
        {
            return accessor.Select(produceOtherInDepot);
        }
        public IList<Book.Model.ProduceOtherInDepotDetail> Select(Model.ProduceOtherCompact startPronoteHeader, Model.ProduceOtherCompact endPronoteHeader, DateTime startDate, DateTime endDate)
        {
            return accessor.Select(startPronoteHeader, endPronoteHeader, startDate, endDate);
        }
        public IList<Model.ProduceOtherInDepotDetail> SelectByCondition(string indepotId, string productId1, string productId2)
        {
            return accessor.SelectByCondition(indepotId, productId1, productId2);
        }
        public IList<Model.ProduceOtherInDepotDetail> SelectByProduceotherInDepotId(string id)
        {
            return accessor.SelectByProduceotherInDepotId(id);
        }
        public void Delete(Model.ProduceOtherInDepot indepot)
        {
            accessor.Delete(indepot);
        }

        public IList<Model.ProduceOtherInDepotDetail> SelectByCondition(DateTime startdate, DateTime enddate, Book.Model.Supplier supper1, Book.Model.Supplier supper2, string ProduceOtherCompactId1, string ProduceOtherCompactId2, Book.Model.Product startPro, Book.Model.Product endPro, string invouceCusidStart, string invouceCusidEnd)
        {
            return accessor.SelectByCondition(startdate, enddate, supper1, supper2, ProduceOtherCompactId1, ProduceOtherCompactId2, startPro, endPro, invouceCusidStart, invouceCusidEnd);
        }
    }
}

