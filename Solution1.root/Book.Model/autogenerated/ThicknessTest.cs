﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：ThicknessTest.autogenerated.cs
// author: mayanjun
// create date：2012-5-15 16:05:20
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
	public partial class ThicknessTest
	{
		#region Data

		/// <summary>
		/// 主键编号
		/// </summary>
		private string _thicknessTestId;
		
		/// <summary>
		/// 主键编号2
		/// </summary>
		private string _pCPGOnlineCheckDetailId;
		
		/// <summary>
		/// 编号
		/// </summary>
		private string _employeeId;
		
		/// <summary>
		/// 插入时间
		/// </summary>
		private DateTime? _insertTime;
		
		/// <summary>
		/// 修改时间
		/// </summary>
		private DateTime? _updateTime;
		
		/// <summary>
		/// 透视率
		/// </summary>
		private double? _perspectiverate;
		
		/// <summary>
		/// 描述备注
		/// </summary>
		private string _thicknessDescript;
		
		/// <summary>
		/// 测试时间
		/// </summary>
		private DateTime? _thicknessTestDate;

        /// <summary>
        /// 人工手动编号
        /// </summary>
		private string _manualId;

        private int? _auditState;

        private string _auditEmpId;

        private Employee _auditEmp;
		
		/// <summary>
		/// 员工
		/// </summary>
		private Employee _employee;

		/// <summary>
		/// 品管线上检查详细
		/// </summary>
		private PCPGOnlineCheckDetail _pCPGOnlineCheckDetail;
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 主键编号
		/// </summary>
		public string ThicknessTestId
		{
			get 
			{
				return this._thicknessTestId;
			}
			set 
			{
				this._thicknessTestId = value;
			}
		}

		/// <summary>
		/// 主键编号2
		/// </summary>
		public string PCPGOnlineCheckDetailId
		{
			get 
			{
				return this._pCPGOnlineCheckDetailId;
			}
			set 
			{
				this._pCPGOnlineCheckDetailId = value;
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
		/// 透视率
		/// </summary>
		public double? Perspectiverate
		{
			get 
			{
				return this._perspectiverate;
			}
			set 
			{
				this._perspectiverate = value;
			}
		}

		/// <summary>
		/// 描述备注
		/// </summary>
		public string ThicknessDescript
		{
			get 
			{
				return this._thicknessDescript;
			}
			set 
			{
				this._thicknessDescript = value;
			}
		}

		/// <summary>
		/// 测试时间
		/// </summary>
		public DateTime? ThicknessTestDate
		{
			get 
			{
				return this._thicknessTestDate;
			}
			set 
			{
				this._thicknessTestDate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string manualId
		{
			get 
			{
				return this._manualId;
			}
			set 
			{
				this._manualId = value;
			}
		}

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

        public virtual string AuditEmpId
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
		/// 品管线上检查详细
		/// </summary>
		public virtual PCPGOnlineCheckDetail PCPGOnlineCheckDetail
		{
			get
			{
				return this._pCPGOnlineCheckDetail;
			}
			set
			{
				this._pCPGOnlineCheckDetail = value;
			}
			
		}
		/// <summary>
		/// 主键编号
		/// </summary>
		public readonly static string PRO_ThicknessTestId = "ThicknessTestId";
		
		/// <summary>
		/// 主键编号2
		/// </summary>
		public readonly static string PRO_PCPGOnlineCheckDetailId = "PCPGOnlineCheckDetailId";
		
		/// <summary>
		/// 编号
		/// </summary>
		public readonly static string PRO_EmployeeId = "EmployeeId";
		
		/// <summary>
		/// 插入时间
		/// </summary>
		public readonly static string PRO_InsertTime = "InsertTime";
		
		/// <summary>
		/// 修改时间
		/// </summary>
		public readonly static string PRO_UpdateTime = "UpdateTime";
		
		/// <summary>
		/// 透视率
		/// </summary>
		public readonly static string PRO_Perspectiverate = "Perspectiverate";
		
		/// <summary>
		/// 描述备注
		/// </summary>
		public readonly static string PRO_ThicknessDescript = "ThicknessDescript";
		
		/// <summary>
		/// 测试时间
		/// </summary>
		public readonly static string PRO_ThicknessTestDate = "ThicknessTestDate";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_manualId = "manualId";

        public readonly static string PRO_AuditState = "AuditState";

        public readonly static string PRO_AuditEmpId = "AuditEmpId";

		#endregion
	}
}