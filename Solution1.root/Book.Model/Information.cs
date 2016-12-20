//------------------------------------------------------------------------------
//
// file name：Information.cs
// author: mayanjun
// create date：2015/8/20 16:34:49
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class Information
    {
        public string ShowMes { get { return this._invoiceType + (this._messageText == "0" ? "已建立！" : "已修改！"); } }
    }
}