﻿//------------------------------------------------------------------------------
//
// file name：ExchangeRate.cs
// author: mayanjun
// create date：2018/11/15 23:30:48
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
    /// <summary>
    /// 汇率
    /// </summary>
    [Serializable]
    public partial class ExchangeRate
    {
        public int? Year
        {
            get
            {
                if (this.UseDate == null)
                    return null;
                else
                    return this.UseDate.Value.Year;
            }
        }

        public int? Month
        {
            get
            {
                if (this.UseDate == null)
                    return null;
                else
                    return this.UseDate.Value.Month;
            }
        }

        public string TenDays
        {
            get
            {
                if (this.UseDate == null)
                    return null;
                else
                {
                    if (this.UseDate.Value.Day < 11)
                        return "上旬";
                    else if (this.UseDate.Value.Day >= 11 && this.UseDate.Value.Day < 21)
                        return "中旬";
                    else
                        return "下旬";
                }
            }
        }

        public static string ConvertCurrencyName(string currency)
        {
            string enName = "";
            switch (currency)
            {
                case "人民幣":
                    enName = "RMB";
                    break;
                case "新台幣":
                    enName = "NTD";
                    break;
                case "美金":
                    enName = "USD";
                    break;
                case "歐元":
                    enName = "EURO";
                    break;
                case "日圓":
                    enName = "JYP";
                    break;
            }

            return enName;
        }
    }
}