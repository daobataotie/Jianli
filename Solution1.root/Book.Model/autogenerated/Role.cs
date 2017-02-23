﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：Role.autogenerated.cs
// author: mayanjun
// create date：2012-6-12 16:16:38
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
	public partial class Role
	{
		#region Data

		/// <summary>
		/// 编号
		/// </summary>
		private string _id;
		
		/// <summary>
		/// 角色编号
		/// </summary>
		private string _roleId;
		
		/// <summary>
		/// 插入时间
		/// </summary>
		private DateTime? _insertTime;
		
		/// <summary>
		/// 修改时间
		/// </summary>
		private DateTime? _updateTime;
		
		/// <summary>
		/// 角色名称
		/// </summary>
		private string _roleName;
		
		/// <summary>
		/// 角色说明
		/// </summary>
		private string _roleDescription;
		
		/// <summary>
		/// 
		/// </summary>
		private bool? _isXOPrice;
		
		/// <summary>
		/// 
		/// </summary>
		private bool? _isXOQuantity;
		
		/// <summary>
		/// 
		/// </summary>
		private bool? _isCOPrice;
		
		/// <summary>
		/// 
		/// </summary>
		private bool? _isCOCount;
		
		/// <summary>
		/// 
		/// </summary>
		private bool? _isStockPrice;
		
		/// <summary>
		/// 
		/// </summary>
		private bool? _isStockCount;
		
		/// <summary>
		/// 
		/// </summary>
		private bool? _isProductCost;
		
		/// <summary>
		/// 人事基本资料
		/// </summary>
		private bool? _isEmployeeBasicInfo;
		
		/// <summary>
		/// 薪资计算与查看
		/// </summary>
		private bool? _isSalaryViewCalc;
		
		/// <summary>
		/// 
		/// </summary>
		private bool? _isXOJiaoYiMingXi;
		
		/// <summary>
		/// 
		/// </summary>
		private bool? _isXOFaPiaoZiLiao;
		
		/// <summary>
		/// 
		/// </summary>
		private bool? _isXOZhangKuanZiLiao;
		
		/// <summary>
		/// 
		/// </summary>
		private bool? _isXOXiangGuanZiLiao;
		
		/// <summary>
		/// 
		/// </summary>
		private bool? _isCOJiaoYiMingXi;
		
		/// <summary>
		/// 
		/// </summary>
		private bool? _isCOFaPiaoZiLiao;
		
		/// <summary>
		/// 
		/// </summary>
		private bool? _isCOZhangKuanZiLiao;
		
		/// <summary>
		/// 
		/// </summary>
		private bool? _isCOXiangGuanZiLiao;
		
		/// <summary>
		/// 
		/// </summary>
		private bool? _isXOJinHuoJinE;
		
		/// <summary>
		/// 
		/// </summary>
		private bool? _isCOJinHuoJinE;
		
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 编号
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
		/// 角色编号
		/// </summary>
		public string RoleId
		{
			get 
			{
				return this._roleId;
			}
			set 
			{
				this._roleId = value;
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
		/// 角色名称
		/// </summary>
		public string RoleName
		{
			get 
			{
				return this._roleName;
			}
			set 
			{
				this._roleName = value;
			}
		}

		/// <summary>
		/// 角色说明
		/// </summary>
		public string RoleDescription
		{
			get 
			{
				return this._roleDescription;
			}
			set 
			{
				this._roleDescription = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool? IsXOPrice
		{
			get 
			{
				return this._isXOPrice;
			}
			set 
			{
				this._isXOPrice = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool? IsXOQuantity
		{
			get 
			{
				return this._isXOQuantity;
			}
			set 
			{
				this._isXOQuantity = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool? IsCOPrice
		{
			get 
			{
				return this._isCOPrice;
			}
			set 
			{
				this._isCOPrice = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool? IsCOCount
		{
			get 
			{
				return this._isCOCount;
			}
			set 
			{
				this._isCOCount = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool? IsStockPrice
		{
			get 
			{
				return this._isStockPrice;
			}
			set 
			{
				this._isStockPrice = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool? IsStockCount
		{
			get 
			{
				return this._isStockCount;
			}
			set 
			{
				this._isStockCount = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool? IsProductCost
		{
			get 
			{
				return this._isProductCost;
			}
			set 
			{
				this._isProductCost = value;
			}
		}

		/// <summary>
		/// 人事基本资料
		/// </summary>
		public bool? IsEmployeeBasicInfo
		{
			get 
			{
				return this._isEmployeeBasicInfo;
			}
			set 
			{
				this._isEmployeeBasicInfo = value;
			}
		}

		/// <summary>
		/// 薪资计算与查看
		/// </summary>
		public bool? IsSalaryViewCalc
		{
			get 
			{
				return this._isSalaryViewCalc;
			}
			set 
			{
				this._isSalaryViewCalc = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool? IsXOJiaoYiMingXi
		{
			get 
			{
				return this._isXOJiaoYiMingXi;
			}
			set 
			{
				this._isXOJiaoYiMingXi = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool? IsXOFaPiaoZiLiao
		{
			get 
			{
				return this._isXOFaPiaoZiLiao;
			}
			set 
			{
				this._isXOFaPiaoZiLiao = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool? IsXOZhangKuanZiLiao
		{
			get 
			{
				return this._isXOZhangKuanZiLiao;
			}
			set 
			{
				this._isXOZhangKuanZiLiao = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool? IsXOXiangGuanZiLiao
		{
			get 
			{
				return this._isXOXiangGuanZiLiao;
			}
			set 
			{
				this._isXOXiangGuanZiLiao = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool? IsCOJiaoYiMingXi
		{
			get 
			{
				return this._isCOJiaoYiMingXi;
			}
			set 
			{
				this._isCOJiaoYiMingXi = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool? IsCOFaPiaoZiLiao
		{
			get 
			{
				return this._isCOFaPiaoZiLiao;
			}
			set 
			{
				this._isCOFaPiaoZiLiao = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool? IsCOZhangKuanZiLiao
		{
			get 
			{
				return this._isCOZhangKuanZiLiao;
			}
			set 
			{
				this._isCOZhangKuanZiLiao = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool? IsCOXiangGuanZiLiao
		{
			get 
			{
				return this._isCOXiangGuanZiLiao;
			}
			set 
			{
				this._isCOXiangGuanZiLiao = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool? IsXOJinHuoJinE
		{
			get 
			{
				return this._isXOJinHuoJinE;
			}
			set 
			{
				this._isXOJinHuoJinE = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool? IsCOJinHuoJinE
		{
			get 
			{
				return this._isCOJinHuoJinE;
			}
			set 
			{
				this._isCOJinHuoJinE = value;
			}
		}
	
		/// <summary>
		/// 编号
		/// </summary>
		public readonly static string PRO_Id = "Id";
		
		/// <summary>
		/// 角色编号
		/// </summary>
		public readonly static string PRO_RoleId = "RoleId";
		
		/// <summary>
		/// 插入时间
		/// </summary>
		public readonly static string PRO_InsertTime = "InsertTime";
		
		/// <summary>
		/// 修改时间
		/// </summary>
		public readonly static string PRO_UpdateTime = "UpdateTime";
		
		/// <summary>
		/// 角色名称
		/// </summary>
		public readonly static string PRO_RoleName = "RoleName";
		
		/// <summary>
		/// 角色说明
		/// </summary>
		public readonly static string PRO_RoleDescription = "RoleDescription";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_IsXOPrice = "IsXOPrice";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_IsXOQuantity = "IsXOQuantity";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_IsCOPrice = "IsCOPrice";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_IsCOCount = "IsCOCount";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_IsStockPrice = "IsStockPrice";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_IsStockCount = "IsStockCount";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_IsProductCost = "IsProductCost";
		
		/// <summary>
		/// 人事基本资料
		/// </summary>
		public readonly static string PRO_IsEmployeeBasicInfo = "IsEmployeeBasicInfo";
		
		/// <summary>
		/// 薪资计算与查看
		/// </summary>
		public readonly static string PRO_IsSalaryViewCalc = "IsSalaryViewCalc";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_IsXOJiaoYiMingXi = "IsXOJiaoYiMingXi";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_IsXOFaPiaoZiLiao = "IsXOFaPiaoZiLiao";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_IsXOZhangKuanZiLiao = "IsXOZhangKuanZiLiao";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_IsXOXiangGuanZiLiao = "IsXOXiangGuanZiLiao";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_IsCOJiaoYiMingXi = "IsCOJiaoYiMingXi";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_IsCOFaPiaoZiLiao = "IsCOFaPiaoZiLiao";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_IsCOZhangKuanZiLiao = "IsCOZhangKuanZiLiao";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_IsCOXiangGuanZiLiao = "IsCOXiangGuanZiLiao";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_IsXOJinHuoJinE = "IsXOJinHuoJinE";
		
		/// <summary>
		/// 
		/// </summary>
		public readonly static string PRO_IsCOJinHuoJinE = "IsCOJinHuoJinE";
		

		#endregion
	}
}