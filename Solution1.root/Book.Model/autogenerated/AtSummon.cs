﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：AtSummon.autogenerated.cs
// author: mayanjun
// create date：2012-3-26 17:51:17
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
	public partial class AtSummon
	{
		#region Data

		/// <summary>
		/// 传票编号
		/// </summary>
		private string _summonId;
		
		/// <summary>
		/// 
		/// </summary>
		private int? _bIllCode;
		
		/// <summary>
		/// 
		/// </summary>
		private DateTime? _summonDate;
		
		/// <summary>
		/// 
		/// </summary>
		private string _summonCategory;
		
		/// <summary>
		/// 
		/// </summary>
		private string _departmentId;
		
		/// <summary>
		/// 借方金额
		/// </summary>
		private decimal? _totalDebits;
		
		/// <summary>
		/// 贷方金额 
		/// </summary>
		private decimal? _creditTotal;
		
		/// <summary>
		/// 
		/// </summary>
		private DateTime? _insertTime;
		
		/// <summary>
		/// 
		/// </summary>
		private DateTime? _updateTime;
		
		/// <summary>
		/// 
		/// </summary>
		private string _id;
		
		/// <summary>
		/// 
		/// </summary>
		private string _employeeDSId;
		
		/// <summary>
		/// 
		/// </summary>
		private string _auditEmpId;
		
		/// <summary>
		/// 
		/// </summary>
		private int? _auditState;
		
		/// <summary>
		/// 
		/// </summary>
		private string _atSummonDesc;
		
		/// <summary>
		/// 部门
		/// </summary>
		private Department _department;
		/// <summary>
		/// 员工
		/// </summary>
		private Employee _auditEmp;
		/// <summary>
		/// 员工
		/// </summary>
		private Employee _employeeDS;
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 传票编号
		/// </summary>
		public string SummonId
		{
			get 
			{
				return this._summonId;
			}
			set 
			{
				this._summonId = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int? BIllCode
		{
			get 
			{
				return this._bIllCode;
			}
			set 
			{
				this._bIllCode = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime? SummonDate
		{
			get 
			{
				return this._summonDate;
			}
			set 
			{
				this._summonDate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string SummonCategory
		{
			get 
			{
				return this._summonCategory;
			}
			set 
			{
				this._summonCategory = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string DepartmentId
		{
			get 
			{
				return this._departmentId;
			}
			set 
			{
				this._departmentId = value;
			}
		}

		/// <summary>
		/// 借方金额
		/// </summary>
		public decimal? TotalDebits
		{
			get 
			{
				return this._totalDebits;
			}
			set 
			{
				this._totalDebits = value;
			}
		}

		/// <summary>
		/// 贷方金额
		/// </summary>
		public decimal? CreditTotal
		{
			get 
			{
				return this._creditTotal;
			}
			set 
			{
				this._creditTotal = value;
			}
		}

		/// <summary>
		/// 
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
		/// 
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

		/// <summary>
		/// 
		/// </summary>
		public string EmployeeDSId
		{
			get 
			{
				return this._employeeDSId;
			}
			set 
			{
				this._employeeDSId = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string AuditEmpId
		{
			get 
			{
				return this._auditEmpId;
			}
			set 
			{
				this._auditEmpId = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int? AuditState
		{
			get 
			{
				return this._auditState;
			}
			set 
			{
				this._auditState = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string AtSummonDesc
		{
			get 
			{
				return this._atSummonDesc;
			}
			set 
			{
				this._atSummonDesc = value;
			}
		}
	
		/// <summary>
		/// 部门
		/// </summary>
		public virtual Department Department
		{
			get
			{
				return this._department;
			}
			set
			{
				this._department = value;
			}
			
		}
		/// <summary>
		/// 员工
		/// </summary>
		public virtual Employee AuditEmp
		{
			get
			{
				return this._auditEmp;
			}
			set
			{
				this._auditEmp = value;
			}
			
		}
		/// <summary>
		/// 员工
		/// </summary>
		public virtual Employee EmployeeDS
		{
			get
			{
				return this._employeeDS;
			}
			set
			{
				this._employeeDS = value;
			}
			
		}
		/// <summary>
		/// 传票编号
		/// </summary>
		public readonly static string PRO_SummonId = "SummonId";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_BIllCode = "BIllCode";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_SummonDate = "SummonDate";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_SummonCategory = "SummonCategory";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_DepartmentId = "DepartmentId";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_TotalDebits = "TotalDebits";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_CreditTotal = "CreditTotal";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_InsertTime = "InsertTime";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_UpdateTime = "UpdateTime";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_Id = "Id";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_EmployeeDSId = "EmployeeDSId";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_AuditEmpId = "AuditEmpId";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_AuditState = "AuditState";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_AtSummonDesc = "AtSummonDesc";
		

		#endregion
	}
}