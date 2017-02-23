﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：DepotOut.autogenerated.cs
// author: mayanjun
// create date：2011-09-30 09:43:59
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
	public partial class DepotOut
	{
		#region Data

		/// <summary>
		/// 主键
		/// </summary>
		private string _depotOutId;
		
		/// <summary>
		/// 库房编号
		/// </summary>
		private string _depotId;
		
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
		/// 日期
		/// </summary>
		private DateTime? _depotOutDate;
		
		/// <summary>
		/// 需求来源
		/// </summary>
		private string _sourceType;
		
		/// <summary>
		/// 说明
		/// </summary>
		private string _description;
		
		/// <summary>
		/// 相关单据编号
		/// </summary>
		private string _invioiceId;
		
		/// <summary>
		/// 
		/// </summary>
		private string _productCategoryId;
		
		/// <summary>
		/// 
		/// </summary>
		private string _invioiceEmployee0Id;

        private int? _auditState;

        private string _auditEmpId;

        private Employee _auditEmp;
		
		/// <summary>
		/// 员工
		/// </summary>
		private Employee _invioiceEmployee0;
		/// <summary>
		/// 员工
		/// </summary>
		private Employee _employee;
		/// <summary>
		/// 库房
		/// </summary>
		private Depot _depot;
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 主键
		/// </summary>
		public string DepotOutId
		{
			get 
			{
				return this._depotOutId;
			}
			set 
			{
				this._depotOutId = value;
			}
		}

		/// <summary>
		/// 库房编号
		/// </summary>
		public string DepotId
		{
			get 
			{
				return this._depotId;
			}
			set 
			{
				this._depotId = value;
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
		/// 日期
		/// </summary>
		public DateTime? DepotOutDate
		{
			get 
			{
				return this._depotOutDate;
			}
			set 
			{
				this._depotOutDate = value;
			}
		}

		/// <summary>
		/// 需求来源
		/// </summary>
		public string SourceType
		{
			get 
			{
				return this._sourceType;
			}
			set 
			{
				this._sourceType = value;
			}
		}

		/// <summary>
		/// 说明
		/// </summary>
		public string description
		{
			get 
			{
				return this._description;
			}
			set 
			{
				this._description = value;
			}
		}

		/// <summary>
		/// 相关单据编号
		/// </summary>
		public string InvioiceId
		{
			get 
			{
				return this._invioiceId;
			}
			set 
			{
				this._invioiceId = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string ProductCategoryId
		{
			get 
			{
				return this._productCategoryId;
			}
			set 
			{
				this._productCategoryId = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string InvioiceEmployee0Id
		{
			get 
			{
				return this._invioiceEmployee0Id;
			}
			set 
			{
				this._invioiceEmployee0Id = value;
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
		public virtual Employee InvioiceEmployee0
		{
			get
			{
				return this._invioiceEmployee0;
			}
			set
			{
				this._invioiceEmployee0 = value;
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
		/// 库房
		/// </summary>
		public virtual Depot Depot
		{
			get
			{
				return this._depot;
			}
			set
			{
				this._depot = value;
			}
			
		}
		/// <summary>
		/// 主键
		/// </summary>
		public readonly static string PRO_DepotOutId = "DepotOutId";
		
		/// <summary>
		/// 库房编号
		/// </summary>
		public readonly static string PRO_DepotId = "DepotId";
		
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
		/// 日期
		/// </summary>
		public readonly static string PRO_DepotOutDate = "DepotOutDate";
		
		/// <summary>
		/// 需求来源
		/// </summary>
		public readonly static string PRO_SourceType = "SourceType";
		
		/// <summary>
		/// 说明
		/// </summary>
		public readonly static string PRO_description = "description";
		
		/// <summary>
		/// 相关单据编号
		/// </summary>
		public readonly static string PRO_InvioiceId = "InvioiceId";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_ProductCategoryId = "ProductCategoryId";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_InvioiceEmployee0Id = "InvioiceEmployee0Id";

        public readonly static string PRO_AuditState = "AuditState";

        public readonly static string PRO_AuditEmpId = "AuditEmpId";

		#endregion
	}
}