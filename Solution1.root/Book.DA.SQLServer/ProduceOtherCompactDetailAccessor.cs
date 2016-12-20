//------------------------------------------------------------------------------
//
// file name：ProduceOtherCompactDetailAccessor.cs
// author: peidun
// create date：2010-1-4 15:32:39
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Book.DA.SQLServer
{
    /// <summary>
    /// Data accessor of ProduceOtherCompactDetail
    /// </summary>
    public partial class ProduceOtherCompactDetailAccessor : EntityAccessor, IProduceOtherCompactDetailAccessor
    {
        public IList<Book.Model.ProduceOtherCompactDetail> Select(Model.ProduceOtherCompact produceOtherCompact)
        {
            return sqlmapper.QueryForList<Model.ProduceOtherCompactDetail>("ProduceOtherCompactDetail.select_byProduceOtherCompactId", produceOtherCompact.ProduceOtherCompactId);
        }

        public IList<Book.Model.ProduceOtherCompactDetail> SelectCompactDetailAndFlag(Model.ProduceOtherCompact produceOtherCompact)
        {
            return sqlmapper.QueryForList<Model.ProduceOtherCompactDetail>("ProduceOtherCompactDetail.select_byProduceOtherCompactIdAndFlag", produceOtherCompact.ProduceOtherCompactId);
        }

        public IList<Book.Model.ProduceOtherCompactDetail> SelectIsInDepot(Model.ProduceOtherCompact produceOtherCompact)
        {
            return sqlmapper.QueryForList<Model.ProduceOtherCompactDetail>("ProduceOtherCompactDetail.selectbyCompactIdIsInDepot", produceOtherCompact.ProduceOtherCompactId);
        }

        public double GetByMPSdetail(string mPSDetailId)
        {
            return sqlmapper.QueryForObject<double>("ProduceOtherCompactDetail.select_byMPSdetail", mPSDetailId);
        }

        public IList<Book.Model.ProduceOtherCompactDetail> Select(string customerStart, string customerEnd, DateTime dateStart, DateTime dateEnd)
        {
            Hashtable ht = new Hashtable();
            ht.Add("startcustomerid", customerStart);
            ht.Add("endcustomerid", customerEnd);
            ht.Add("startdate", dateStart);
            ht.Add("enddate", dateEnd);
            return sqlmapper.QueryForList<Book.Model.ProduceOtherCompactDetail>("ProduceOtherCompactDetail.select_byCustomerANDdate", ht);
        }

        public IList<Model.ProduceOtherCompactDetail> SelectByConditoin(string cid1, string cid2, DateTime startdate, DateTime enddate, string pid0, string pid1, string sid0, string sid1)
        {
            Hashtable ht = new Hashtable();
            ht.Add("cid1", cid1);
            ht.Add("cid2", cid2);
            ht.Add("startdate", startdate);
            ht.Add("enddate", enddate);
            ht.Add("pid0", pid0);
            ht.Add("pid1", pid1);
            ht.Add("sid0", sid0);
            ht.Add("sid1", sid1);
            return sqlmapper.QueryForList<Model.ProduceOtherCompactDetail>("ProduceOtherCompactDetail.selectBycondition", ht);
        }

        public IList<Book.Model.ProduceOtherCompactDetail> GetThreeMaths()
        {
            return sqlmapper.QueryForList<Model.ProduceOtherCompactDetail>("ProduceOtherCompactDetail.Select_ThreeMaths", null);
        }

        public IList<Book.Model.ProduceOtherCompactDetail> GetDate(DateTime startDate, DateTime endDate)
        {
            Hashtable ht = new Hashtable();

            ht.Add("startdate", startDate);
            ht.Add("enddate", endDate);
            return sqlmapper.QueryForList<Model.ProduceOtherCompactDetail>("ProduceOtherCompactDetail.select_GetToDate", ht);
        }

        public IList<Model.ProduceOtherCompactDetail> Select(string CompactId, string StartpId, string EndpId)
        {
            StringBuilder sb = new StringBuilder("select *,(SELECT ProductName FROM Product WHERE Product.ProductId = ProduceOtherCompactDetail.ProductId) AS ProductName,(SELECT CustomerProductName FROM Product WHERE Product.ProductId = ProduceOtherCompactDetail.ProductId) AS CustomerProductName from ProduceOtherCompactDetail where 1 = 1 ");

            sb.Append(" AND ProduceOtherCompactId = '" + CompactId + "'");
            if (!string.IsNullOrEmpty(StartpId) && !string.IsNullOrEmpty(EndpId))
            {
                sb.Append(" AND ProductId IN (SELECT Product.ProductId FROM Product WHERE Id BETWEEN '" + StartpId + "' AND '" + EndpId + "')");
            }
            return this.DataReaderBind<Model.ProduceOtherCompactDetail>(sb.ToString(), null, CommandType.Text);

            #region 注释
            //Hashtable ht = new Hashtable();
            //ht.Add("ProduceOtherCompactDetail", CompactId);
            //ht.Add("StartpId", StartpId);
            //ht.Add("EndpId", EndpId);
            //return sqlmapper.QueryForList<Model.ProduceOtherCompactDetail>("ProduceOtherCompactDetail.selectByHeaderIdAndPid", ht);
            #endregion
        }


        public IList<Model.ProduceOtherCompactDetail> SelectByDateRangeAndProductId(DateTime dateStart, DateTime dateEnd, string p)
        {
            Hashtable ht = new Hashtable();
            ht.Add("dateStart", dateStart);
            ht.Add("dateEnd", dateEnd);
            ht.Add("productid", p);
            return sqlmapper.QueryForList<Model.ProduceOtherCompactDetail>("ProduceOtherCompactDetail.SelectByDateRangeAndProductId", ht);
        }

        public IList<Model.ProduceOtherCompactDetail> SelectByDateAndCondition(string StartCompactId, string EndCompactId, DateTime Startdate, DateTime EndDate, string StartSupplierId, string EndSupplierId, string StartPid, string EndPid, DateTime? StartJQ, DateTime? EndJQ, int IsClosed)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select s.SupplierFullName,po.ProduceOtherCompactId,p.ProductName,p.CustomerProductName,p.ProductDescription,po.IsClose,pod.OtherCompactCount,pod.InDepotCount,pod.CancelQuantity,pod.ProductUnit,pod.JiaoQi,pod.Description from ProduceOtherCompactDetail pod left join ProduceOtherCompact po on pod.ProduceOtherCompactId=po.ProduceOtherCompactId left join Product p on pod.ProductId=p.ProductId left join supplier s on po.SupplierId=s.SupplierId where po.ProduceOtherCompactDate between '" + Startdate.ToString("yyyy-MM-dd") + "' and '" + EndDate.ToString("yyyy-MM-dd HH:mm:ss") + "'");
            if (!string.IsNullOrEmpty(StartCompactId) || !string.IsNullOrEmpty(EndCompactId))
            {
                if (!string.IsNullOrEmpty(StartCompactId) && !string.IsNullOrEmpty(EndCompactId))
                    sql.Append(" and po.ProduceOtherCompactId between '" + StartCompactId + "' and '" + EndCompactId + "'");
                else
                    sql.Append(" and po.ProduceOtherCompactId = '" + (string.IsNullOrEmpty(StartCompactId) ? EndCompactId : StartCompactId) + "'");
            }
            if (!string.IsNullOrEmpty(StartSupplierId) || !string.IsNullOrEmpty(EndSupplierId))
            {
                if (!string.IsNullOrEmpty(StartSupplierId) && !string.IsNullOrEmpty(EndSupplierId))
                    sql.Append(" and s.Id between '" + StartSupplierId + "' and '" + EndSupplierId + "'");
                else
                    sql.Append(" and s.Id='" + (string.IsNullOrEmpty(StartSupplierId) ? EndSupplierId : StartSupplierId) + "'");
            }
            if (!string.IsNullOrEmpty(StartPid) || !string.IsNullOrEmpty(EndPid))
            {
                if (!string.IsNullOrEmpty(StartPid) && !string.IsNullOrEmpty(EndPid))
                    sql.Append(" and p.Id between '" + StartPid + "' and '" + EndPid + "'");
                else
                    sql.Append(" and p.Id = '" + (string.IsNullOrEmpty(StartPid) ? EndPid : StartPid) + "'");
            }
            if (StartJQ != null && EndJQ != null)
                sql.Append(" and pod.JiaoQi between '" + StartJQ.Value.ToString("yyyy-MM-dd") + "' and '" + EndJQ.Value.Date.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss") + "' ");
            if (IsClosed == 1)
                sql.Append(" and po.IsClose=1");
            else if (IsClosed == 2)
                sql.Append(" and (po.IsClose=0 or po.IsClose is null)");
            return this.DataReaderBind<Model.ProduceOtherCompactDetail>(sql.ToString(), null, CommandType.Text);
        }
    }
}
