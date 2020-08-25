//------------------------------------------------------------------------------
//
// file name：TechonlogyHeaderAccessor.cs
// author: peidun
// create date：2009-12-7 14:57:40
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
    /// Data accessor of TechonlogyHeader
    /// </summary>
    public partial class TechonlogyHeaderAccessor : EntityAccessor, ITechonlogyHeaderAccessor
    {
        public int GetSameNameCount(string techonlogyHeadername)
        {
            return sqlmapper.QueryForObject<int>("TechonlogyHeader.GetSameNameCount", techonlogyHeadername + "%");
        }

        public IList<Model.TechonlogyHeader> GetSameNameList(string techonlogyHeadername)
        {
            return sqlmapper.QueryForList<Model.TechonlogyHeader>("TechonlogyHeader.GetSameNameList", techonlogyHeadername + "%");
        }
    }
}
