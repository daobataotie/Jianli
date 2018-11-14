//------------------------------------------------------------------------------
//
// file name：PackingListDetailAccessor.cs
// author: mayanjun
// create date：2018/11/11 17:33:41
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
    /// Data accessor of PackingListDetail
    /// </summary>
    public partial class PackingListDetailAccessor : EntityAccessor, IPackingListDetailAccessor
    {
        public IList<Model.PackingListDetail> SelectByHeader(string headerId)
        {
            return sqlmapper.QueryForList<Model.PackingListDetail>("PackingListDetail.SelectByHeader", headerId);
        }

        public void DeleteByHeader(string headerId)
        {
            sqlmapper.Delete("PackingListDetail.DeleteByHeader", headerId);
        }
    }
}
