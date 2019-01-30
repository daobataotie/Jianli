//------------------------------------------------------------------------------
//
// file name:InvoiceXSDetailAccessor.cs
// author: peidun
// create date:2008/6/6 10:00:50
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
    /// Data accessor of InvoiceXSDetail
    /// </summary>
    public partial class InvoiceXSDetailAccessor : EntityAccessor, IInvoiceXSDetailAccessor
    {
        public IList<Book.Model.InvoiceXSDetail> Select(Book.Model.InvoiceXS invoiceXS)
        {
            return sqlmapper.QueryForList<Model.InvoiceXSDetail>("InvoiceXSDetail.select_by_invoiceid", invoiceXS.InvoiceId);
        }

        public void Delete(Book.Model.InvoiceXS invoice)
        {
            sqlmapper.Delete("InvoiceXSDetail.delete_by_invoiceid", invoice.InvoiceId);
        }

        public IList<Book.Model.InvoiceXSDetail> Select(DateTime startDate, DateTime endDate, string csid, string ceid, string psid, string peid)
        {
            Hashtable pars = new Hashtable();
            pars.Add("startDate", startDate);
            pars.Add("endDate", endDate);
            pars.Add("csid", csid);
            pars.Add("ceid", ceid);
            pars.Add("psid", psid);
            pars.Add("peid", peid);
            return sqlmapper.QueryForList<Model.InvoiceXSDetail>("InvoiceXSDetail.selectbyDateReangeAndProductReangeCompanyReange", pars);

        }

        public IList<Book.Model.InvoiceXSDetail> Select(Model.InvoiceXO invoiceXO)
        {
            return sqlmapper.QueryForList<Model.InvoiceXSDetail>("InvoiceXSDetail.select_count", invoiceXO.InvoiceId);
        }

        public IList<Model.InvoiceXSDetail> Select(Model.InvoiceXS invoiceXS, string productStart, string productEnd)
        {
            IList<Book.Model.InvoiceXSDetail> invoicexs = null;
            Hashtable ht = new Hashtable();

            ht.Add("invoiceId", invoiceXS.InvoiceId);
            ht.Add("productStart", productStart);
            ht.Add("productEnd", productEnd);

            if (string.IsNullOrEmpty(productEnd))
            {
                invoicexs = sqlmapper.QueryForList<Book.Model.InvoiceXSDetail>("InvoiceXSDetail.selectByProductIdQuJianEndNULL", ht);
            }
            else
            {
                invoicexs = sqlmapper.QueryForList<Model.InvoiceXSDetail>("InvoiceXSDetail.selectByProductIdQuJian", ht);
            }
            return invoicexs;
        }

        public IList<Book.Model.InvoiceXSDetail> Select(DateTime startDate, DateTime endDate, Model.Employee employee, Model.Customer customer, Model.Depot depot)
        {
            Hashtable pars = new Hashtable();
            pars.Add("startdate", startDate);
            pars.Add("enddate", endDate);
            pars.Add("customerid", customer == null ? null : customer.CustomerId);
            pars.Add("employeeId", employee == null ? null : employee.EmployeeId);
            pars.Add("depotid", depot == null ? null : depot.DepotId);
            return sqlmapper.QueryForList<Model.InvoiceXSDetail>("InvoiceXSDetail.selectByCustomEmpDepetQuJian", pars);

        }

        public Model.InvoiceXSDetail GetByProIdPosIdInvoiceId(string productId, string positionId, string invoiceId)
        {
            Hashtable ht = new Hashtable();
            ht.Add("productId", productId);
            ht.Add("positionId", positionId);
            ht.Add("invoiceId", invoiceId);
            return sqlmapper.QueryForObject<Model.InvoiceXSDetail>("InvoiceXSDetail.GetByProIdPosIdInvoiceId", ht);
        }

        public double GetSumByProductIdAndInvoiceId(string productId, string invoiceId)
        {
            Hashtable ht = new Hashtable();
            ht.Add("productId", productId);
            ht.Add("invoiceId", invoiceId);
            return sqlmapper.QueryForObject<double>("InvoiceXSDetail.GetSumByProductIdAndInvoiceId", ht);
        }

        public IList<Model.InvoiceXSDetail> Selectbyinvoiceidfz(Model.InvoiceXS inovicexs)
        {
            return sqlmapper.QueryForList<Model.InvoiceXSDetail>("InvoiceXSDetail.selectbyinvoiceidfz", inovicexs.InvoiceId);
        }

        public IList<Book.Model.InvoiceXSDetail> SelectByDateRange(DateTime startdate, DateTime enddate)
        {
            Hashtable ht = new Hashtable();
            ht.Add("startdate", startdate);
            ht.Add("enddate", enddate);
            return sqlmapper.QueryForList<Model.InvoiceXSDetail>("InvoiceXSDetail.SelectByDateRange", ht);
        }

        public IList<Book.Model.InvoiceXSDetail> SelectbyConditionX(DateTime StartDate, DateTime EndDate, DateTime Yjri1, DateTime Yjri2, Book.Model.Customer Customer1, Book.Model.Customer Customer2, string XOId1, string XOId2, Book.Model.Product Product, Book.Model.Product Product2, string CusXOId, int OrderColumn, int OrderType, Model.Employee startEmp, Model.Employee endEmp, string FreightedCompanyId, string ConveyanceMethodId, string product_Id)
        {
            //StringBuilder sb = new StringBuilder();
            //if (Product != null && Product2 != null)
            //    sb.Append(" AND ProductId BETWEEN '" + Product.Id + "' AND '" + Product2.Id + "'");
            //if (!string.IsNullOrEmpty(CusXOId))
            //    sb.Append(" AND InvoiceXOId IN (SELECT InvoiceId FROM InvoiceXO WHERE CustomerInvoiceXOId = '" + CusXOId + "')");
            //sb.Append(" AND InvoiceId IN (SELECT InvoiceId FROM InvoiceXS WHERE InvoiceDate BETWEEN '" + StartDate.ToString("yyyy-MM-dd") + "' AND '" + EndDate.Date.AddDays(1).ToString("yyyy-MM-dd") + "')");
            //if (Yjri1 != global::Helper.DateTimeParse.NullDate && Yjri2 != global::Helper.DateTimeParse.EndDate)
            //    sb.Append(" AND InvoiceXOId IN (SELECT InvoiceId FROM InvoiceXO WHERE InvoiceYjrq BETWEEN '" + Yjri1.ToString("yyyy-MM-dd") + "' AND '" + Yjri2.Date.AddDays(1).ToString("yyyy-MM-dd") + "')");
            //if (Customer1 != null && Customer2 != null)
            //    sb.Append(" AND InvoiceId IN (SELECT InvoiceId FROM InvoiceXS WHERE CustomerId IN (SELECT CustomerId FROM Customer WHERE Id BETWEEN '" + Customer1.Id + "' AND '" + Customer2.Id + "'))");
            //if (!string.IsNullOrEmpty(XOId1) && !string.IsNullOrEmpty(XOId2))
            //    sb.Append(" AND InvoiceId BETWEEN '" + XOId1 + "' AND '" + XOId2 + "'");

            //return sqlmapper.QueryForList<Model.InvoiceXSDetail>("InvoiceXSDetail.SelectbyConditionX", sb.ToString());

            StringBuilder sb = new StringBuilder();
            sb.Append("  SELECT xsd.* ,p.ProductName,p.ProductSpecification,xs.InvoiceDate,xod.InvoiceXODetailQuantity as InvoiceXODetailQuantity1,xod.InvoiceXODetailQuantity0,xo.CustomerInvoiceXOId FROM InvoiceXSDetail xsd left join Product p on xsd.ProductId=p.ProductId left join InvoiceXS xs on xs.InvoiceId=xsd.InvoiceId left join InvoiceXODetail xod on xod.InvoiceXODetailId=xsd.InvoiceXODetailId left join InvoiceXO xo on xo.InvoiceId=xsd.InvoiceXOId  WHERE xs.InvoiceDate BETWEEN '" + StartDate.ToString("yyyy-MM-dd") + "' AND '" + EndDate.Date.AddDays(1).ToString("yyyy-MM-dd") + "'");

            if (Product != null && Product2 != null)
                sb.Append(" AND xsd.ProductId in (Select ProductId from Product where Id BETWEEN '" + Product.Id + "' AND '" + Product2.Id + "')");
            if (!string.IsNullOrEmpty(CusXOId))
                sb.Append(" AND xo.CustomerInvoiceXOId = '" + CusXOId + "'");
            if (Yjri1 != global::Helper.DateTimeParse.NullDate && Yjri2 != global::Helper.DateTimeParse.EndDate)
                sb.Append(" AND xo.InvoiceYjrq BETWEEN '" + Yjri1.ToString("yyyy-MM-dd") + "' AND '" + Yjri2.Date.AddDays(1).ToString("yyyy-MM-dd") + "'");
            if (Customer1 != null && Customer2 != null)
                sb.Append(" AND xs.CustomerId IN (SELECT CustomerId FROM Customer WHERE Id BETWEEN '" + Customer1.Id + "' AND '" + Customer2.Id + "')");
            if (!string.IsNullOrEmpty(XOId1) && !string.IsNullOrEmpty(XOId2))
                sb.Append(" AND InvoiceId BETWEEN '" + XOId1 + "' AND '" + XOId2 + "'");
            if (startEmp != null && endEmp != null)
            {
                sb.Append(" And xs.Employee0Id in (select EmployeeId from Employee where IDNo between '" + startEmp.IDNo + "' and '" + endEmp.IDNo + "')");
            }
            if (!string.IsNullOrEmpty(FreightedCompanyId))
                sb.Append(" and  xs.InvoiceId in(select invoiceid from InvoiceXS where  TransportCompany='" + FreightedCompanyId + "') ");
            if (!string.IsNullOrEmpty(ConveyanceMethodId))
                sb.Append(" and  xs.InvoiceId in(select invoiceid from InvoiceXS where  ConveyanceMethodId='" + ConveyanceMethodId + "')");
            if (!string.IsNullOrEmpty(product_Id))
                sb.Append(" AND xsd.ProductId in (Select ProductId from Product where Id ='" + product_Id + "' )");

            return this.DataReaderBind<Model.InvoiceXSDetail>(sb.ToString(), null, CommandType.Text);
        }

        //应收账款明细表
        public DataTable SelectbyConditionXBiao(DateTime StartDate, DateTime EndDate, DateTime Yjri1, DateTime Yjri2, Book.Model.Customer Customer1, Book.Model.Customer Customer2, string XOId1, string XOId2, Book.Model.Product Product, Book.Model.Product Product2, string CusXOId, int OrderColumn, int OrderType, bool? isSpecial, string product_Id)
        {
            StringBuilder sb_xs = new StringBuilder("SELECT InvoiceId AS CHDH,(SELECT InvoiceDate FROM InvoiceXS WHERE InvoiceId = InvoiceXSDetail.InvoiceId) AS CHRQ,(SELECT ProductName+'{'+ISNULL(CustomerProductName,'')+'}' FROM Product WHERE ProductId = InvoiceXSDetail.ProductId) AS ProductName,(SELECT CustomerInvoiceXOId FROM InvoiceXO WHERE InvoiceId = InvoiceXOId ) AS KHDDBH,InvoiceXSDetailQuantity AS BCCHSL,InvoiceProductUnit AS DanWei,InvoiceXSDetailPrice AS DanJia,InvoiceAllowance AS ZheRang,ROUND(InvoiceXSDetailMoney,0) AS JinE,ROUND(InvoiceXSDetailTaxMoney,0)-ROUND(InvoiceXSDetailMoney,0) AS ShuiE,ROUND(InvoiceXSDetailTaxMoney,0) AS YingShou FROM InvoiceXSDetail WHERE 1 = 1 ");
            //StringBuilder sb_xt = new StringBuilder("SELECT InvoiceId AS CHDH,(SELECT InvoiceDate FROM InvoiceXT WHERE InvoiceId = InvoiceXTDetail.InvoiceId) AS CHRQ,(SELECT ProductName+'{'+ISNULL(CustomerProductName,'')+'}' FROM Product WHERE ProductId = InvoiceXTDetail.ProductId ) AS ProductName,(SELECT CustomerInvoiceXOId FROM InvoiceXO WHERE InvoiceId = InvoiceXOId) AS KHDDBH,InvoiceXTDetailQuantity AS BCCHSL,InvoiceProductUnit AS DanWei,InvoiceXTDetailPrice AS DanJia,InvoiceXTDetailDiscount AS ZheRang,ROUND((0-InvoiceXTDetailMoney1),0) AS JinE,ROUND((0-InvoiceXTDetailMoney0)+(0-ISNULl(InvoiceXTDetailPrice,0)*isnull(InvoiceXTDetailQuantity,0)*0.05),0)-ROUND((0-InvoiceXTDetailMoney1),0) AS ShuiE,ROUND((0-InvoiceXTDetailMoney0)+(0-ISNULl(InvoiceXTDetailPrice,0)*isnull(InvoiceXTDetailQuantity,0)*0.05),0) AS YingShou FROM InvoiceXTDetail WHERE 1 = 1 ");
            StringBuilder sb_xt = new StringBuilder("SELECT xd.InvoiceId AS CHDH,x.InvoiceDate AS CHRQ,(SELECT ProductName+'{'+ISNULL(CustomerProductName,'')+'}' FROM Product WHERE ProductId = xd.ProductId ) AS ProductName,(SELECT CustomerInvoiceXOId FROM InvoiceXO WHERE InvoiceId = InvoiceXOId) AS KHDDBH,InvoiceXTDetailQuantity AS BCCHSL,InvoiceProductUnit AS DanWei,InvoiceXTDetailPrice AS DanJia,InvoiceXTDetailDiscount AS ZheRang,ROUND((0-InvoiceXTDetailMoney1),0) AS JinE,ROUND((0-InvoiceXTDetailMoney1)*x.InvoiceTaxRate/100,0) AS ShuiE,ROUND((0-InvoiceXTDetailMoney1)*(1+x.InvoiceTaxRate/100),0) AS YingShou FROM InvoiceXTDetail xd left join InvoiceXT x on xd.InvoiceId=x.InvoiceId WHERE 1 = 1 ");

            //时间日期
            sb_xs.Append(" AND InvoiceId IN (SELECT InvoiceId FROM InvoiceXS WHERE InvoiceDate BETWEEN '" + StartDate.ToString("yyyy-MM-dd") + "' AND '" + EndDate.Date.AddDays(1).ToString("yyyy-MM-dd") + "')");
            sb_xt.Append(" AND xd.InvoiceId IN (SELECT InvoiceId FROM InvoiceXT WHERE InvoiceDate BETWEEN '" + StartDate.ToString("yyyy-MM-dd") + "' AND '" + EndDate.Date.AddDays(1).ToString("yyyy-MM-dd") + "')");

            //预交日期
            if (Yjri1 != global::Helper.DateTimeParse.NullDate && Yjri2 != global::Helper.DateTimeParse.EndDate)
                sb_xs.Append(" AND InvoiceXOId IN (SELECT InvoiceId FROM InvoiceXO WHERE InvoiceYjrq BETWEEN '" + Yjri1.ToString("yyyy-MM-dd") + "' AND '" + Yjri2.Date.AddDays(1).ToString("yyyy-MM-dd") + "')");

            //客户
            if (Customer1 != null && Customer2 != null)
            {
                sb_xs.Append(" AND InvoiceId IN (SELECT InvoiceId FROM InvoiceXS WHERE CustomerId IN (SELECT CustomerId FROM Customer WHERE Id BETWEEN '" + Customer1.Id + "' AND '" + Customer2.Id + "'))");
                sb_xt.Append(" AND xd.InvoiceId IN (SELECT InvoiceId FROM InvoiceXT WHERE CustomerId IN (SELECT CustomerId FROM Customer WHERE Id BETWEEN '" + Customer1.Id + "' AND '" + Customer2.Id + "'))");
            }

            //头编号
            if (!string.IsNullOrEmpty(XOId1) && !string.IsNullOrEmpty(XOId2))
                sb_xs.Append(" AND InvoiceId BETWEEN '" + XOId1 + "' AND '" + XOId2 + "'");

            //客户订单编号
            if (!string.IsNullOrEmpty(CusXOId))
            {
                sb_xs.Append(" AND InvoiceXOId IN (SELECT InvoiceId FROM InvoiceXO WHERE CustomerInvoiceXOId = '" + CusXOId + "')");
                sb_xt.Append(" AND xd.InvoiceXOId IN (SELECT InvoiceId FROM InvoiceXO WHERE CustomerInvoiceXOId = '" + CusXOId + "')");
            }
            //商品
            if (Product != null && Product2 != null)
            {
                sb_xs.Append(" AND ProductId IN (SELECT Product.ProductId FROM Product WHERE Id BETWEEN '" + Product.Id + "' AND '" + Product2.Id + "')");
                sb_xt.Append(" AND xd.ProductId IN (SELECT Product.ProductId FROM Product WHERE Id BETWEEN '" + Product.Id + "' AND '" + Product2.Id + "')");
            }
            //商品編號 2018年12月28日17:39:40
            if (!string.IsNullOrEmpty(product_Id))
            {
                sb_xs.Append(" AND ProductId IN (SELECT Product.ProductId FROM Product WHERE Id ='" + product_Id + "')");
                sb_xt.Append(" AND xd.ProductId IN (SELECT Product.ProductId FROM Product WHERE Id ='" + product_Id + "')");
            }

            //特殊  只在应收账款明细表使用，其他引用 传递 null
            if (isSpecial != null)
            {
                if ((bool)isSpecial)
                    sb_xs.Append(" AND InvoiceId in (select InvoiceId from InvoiceXS where Special='" + 1 + "')");
                else
                    sb_xs.Append(" AND InvoiceId in (select InvoiceId from InvoiceXS where Special='" + 0 + "'  or Special is null)");
            }

            //赠送的不算做应收
            sb_xs.Append(" AND InvoiceXODetailId not in (select InvoiceXODetailId from InvoiceXODetail where Islargess=1)");
            sb_xt.Append(" AND xd.InvoiceXODetailId not in (select InvoiceXODetailId from InvoiceXODetail where Islargess=1)");

            string sql = sb_xs.ToString() + " UNION ALL " + sb_xt.ToString() + " order by CHDH,CHRQ";

            using (SqlConnection con = new SqlConnection(sqlmapper.DataSource.ConnectionString))
            {
                SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds != null && ds.Tables.Count > 0)
                    return ds.Tables[0];
            }
            return null;
        }

        //根據客戶訂單號查詢所有出貨單明細
        public IList<Model.InvoiceXSDetail> SelectByInvoiceXOId(string invoiceXOId)
        {
            string sql = "select xsd.InvoiceId,xsd.InvoiceXSDetailQuantity,p.Id as Product_Id,p.ProductName from InvoiceXSDetail xsd left join Product p on p.ProductId=xsd.ProductId left join InvoiceXODetail xod on xod.InvoiceXODetailId=xsd.InvoiceXODetailId where xsd.InvoiceXOId='" + invoiceXOId + "' order by xsd.InvoiceId, xsd.Inumber,p.Id";

            return this.DataReaderBind<Model.InvoiceXSDetail>(sql, null, CommandType.Text);
        }
    }
}
