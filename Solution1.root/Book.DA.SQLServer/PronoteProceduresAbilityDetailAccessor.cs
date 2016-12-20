//------------------------------------------------------------------------------
//
// file name：PronoteProceduresAbilityDetailAccessor.cs
// author: mayanjun
// create date：2010-9-23 14:25:23
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
    /// Data accessor of PronoteProceduresAbilityDetail
    /// </summary>
    public partial class PronoteProceduresAbilityDetailAccessor : EntityAccessor, IPronoteProceduresAbilityDetailAccessor
    {
        public IList<Model.PronoteProceduresAbilityDetail> GetByHeader(Model.PronoteProceduresAbility header)
        {
            if (header == null) return null;
            return sqlmapper.QueryForList<Model.PronoteProceduresAbilityDetail>("PronoteProceduresAbilityDetail.getByHeader", header.PronoteProceduresAbilityId);
        }

        public Model.PronoteProceduresAbilityDetail SelectByProductAndProcedures(string productid, string proceduresId,string pronoteMachineId)
        {
            pronoteMachineId = "%" + pronoteMachineId + "%";
            Hashtable ht = new Hashtable();
            ht.Add("productid", productid);
            ht.Add("proceduresId", proceduresId);
            ht.Add("pronoteMachineId", pronoteMachineId);
            return sqlmapper.QueryForObject<Model.PronoteProceduresAbilityDetail>("PronoteProceduresAbilityDetail.SelectByProductAndProcedures", ht);
        }
    }
}
