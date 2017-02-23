﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：InvoiceXO.autogenerated.cs
// author: mayanjun
// create date：2011-12-24 11:29:18
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
    public partial class InvoiceXO
    {
        #region Data

        /// <summary>
        /// 客户编号
        /// </summary>
        private string _customerId;

        /// <summary>
        /// 销售订单总额
        /// </summary>
        private decimal? _invoiceTotal;

        /// <summary>
        /// 销售税率
        /// </summary>
        private double? _invoiceTaxrate;

        /// <summary>
        /// 销售税额
        /// </summary>
        private decimal? _invoiceTax;

        /// <summary>
        /// 交货日期
        /// </summary>
        private DateTime? _invoiceYjrq;

        /// <summary>
        /// 合计
        /// </summary>
        private decimal? _invoiceHeji;

        /// <summary>
        /// 折让
        /// </summary>
        private decimal? _invoiceDiscount;

        /// <summary>
        /// 付款日期
        /// </summary>
        private DateTime? _invoicePayDate;

        /// <summary>
        /// 传票编号
        /// </summary>
        private string _invoiceCPBH;

        /// <summary>
        /// 课税类别
        /// </summary>
        private string _invoiceKSLB;

        /// <summary>
        /// 开立方式
        /// </summary>
        private string _invoiceKLFS;

        /// <summary>
        /// 发票编号
        /// </summary>
        private string _invoiceFPBH;

        /// <summary>
        /// 开票联式
        /// </summary>
        private string _invoiceKPLS;

        /// <summary>
        /// 发票金额
        /// </summary>
        private decimal? _invoiceFPJE;

        /// <summary>
        /// 税率计算方式
        /// </summary>
        private int? _taxCaluType;

        /// <summary>
        /// 订单标志
        /// </summary>
        private int? _invoiceFlag;

        /// <summary>
        /// 发票日期
        /// </summary>
        private DateTime? _invoiceFPDate;

        /// <summary>
        /// 应收款
        /// </summary>
        private decimal? _invoiceReceiveable;

        /// <summary>
        /// 产品类型
        /// </summary>
        private int? _productType;

        /// <summary>
        /// 
        /// </summary>
        private string _customerInvoiceXOId;

        /// <summary>
        /// 
        /// </summary>
        private string _xocustomerId;

        /// <summary>
        /// 
        /// </summary>
        private bool? _checkeds;

        /// <summary>
        /// 
        /// </summary>
        private int? _invoiceMPSState;

        /// <summary>
        /// 
        /// </summary>
        private string _employee4Id;

        /// <summary>
        /// 
        /// </summary>
        private string _customerLotNumber;

        /// <summary>
        /// 
        /// </summary>
        private bool? _isClose;

        /// <summary>
        /// 
        /// </summary>
        private int? _auditState;

        /// <summary>
        /// 
        /// </summary>
        private string _auditEmpId;

        /// <summary>
        /// 是否为外销订单
        /// </summary>
        private bool? _isForeigntrade;

        /// <summary>
        /// 货币种类
        /// </summary>
        private string _Currency;

        /// <summary>
        /// 结案日期
        /// </summary>
        private DateTime? _JieAnDate;

        /// <summary>
        /// 唛头
        /// </summary>
        private string _CustomerMarks;

        /// <summary>
        /// 客户
        /// </summary>
        private Customer _xocustomer;
        /// <summary>
        /// 员工
        /// </summary>
        private Employee _employee4;
        /// <summary>
        /// 客户
        /// </summary>
        private Customer _customer;
        private bool _isNotAutoClose;

        public bool IsNotAutoClose
        {
            get { return _isNotAutoClose; }
            set { _isNotAutoClose = value; }
        }

        /// <summary>
        /// 是否为插单
        /// </summary>
        private bool _isChadan;

        private decimal? _delayTime;

        /// <summary>
        /// 预交日期，初始值，插单后不改变值。
        /// </summary>
        private DateTime? _invoiceYjrqForChadan;

        #endregion

        #region Properties

        /// <summary>
        /// 客户编号
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
        /// 销售订单总额
        /// </summary>
        public decimal? InvoiceTotal
        {
            get
            {
                return this._invoiceTotal;
            }
            set
            {
                this._invoiceTotal = value;
            }
        }

        /// <summary>
        /// 销售税率
        /// </summary>
        public double? InvoiceTaxrate
        {
            get
            {
                return this._invoiceTaxrate;
            }
            set
            {
                this._invoiceTaxrate = value;
            }
        }

        /// <summary>
        /// 销售税额
        /// </summary>
        public decimal? InvoiceTax
        {
            get
            {
                return this._invoiceTax;
            }
            set
            {
                this._invoiceTax = value;
            }
        }

        /// <summary>
        /// 交货日期
        /// </summary>
        public DateTime? InvoiceYjrq
        {
            get
            {
                return this._invoiceYjrq;
            }
            set
            {
                this._invoiceYjrq = value;
            }
        }

        /// <summary>
        /// 合计
        /// </summary>
        public decimal? InvoiceHeji
        {
            get
            {
                return this._invoiceHeji;
            }
            set
            {
                this._invoiceHeji = value;
            }
        }

        /// <summary>
        /// 折让
        /// </summary>
        public decimal? InvoiceDiscount
        {
            get
            {
                return this._invoiceDiscount;
            }
            set
            {
                this._invoiceDiscount = value;
            }
        }

        /// <summary>
        /// 付款日期
        /// </summary>
        public DateTime? InvoicePayDate
        {
            get
            {
                return this._invoicePayDate;
            }
            set
            {
                this._invoicePayDate = value;
            }
        }

        /// <summary>
        /// 传票编号
        /// </summary>
        public string InvoiceCPBH
        {
            get
            {
                return this._invoiceCPBH;
            }
            set
            {
                this._invoiceCPBH = value;
            }
        }

        /// <summary>
        /// 课税类别
        /// </summary>
        public string InvoiceKSLB
        {
            get
            {
                return this._invoiceKSLB;
            }
            set
            {
                this._invoiceKSLB = value;
            }
        }

        /// <summary>
        /// 开立方式
        /// </summary>
        public string InvoiceKLFS
        {
            get
            {
                return this._invoiceKLFS;
            }
            set
            {
                this._invoiceKLFS = value;
            }
        }

        /// <summary>
        /// 发票编号
        /// </summary>
        public string InvoiceFPBH
        {
            get
            {
                return this._invoiceFPBH;
            }
            set
            {
                this._invoiceFPBH = value;
            }
        }

        /// <summary>
        /// 开票联式
        /// </summary>
        public string InvoiceKPLS
        {
            get
            {
                return this._invoiceKPLS;
            }
            set
            {
                this._invoiceKPLS = value;
            }
        }

        /// <summary>
        /// 发票金额
        /// </summary>
        public decimal? InvoiceFPJE
        {
            get
            {
                return this._invoiceFPJE;
            }
            set
            {
                this._invoiceFPJE = value;
            }
        }

        /// <summary>
        /// 税率计算方式
        /// </summary>
        public int? TaxCaluType
        {
            get
            {
                return this._taxCaluType;
            }
            set
            {
                this._taxCaluType = value;
            }
        }

        /// <summary>
        /// 订单标志
        /// </summary>
        public int? InvoiceFlag
        {
            get
            {
                return this._invoiceFlag;
            }
            set
            {
                this._invoiceFlag = value;
            }
        }

        /// <summary>
        /// 发票日期
        /// </summary>
        public DateTime? InvoiceFPDate
        {
            get
            {
                return this._invoiceFPDate;
            }
            set
            {
                this._invoiceFPDate = value;
            }
        }

        /// <summary>
        /// 应收款
        /// </summary>
        public decimal? InvoiceReceiveable
        {
            get
            {
                return this._invoiceReceiveable;
            }
            set
            {
                this._invoiceReceiveable = value;
            }
        }

        /// <summary>
        /// 产品类型
        /// </summary>
        public int? ProductType
        {
            get
            {
                return this._productType;
            }
            set
            {
                this._productType = value;
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
        public string xocustomerId
        {
            get
            {
                return this._xocustomerId;
            }
            set
            {
                this._xocustomerId = value;
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
        public int? InvoiceMPSState
        {
            get
            {
                return this._invoiceMPSState;
            }
            set
            {
                this._invoiceMPSState = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Employee4Id
        {
            get
            {
                return this._employee4Id;
            }
            set
            {
                this._employee4Id = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CustomerLotNumber
        {
            get
            {
                return this._customerLotNumber;
            }
            set
            {
                this._customerLotNumber = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool? IsClose
        {
            get
            {
                return this._isClose;
            }
            set
            {
                this._isClose = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? AuditState1
        {
            get
            {
                return _auditState;
            }
            set
            {
                _auditState = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string AuditEmpId1
        {
            get
            {
                return _auditEmpId;
            }
            set
            {
                _auditEmpId = value;
            }
        }

        /// <summary>
        /// 是否为外销订单
        /// </summary>
        public bool? IsForeigntrade
        {
            get
            {
                return _isForeigntrade;
            }
            set
            {
                _isForeigntrade = value;
            }
        }

        /// <summary>
        /// 货币种类
        /// </summary>
        public string Currency
        {
            get { return _Currency; }
            set { _Currency = value; }
        }

        /// <summary>
        /// 结案日期
        /// </summary>
        public DateTime? JieAnDate
        {
            get { return _JieAnDate; }
            set { _JieAnDate = value; }
        }

        /// <summary>
        /// 唛头
        /// </summary>
        public string CustomerMarks
        {
            get { return _CustomerMarks; }
            set { _CustomerMarks = value; }
        }

        /// <summary>
        /// 是否为插单
        /// </summary>
        public bool IsChadan
        {
            get { return _isChadan; }
            set { _isChadan = value; }
        }

        /// <summary>
        /// 插单延时
        /// </summary>
        public decimal? DelayTime
        {
            get { return _delayTime; }
            set { _delayTime = value; }
        }

        /// <summary>
        /// 预交日期，初始值，插单后不改变值。
        /// </summary>
        public DateTime? InvoiceYjrqForChadan
        {
            get { return _invoiceYjrqForChadan; }
            set { _invoiceYjrqForChadan = value; }
        }

        /// <summary>
        /// 客户
        /// </summary>
        public virtual Customer xocustomer
        {
            get
            {
                return this._xocustomer;
            }
            set
            {
                this._xocustomer = value;
            }

        }
        /// <summary>
        /// 员工
        /// </summary>
        public virtual Employee Employee4
        {
            get
            {
                return this._employee4;
            }
            set
            {
                this._employee4 = value;
            }

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
        /// 客户编号
        /// </summary>
        public readonly static string PRO_CustomerId = "CustomerId";

        /// <summary>
        /// 销售订单总额
        /// </summary>
        public readonly static string PRO_InvoiceTotal = "InvoiceTotal";

        /// <summary>
        /// 销售税率
        /// </summary>
        public readonly static string PRO_InvoiceTaxrate = "InvoiceTaxrate";

        /// <summary>
        /// 销售税额
        /// </summary>
        public readonly static string PRO_InvoiceTax = "InvoiceTax";

        /// <summary>
        /// 交货日期
        /// </summary>
        public readonly static string PRO_InvoiceYjrq = "InvoiceYjrq";

        /// <summary>
        /// 合计
        /// </summary>
        public readonly static string PRO_InvoiceHeji = "InvoiceHeji";

        /// <summary>
        /// 折让
        /// </summary>
        public readonly static string PRO_InvoiceDiscount = "InvoiceDiscount";

        /// <summary>
        /// 付款日期
        /// </summary>
        public readonly static string PRO_InvoicePayDate = "InvoicePayDate";

        /// <summary>
        /// 传票编号
        /// </summary>
        public readonly static string PRO_InvoiceCPBH = "InvoiceCPBH";

        /// <summary>
        /// 课税类别
        /// </summary>
        public readonly static string PRO_InvoiceKSLB = "InvoiceKSLB";

        /// <summary>
        /// 开立方式
        /// </summary>
        public readonly static string PRO_InvoiceKLFS = "InvoiceKLFS";

        /// <summary>
        /// 发票编号
        /// </summary>
        public readonly static string PRO_InvoiceFPBH = "InvoiceFPBH";

        /// <summary>
        /// 开票联式
        /// </summary>
        public readonly static string PRO_InvoiceKPLS = "InvoiceKPLS";

        /// <summary>
        /// 发票金额
        /// </summary>
        public readonly static string PRO_InvoiceFPJE = "InvoiceFPJE";

        /// <summary>
        /// 税率计算方式
        /// </summary>
        public readonly static string PRO_TaxCaluType = "TaxCaluType";

        /// <summary>
        /// 订单标志
        /// </summary>
        public readonly static string PRO_InvoiceFlag = "InvoiceFlag";

        /// <summary>
        /// 发票日期
        /// </summary>
        public readonly static string PRO_InvoiceFPDate = "InvoiceFPDate";

        /// <summary>
        /// 应收款
        /// </summary>
        public readonly static string PRO_InvoiceReceiveable = "InvoiceReceiveable";

        /// <summary>
        /// 产品类型
        /// </summary>
        public readonly static string PRO_ProductType = "ProductType";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_CustomerInvoiceXOId = "CustomerInvoiceXOId";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_xocustomerId = "xocustomerId";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_Checkeds = "Checkeds";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_InvoiceMPSState = "InvoiceMPSState";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_Employee4Id = "Employee4Id";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_CustomerLotNumber = "CustomerLotNumber";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_IsClose = "IsClose";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_AuditState1 = "AuditState1";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_AuditEmpId1 = "AuditEmpId1";

        /// <summary>
        /// 是否为外销订单
        /// </summary>
        public readonly static string PRO_IsForeigntrade = "IsForeigntrade";

        /// <summary>
        /// 货币类型
        /// </summary>
        public readonly static string PRO_Currency = "Currency";

        /// <summary>
        /// 结案日期
        /// </summary>
        public readonly static string PRO_JieAnDate = "JieAnDate";

        /// <summary>
        /// 唛头
        /// </summary>
        public readonly static string PRO_CustomerMarks = "CustomerMarks";

        public readonly static string PRO_IsChadan = "IsChadan";

        public readonly static string PRO_InvoiceYjrqForChadan = "InvoiceYjrqForChadan";

        public readonly static string PRO_DelayTime = "DelayTime";

        #endregion
    }
}