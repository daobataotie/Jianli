﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：ProduceOtherCompact.autogenerated.cs
// author: mayanjun
// create date：2012-2-4 11:20:37
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
    public partial class ProduceOtherCompact
    {
        #region Data

        /// <summary>
        /// 编号
        /// </summary>
        private string _produceOtherCompactId;

        /// <summary>
        /// 供应商编号
        /// </summary>
        private string _supplierId;

        /// <summary>
        /// 操作人
        /// </summary>
        private string _employee0Id;

        /// <summary>
        /// 日期
        /// </summary>
        private DateTime? _produceOtherCompactDate;

        /// <summary>
        /// 说明
        /// </summary>
        private string _produceOtherCompactDesc;

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
        private string _mRSHeaderId;

        /// <summary>
        /// 
        /// </summary>
        private string _employee1Id;

        /// <summary>
        /// 
        /// </summary>
        private string _employee2Id;

        /// <summary>
        /// 
        /// </summary>
        private int? _otherProduceType;

        /// <summary>
        /// 
        /// </summary>
        private int? _otherOperationType;

        /// <summary>
        /// 
        /// </summary>
        private string _paymentCondition;

        /// <summary>
        /// 
        /// </summary>
        private int? _invoiceDetailFlag;

        /// <summary>
        /// 
        /// </summary>
        private string _departmentId;

        /// <summary>
        /// 
        /// </summary>
        private int? _invoiceMaterialFlag;

        /// <summary>
        /// 
        /// </summary>
        private int? _invoiceStatus;

        /// <summary>
        /// 
        /// </summary>
        private DateTime? _jiaoHuoDate;

        /// <summary>
        /// 
        /// </summary>
        private string _pronoteHeaderId;

        /// <summary>
        /// 
        /// </summary>
        private string _nextWorkHouseId;

        /// <summary>
        /// 
        /// </summary>
        private string _customerId;

        /// <summary>
        /// 
        /// </summary>
        private string _invoiceXOId;

        /// <summary>
        /// 
        /// </summary>
        private string _customerInvoiceXOId;

        /// <summary>
        /// 
        /// </summary>
        private int? _auditState;

        /// <summary>
        /// 
        /// </summary>
        private string _auditEmpId;

        /// <summary>
        /// 批号
        /// </summary>
        private string _LotNumber;

        private bool? _isClose;

        public bool? IsClose
        {
            get { return _isClose; }
            set { _isClose = value; }
        }

        /// <summary>
        /// 客户
        /// </summary>
        private Customer _customer;
        /// <summary>
        /// 部门
        /// </summary>
        private Department _department;
        /// <summary>
        /// 员工
        /// </summary>
        private Employee _employee1;
        /// <summary>
        /// 员工
        /// </summary>
        private Employee _employee2;
        /// <summary>
        /// 员工
        /// </summary>
        private Employee _auditEmp;
        /// <summary>
        /// 销售订单
        /// </summary>
        private InvoiceXO _invoiceXO;
        /// <summary>
        /// 供应商
        /// </summary>
        private Supplier _supplier;
        /// <summary>
        /// 员工
        /// </summary>
        private Employee _employee0;
        /// <summary>
        /// 工作中心
        /// </summary>
        private WorkHouse _nextWorkHouse;

        #endregion

        #region Properties

        /// <summary>
        /// 编号
        /// </summary>
        public string ProduceOtherCompactId
        {
            get
            {
                return this._produceOtherCompactId;
            }
            set
            {
                this._produceOtherCompactId = value;
            }
        }

        /// <summary>
        /// 供应商编号
        /// </summary>
        public string SupplierId
        {
            get
            {
                return this._supplierId;
            }
            set
            {
                this._supplierId = value;
            }
        }

        /// <summary>
        /// 操作人
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
        /// 日期
        /// </summary>
        public DateTime? ProduceOtherCompactDate
        {
            get
            {
                return this._produceOtherCompactDate;
            }
            set
            {
                this._produceOtherCompactDate = value;
            }
        }

        /// <summary>
        /// 说明
        /// </summary>
        public string ProduceOtherCompactDesc
        {
            get
            {
                return this._produceOtherCompactDesc;
            }
            set
            {
                this._produceOtherCompactDesc = value;
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
        public string MRSHeaderId
        {
            get
            {
                return this._mRSHeaderId;
            }
            set
            {
                this._mRSHeaderId = value;
            }
        }

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        public string Employee2Id
        {
            get
            {
                return this._employee2Id;
            }
            set
            {
                this._employee2Id = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? OtherProduceType
        {
            get
            {
                return this._otherProduceType;
            }
            set
            {
                this._otherProduceType = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? OtherOperationType
        {
            get
            {
                return this._otherOperationType;
            }
            set
            {
                this._otherOperationType = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PaymentCondition
        {
            get
            {
                return this._paymentCondition;
            }
            set
            {
                this._paymentCondition = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? InvoiceDetailFlag
        {
            get
            {
                return this._invoiceDetailFlag;
            }
            set
            {
                this._invoiceDetailFlag = value;
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
        /// 
        /// </summary>
        public int? InvoiceMaterialFlag
        {
            get
            {
                return this._invoiceMaterialFlag;
            }
            set
            {
                this._invoiceMaterialFlag = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? InvoiceStatus
        {
            get
            {
                return this._invoiceStatus;
            }
            set
            {
                this._invoiceStatus = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? JiaoHuoDate
        {
            get
            {
                return this._jiaoHuoDate;
            }
            set
            {
                this._jiaoHuoDate = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PronoteHeaderId
        {
            get
            {
                return this._pronoteHeaderId;
            }
            set
            {
                this._pronoteHeaderId = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string NextWorkHouseId
        {
            get
            {
                return this._nextWorkHouseId;
            }
            set
            {
                this._nextWorkHouseId = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CustomerId
        {
            get
            {
                return this._customerId;
            }
            set
            {
                this._customerId = value;
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
        public string CustomerInvoiceXOId
        {
            get
            {
                return this._customerInvoiceXOId;
            }
            set
            {
                this._customerInvoiceXOId = value;
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
        /// 批号
        /// </summary>
        public string LotNumber
        {
            get { return this._LotNumber; }
            set { this._LotNumber = value; }
        }

        /// <summary>
        /// 客户
        /// </summary>
        public virtual Customer Customer
        {
            get
            {
                return this._customer;
            }
            set
            {
                this._customer = value;
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
        public virtual Employee Employee2
        {
            get
            {
                return this._employee2;
            }
            set
            {
                this._employee2 = value;
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
        /// 供应商
        /// </summary>
        public virtual Supplier Supplier
        {
            get
            {
                return this._supplier;
            }
            set
            {
                this._supplier = value;
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
        /// 工作中心
        /// </summary>
        public virtual WorkHouse NextWorkHouse
        {
            get
            {
                return this._nextWorkHouse;
            }
            set
            {
                this._nextWorkHouse = value;
            }

        }
        /// <summary>
        /// 编号
        /// </summary>
        public readonly static string PRO_ProduceOtherCompactId = "ProduceOtherCompactId";

        /// <summary>
        /// 供应商编号
        /// </summary>
        public readonly static string PRO_SupplierId = "SupplierId";

        /// <summary>
        /// 操作人
        /// </summary>
        public readonly static string PRO_Employee0Id = "Employee0Id";

        /// <summary>
        /// 日期
        /// </summary>
        public readonly static string PRO_ProduceOtherCompactDate = "ProduceOtherCompactDate";

        /// <summary>
        /// 说明
        /// </summary>
        public readonly static string PRO_ProduceOtherCompactDesc = "ProduceOtherCompactDesc";

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
        public readonly static string PRO_MRSHeaderId = "MRSHeaderId";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_Employee1Id = "Employee1Id";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_Employee2Id = "Employee2Id";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_OtherProduceType = "OtherProduceType";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_OtherOperationType = "OtherOperationType";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_PaymentCondition = "PaymentCondition";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_InvoiceDetailFlag = "InvoiceDetailFlag";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_DepartmentId = "DepartmentId";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_InvoiceMaterialFlag = "InvoiceMaterialFlag";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_InvoiceStatus = "InvoiceStatus";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_JiaoHuoDate = "JiaoHuoDate";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_PronoteHeaderId = "PronoteHeaderId";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_NextWorkHouseId = "NextWorkHouseId";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_CustomerId = "CustomerId";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_InvoiceXOId = "InvoiceXOId";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_CustomerInvoiceXOId = "CustomerInvoiceXOId";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_AuditState = "AuditState";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_AuditEmpId = "AuditEmpId";

        /// <summary>
        /// 批号
        /// </summary>
        public readonly static string PRO_LotNumber = "LotNumber";
        #endregion
    }
}