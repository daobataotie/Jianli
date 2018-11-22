//------------------------------------------------------------------------------
//
// file name：ExchangeRateManager.cs
// author: mayanjun
// create date：2018/11/15 23:30:48
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Book.BL
{
    /// <summary>
    /// Business logic for dbo.ExchangeRate.
    /// </summary>
    public partial class ExchangeRateManager
    {

        /// <summary>
        /// Delete ExchangeRate by primary key.
        /// </summary>
        public void Delete(string id)
        {
            //
            // todo:add other logic here
            //
            accessor.Delete(id);
        }

        /// <summary>
        /// Insert a ExchangeRate.
        /// </summary>
        public void Insert(Model.ExchangeRate exchangeRate)
        {
            //
            // todo:add other logic here
            //
            accessor.Insert(exchangeRate);
        }

        /// <summary>
        /// Update a ExchangeRate.
        /// </summary>
        public void Update(Model.ExchangeRate exchangeRate)
        {
            //
            // todo: add other logic here.
            //
            accessor.Update(exchangeRate);
        }

        public bool IsExistsSame(Model.ExchangeRate model)
        {
            return accessor.IsExistsSame(model);
        }

        public decimal GetRateByDateAndCurrency(DateTime date, string currency)
        {
            return accessor.GetRateByDateAndCurrency(date, currency);
        }

        public void Update(IList<Model.ExchangeRate> list)
        {
            foreach (var item in list)
            {
                if (item.UseDate == null)
                    throw new Helper.RequireValueException(Model.ExchangeRate.PRO_UseDate);
                if (string.IsNullOrEmpty(item.Currency))
                    throw new Helper.RequireValueException(Model.ExchangeRate.PRO_Currency);
                //if (IsExistsSame(item))
                //    throw new Helper.RequireValueException(Model.ExchangeRate.PRO_Id);

                //更改日期
                if (item.UseDate.Value.Day < 11)
                    item.UseDate = DateTime.Parse(string.Format("{0}-{1}-{2}", item.Year, item.Month, "1"));
                else if (item.UseDate.Value.Day >= 11 && item.UseDate.Value.Day < 21)
                    item.UseDate = DateTime.Parse(string.Format("{0}-{1}-{2}", item.Year, item.Month, "11"));
                else
                    item.UseDate = DateTime.Parse(string.Format("{0}-{1}-{2}", item.Year, item.Month, "21"));

                if (IsExistsSame(item))
                    throw new Exception(string.Format("已存在相同的日期 {0}-{1}-{2} 相同的幣別 {3}", item.Year, item.Month, item.TenDays, item.Currency));
            }

            foreach (var item in list)
            {
                if (accessor.ExistsPrimary(item.Id))
                {
                    accessor.Update(item);
                }
                else
                {
                    this.Insert(item);
                }
            }
        }
    }
}
