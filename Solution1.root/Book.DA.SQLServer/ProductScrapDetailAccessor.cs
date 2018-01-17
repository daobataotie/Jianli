//------------------------------------------------------------------------------
//
// file name：ProductScrapDetailAccessor.cs
// author: mayanjun
// create date：2018-01-14 22:36:49
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
    /// Data accessor of ProductScrapDetail
    /// </summary>
    public partial class ProductScrapDetailAccessor : EntityAccessor, IProductScrapDetailAccessor
    {
        public IList<Model.ProductScrapDetail> SelectByPrimaryId(string id)
        {
            return sqlmapper.QueryForList<Model.ProductScrapDetail>("ProductScrapDetail.SelectByPrimaryId", id);
        }

        public void DeleteByPrimaryId(string id)
        {
            sqlmapper.Delete("ProductScrapDetail.DeleteByPrimaryId", id);
        }

        public IList<Model.ProductScrapDetail> SelectByCondition(DateTime dateTime, DateTime dateTime_2, string productId)
        {
            string sql = " where ps.ProductScrapDate between '" + dateTime.Date.ToString("yyyy-MM-dd") + "' and '" + dateTime_2.Date.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss") + "'";
            if (!string.IsNullOrEmpty(productId))
                sql += " and psd.ProductId='" + productId + "'";

            Hashtable ht = new Hashtable();
            ht.Add("sql", sql);

            return sqlmapper.QueryForList<Model.ProductScrapDetail>("ProductScrapDetail.SelectByCondition", ht);
        }
    }
}
