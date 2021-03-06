﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：Leave.autogenerated.cs
// author: mayanjun
// create date：2011-12-28 14:40:50
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
	public partial class Leave
	{
		#region Data

		/// <summary>
		/// 请假编号
		/// </summary>
		private string _leaveId;
		
		/// <summary>
		/// 休假类别编号
		/// </summary>
		private string _leaveTypeId;
		
		/// <summary>
		/// 编号
		/// </summary>
		private string _employeeId;
		
		/// <summary>
		/// 请假日期
		/// </summary>
		private DateTime? _leaveDate;
		
		/// <summary>
		/// 请假天数类别
		/// </summary>
		private int? _leaveRange;
		
		/// <summary>
		/// 请假原因
		/// </summary>
		private string _leaveText;
		
		/// <summary>
		/// 员工
		/// </summary>
		private Employee _employee;
		/// <summary>
		/// 休假类别
		/// </summary>
		private LeaveType _leaveType;
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 请假编号
		/// </summary>
		public string LeaveId
		{
			get 
			{
				return this._leaveId;
			}
			set 
			{
				this._leaveId = value;
			}
		}

		/// <summary>
		/// 休假类别编号
		/// </summary>
		public string LeaveTypeId
		{
			get 
			{
				return this._leaveTypeId;
			}
			set 
			{
				this._leaveTypeId = value;
			}
		}

		/// <summary>
		/// 编号
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
		/// 请假日期
		/// </summary>
		public DateTime? LeaveDate
		{
			get 
			{
				return this._leaveDate;
			}
			set 
			{
				this._leaveDate = value;
			}
		}

		/// <summary>
		/// 请假天数类别
		/// </summary>
		public int? LeaveRange
		{
			get 
			{
				return this._leaveRange;
			}
			set 
			{
				this._leaveRange = value;
			}
		}

		/// <summary>
		/// 请假原因
		/// </summary>
		public string LeaveText
		{
			get 
			{
				return this._leaveText;
			}
			set 
			{
				this._leaveText = value;
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
		/// 休假类别
		/// </summary>
		public virtual LeaveType LeaveType
		{
			get
			{
				return this._leaveType;
			}
			set
			{
				this._leaveType = value;
			}
			
		}
		/// <summary>
		/// 请假编号
		/// </summary>
		public readonly static string PRO_LeaveId = "LeaveId";
		
		/// <summary>
		/// 休假类别编号
		/// </summary>
		public readonly static string PRO_LeaveTypeId = "LeaveTypeId";
		
		/// <summary>
		/// 编号
		/// </summary>
		public readonly static string PRO_EmployeeId = "EmployeeId";
		
		/// <summary>
		/// 请假日期
		/// </summary>
		public readonly static string PRO_LeaveDate = "LeaveDate";
		
		/// <summary>
		/// 请假天数类别
		/// </summary>
		public readonly static string PRO_LeaveRange = "LeaveRange";
		
		/// <summary>
		/// 请假原因
		/// </summary>
		public readonly static string PRO_LeaveText = "LeaveText";
		

		#endregion
	}
}
