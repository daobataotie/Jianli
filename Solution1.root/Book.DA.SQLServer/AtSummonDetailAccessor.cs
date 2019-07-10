﻿//------------------------------------------------------------------------------
//
// file name：AtSummonDetailAccessor.cs
// author: mayanjun
// create date：2010-11-24 09:40:43
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
    /// Data accessor of AtSummonDetail
    /// </summary>
    public partial class AtSummonDetailAccessor : EntityAccessor, IAtSummonDetailAccessor
    {
        public IList<Model.AtSummonDetail> Select(Model.AtSummon atSummon)
        {
            return sqlmapper.QueryForList<Model.AtSummonDetail>("AtSummonDetail.getBySummonId", atSummon.SummonId);
        }

        public IList<Book.Model.AtSummonDetail> Select(DateTime startDate, DateTime endDate, string startSubjectId, string endSubjectId)
        {
            Hashtable ht = new Hashtable();
            ht.Add("startdate", startDate);
            ht.Add("enddate", endDate);

            StringBuilder sql = new StringBuilder();
            if (!string.IsNullOrEmpty(startSubjectId) || !string.IsNullOrEmpty(endSubjectId))
            {
                if (!string.IsNullOrEmpty(startSubjectId) && !string.IsNullOrEmpty(endSubjectId))
                    sql.Append(" and SubjectId IN (SELECT SubjectId FROM AtAccountSubject WHERE id BETWEEN '" + startSubjectId + "' AND '" + endSubjectId + "')");
                else
                    sql.Append(" and SubjectId = (SELECT SubjectId FROM AtAccountSubject WHERE id = '" + (string.IsNullOrEmpty(startSubjectId) ? endSubjectId : startSubjectId) + "')");
            }
            //sql.Append("group by SubjectId");
            ht.Add("sql", sql);
            return sqlmapper.QueryForList<Model.AtSummonDetail>("AtSummonDetail.select_byDdateAndSubject", ht);
        }

        public int CountSummon<T>(string lending, string subjectId)
        {
            Hashtable ht = new Hashtable();
            ht.Add("lending", lending);
            ht.Add("subjectId", subjectId);
            return sqlmapper.QueryForObject<int>(typeof(T).Name + ".getByLendAndSubjectId", ht);
        }

        public int CountSummonTo(string lending, string subjectId)
        {
            return this.CountSummon<Model.AtSummonDetail>(lending, subjectId);
        }

        public void DeleteByHeadId(string headid)
        {
            sqlmapper.Delete("AtSummonDetail.DeleteByHeadId", headid);
        }

        public IList<Book.Model.AtSummonDetail> SelectAndSCtype(DateTime startDate, DateTime endDate, string SumonCatetoryType)
        {
            Hashtable ht = new Hashtable();
            ht.Add("startDate", startDate.ToString("yyyy-MM-dd"));
            ht.Add("endDate", endDate.ToString("yyyy-MM-dd"));
            ht.Add("SumonCatetoryType", SumonCatetoryType);

            return sqlmapper.QueryForList<Model.AtSummonDetail>("AtSummonDetail.SelectAndSCtype", ht);
        }

        public IList<Book.Model.AtSummonDetail> SelectByDate(DateTime startDate, DateTime endDate)
        {
            Hashtable ht = new Hashtable();
            ht.Add("startdate", startDate.ToString("yyyy-MM-dd"));
            ht.Add("enddate", endDate.ToString("yyyy-MM-dd"));
            return sqlmapper.QueryForList<Model.AtSummonDetail>("AtSummonDetail.SelectByDate", ht);
        }

        public decimal GET_ZFLZ_Yue(Model.AtAccountSubject subject, DateTime startdate)
        {
            Hashtable ht = new Hashtable();
            ht.Add("subjectid", subject == null ? null : subject.SubjectId);
            ht.Add("startdate", startdate);

            if (subject != null && subject.Id == "1101000")
                return sqlmapper.QueryForObject<decimal>("AtSummonDetail.GET_ZFLZ_YueXianJin", ht);
            else
                return sqlmapper.QueryForObject<decimal>("AtSummonDetail.GET_ZFLZ_Yue", ht);
        }

        public IList<Model.AtSummonDetail> Select_ZFLZ_GroupSubject(string subjectid, DateTime startdate, DateTime enddate)
        {
            Hashtable ht = new Hashtable();
            ht.Add("subjectid", subjectid);
            ht.Add("startdate", startdate);
            ht.Add("enddate", enddate);
            return sqlmapper.QueryForList<Model.AtSummonDetail>("AtSummonDetail.Select_ZFLZ_GroupSubject", ht);
        }

        public IList<Book.Model.AtSummonDetail> Select_ZFLZ_XianJinGroupSubject(string subjectid, DateTime startdate, DateTime enddate)
        {
            Hashtable ht = new Hashtable();
            ht.Add("subjectid", subjectid);
            ht.Add("startdate", startdate);
            ht.Add("enddate", enddate);
            return sqlmapper.QueryForList<Model.AtSummonDetail>("AtSummonDetail.Select_ZFLZ_XianJinGroupSubject", ht);
        }

        //public double GET_ZFLZ_YueXIANJin(string subjectid, DateTime startdate, DateTime enddate)
        //{
        //    Hashtable ht = new Hashtable();
        //    ht.Add("subjectid", subjectid);
        //    ht.Add("startdate", startdate);
        //    ht.Add("enddate", enddate);
        //    return sqlmapper.QueryForObject<double>("AtSummonDetail.GET_ZFLZ_YueXIANJin", ht);
        //}

        public bool IsExistsDetailForInsert(string SummonCatetory, string Lending, string SubjectId, decimal AMoney)
        {
            Hashtable ht = new Hashtable();
            ht.Add("SummonCatetory", SummonCatetory);
            ht.Add("Lending", Lending);
            ht.Add("SubjectId", SubjectId);
            ht.Add("AMoney", AMoney);
            return sqlmapper.QueryForObject<bool>("AtSummonDetail.IsExistsDetailForInsert", ht);
        }

        public bool IsExistsDetailForUpdate(string SummonDetailId, string SummonCatetory, string Lending, string SubjectId, decimal AMoney)
        {
            Hashtable ht = new Hashtable();
            ht.Add("SummonDetailId", SummonDetailId);
            ht.Add("SummonCatetory", SummonCatetory);
            ht.Add("Lending", Lending);
            ht.Add("SubjectId", SubjectId);
            ht.Add("AMoney", AMoney);
            return sqlmapper.QueryForObject<bool>("AtSummonDetail.IsExistsDetailForUpdate", ht);
        }
        /// <summary>
        /// 现金支出传票明细
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public DataTable GetByDate(DateTime startDate, DateTime endDate)
        {
            string sql = "select at.SummonDate,s.Id,s.SubjectName,a.Summary, case at.SummonCategory when '現金支出傳票' then 0 else a.AMoney end as Income,case at.SummonCategory when '現金支出傳票' then a.AMoney else 0 end as Pay, (case at.SummonCategory when '現金支出傳票' then 0 else a.AMoney end -case at.SummonCategory when '現金支出傳票' then a.AMoney else 0 end ) as YE from AtSummonDetail a left join AtSummon at on a.SummonId=at.SummonId left join AtAccountSubject s on a.SubjectId=s.SubjectId where at.SummonDate between '" + startDate.ToString("yyyy-MM-dd") + "' and '" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and (SummonCategory='現金支出傳票' or (SummonCategory='轉帳傳票' and s.SubjectName='現金'))order by at.SummonDate,at.SummonCategory  ";
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(sql, sqlmapper.DataSource.ConnectionString);
            sda.Fill(dt);
            return dt;
        }

        public decimal SelectYEByDate(DateTime date)
        {
            string sql = " select (select Cast(sum(isnull(AMoney,0)) as decimal) from AtSummonDetail a left join AtAccountSubject s  on a.SubjectId=s.SubjectId left join AtSummon at on a.SummonId=at.SummonId where at.SummonCategory='轉帳傳票' and s.SubjectName='現金' and at.SummonDate<'" + date.ToString("yyyy-MM-dd") + "') -  (select Cast(sum(isnull(AMoney,0)) as decimal) from AtSummonDetail a left join AtSummon at on a.SummonId=at.SummonId where at.SummonCategory='現金支出傳票' and at.SummonDate<'" + date.ToString("yyyy-MM-dd") + "') +(select TheBalance from AtAccountSubject where SubjectName='現金')";
            if (SQLDB.SqlHelper.ExecuteScalar(sqlmapper.DataSource.ConnectionString, CommandType.Text, sql, null) != DBNull.Value)
                return Convert.ToDecimal(SQLDB.SqlHelper.ExecuteScalar(sqlmapper.DataSource.ConnectionString, CommandType.Text, sql, null));
            else
                return 0;
        }

        public IList<Model.DetailLedger> SelectDetailLedger(DateTime dateStart, DateTime dateEnd, string subIdStart, string subIdEnd)
        {
            string sql = "select at.SummonDate,at.Id,atd.Summary,atd.Lending,atd.AMoney,(case when atd.Lending='借' then AMoney else 0 end) as JMoney,(case when atd.Lending='貸' then AMoney else 0 end) as DMoney,ats.TheBalance,ats.SubjectName,ats.Id as Subject_Id from AtSummonDetail atd left join AtSummon at on at.SummonId=atd.SummonId left join AtAccountSubject ats on atd.SubjectId=ats.SubjectId  where at.SummonDate between '" + dateStart.ToString("yyyy-MM-dd") + "' and '" + dateEnd.Date.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss") + "'  and ats.Id between '" + subIdStart + "' and '" + subIdEnd + "' order by ats.Id,at.SummonDate";

            #region MyRegion
            //List<Model.DetailLedger> list = new List<Book.Model.DetailLedger>();
            //Model.DetailLedger detailLedger;
            //using (SqlDataReader dataReader = SQLDB.SqlHelper.ExecuteReader(SQLDB.SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql, null))
            //{
            //    while (dataReader.Read())
            //    {
            //        detailLedger = new Model.DetailLedger();
            //        for (int i = 0; i < dataReader.FieldCount; i++)
            //        {
            //            foreach (var item in detailLedger.GetType().GetProperties())
            //            {
            //                string fieldName = item.Name;//属性名
            //                //判断当前迭代出的属性名称是否和迭代出的dataReader的列名称一致
            //                if (item.Name.ToLower().Equals(dataReader.GetName(i).ToLower()))
            //                {
            //                    //从DataReader中读取值
            //                    object _value = dataReader[fieldName];
            //                    //将当前dataReader的单列值赋予相匹配的属性,否则赋予一个null值.
            //                    if (_value != null && _value != DBNull.Value)
            //                        item.SetValue(detailLedger, _value, null);
            //                    else
            //                        item.SetValue(detailLedger, null, null);
            //                }
            //            }
            //        }
            //        list.Add(detailLedger);

            //    }
            //}

            //return list; 
            #endregion

            return this.DataReaderBind<Model.DetailLedger>(sql, null, CommandType.Text);
        }

        public IList<Model.DetailLedger> SelectJournal(DateTime dateStart, DateTime dateEnd, string startId, string endId, string category)
        {
            StringBuilder sql = new StringBuilder("select at.SummonDate,at.Id,at.SummonCategory,ats.SubjectName,ats.Id as Subject_Id,atd.Summary,(case when atd.Lending='借' then atd.AMoney else 0 end ) as JMoney,(case when atd.Lending='貸' then atd.AMoney else 0 end ) as DMoney from AtSummonDetail atd left join AtSummon at on atd.SummonId=at.SummonId left join AtAccountSubject ats on atd.SubjectId=ats.SubjectId where at.SummonDate between '" + dateStart.ToString("yyyy-MM-dd") + "' and '" + dateEnd.Date.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss") + "' ");

            if (!string.IsNullOrEmpty(startId) && !string.IsNullOrEmpty(endId))
            {
                sql.Append(" and at.Id between '" + startId + "' and '" + endId + "' ");
            }
            if (!string.IsNullOrEmpty(category))
                sql.Append(" and at.SummonCategory in (" + category + ")");
            sql.Append(" order by at.SummonDate,at.Id");

            return DataReaderBind<Model.DetailLedger>(sql.ToString(), null, CommandType.Text);
        }
    }
}
