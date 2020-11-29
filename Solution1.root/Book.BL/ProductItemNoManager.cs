//------------------------------------------------------------------------------
//
// file name：ProductItemNoManager.cs
// author: mayanjun
// create date：2020/11/29 10:55:25
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    /// <summary>
    /// Business logic for dbo.ProductItemNo.
    /// </summary>
    public partial class ProductItemNoManager
    {

        /// <summary>
        /// Delete ProductItemNo by primary key.
        /// </summary>
        public void Delete(string itemNo)
        {
            //
            // todo:add other logic here
            //
            try
            {
                BL.V.BeginTransaction();

                accessor.Delete(itemNo);

                BL.V.CommitTransaction();
            }
            catch (Exception ex)
            {
                BL.V.RollbackTransaction();

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Insert a ProductItemNo.
        /// </summary>
        public void Insert(Model.ProductItemNo productItemNo)
        {
            //
            // todo:add other logic here
            //

            Validate(productItemNo);

            try
            {
                BL.V.BeginTransaction();

                productItemNo.InsertTime = DateTime.Now;
                accessor.Insert(productItemNo);

                BL.V.CommitTransaction();
            }
            catch (Exception ex)
            {
                BL.V.RollbackTransaction();

                if (ex.Message.Contains("PRIMARY KEY") && ex.Message.Contains(productItemNo.ItemNo))
                    throw new Exception("料號已存在：" + productItemNo.ItemNo);

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Update a ProductItemNo.
        /// </summary>
        public void Update(Model.ProductItemNo productItemNo, string oldId)
        {
            //
            // todo: add other logic here.
            //
            Validate(productItemNo);

            try
            {
                BL.V.BeginTransaction();

                //accessor.Update(productItemNo);  //因为主键就是ItemNo，已经更改，所以永远修改不成功

                accessor.Delete(oldId);

                productItemNo.InsertTime = DateTime.Now;
                productItemNo.UpdateTime = DateTime.Now;
                accessor.Insert(productItemNo);

                BL.V.CommitTransaction();
            }
            catch (Exception ex)
            {
                BL.V.RollbackTransaction();

                if (ex.Message.Contains("PRIMARY KEY") && ex.Message.Contains(productItemNo.ItemNo))
                    throw new Exception("料號已存在：" + productItemNo.ItemNo);

                throw new Exception(ex.Message);
            }
        }

        private void Validate(Model.ProductItemNo productItemNo)
        {
            if (string.IsNullOrEmpty(productItemNo.ItemNo))
            {
                throw new Helper.RequireValueException(Model.ProductItemNo.PRO_ItemNo);
            }
            if (string.IsNullOrEmpty(productItemNo.InternalDescription))
            {
                throw new Helper.RequireValueException(Model.ProductItemNo.PRO_InternalDescription);
            }
        }
    }
}
