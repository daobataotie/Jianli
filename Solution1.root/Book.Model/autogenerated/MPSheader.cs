﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：MPSheader.autogenerated.cs
// author: mayanjun
// create date：2012-2-4 10:59:15
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
    public partial class MPSheader
    {
        #region Data

        /// <summary>
        /// 编号
        /// </summary>
        private string _mPSheaderId;

        /// <summary>
        /// 计划人呢
        /// </summary>
        private string _employee1Id;

        /// <summary>
        /// 制表人
        /// </summary>
        private string _employee0Id;

        /// <summary>
        /// 修改时间
        /// </summary>
        private DateTime? _updateTime;

        /// <summary>
        /// 插入时间
        /// </summary>
        private DateTime? _insertTime;

        /// <summary>
        /// Attribute_781
        /// </summary>
        private string _id;

        /// <summary>
        /// 计划名称
        /// </summary>
        private string _mPSheaderName;

        /// <summary>
        /// 开始日期
        /// </summary>
        private DateTime? _mPSStartDate;

        /// <summary>
        /// 计划状态
        /// </summary>
        private string _mPSheaderState;

        /// <summary>
        /// 结束日期
        /// </summary>
        private DateTime? _mPSEndDate;

        /// <summary>
        /// 说明
        /// </summary>
        private string _mPSheaderDesc;

        /// <summary>
        /// 
        /// </summary>
        private bool? _checkeds;

        /// <summary>
        /// 
        /// </summary>
        private string _workHouseId;

        /// <summary>
        /// 
        /// </summary>
        private bool? _isBuildMRP;

        /// <summary>
        /// 
        /// </summary>
        private bool? _isAdvisementOnWay;

        /// <summary>
        /// 
        /// </summary>
        private bool? _isAdvisementSafetyStock;

        /// <summary>
        /// 
        /// </summary>
        private string _invoiceXOId;

        /// <summary>
        /// 
        /// </summary>
        private int? _auditState;

        /// <summary>
        /// 
        /// </summary>
        private string _auditEmpId;

        /// <summary>
        /// 员工
        /// </summary>
        private Employee _employee0;
        /// <summary>
        /// 员工
        /// </summary>
        private Employee _employee1;
        /// <summary>
        /// 员工
        /// </summary>
        private Employee _auditEmp;
        /// <summary>
        /// 销售订单
        /// </summary>
        private InvoiceXO _invoiceXO;
        /// <summary>
        /// 工作中心
        /// </summary>
        private WorkHouse _workHouse;

        #endregion

        #region Properties

        /// <summary>
        /// 编号
        /// </summary>
        public string MPSheaderId
        {
            get
            {
                return this._mPSheaderId;
            }
            set
            {
                this._mPSheaderId = value;
            }
        }

        /// <summary>
        /// 计划人呢
        /// </summary>
        public string Employee1Id
        {
            get
            {
                return this._employee1Id;
            }
            set
            {
                this._employee1Id = value;
            }
        }

        /// <summary>
        /// 制表人
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
        /// Attribute_781
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
        /// 计划名称
        /// </summary>
        public string MPSheaderName
        {
            get
            {
                return this._mPSheaderName;
            }
            set
            {
                this._mPSheaderName = value;
            }
        }

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? MPSStartDate
        {
            get
            {
                return this._mPSStartDate;
            }
            set
            {
                this._mPSStartDate = value;
            }
        }

        /// <summary>
        /// 计划状态
        /// </summary>
        public string MPSheaderState
        {
            get
            {
                return this._mPSheaderState;
            }
            set
            {
                this._mPSheaderState = value;
            }
        }

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? MPSEndDate
        {
            get
            {
                return this._mPSEndDate;
            }
            set
            {
                this._mPSEndDate = value;
            }
        }

        /// <summary>
        /// 说明
        /// </summary>
        public string MPSheaderDesc
        {
            get
            {
                return this._mPSheaderDesc;
            }
            set
            {
                this._mPSheaderDesc = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool? Checkeds
        {
            get
            {
                return this._checkeds;
            }
            set
            {
                this._checkeds = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string WorkHouseId
        {
            get
            {
                return this._workHouseId;
            }
            set
            {
                this._workHouseId = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool? IsBuildMRP
        {
            get
            {
                return this._isBuildMRP;
            }
            set
            {
                this._isBuildMRP = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool? IsAdvisementOnWay
        {
            get
            {
                return this._isAdvisementOnWay;
            }
            set
            {
                this._isAdvisementOnWay = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool? IsAdvisementSafetyStock
        {
            get
            {
                return this._isAdvisementSafetyStock;
            }
            set
            {
                this._isAdvisementSafetyStock = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string InvoiceXOId
        {
            get
            {
                return this._invoiceXOId;
            }
            set
            {
                this._invoiceXOId = value;
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
        public virtual Employee Employee1
        {
            get
            {
                return this._employee1;
            }
            set
            {
                this._employee1 = value;
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
        /// 销售订单
        /// </summary>
        public virtual InvoiceXO InvoiceXO
        {
            get
            {
                return this._invoiceXO;
            }
            set
            {
                this._invoiceXO = value;
            }

        }
        /// <summary>
        /// 工作中心
        /// </summary>
        public virtual WorkHouse WorkHouse
        {
            get
            {
                return this._workHouse;
            }
            set
            {
                this._workHouse = value;
            }

        }
        /// <summary>
        /// 编号
        /// </summary>
        public readonly static string PRO_MPSheaderId = "MPSheaderId";

        /// <summary>
        /// 计划人呢
        /// </summary>
        public readonly static string PRO_Employee1Id = "Employee1Id";

        /// <summary>
        /// 制表人
        /// </summary>
        public readonly static string PRO_Employee0Id = "Employee0Id";

        /// <summary>
        /// 修改时间
        /// </summary>
        public readonly static string PRO_UpdateTime = "UpdateTime";

        /// <summary>
        /// 插入时间
        /// </summary>
        public readonly static string PRO_InsertTime = "InsertTime";

        /// <summary>
        /// Attribute_781
        /// </summary>
        public readonly static string PRO_Id = "Id";

        /// <summary>
        /// 计划名称
        /// </summary>
        public readonly static string PRO_MPSheaderName = "MPSheaderName";

        /// <summary>
        /// 开始日期
        /// </summary>
        public readonly static string PRO_MPSStartDate = "MPSStartDate";

        /// <summary>
        /// 计划状态
        /// </summary>
        public readonly static string PRO_MPSheaderState = "MPSheaderState";

        /// <summary>
        /// 结束日期
        /// </summary>
        public readonly static string PRO_MPSEndDate = "MPSEndDate";

        /// <summary>
        /// 说明
        /// </summary>
        public readonly static string PRO_MPSheaderDesc = "MPSheaderDesc";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_Checkeds = "Checkeds";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_WorkHouseId = "WorkHouseId";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_IsBuildMRP = "IsBuildMRP";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_IsAdvisementOnWay = "IsAdvisementOnWay";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_IsAdvisementSafetyStock = "IsAdvisementSafetyStock";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_InvoiceXOId = "InvoiceXOId";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_AuditState = "AuditState";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_AuditEmpId = "AuditEmpId";


        #endregion
    }
}