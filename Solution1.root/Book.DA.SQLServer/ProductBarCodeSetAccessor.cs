//------------------------------------------------------------------------------
//
// file name：ProductBarCodeSetAccessor.cs
// author: mayanjun
// create date：2016/3/31 21:50:14
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
    /// Data accessor of ProductBarCodeSet
    /// </summary>
    public partial class ProductBarCodeSetAccessor : EntityAccessor, IProductBarCodeSetAccessor
    {
        public Model.ProductBarCodeSet SelectFirst()
        {
            return sqlmapper.QueryForObject<Model.ProductBarCodeSet>("ProductBarCodeSet.SelectFirst", null);
        }

        public void Increment()
        {
            sqlmapper.Update("ProductBarCodeSet.Increment", null);
        }
    }
}
