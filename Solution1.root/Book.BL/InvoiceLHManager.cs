//------------------------------------------------------------------------------
//
// file name：InvoiceLHManager.cs
// author: mayanjun
// create date：2018/10/20 11:17:53
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    /// <summary>
    /// Business logic for dbo.InvoiceLH.
    /// </summary>
    public partial class InvoiceLHManager : InvoiceManager
    {
		
		/// <summary>
		/// Delete InvoiceLH by primary key.
		/// </summary>
		public void Delete(string invoiceId)
		{
			//
			// todo:add other logic here
			//
			accessor.Delete(invoiceId);
		}

		/// <summary>
		/// Insert a InvoiceLH.
		/// </summary>
        public void Insert(Model.InvoiceLH invoiceLH)
        {
			//
			// todo:add other logic here
			//
            accessor.Insert(invoiceLH);
        }
		
		/// <summary>
		/// Update a InvoiceLH.
		/// </summary>
        public void Update(Model.InvoiceLH invoiceLH)
        {
			//
			// todo: add other logic here.
			//
            accessor.Update(invoiceLH);
        }

        protected override void _Insert(Book.Model.Invoice invoice)
        {
            throw new NotImplementedException();
        }

        protected override void _Update(Book.Model.Invoice invoice)
        {
            throw new NotImplementedException();
        }

        protected override void _TurnNormal(Book.Model.Invoice invoice)
        {
            throw new NotImplementedException();
        }

        protected override void _TurnNull(Book.Model.Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
