﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：ExchangeRate.autogenerated.cs
// author: mayanjun
// create date：2018/11/15 23:30:49
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
	public partial class ExchangeRate
	{
		#region Data

		/// <summary>
		/// 
		/// </summary>
		private string _id;

        private DateTime? _useDate;

        private string _currency;

        private decimal _rate;
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 
		/// </summary>
		public string Id
		{
			get 
			{
				return this._id;
			}
			set 
			{
				this._id = value;
			}
		}
        
        public DateTime? UseDate
        {
            get { return _useDate; }
            set { _useDate = value; }
        }

        public string Currency
        {
            get { return _currency; }
            set { _currency = value; }
        }

        public decimal Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_Id = "Id";
		
		/// <summary>
		/// 
		/// </summary>
        public readonly static string PRO_UseDate = "UseDate";
		
		/// <summary>
		/// 
		/// </summary>
        public readonly static string PRO_Currency = "Currency";
		
		/// <summary>
		/// 
		/// </summary>
        public readonly static string PRO_Rate = "Rate";
		
		
		#endregion
	}
}