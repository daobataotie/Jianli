//------------------------------------------------------------------------------
//
// file name：OperatorsAccessor.cs
// author: peidun
// create date：2009-09-09  下午 04:08:32
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Book.DA.SQLServer
{
    /// <summary>
    /// Data accessor of Operators
    /// </summary>
    public partial class OperatorsAccessor : EntityAccessor, IOperatorsAccessor
    {
        #region IOperatorsAccessor Members


        public IList<Book.Model.Operators> SelectOperators()
        {
            return sqlmapper.QueryForList<Model.Operators>("Operators.select_operators", null);
        }

        public Book.Model.Operators GetByOperatorName(string operatorName)
        {
            return sqlmapper.QueryForObject<Model.Operators>("Operators.get_byName", operatorName);
        }

        public IList<Book.Model.Operators> SelectOrderByName()
        {
            return sqlmapper.QueryForList<Book.Model.Operators>("Operators.selectOrderByName", null);
        }

        public IList<Book.Model.Operators> SelectRelationEmployeeInfo()
        {
            string sql = "select os.*,a.RoleName,e.EmployeeName,d.DepartmentName from Operators  os left join (select o.OperatorsId,r.RoleName from OperationRole o left join Role r on o.RoleId=r.RoleId where o.IsHold=1) as a on os.OperatorsId=a.OperatorsId left join Employee e on os.EmployeeId=e.EmployeeId left join Department d on e.DepartmentId=d.DepartmentId";

            return this.DataReaderBind<Model.Operators>(sql, null, CommandType.Text);
        }
        #endregion
    }
}
