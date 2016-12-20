//------------------------------------------------------------------------------
//
// file name：ProduceMaterialdetailsAccessor.cs
// author: peidun
// create date：2009-12-30 16:33:31
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
    /// Data accessor of ProduceMaterialdetails
    /// </summary>
    public partial class ProduceMaterialdetailsAccessor : EntityAccessor, IProduceMaterialdetailsAccessor
    {
        public IList<Book.Model.ProduceMaterialdetails> Select(Model.ProduceMaterial produceMaterial)
        {
            return sqlmapper.QueryForList<Model.ProduceMaterialdetails>("ProduceMaterialdetails.select_byProduceMaterialID", produceMaterial.ProduceMaterialID);
        }

        public IList<Book.Model.ProduceMaterialdetails> SelectByState(Model.ProduceMaterial produceMaterial)
        {
            return sqlmapper.QueryForList<Model.ProduceMaterialdetails>("ProduceMaterialdetails.select_byState", produceMaterial.ProduceMaterialID);
        }

        public IList<Book.Model.ProduceMaterialdetails> Select(string houseid, DateTime startDate, DateTime endDate)
        {
            Hashtable ht = new Hashtable();
            ht.Add("houseid", houseid);
            ht.Add("startDate", startDate);
            ht.Add("enddate", endDate);
            return sqlmapper.QueryForList<Model.ProduceMaterialdetails>("ProduceMaterialdetails.SelectByHouseDates", ht);
        }

        public IList<Model.ProduceMaterialdetails> SelectBycondition(DateTime starDate, DateTime endDate, string produceMaterialId0, string produceMaterialId1, string pId0, string pId1, string departmentId0, string departmentId1, string PronoteHeaderId0, string PronoteHeaderId1)
        {
            Hashtable ht = new Hashtable();
            ht.Add("starDate", starDate);
            ht.Add("endDate", endDate);
            ht.Add("produceMaterialId0", produceMaterialId0);
            ht.Add("produceMaterialId1", produceMaterialId1);
            ht.Add("pId0", pId0);
            ht.Add("pId1", pId1);
            ht.Add("dId0", departmentId0);
            ht.Add("dId1", departmentId1);
            ht.Add("pronoteId0", PronoteHeaderId0);
            ht.Add("pronoteId1", PronoteHeaderId1);
            return sqlmapper.QueryForList<Model.ProduceMaterialdetails>("ProduceMaterialdetails.selectBycondition", ht);
        }

        public Model.ProduceMaterialdetails SelectByProductIdAndHeadId(string productId, string produceMaterialId)
        {
            Hashtable ht = new Hashtable();
            ht.Add("produceMaterialId", produceMaterialId);
            ht.Add("productId", productId);
            return sqlmapper.QueryForObject<Model.ProduceMaterialdetails>("ProduceMaterialdetails.selectByproductIdAndHeadId", ht);
        }

        public IList<Model.ProduceMaterialdetails> SelectByProductIdAndHeadId(Model.Product pId0, Model.Product pId1, string produceMaterialId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * ");
            sb.Append(" ,(SELECT ProductName FROM Product WHERE Product.ProductId = ProduceMaterialdetails.ProductId) AS ProductName");
            sb.Append(" ,(SELECT CustomerProductName FROM Product WHERE Product.ProductId = ProduceMaterialdetails.ProductId) AS CustomerProductName");
            sb.Append(" FROM ProduceMaterialdetails WHERE ProduceMaterialID='" + produceMaterialId + "'");
            if (pId0 != null && pId1 != null)
            {
                sb.Append(" AND ProductId IN (SELECT ProductId FROM Product WHERE Id BETWEEN '" + pId0.Id + "' AND '" + pId1.Id + "')");
            }

            return this.DataReaderBind<Model.ProduceMaterialdetails>(sb.ToString(), null, CommandType.Text);

            #region 注释
            //Hashtable ht = new Hashtable();
            //ht.Add("produceMaterialId", produceMaterialId);
            //ht.Add("pId0", pId0 == null ? null : pId0.ProductName);
            //ht.Add("pId1", pId1 == null ? null : pId1.ProductName);
            //return sqlmapper.QueryForList<Model.ProduceMaterialdetails>("ProduceMaterialdetails.selectByproductIdAndHeadIdRange", ht);
            #endregion
        }

        public double GetMaterialprocesedsumForPDMId(string PDMid)
        {
            return sqlmapper.QueryForObject<double>("ProduceMaterialdetails.GetMaterialprocesedsumForPDMId", PDMid);
        }

        public IList<Model.ProduceMaterialdetails> SelectTotalByProduceMaterialID(Model.Product pId0, Model.Product pId1, string str)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT (SELECT ProductName FROM Product WHERE Product.ProductId = ProduceMaterialdetails.ProductId) AS ProductName");
            sb.Append(",sum(Materialprocessum) AS Materialprocessum,sum(Materialprocesedsum) AS Materialprocesedsum");
            sb.Append(" FROM ProduceMaterialdetails WHERE ProduceMaterialID in (" + str + ")");
            if (pId0 != null && pId1 != null)
            {
                sb.Append(" AND ProductId IN (SELECT ProductId FROM Product WHERE Id BETWEEN '" + pId0.Id + "' AND '" + pId1.Id + "')");
            }
            sb.Append("GROUP BY ProduceMaterialdetails.ProductId");
            return this.DataReaderBind<Model.ProduceMaterialdetails>(sb.ToString(), null, CommandType.Text);
        }

        public IList<Model.ProduceMaterialdetails> SelectByDateRange(string ProductId, DateTime StartDate, DateTime EndDate)
        {
            string str = "select pmd.ProduceMaterialID,pm.ProduceMaterialDate,isnull(pmd.Materialprocessum,0) as Materialprocessum,isnull(pmd.Materialprocesedsum,0) as Materialprocesedsum,pmd.Distributioned,pmd.PronoteHeaderID,pmd.MRSHeaderId from ProduceMaterialdetails pmd left join ProduceMaterial pm on pmd.ProduceMaterialID=pm.ProduceMaterialID where pm.ProduceMaterialDate BETWEEN '" + StartDate.ToString("yyyy-MM-dd") + "' AND '" + EndDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and pmd.productid='" + ProductId + "' union all select pomd.ProduceOtherMaterialId,pom.ProduceOtherMaterialDate,isnull(pomd.OtherMaterialQuantity,0),isnull(pomd.OtherMaterialALLUserQuantity,0),pomd.Distributioned,'',poc.MRSHeaderId from ProduceOtherMaterialDetail pomd left join ProduceOtherMaterial pom on pomd.ProduceOtherMaterialId=pom.ProduceOtherMaterialId left join ProduceOtherCompact poc on pom.ProduceOtherCompactId=poc.ProduceOtherCompactId where pom.ProduceOtherMaterialDate BETWEEN '" + StartDate.ToString("yyyy-MM-dd") + "' AND '" + EndDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and pomd.ProductId='" + ProductId + "' order by ProduceMaterialID,ProduceMaterialDate";

            return this.DataReaderBind<Model.ProduceMaterialdetails>(str, null, CommandType.Text);
        }

        public IList<Model.ProduceMaterialdetails> SelectForDistributioned(string productid, DateTime  InsertTime)
        {
            Hashtable ht = new Hashtable();
            ht.Add("productid", productid);
            ht.Add("InsertTime", InsertTime);
            return sqlmapper.QueryForList<Model.ProduceMaterialdetails>("ProduceMaterialdetails.SelectForDistributioned", ht);
        }
    }
}
