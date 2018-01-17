//------------------------------------------------------------------------------
//
// file name：ProductScrapManager.cs
// author: mayanjun
// create date：2018-01-14 22:36:48
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    /// <summary>
    /// Business logic for dbo.ProductScrap.
    /// </summary>
    public partial class ProductScrapManager
    {

        /// <summary>
        /// Delete ProductScrap by primary key.
        /// </summary>
        public void Delete(string productScrapId)
        {
            //
            // todo:add other logic here
            //
            try
            {
                BL.V.BeginTransaction();

                Model.ProductScrap model = this.GetDetails(productScrapId);
                //accessorDetail.DeleteByPrimaryId(productScrapId);
                foreach (var item in model.Details)
                {
                    accessorDetail.Delete(item.ProductScrapDetailId);

                    accessorStock.Increment(new BL.DepotPositionManager().Get(item.DepotPositionId), item.Product, Convert.ToDouble(item.ScrapQuantity));
                    accessorProduct.UpdateProduct_Stock(item.Product);
                }
                accessor.Delete(productScrapId);

                string invoiceKind = this.GetInvoiceKind().ToLower();
                string sequencekey_d = string.Format("{0}-d-{1}", invoiceKind, model.InsertTime.Value.ToString("yyyy-MM-dd"));
                SequenceManager.Decrement(sequencekey_d);

                BL.V.CommitTransaction();
            }
            catch (Exception ex)
            {
                BL.V.RollbackTransaction();
                throw ex;
            }
        }

        /// <summary>
        /// Insert a ProductScrap.
        /// </summary>
        public void Insert(Model.ProductScrap productScrap)
        {
            //
            // todo:add other logic here
            //
            try
            {
                BL.V.BeginTransaction();

                Validate(productScrap);

                productScrap.InsertTime = DateTime.Now;
                productScrap.UpdateTime = DateTime.Now;
                TiGuiExists(productScrap);
                string invoiceKind = this.GetInvoiceKind().ToLower();
                string sequencekey_d = string.Format("{0}-d-{1}", invoiceKind, productScrap.InsertTime.Value.ToString("yyyy-MM-dd"));
                SequenceManager.Increment(sequencekey_d);
                accessor.Insert(productScrap);


                foreach (var item in productScrap.Details)
                {
                    accessorDetail.Insert(item);

                    accessorStock.Decrement(new BL.DepotPositionManager().Get(item.DepotPositionId), item.Product, Convert.ToDouble(item.ScrapQuantity));
                    accessorProduct.UpdateProduct_Stock(item.Product);
                }

                BL.V.CommitTransaction();
            }
            catch (Exception ex)
            {
                BL.V.RollbackTransaction();
                throw ex;
            }
        }

        /// <summary>
        /// Update a ProductScrap.
        /// </summary>
        public void Update(Model.ProductScrap productScrap)
        {
            //
            // todo: add other logic here.
            //
            try
            {
                BL.V.BeginTransaction();
                Validate(productScrap);
                productScrap.UpdateTime = DateTime.Now;
                accessor.Update(productScrap);

                //accessorDetail.DeleteByPrimaryId(productScrap.ProductScrapId);
                IList<Model.ProductScrapDetail> oldDetails = accessorDetail.SelectByPrimaryId(productScrap.ProductScrapId);
                foreach (var item in oldDetails)
                {
                    accessorDetail.Delete(item.ProductScrapDetailId);

                    accessorStock.Increment(new BL.DepotPositionManager().Get(item.DepotPositionId), item.Product, Convert.ToDouble(item.ScrapQuantity));
                    accessorProduct.UpdateProduct_Stock(item.Product);
                }

                foreach (var item in productScrap.Details)
                {
                    accessorDetail.Insert(item);

                    accessorStock.Decrement(new BL.DepotPositionManager().Get(item.DepotPositionId), item.Product, Convert.ToDouble(item.ScrapQuantity));
                    accessorProduct.UpdateProduct_Stock(item.Product);

                }
                BL.V.CommitTransaction();
            }
            catch (Exception ex)
            {
                BL.V.RollbackTransaction();
                throw ex;
            }
        }

        private void Validate(Book.Model.ProductScrap productScrap)
        {
            if (productScrap.ProductScrapDate == null)
                throw new Helper.InvalidValueException(Model.ProductScrap.PRO_ProductScrapDate);

            foreach (var item in productScrap.Details)
            {
                if (string.IsNullOrEmpty(item.DepotPositionId))
                {
                    throw new Helper.InvalidValueException(Model.ProductScrapDetail.PRO_DepotPositionId);
                }
            }
        }

        public Model.ProductScrap GetDetails(string id)
        {
            Model.ProductScrap model = this.Get(id);
            if (model != null)
                model.Details = accessorDetail.SelectByPrimaryId(id);
            return model;
        }

        protected override string GetSettingId()
        {
            return "psRule";
        }

        protected override string GetInvoiceKind()
        {
            return "ps";
        }

        private void TiGuiExists(Model.ProductScrap model)
        {
            if (this.ExistsPrimary(model.ProductScrapId))
            {
                //设置KEY值
                string invoiceKind = this.GetInvoiceKind().ToLower();
                string sequencekey_d = string.Format("{0}-d-{1}", invoiceKind, model.InsertTime.Value.ToString("yyyy-MM-dd"));
                SequenceManager.Increment(sequencekey_d);
                model.ProductScrapId = this.GetIdSimple(model.InsertTime.Value);
                TiGuiExists(model);
            }

        }
    }
}
