﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：OperationRole.autogenerated.cs
// author: peidun
// create date：2009-10-13 上午 11:45:15
//
//------------------------------------------------------------------------------
using System;
namespace Book.Model
{
	public partial class OperationRole
	{
		#region Data

		/// <summary>
		/// 主键
		/// </summary>
		private string _primaryKey;
		
		/// <summary>
		/// 角色编号
		/// </summary>
		private string _roleId;
		
		/// <summary>
		/// 编号
		/// </summary>
		private string _operatorsId;
		
		/// <summary>
		/// 是否隶属
		/// </summary>
		private bool? _isHold;
		
		/// <summary>
		/// 操作员
		/// </summary>
		private Operators operators;
		/// <summary>
		/// 角色
		/// </summary>
		private Role role;
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 主键
		/// </summary>
		public string PrimaryKey
		{
			get 
			{
				return this._primaryKey;
			}
			set 
			{
				this._primaryKey = value;
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
		/// 编号
		/// </summary>
		public string OperatorsId
		{
			get 
			{
				return this._operatorsId;
			}
			set 
			{
				this._operatorsId = value;
			}
		}

		/// <summary>
		/// 是否隶属
		/// </summary>
		public bool? IsHold
		{
			get 
			{
				return this._isHold;
			}
			set 
			{
				this._isHold = value;
			}
		}
	
		/// <summary>
		/// 操作员
		/// </summary>
		public virtual Operators Operators
		{
			get
			{
				return this.operators;
			}
			set
			{
				this.operators = value;
			}
			
		}
		/// <summary>
		/// 角色
		/// </summary>
		public virtual Role Role
		{
			get
			{
				return this.role;
			}
			set
			{
				this.role = value;
			}
			
		}
		/// <summary>
		/// 主键
		/// </summary>
		public readonly static string PROPERTY_PRIMARYKEY = "PrimaryKey";
		
		/// <summary>
		/// 角色编号
		/// </summary>
		public readonly static string PROPERTY_ROLEID = "RoleId";
		
		/// <summary>
		/// 编号
		/// </summary>
		public readonly static string PROPERTY_OPERATORSID = "OperatorsId";
		
		/// <summary>
		/// 是否隶属
		/// </summary>
		public readonly static string PROPERTY_ISHOLD = "IsHold";
		

		#endregion
	}
}