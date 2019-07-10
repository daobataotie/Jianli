﻿//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：AtSummonDetailManager.autogenerated.cs
// author: mayanjun
// create date：2011-3-3 14:30:19
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    public partial class AtSummonDetailManager
    {
        ///<summary>
        /// Data accessor of dbo.AtSummonDetail
        ///</summary>
        private static readonly DA.IAtSummonDetailAccessor accessor = (DA.IAtSummonDetailAccessor)Accessors.Get("AtSummonDetailAccessor");

        /// <summary>
        /// Select by primary key.
        /// </summary>		
        public Model.AtSummonDetail Get(string summonDetailId)
        {
            return accessor.Get(summonDetailId);
        }

        public bool HasRows(string summonDetailId)
        {
            return accessor.HasRows(summonDetailId);
        }

        public bool HasRows()
        {
            return accessor.HasRows();
        }

        public bool Exists(string id)
        {
            return accessor.Exists(id);
        }

        public Model.AtSummonDetail GetById(string id)
        {
            return accessor.GetById(id);
        }
        public bool ExistsExcept(Model.AtSummonDetail e)
        {
            return accessor.ExistsExcept(e);
        }


        public bool HasRowsBefore(Model.AtSummonDetail e)
        {
            return accessor.HasRowsBefore(e);
        }

        public bool HasRowsAfter(Model.AtSummonDetail e)
        {
            return accessor.HasRowsAfter(e);
        }

        public Model.AtSummonDetail GetFirst()
        {
            return accessor.GetFirst();
        }

        public Model.AtSummonDetail GetLast()
        {
            return accessor.GetLast();
        }

        public Model.AtSummonDetail GetPrev(Model.AtSummonDetail e)
        {
            return accessor.GetPrev(e);
        }

        public Model.AtSummonDetail GetNext(Model.AtSummonDetail e)
        {
            return accessor.GetNext(e);
        }
        /// <summary>
        /// Select all.
        /// </summary>
        public IList<Model.AtSummonDetail> Select()
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
        public IList<Model.AtSummonDetail> Select(Helper.OrderDescription orderDescription, Helper.PagingDescription pagingDescription)
        {
            return accessor.Select(orderDescription, pagingDescription);
        }
        public bool ExistsPrimary(string id)
        {
            return accessor.ExistsPrimary(id);
        }

        public bool IsExistsDetailForInsert(string SummonCatetory, string Lending, string SubjectId, decimal AMoney)
        {
            return accessor.IsExistsDetailForInsert(SummonCatetory, Lending, SubjectId, AMoney);
        }

        public bool IsExistsDetailForUpdate(string SummonDetailId, string SummonCatetory, string Lending, string SubjectId, decimal AMoney)
        {
            return accessor.IsExistsDetailForUpdate(SummonDetailId, SummonCatetory, Lending, SubjectId, AMoney);
        }

        public IList<Model.DetailLedger> SelectDetailLedger(DateTime dateStart, DateTime dateEnd, string subIdStart, string subIdEnd)
        {
            return accessor.SelectDetailLedger(dateStart, dateEnd, subIdStart, subIdEnd);
        }

        public IList<Model.DetailLedger> SelectJournal(DateTime dateStart, DateTime dateEnd, string startId, string endId, string category)
        {
            return accessor.SelectJournal(dateStart, dateEnd, startId, endId, category);
        }
    }
}
