﻿//------------------------------------------------------------------------------
//
// file name：InvoiceCOManager.cs
// author: peidun
// create date：2008/6/6 10:00:59
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Book.BL
{
    /// <summary>
    /// Business logic for dbo.InvoiceCO.
    /// </summary>
    public partial class InvoiceCOManager : InvoiceManager
    {
        private static readonly DA.IInvoiceCODetailAccessor invoiceCODetailAccessor = (DA.IInvoiceCODetailAccessor)Accessors.Get("InvoiceCODetailAccessor");
        private static readonly DA.IProductAccessor productAccessor = (DA.IProductAccessor)Accessors.Get("ProductAccessor");
        private static readonly ProductManager productManager = new ProductManager();
        #region Select

        public IList<Model.InvoiceCO> Select(DateTime start, DateTime end)
        {
            return accessor.Select(start, end);
        }

        public IList<Model.InvoiceCO> Select(Helper.InvoiceStatus status)
        {
            return accessor.Select(status);
        }
        public Model.InvoiceCO Get(string invoiceId)
        {
            Model.InvoiceCO invoice = accessor.Get(invoiceId);
            if (invoice != null)
                invoice.Details = invoiceCODetailAccessor.Select(invoice);
            return invoice;
        }
        #endregion

        #region Override

        protected override void _Insert(Book.Model.Invoice invoice)
        {
            if (!(invoice is Model.InvoiceCO))
                throw new ArgumentException();

            _Insert((Model.InvoiceCO)invoice);
        }

        protected override void _Update(Book.Model.Invoice invoice)
        {
            if (!(invoice is Model.InvoiceCO))
                throw new ArgumentException();

            _Update((Model.InvoiceCO)invoice);
        }

        protected override void _TurnNormal(Model.Invoice invoice)
        {
            if (!(invoice is Model.InvoiceCO))
                throw new ArgumentException();

            _TurnNormal((Model.InvoiceCO)invoice);
        }

        protected override void _TurnNull(Model.Invoice invoice)
        {
            if (!(invoice is Model.InvoiceCO))
                throw new ArgumentException();

            _TurnNull((Model.InvoiceCO)invoice);
        }

        public override void Delete(string invoiceId)
        {
            try
            {
                //修改物料需求的排单状态
                accessor.UpdateMRSState(invoiceId);

                accessor.Delete(invoiceId);
            }
            catch
            {
                BL.V.RollbackTransaction();
                throw;
            }
        }

        #region Other

        protected override string GetInvoiceKind()
        {
            return "CO";
        }

        protected override string GetSettingId()
        {
            return "InvoiceNumberRuleOfCO";
        }


        protected override Book.DA.IInvoiceAccessor GetAccessor()
        {
            return accessor;
        }
        #endregion

        #region Validation

        protected override void _ValidateForUpdate(Book.Model.Invoice invoice)
        {
            base._ValidateForUpdate(invoice);
            Validate((Model.InvoiceCO)invoice);
            //
        }

        protected override void _ValidateForInsert(Book.Model.Invoice invoice)
        {
            base._ValidateForInsert(invoice);

            Validate((Model.InvoiceCO)invoice);
        }

        //public void InsertInvoiceCO(Model.InvoiceCO invoiceCO)
        //{
        //    try
        //    {
        //        V.BeginTransaction();
        //        accessor.Insert(invoiceCO);
        //        string invoiceKind = this.GetInvoiceKind().ToLower();

        //        string sequencekey_y = string.Format("{0}-y-{1}", invoiceKind, DateTime.Now.Year);
        //        string sequencekey_m = string.Format("{0}-m-{1}-{2}", invoiceKind, DateTime.Now.Year, DateTime.Now.Month);
        //        string sequencekey_d = string.Format("{0}-d-{1}", invoiceKind, DateTime.Now.ToString("yyyy-MM-dd"));
        //        string sequencekey = string.Format(invoiceKind);

        //        SequenceManager.Increment(sequencekey_y);
        //        SequenceManager.Increment(sequencekey_m);
        //        SequenceManager.Increment(sequencekey_d);
        //        SequenceManager.Increment(sequencekey);
        //        V.CommitTransaction();
        //    }
        //    catch
        //    {
        //        V.RollbackTransaction();
        //        throw;

        //    }
        //}

        private void Validate(Book.Model.InvoiceCO invoice)
        {
            if (invoice.Supplier == null)
            {
                throw new Helper.RequireValueException("Company");
            }

            if (invoice.Details.Count == 0)
            {
                throw new Helper.RequireValueException("Details");
            }
            else
            {

                if (string.IsNullOrEmpty(invoice.Details[0].ProductId))
                {
                    if (invoice.Details.Count <= 1)
                    {
                        throw new Helper.RequireValueException("Details");
                    }
                }
            }
            //foreach (Model.InvoiceCODetail detail in invoice.Details)
            //{
            //    if (detail.Product == null || string.IsNullOrEmpty(detail.Product.ProductId)) continue;
            //    //if (detail.InvoiceCODetailPrice == 0)
            //    //{
            //    //    throw new Helper.RequireValueException("Price");
            //    //}
            //}
        }

        #endregion

        #endregion

        private void _TurnNormal(Model.InvoiceCO invoice)
        {
            invoice.InvoiceStatus = (int)Helper.InvoiceStatus.Normal;
            _Update(invoice);
        }

        private void _TurnNull(Model.InvoiceCO invoice)
        {
            invoice.InvoiceStatus = (int)Helper.InvoiceStatus.Null;
            _Update(invoice);
        }

        private void _Insert(Model.InvoiceCO invoice)
        {
            invoice.InvoiceFlag = 0;
            invoice.InsertTime = DateTime.Now;
            invoice.UpdateTime = DateTime.Now;
            invoice.InvoiceGZTime = DateTime.Now;
            invoice.SupplierId = invoice.Supplier.SupplierId;
            if (invoice.Employee0 != null)
            {
                invoice.Employee0Id = invoice.Employee0.EmployeeId;
            }

            if (invoice.Employee1 != null)
            {
                invoice.Employee1Id = invoice.Employee1.EmployeeId;
            }

            if (invoice.Employee2 != null)
            {
                invoice.Employee2Id = invoice.Employee2.EmployeeId;
            }
            invoice.IsClose = false;
            accessor.Insert(invoice);
            foreach (Model.InvoiceCODetail detail in invoice.Details)
            {
                if (detail.Product == null || string.IsNullOrEmpty(detail.Product.ProductId)) continue;
                detail.InvoiceId = invoice.InvoiceId;
                detail.DetailsFlag = Convert.ToInt32(Helper.DetailsFlag.OnTheWay);
                detail.ArrivalQuantity = 0;
                detail.NoArrivalQuantity = detail.OrderQuantity;
                detail.InvoiceCTQuantity = 0;
                Model.Product product = productAccessor.Get(detail.ProductId);
                //product.OrderOnWayQuantity += detail.NoArrivalQuantity;
                product.OrderOnWayQuantity = Convert.ToDouble(product.OrderOnWayQuantity) + Convert.ToDouble(detail.NoArrivalQuantity);
                productManager.update(product);
                // this.UpdateSql("update product set OrderOnWayQuantity=isnull( OrderOnWayQuantity,0)+" + (detail.OrderQuantity.HasValue ? detail.OrderQuantity : 0) + " where productid='" + detail.ProductId + "'");
                invoiceCODetailAccessor.Insert(detail);
            }
        }
        private void _Update(Model.InvoiceCO invoice)
        {

            Model.InvoiceCO invoiceOriginal = this.Get(invoice.InvoiceId);

            switch ((Helper.InvoiceStatus)invoiceOriginal.InvoiceStatus)
            {
                #region Draft

                case Helper.InvoiceStatus.Draft:
                    switch ((Helper.InvoiceStatus)invoice.InvoiceStatus)
                    {
                        #region Draft -> Draft

                        case Helper.InvoiceStatus.Draft:

                            invoice.UpdateTime = DateTime.Now; 
                            invoice.SupplierId = invoice.Supplier.SupplierId;
                            invoice.Employee0Id = invoice.Employee0.EmployeeId;
                            accessor.Update(invoice);

                            invoiceCODetailAccessor.Delete(invoice);
                            foreach (Model.InvoiceCODetail detail in invoice.Details)
                            {
                                if (detail.Product == null || string.IsNullOrEmpty(detail.Product.ProductId)) continue;
                                detail.InvoiceCODetailId = Guid.NewGuid().ToString();
                                detail.InvoiceId = invoice.InvoiceId;
                                invoiceCODetailAccessor.Insert(detail);
                            }
                            break;

                        #endregion

                        #region Draft -> Normal

                        case Helper.InvoiceStatus.Normal:

                            invoice.UpdateTime = DateTime.Now; ;
                            invoice.SupplierId = invoice.Supplier.SupplierId;
                            invoice.Employee0Id = invoice.Employee0.EmployeeId;
                            invoice.Employee2Id = invoice.Employee2.EmployeeId;
                            invoice.InvoiceGZTime = DateTime.Now; ;
                            accessor.Update(invoice);

                            invoiceCODetailAccessor.Delete(invoice);
                            foreach (Model.InvoiceCODetail detail in invoice.Details)
                            {
                                if (detail.Product == null || string.IsNullOrEmpty(detail.Product.ProductId)) continue;
                                detail.InvoiceCODetailId = Guid.NewGuid().ToString();
                                detail.InvoiceId = invoice.InvoiceId;
                                invoiceCODetailAccessor.Insert(detail);
                            }
                            break;

                        #endregion

                        #region Draft -> Null

                        case Helper.InvoiceStatus.Null:
                            throw new InvalidOperationException();

                        #endregion
                    }
                    break;

                #endregion

                #region Normal

                case Helper.InvoiceStatus.Normal:
                    switch ((Helper.InvoiceStatus)invoice.InvoiceStatus)
                    {
                        #region Normal -> Draft

                        case Helper.InvoiceStatus.Draft:
                            throw new InvalidOperationException();

                        #endregion

                        #region Normal -> Normal

                        case Helper.InvoiceStatus.Normal:
                            invoiceOriginal.InvoiceStatus = (int)Helper.InvoiceStatus.Null;
                            _TurnNull(invoiceOriginal);
                            //accessor.Delete(invoiceOriginal.InvoiceId);
                            //invoice.InsertTime = invoiceOriginal.InsertTime;
                            //invoice.UpdateTime = DateTime.Now;
                            //_Insert(invoice);
                            invoice.UpdateTime = DateTime.Now;
                            invoice.Employee3Id = null;
                            invoice.InvoiceZFTime = DateTime.Now;

                            invoiceCODetailAccessor.Delete(invoiceOriginal);
                            foreach (Model.InvoiceCODetail detail in invoice.Details)
                            {
                                if (detail.Product == null || string.IsNullOrEmpty(detail.Product.ProductId)) continue;
                                detail.InvoiceId = invoice.InvoiceId;
                                if (!detail.InvoiceCTQuantity.HasValue)
                                    detail.InvoiceCTQuantity = 0;
                                detail.ArrivalQuantity = detail.ArrivalQuantity == null ? 0 : detail.ArrivalQuantity;
                                detail.NoArrivalQuantity = detail.OrderQuantity - detail.ArrivalQuantity + detail.InvoiceCTQuantity;
                                if (detail.NoArrivalQuantity < 0) detail.NoArrivalQuantity = 0;

                                if (detail.NoArrivalQuantity == 0)
                                    detail.DetailsFlag = Convert.ToInt32(Helper.DetailsFlag.AllArrived);
                                else
                                    detail.DetailsFlag = Convert.ToInt32(Helper.DetailsFlag.OnTheWay);

                                Model.Product product = productAccessor.Get(detail.ProductId);
                                //product.OrderOnWayQuantity += detail.NoArrivalQuantity;
                                product.OrderOnWayQuantity = Convert.ToDouble(product.OrderOnWayQuantity) + Convert.ToDouble(detail.NoArrivalQuantity);
                                productManager.update(product);
                                invoiceCODetailAccessor.Insert(detail);
                            }
                            EvaInvoiceFlag(invoice);
                            accessor.Update(invoice);

                            break;

                        #endregion

                        #region Normal -> null

                        case Helper.InvoiceStatus.Null:
                            foreach (Model.InvoiceCODetail detail in invoice.Details)
                            {
                                if (detail.Product == null || string.IsNullOrEmpty(detail.Product.ProductId)) continue;
                                Model.Product product = productAccessor.Get(detail.ProductId);
                                //product.OrderOnWayQuantity -= detail.NoArrivalQuantity;
                                product.OrderOnWayQuantity = Convert.ToDouble(product.OrderOnWayQuantity) - Convert.ToDouble(detail.NoArrivalQuantity);
                                //2017年7月24日00:07:10： 可以为负,否则会导致不准
                                //product.OrderOnWayQuantity = product.OrderOnWayQuantity <= 0 ? 0 : product.OrderOnWayQuantity;
                                productManager.update(product);
                                //  invoiceCODetailAccessor.Update(detail);
                            }
                            break;

                        #endregion
                    }
                    break;

                #endregion

                #region Null

                case Helper.InvoiceStatus.Null:
                    throw new InvalidOperationException();

                #endregion
            }
        }

        public IList<Model.InvoiceCO> Select(Model.Supplier supplier)
        {
            return accessor.Select(supplier);
        }

        public void UpdateAccess(Book.Model.InvoiceCO invoiceCO)
        {
            accessor.Updates(invoiceCO);
        }
        public IList<Model.InvoiceCO> SelectbySupplierAndinvoiceId(Model.Supplier supplier, string invoiceId)
        {
            return accessor.SelectbySupplierAndinvoiceId(supplier, invoiceId);
        }

        public void EvaInvoiceFlag(Model.InvoiceCO invoiceCO)
        {
            int flag = 0;
            foreach (Model.InvoiceCODetail detail in invoiceCO.Details)
            {
                flag += detail.DetailsFlag.Value;
            }
            if (flag == 0)
                invoiceCO.InvoiceFlag = 0;
            else if (flag < invoiceCO.Details.Count * 2)
                invoiceCO.InvoiceFlag = 1;
            else if (flag == invoiceCO.Details.Count * 2)
            {
                invoiceCO.InvoiceFlag = 2;
                invoiceCO.IsClose = true;
            }
        }
        public void UpdateInvoiceFlag(Model.InvoiceCO invoiceCO)
        {

            int flag = 0;
            IList<Model.InvoiceCODetail> list = invoiceCODetailAccessor.Select(invoiceCO);
            foreach (Model.InvoiceCODetail detail in list)
            {
                flag += detail.DetailsFlag == null ? 0 : detail.DetailsFlag.Value;
            }
            if (flag == 0)
                invoiceCO.InvoiceFlag = 0;
            else if (flag < list.Count * 2)
                invoiceCO.InvoiceFlag = 1;
            else if (flag == list.Count * 2)
            {
                invoiceCO.InvoiceFlag = 2;
                invoiceCO.IsClose = true;
            }
            accessor.Update(invoiceCO);
        }
        public IList<Model.InvoiceCO> SelectByMrsHeaderId(string MrsHeaderId)
        {
            return accessor.SelectByMrsHeaderId(MrsHeaderId);
        }
        public IList<Book.Model.InvoiceCO> SelectDateRangAndWhere(string costartid, string coendid, Model.Supplier SupplierStart, Model.Supplier SupplierEnd, DateTime? dateStart, DateTime? dateEnd, Model.Product productStart, Model.Product productEnd, string cusxoid, DateTime dateJHStart, DateTime dateJHEnd, int invoiceFlag, string InvoiceCGIdStart, string InvoiceCGIdEnd)
        {
            return accessor.SelectDateRangAndWhere(costartid, coendid, SupplierStart, SupplierEnd, dateStart, dateEnd, productStart, productEnd, cusxoid, dateJHStart, dateJHEnd, invoiceFlag, InvoiceCGIdStart, InvoiceCGIdEnd);
        }

        public string SelectByInvoiceCusID(string id)
        {
            return accessor.SelectByInvoiceCusID(id);
        }

        public DateTime GetInvoiceYjrq(string id)
        {
            return accessor.GetInvoiceYjrq(id);
        }

        protected override void TiGuiExists(Book.Model.Invoice model)
        {
            MethodInfo methodinfo = this.GetType().GetMethod("HasRows", new Type[] { typeof(string) });
            bool f = (bool)methodinfo.Invoke(this, new object[] { model.InvoiceId });
            if (f)
            {
                //设置KEY值
                string invoiceKind = this.GetInvoiceKind().ToLower();
                string sequencekey_d = string.Format("{0}-d-{1}", invoiceKind, model.InsertTime.Value.ToString("yyyy-MM-dd"));
                SequenceManager.Increment(sequencekey_d);
                model.InvoiceId = this.GetIdSimple(model.InsertTime.Value);
                TiGuiExists(model);
            }
        }
    }
}