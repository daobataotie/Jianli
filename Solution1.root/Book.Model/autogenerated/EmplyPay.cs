﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：EmplyPay.autogenerated.cs
// author: peidun
// create date：2010-3-24 11:21:45
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
	public partial class EmplyPay
	{
		#region Data

		/// <summary>
		/// 薪资记录编号
		/// </summary>
		private string _emplyPayId;
		
		/// <summary>
		/// 员工编号
		/// </summary>
		private string _employeeId;
		
		/// <summary>
		/// 操作员
		/// </summary>
		private string _employee0Id;
		
		/// <summary>
		/// 插入时间
		/// </summary>
		private DateTime? _insertTime;
		
		/// <summary>
		/// 修改时间
		/// </summary>
		private DateTime? _updateTime;
		
		/// <summary>
		/// 薪资月份
		/// </summary>
		private DateTime? _payDate;
		
		/// <summary>
		/// 历史日薪
		/// </summary>
		private decimal? _edailyPay;
		
		/// <summary>
		/// 月薪
		/// </summary>
		private decimal? _emonthlyPay;
		
		/// <summary>
		/// 责任津贴
		/// </summary>
		private decimal? _edutyPay;
		
		/// <summary>
		/// 职位津贴
		/// </summary>
		private decimal? _epostPay;
		
		/// <summary>
		/// 职场津贴
		/// </summary>
		private decimal? _efeldPay;
		
		/// <summary>
		/// 保险费
		/// </summary>
		private decimal? _einsurance;
		
		/// <summary>
		/// 平时加班补贴
		/// </summary>
		private decimal? _eoverpay;
		
		/// <summary>
		/// 假日加班每小时补贴
		/// </summary>
		private decimal? _eleavepay;
		
		/// <summary>
		/// 其他
		/// </summary>
		private decimal? _eotherPay;
		
		/// <summary>
		/// 税率
		/// </summary>
		private double? _etax;
		
		/// <summary>
		/// 员工
		/// </summary>
		private Employee _employee0;
		/// <summary>
		/// 员工
		/// </summary>
		private Employee _employee;
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 薪资记录编号
		/// </summary>
		public string EmplyPayId
		{
			get 
			{
				return this._emplyPayId;
			}
			set 
			{
				this._emplyPayId = value;
			}
		}

		/// <summary>
		/// 员工编号
		/// </summary>
		public string EmployeeId
		{
			get 
			{
				return this._employeeId;
			}
			set 
			{
				this._employeeId = value;
			}
		}

		/// <summary>
		/// 操作员
		/// </summary>
		public string Employee0Id
		{
			get 
			{
				return this._employee0Id;
			}
			set 
			{
				this._employee0Id = value;
			}
		}

		/// <summary>
		/// 插入时间
		/// </summary>
		public DateTime? InsertTime
		{
			get 
			{
				return this._insertTime;
			}
			set 
			{
				this._insertTime = value;
			}
		}

		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime? UpdateTime
		{
			get 
			{
				return this._updateTime;
			}
			set 
			{
				this._updateTime = value;
			}
		}

		/// <summary>
		/// 薪资月份
		/// </summary>
		public DateTime? PayDate
		{
			get 
			{
				return this._payDate;
			}
			set 
			{
				this._payDate = value;
			}
		}

		/// <summary>
		/// 历史日薪
		/// </summary>
		public decimal? EdailyPay
		{
			get 
			{
				return this._edailyPay;
			}
			set 
			{
				this._edailyPay = value;
			}
		}

		/// <summary>
		/// 月薪
		/// </summary>
		public decimal? EmonthlyPay
		{
			get 
			{
				return this._emonthlyPay;
			}
			set 
			{
				this._emonthlyPay = value;
			}
		}

		/// <summary>
		/// 责任津贴
		/// </summary>
		public decimal? EdutyPay
		{
			get 
			{
				return this._edutyPay;
			}
			set 
			{
				this._edutyPay = value;
			}
		}

		/// <summary>
		/// 职位津贴
		/// </summary>
		public decimal? EpostPay
		{
			get 
			{
				return this._epostPay;
			}
			set 
			{
				this._epostPay = value;
			}
		}

		/// <summary>
		/// 职场津贴
		/// </summary>
		public decimal? EfeldPay
		{
			get 
			{
				return this._efeldPay;
			}
			set 
			{
				this._efeldPay = value;
			}
		}

		/// <summary>
		/// 保险费
		/// </summary>
		public decimal? Einsurance
		{
			get 
			{
				return this._einsurance;
			}
			set 
			{
				this._einsurance = value;
			}
		}

		/// <summary>
		/// 平时加班补贴
		/// </summary>
		public decimal? Eoverpay
		{
			get 
			{
				return this._eoverpay;
			}
			set 
			{
				this._eoverpay = value;
			}
		}

		/// <summary>
		/// 假日加班每小时补贴
		/// </summary>
		public decimal? Eleavepay
		{
			get 
			{
				return this._eleavepay;
			}
			set 
			{
				this._eleavepay = value;
			}
		}

		/// <summary>
		/// 其他
		/// </summary>
		public decimal? EotherPay
		{
			get 
			{
				return this._eotherPay;
			}
			set 
			{
				this._eotherPay = value;
			}
		}

		/// <summary>
		/// 税率
		/// </summary>
		public double? Etax
		{
			get 
			{
				return this._etax;
			}
			set 
			{
				this._etax = value;
			}
		}
	
		/// <summary>
		/// 员工
		/// </summary>
		public virtual Employee Employee0
		{
			get
			{
				return this._employee0;
			}
			set
			{
				this._employee0 = value;
			}
			
		}
		/// <summary>
		/// 员工
		/// </summary>
		public virtual Employee Employee
		{
			get
			{
				return this._employee;
			}
			set
			{
				this._employee = value;
			}
			
		}
		/// <summary>
		/// 薪资记录编号
		/// </summary>
		public readonly static string PROPERTY_EMPLYPAYID = "EmplyPayId";
		
		/// <summary>
		/// 员工编号
		/// </summary>
		public readonly static string PROPERTY_EMPLOYEEID = "EmployeeId";
		
		/// <summary>
		/// 操作员
		/// </summary>
		public readonly static string PROPERTY_EMPLOYEE0ID = "Employee0Id";
		
		/// <summary>
		/// 插入时间
		/// </summary>
		public readonly static string PROPERTY_INSERTTIME = "InsertTime";
		
		/// <summary>
		/// 修改时间
		/// </summary>
		public readonly static string PROPERTY_UPDATETIME = "UpdateTime";
		
		/// <summary>
		/// 薪资月份
		/// </summary>
		public readonly static string PROPERTY_PAYDATE = "PayDate";
		
		/// <summary>
		/// 历史日薪
		/// </summary>
		public readonly static string PROPERTY_EDAILYPAY = "EdailyPay";
		
		/// <summary>
		/// 月薪
		/// </summary>
		public readonly static string PROPERTY_EMONTHLYPAY = "EmonthlyPay";
		
		/// <summary>
		/// 责任津贴
		/// </summary>
		public readonly static string PROPERTY_EDUTYPAY = "EdutyPay";
		
		/// <summary>
		/// 职位津贴
		/// </summary>
		public readonly static string PROPERTY_EPOSTPAY = "EpostPay";
		
		/// <summary>
		/// 职场津贴
		/// </summary>
		public readonly static string PROPERTY_EFELDPAY = "EfeldPay";
		
		/// <summary>
		/// 保险费
		/// </summary>
		public readonly static string PROPERTY_EINSURANCE = "Einsurance";
		
		/// <summary>
		/// 平时加班补贴
		/// </summary>
		public readonly static string PROPERTY_EOVERPAY = "Eoverpay";
		
		/// <summary>
		/// 假日加班每小时补贴
		/// </summary>
		public readonly static string PROPERTY_ELEAVEPAY = "Eleavepay";
		
		/// <summary>
		/// 其他
		/// </summary>
		public readonly static string PROPERTY_EOTHERPAY = "EotherPay";
		
		/// <summary>
		/// 税率
		/// </summary>
		public readonly static string PROPERTY_ETAX = "Etax";
		

		#endregion
	}
}
