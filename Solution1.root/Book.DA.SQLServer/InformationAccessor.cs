//------------------------------------------------------------------------------
//
// file name：InformationAccessor.cs
// author: mayanjun
// create date：2015/8/20 16:34:49
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
    /// Data accessor of Information
    /// </summary>
    public partial class InformationAccessor : EntityAccessor, IInformationAccessor
    {
        public IList<Model.Information> SelectByEmployee(string Employeeid, string type)
        {
            Hashtable ht = new Hashtable();
            ht.Add("EmployeeId", Employeeid);
            ht.Add("sql", type);
            return sqlmapper.QueryForList<Model.Information>("Information.SelectByEmployee", ht);
        }
    }
}
