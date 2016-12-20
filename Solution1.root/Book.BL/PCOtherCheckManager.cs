//------------------------------------------------------------------------------
//
// file name：PCOtherCheckManager.cs
// author: mayanjun
// create date：2011-11-10 15:05:55
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    /// <summary>
    /// Business logic for dbo.PCOtherCheck.
    /// </summary>
    public partial class PCOtherCheckManager : BaseManager
    {
        private static readonly DA.IPCOtherCheckDetailAccessor PCOtherCheckDetailAccessor = (DA.IPCOtherCheckDetailAccessor)Accessors.Get("PCOtherCheckDetailAccessor");
        BL.InvoiceCODetailManager codetailManager = new InvoiceCODetailManager();
        BL.ProduceOtherCompactDetailManager pocdetailManager = new ProduceOtherCompactDetailManager();

        /// <summary>
        /// Delete PCOtherCheck by primary key.
        /// </summary>
        public void Delete(string pCOtherCheckId)
        {
            accessor.Delete(pCOtherCheckId);
        }
        public void Delete(Model.PCOtherCheck model)
        {
            try
            {
                BL.V.BeginTransaction();

                foreach (var item in model.Detail)
                {
                    //采购单已做过进料检验的数量
                    if (item.PCOtherCheckDetailFromPC == "1")
                    {
                        Model.InvoiceCODetail codetail = this.codetailManager.Get(item.FromInvoiceDetailID);
                        if (codetail != null)
                        {
                            codetail.HasCheckQuantity = Convert.ToDecimal(codetail.HasCheckQuantity) - Convert.ToDecimal(item.InQuantity);
                            codetail.HasCheckQuantity = codetail.HasCheckQuantity < 0 ? 0 : codetail.HasCheckQuantity;
                            this.codetailManager.Update(codetail);
                        }
                    }

                    //委外合同
                    if (item.PCOtherCheckDetailFromPC == "0")
                    {
                        Model.ProduceOtherCompactDetail pocdetail = this.pocdetailManager.Get(item.FromInvoiceDetailID);
                        if (pocdetail != null)
                        {
                            pocdetail.HasCheckQuantity = Convert.ToDecimal(pocdetail.HasCheckQuantity) - Convert.ToDecimal(item.InQuantity);
                            pocdetail.HasCheckQuantity = pocdetail.HasCheckQuantity < 0 ? 0 : pocdetail.HasCheckQuantity;
                            this.pocdetailManager.Update(pocdetail);
                        }
                    }
                }

                PCOtherCheckDetailAccessor.DeleteByPCOCId(model.PCOtherCheckId);

                this.Delete(model.PCOtherCheckId);

                BL.V.CommitTransaction();
            }
            catch
            {
                BL.V.RollbackTransaction();
                throw;
            }
        }

        /// <summary>
        /// Insert a PCOtherCheck.
        /// </summary>
        public void Insert(Model.PCOtherCheck pCOtherCheck)
        {
            Validate(pCOtherCheck);
            try
            {
                BL.V.BeginTransaction();
                TiGuiExists(pCOtherCheck);
                pCOtherCheck.InsertTime = DateTime.Now;
                pCOtherCheck.UpdateTime = DateTime.Now;

                string invoiceKind = this.GetInvoiceKind().ToLower();
                string sequencekey_y = string.Format("{0}-y-{1}", invoiceKind, pCOtherCheck.InsertTime.Value.Year);
                string sequencekey_m = string.Format("{0}-m-{1}-{2}", invoiceKind, pCOtherCheck.InsertTime.Value.Year, pCOtherCheck.InsertTime.Value.Month);
                string sequencekey_d = string.Format("{0}-d-{1}", invoiceKind, pCOtherCheck.InsertTime.Value.ToString("yyyy-MM-dd"));
                string sequencekey = string.Format(invoiceKind);
                SequenceManager.Increment(sequencekey_y);
                SequenceManager.Increment(sequencekey_m);
                SequenceManager.Increment(sequencekey_d);
                SequenceManager.Increment(sequencekey);

                accessor.Insert(pCOtherCheck);

                foreach (Model.PCOtherCheckDetail PcotherCheckDetail in pCOtherCheck.Detail)
                {
                    if (PcotherCheckDetail.Product == null || string.IsNullOrEmpty(PcotherCheckDetail.Product.ProductId)) continue;
                    PcotherCheckDetail.PCOtherCheckId = pCOtherCheck.PCOtherCheckId;
                    PCOtherCheckDetailAccessor.Insert(PcotherCheckDetail);

                    //采购单已做过进料检验的数量
                    if (PcotherCheckDetail.PCOtherCheckDetailFromPC == "1")
                    {
                        Model.InvoiceCODetail codetail = this.codetailManager.Get(PcotherCheckDetail.FromInvoiceDetailID);
                        if (codetail != null)
                        {
                            codetail.HasCheckQuantity = Convert.ToDecimal(codetail.HasCheckQuantity) + Convert.ToDecimal(PcotherCheckDetail.InQuantity);
                            this.codetailManager.Update(codetail);
                        }
                    }

                    //委外合同
                    if (PcotherCheckDetail.PCOtherCheckDetailFromPC == "0")
                    {
                        Model.ProduceOtherCompactDetail pocdetail = this.pocdetailManager.Get(PcotherCheckDetail.FromInvoiceDetailID);
                        if (pocdetail != null)
                        {
                            pocdetail.HasCheckQuantity = Convert.ToDecimal(pocdetail.HasCheckQuantity) + Convert.ToDecimal(PcotherCheckDetail.InQuantity);
                            this.pocdetailManager.Update(pocdetail);
                        }
                    }
                }
                BL.V.CommitTransaction();
            }
            catch
            {
                BL.V.RollbackTransaction();
                throw;
            }
        }

        /// <summary>
        /// Update a PCOtherCheck.
        /// </summary>
        public void Update(Model.PCOtherCheck pCOtherCheck)
        {
            Validate(pCOtherCheck);
            if (pCOtherCheck != null)
            {
                //修改头
                pCOtherCheck.UpdateTime = DateTime.Now;
                accessor.Update(pCOtherCheck);

                //删除详细
                IList<Model.PCOtherCheckDetail> Oldlist = PCOtherCheckDetailAccessor.Selct(pCOtherCheck);
                foreach (var item in Oldlist)
                {
                    //采购单已做过进料检验的数量
                    if (item.PCOtherCheckDetailFromPC == "1")
                    {
                        Model.InvoiceCODetail codetail = this.codetailManager.Get(item.FromInvoiceDetailID);
                        if (codetail != null)
                        {
                            codetail.HasCheckQuantity = Convert.ToDecimal(codetail.HasCheckQuantity) - Convert.ToDecimal(item.InQuantity);
                            codetail.HasCheckQuantity = codetail.HasCheckQuantity < 0 ? 0 : codetail.HasCheckQuantity;
                            this.codetailManager.Update(codetail);
                        }
                    }

                    //委外合同
                    if (item.PCOtherCheckDetailFromPC == "0")
                    {
                        Model.ProduceOtherCompactDetail pocdetail = this.pocdetailManager.Get(item.FromInvoiceDetailID);
                        if (pocdetail != null)
                        {
                            pocdetail.HasCheckQuantity = Convert.ToDecimal(pocdetail.HasCheckQuantity) - Convert.ToDecimal(item.InQuantity);
                            pocdetail.HasCheckQuantity = pocdetail.HasCheckQuantity < 0 ? 0 : pocdetail.HasCheckQuantity;
                            this.pocdetailManager.Update(pocdetail);
                        }
                    }
                }
                PCOtherCheckDetailAccessor.DeleteByPCOCId(pCOtherCheck.PCOtherCheckId);

                //添加详细
                foreach (Model.PCOtherCheckDetail details in pCOtherCheck.Detail)
                {
                    details.PCOtherCheckId = pCOtherCheck.PCOtherCheckId;
                    PCOtherCheckDetailAccessor.Insert(details);

                    //采购单已做过进料检验的数量
                    if (details.PCOtherCheckDetailFromPC == "1")
                    {
                        Model.InvoiceCODetail codetail = this.codetailManager.Get(details.FromInvoiceDetailID);
                        if (codetail != null)
                        {
                            codetail.HasCheckQuantity = Convert.ToDecimal(codetail.HasCheckQuantity) + Convert.ToDecimal(details.InQuantity);
                            this.codetailManager.Update(codetail);
                        }
                    }

                    //委外合同
                    if (details.PCOtherCheckDetailFromPC == "0")
                    {
                        Model.ProduceOtherCompactDetail pocdetail = this.pocdetailManager.Get(details.FromInvoiceDetailID);
                        if (pocdetail != null)
                        {
                            pocdetail.HasCheckQuantity = Convert.ToDecimal(pocdetail.HasCheckQuantity) + Convert.ToDecimal(details.InQuantity);
                            this.pocdetailManager.Update(pocdetail);
                        }
                    }
                }
            }
        }

        private void Validate(Model.PCOtherCheck _pcoc)
        {
            if (string.IsNullOrEmpty(_pcoc.PCOtherCheckId))
                throw new Helper.RequireValueException(Model.PCOtherCheck.PRO_PCOtherCheckId);
            if (string.IsNullOrEmpty(_pcoc.PCOtherCheckDate.ToString()))
                throw new Helper.RequireValueException(Model.PCOtherCheck.PRO_PCOtherCheckDate);
            if (string.IsNullOrEmpty(_pcoc.Employee0Id))
                throw new Helper.RequireValueException(Model.PCOtherCheck.PRO_Employee0Id);

            foreach (var item in _pcoc.Detail)
            {
                if (item.PCOtherCheckDetailQuantity > item.InQuantity)
                    throw new Helper.InvalidValueException(Model.PCOtherCheckDetail.PRO_PCOtherCheckDetailQuantity);
            }
        }

        private void TiGuiExists(Model.PCOtherCheck model)
        {
            if (this.ExistsPrimary(model.PCOtherCheckId))
            {
                //设置KEY值
                string invoiceKind = this.GetInvoiceKind().ToLower();
                string sequencekey_y = string.Format("{0}-y-{1}", invoiceKind, model.PCOtherCheckDate.Value.Year);
                string sequencekey_m = string.Format("{0}-m-{1}-{2}", invoiceKind, model.PCOtherCheckDate.Value.Year, model.PCOtherCheckDate.Value.Month);
                string sequencekey_d = string.Format("{0}-d-{1}", invoiceKind, model.PCOtherCheckDate.Value.ToString("yyyy-MM-dd"));
                string sequencekey = string.Format(invoiceKind);
                SequenceManager.Increment(sequencekey_y);
                SequenceManager.Increment(sequencekey_m);
                SequenceManager.Increment(sequencekey_d);
                SequenceManager.Increment(sequencekey);
                model.PCOtherCheckId = this.GetId(model.PCOtherCheckDate.Value);
                TiGuiExists(model);
                //throw new Helper.InvalidValueException(Model.Product.PRO_Id);               
            }

        }

        public Model.PCOtherCheck GetDetails(string PCOtherCheckId)
        {
            Model.PCOtherCheck _Pcoc = accessor.Get(PCOtherCheckId);
            _Pcoc.Detail = PCOtherCheckDetailAccessor.Selct(_Pcoc);
            return _Pcoc;
        }

        public IList<Model.PCOtherCheck> SelectByDateRage(DateTime StartDate, DateTime EndDate, Model.Product product, Model.Customer customer, string CusXOId)
        {
            return accessor.SelectByDateRage(StartDate, EndDate, product, customer, CusXOId);
        }

        protected override string GetSettingId()
        {
            return "pcocRule";
        }

        protected override string GetInvoiceKind()
        {
            return "pcoc";
        }
    }
}

