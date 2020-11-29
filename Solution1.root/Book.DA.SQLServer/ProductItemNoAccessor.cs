//------------------------------------------------------------------------------
//
// file name：ProductItemNoAccessor.cs
// author: mayanjun
// create date：2020/11/29 10:55:25
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
    /// Data accessor of ProductItemNo
    /// </summary>
    public partial class ProductItemNoAccessor : EntityAccessor, IProductItemNoAccessor
    {
    }
}
