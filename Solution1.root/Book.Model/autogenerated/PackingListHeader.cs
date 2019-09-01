﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：PackingListHeader.autogenerated.cs
// author: mayanjun
// create date：2018/11/11 17:33:42
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
    public partial class PackingListHeader
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private string _packingNo;

        /// <summary>
        /// 
        /// </summary>
        private DateTime? _packingDate;

        /// <summary>
        /// 
        /// </summary>
        private string _customerId;

        /// <summary>
        /// 
        /// </summary>
        private string _perSS;

        /// <summary>
        /// 
        /// </summary>
        private DateTime? _sailingOnOrAbout;

        /// <summary>
        /// 
        /// </summary>
        private string _fromPortId;

        /// <summary>
        /// 
        /// </summary>
        private string _toPortId;

        /// <summary>
        /// 
        /// </summary>
        private string _markNos;

        /// <summary>
        /// 
        /// </summary>
        private DateTime? _insertTime;

        /// <summary>
        /// 
        /// </summary>
        private DateTime? _updateTime;

        /// <summary>
        /// 客户
        /// </summary>
        private Customer _customer;
        /// <summary>
        /// 
        /// </summary>
        private Port _fromPort;
        /// <summary>
        /// 
        /// </summary>
        private Port _toPort;

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public string PackingNo
        {
            get
            {
                return this._packingNo;
            }
            set
            {
                this._packingNo = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? PackingDate
        {
            get
            {
                return this._packingDate;
            }
            set
            {
                this._packingDate = value;
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
        /// 船名航次
        /// </summary>
        public string PerSS
        {
            get
            {
                return this._perSS;
            }
            set
            {
                this._perSS = value;
            }
        }

        /// <summary>
        /// 裝船日
        /// </summary>
        public DateTime? SailingOnOrAbout
        {
            get
            {
                return this._sailingOnOrAbout;
            }
            set
            {
                this._sailingOnOrAbout = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string FromPortId
        {
            get
            {
                return this._fromPortId;
            }
            set
            {
                this._fromPortId = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ToPortId
        {
            get
            {
                return this._toPortId;
            }
            set
            {
                this._toPortId = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string MarkNos
        {
            get
            {
                return this._markNos;
            }
            set
            {
                this._markNos = value;
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
        /// 
        /// </summary>
        public virtual Port FromPort
        {
            get
            {
                return this._fromPort;
            }
            set
            {
                this._fromPort = value;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        public virtual Port ToPort
        {
            get
            {
                return this._toPort;
            }
            set
            {
                this._toPort = value;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_PackingNo = "PackingNo";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_PackingDate = "PackingDate";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_CustomerId = "CustomerId";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_PerSS = "PerSS";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_SailingOnOrAbout = "SailingOnOrAbout";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_FromPortId = "FromPortId";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_ToPortId = "ToPortId";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_MarkNos = "MarkNos";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_InsertTime = "InsertTime";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PRO_UpdateTime = "UpdateTime";


        #endregion

        private string _customerFullName;

        public string CustomerFullName
        {
            get { return _customerFullName; }
            set { _customerFullName = value; }
        }

        private string _customerAddress;

        public string CustomerAddress
        {
            get { return _customerAddress; }
            set { _customerAddress = value; }
        }

        private string _unit;

        public string Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        public readonly static string PRO_CustomerFullName = "CustomerFullName";

        public readonly static string PRO_CustomerAddress = "CustomerAddress";

        public readonly static string PRO_Unit = "Unit";
    }
}