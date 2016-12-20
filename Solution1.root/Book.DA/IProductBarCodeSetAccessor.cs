//------------------------------------------------------------------------------
//
// file name：IProductBarCodeSetAccessor.cs
// author: mayanjun
// create date：2016/3/31 21:50:14
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    /// <summary>
    /// Interface of data accessor of dbo.ProductBarCodeSet
    /// </summary>
    public partial interface IProductBarCodeSetAccessor : IAccessor
    {
        Model.ProductBarCodeSet SelectFirst();
        void Increment();
    }
}
