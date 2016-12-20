//------------------------------------------------------------------------------
//
// file name：ProductBarCodeSetManager.cs
// author: mayanjun
// create date：2016/3/31 21:50:14
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    /// <summary>
    /// Business logic for dbo.ProductBarCodeSet.
    /// </summary>
    public partial class ProductBarCodeSetManager
    {

        /// <summary>
        /// Delete ProductBarCodeSet by primary key.
        /// </summary>
        public void Delete(string productBarCodeSetId)
        {
            //
            // todo:add other logic here
            //
            accessor.Delete(productBarCodeSetId);
        }

        /// <summary>
        /// Insert a ProductBarCodeSet.
        /// </summary>
        public void Insert(Model.ProductBarCodeSet productBarCodeSet)
        {
            //
            // todo:add other logic here
            //
            try
            {
                BL.V.BeginTransaction();
                accessor.Insert(productBarCodeSet);
                BL.V.CommitTransaction();
            }
            catch
            {
                BL.V.RollbackTransaction();
                throw;
            }
        }

        /// <summary>
        /// Update a ProductBarCodeSet.
        /// </summary>
        public void Update(Model.ProductBarCodeSet productBarCodeSet)
        {
            //
            // todo: add other logic here.
            //
            try
            {
                BL.V.BeginTransaction();
                accessor.Update(productBarCodeSet);
                BL.V.CommitTransaction();
            }
            catch
            {
                BL.V.RollbackTransaction();
                throw;
            }
        }

        public Model.ProductBarCodeSet SelectFirst()
        {
            return accessor.SelectFirst();
        }

        /// <summary>
        /// 生成商品條碼
        /// </summary>
        /// <returns></returns>
        public string RandomBarCode()
        {
            Model.ProductBarCodeSet m = this.SelectFirst();
            if (m == null)
            {
                m = new Book.Model.ProductBarCodeSet();
                m.ProductBarCodeSetId = Guid.NewGuid().ToString();
                m.NationalCode = "471";
                m.CompanyCode = "00000";
                m.ValueKey = 0;

                this.Insert(m);
            }
            int a = m.ValueKey.HasValue ? m.ValueKey.Value : 0;
            string s = string.Empty;
            if (a < 100000)
            {
                s = a.ToString("00000");
                return m.NationalCode + m.CompanyCode + s;
            }
            else
            {
                //throw new Helper.MessageValueException("條碼編號超出使用範圍，請聯繫管理員！");
                return "";
            }
        }

        public void Increment()
        {
            accessor.Increment();
        }
    }
}
