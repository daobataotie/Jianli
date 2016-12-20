//------------------------------------------------------------------------------
//
// file name：IInformationAccessor.cs
// author: mayanjun
// create date：2015/8/20 16:34:49
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Book.DA
{
    /// <summary>
    /// Interface of data accessor of dbo.Information
    /// </summary>
    public partial interface IInformationAccessor : IAccessor
    {
        IList<Model.Information> SelectByEmployee(string Employeeid, string type);
    }
}
