﻿//------------------------------------------------------------------------------
//
// file name:StockAccessor.cs
// author: peidun
// create date:2008/6/6  10:00:51
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
    /// Data accessor of Stock
    /// </summary>
    public partial class StockAccessor : EntityAccessor, IStockAccessor
    {
        public DataTable SelectDataTable()
        {
            return this.SelectDataTable("");
        }

        public DataTable SelectDataTable(string strWhere)
        {
            string strSql = "SELECT DepotPosition.*, Product.*,Product.id spid, Stock.*,Depot.*,ProductUnit.* FROM ((((Product INNER JOIN Stock ON Product.ProductId = Stock.ProductId) INNER JOIN DepotPosition ON Stock.DepotPositionId = DepotPosition.DepotPositionId) INNER JOIN Depot ON Depot.depotid=DepotPosition.depotid) INNER JOIN ProductUnit ON product.DepotUnitId = ProductUnit.ProductUnitId and product.productid = stock.productid) ";
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql += @" where " + strWhere;
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(strSql, sqlmapper.DataSource.ConnectionString);
            DataTable Stocks = new DataTable();
            dataAdapter.Fill(Stocks);
            return Stocks;
        }

        public System.Data.DataTable SelectDataTable(Model.Product product)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select sum(StockQuantity0) as StockBeginQuantity,");
            sb.Append("sum(StockQuantity1) as StockCurrentQuantity,");

            sb.Append("sum(StockBeginJR) as StockBeginJR1,");
            sb.Append("sum(StockBeginJC) as StockBeginJC1,");
            sb.Append("sum(StockCurrentJR) as StockCurrentJR1,");
            sb.Append("sum(StockCurrentJC) as StockCurrentJC1 ");
            sb.Append("from stock where productId = '" + product.ProductId + "'");

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sb.ToString(), sqlmapper.DataSource.ConnectionString);
            DataTable table = new DataTable("QuantityAndJR");
            dataAdapter.Fill(table);
            return table;
        }

        public void UpdateDataTable(DataTable stocks)
        {
            SqlConnection conn = new SqlConnection(sqlmapper.DataSource.ConnectionString);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();

            dataAdapter.UpdateCommand = new SqlCommand("update dbo.Stock set productid=@productid,DepotPositionId=@depotPositionId,stockquantity0=@stockquantity0,stockquantity1=@stockquantity1,stockquantityD=@stockquantityD,stockquantityU=@stockquantityU,StockBeginJR =@stockBeginJR,StockBeginJC = @stockBeginJC,StockCurrentJR = @StockCurrentJR,StockCurrentJC = @StockCurrentJC where stockid=@stockid", conn);
            dataAdapter.UpdateCommand.Parameters.Add(new SqlParameter("@productid", SqlDbType.VarChar, 50, "Productid"));
            dataAdapter.UpdateCommand.Parameters.Add(new SqlParameter("@depotPositionId", SqlDbType.VarChar, 50, "DepotPositionId"));
            dataAdapter.UpdateCommand.Parameters.Add(new SqlParameter("@stockquantity0", SqlDbType.Float, 32, "StockQuantity0"));
            dataAdapter.UpdateCommand.Parameters.Add(new SqlParameter("@stockquantity1", SqlDbType.Float, 32, "StockQuantity1"));
            dataAdapter.UpdateCommand.Parameters.Add(new SqlParameter("@stockquantityD", SqlDbType.Float, 32, "StockQuantityD"));
            dataAdapter.UpdateCommand.Parameters.Add(new SqlParameter("@stockquantityU", SqlDbType.Float, 32, "StockQuantityU"));
            dataAdapter.UpdateCommand.Parameters.Add(new SqlParameter("@stockid", SqlDbType.VarChar, 50, "StockId"));

            dataAdapter.UpdateCommand.Parameters.Add(new SqlParameter("@stockBeginJR", SqlDbType.Float, 32, "StockBeginJR"));
            dataAdapter.UpdateCommand.Parameters.Add(new SqlParameter("@stockCurrentJR", SqlDbType.Float, 32, "StockCurrentJR"));
            dataAdapter.UpdateCommand.Parameters.Add(new SqlParameter("@stockBeginJC", SqlDbType.Float, 32, "StockBeginJC"));
            dataAdapter.UpdateCommand.Parameters.Add(new SqlParameter("@stockCurrentJC", SqlDbType.Float, 32, "StockCurrentJC"));
            dataAdapter.Update(stocks);
        }

        public bool Exists(Book.Model.DepotPosition depotPosition, Book.Model.Product product)
        {
            Hashtable paras = new Hashtable();
            paras.Add("positionId", depotPosition.DepotPositionId);
            paras.Add("ProductId", product.ProductId);
            return sqlmapper.QueryForObject<int>("Stock.count_productId_depotid", paras) > 0 ? true : false;
        }

        public void Increment(Book.Model.DepotPosition depotPosition, Book.Model.Product product, double quantity)
        {
            Hashtable paras = new Hashtable();
            paras.Add("Quantity", quantity);
            paras.Add("positionId", depotPosition.DepotPositionId);
            paras.Add("ProductId", product.ProductId);

            if (!Exists(depotPosition, product))
            {
                Model.Stock stock = new Book.Model.Stock();
                stock.StockId = Guid.NewGuid().ToString();
                stock.DepotPositionId = depotPosition.DepotPositionId;
                stock.DepotId = depotPosition.DepotId;
                stock.ProductId = product.ProductId;
                stock.StockQuantity1 = quantity;
                this.Insert(stock);
            }
            else
                sqlmapper.Update("Stock.increment", paras);
        }

        public void Decrement(Book.Model.DepotPosition depotPosition, Book.Model.Product product, double quantity)
        {
            if (!Exists(depotPosition, product))
            {
                Model.Stock stock = new Book.Model.Stock();
                stock.StockId = Guid.NewGuid().ToString();
                stock.DepotPositionId = depotPosition.DepotPositionId;
                stock.DepotId = depotPosition.DepotId;
                stock.ProductId = product.ProductId;
                stock.StockQuantity1 = 0 - quantity;
                this.Insert(stock);
            }
            else
            {
                Hashtable paras = new Hashtable();
                paras.Add("Quantity", quantity);
                paras.Add("positionId", depotPosition.DepotPositionId);
                paras.Add("ProductId", product.ProductId);
                sqlmapper.Update("Stock.decrement", paras);
            }
        }

        public void Increment(Book.Model.DepotPosition depotPosition, Book.Model.Product product, double? quantity)
        {
            this.Increment(depotPosition, product, quantity == null ? 0 : quantity.Value);
        }

        public void Decrement(Book.Model.DepotPosition depotPosition, Book.Model.Product product, double? quantity)
        {
            this.Decrement(depotPosition, product, quantity == null ? 0 : quantity.Value);
        }

        public void IncrementJR(Book.Model.DepotPosition depotPosition, Book.Model.Product product, double quantity)
        {
            Hashtable paras = new Hashtable();
            paras.Add("Quantity", quantity);
            paras.Add("positionId", depotPosition == null ? null : depotPosition.DepotPositionId);
            paras.Add("ProductId", product.ProductId);
            sqlmapper.Update("Stock.incrementjr", paras);
        }

        public void IncrementJC(Book.Model.DepotPosition depotPosition, Book.Model.Product product, double quantity)
        {
            Hashtable paras = new Hashtable();
            paras.Add("Quantity", quantity);
            paras.Add("positionId", depotPosition.DepotPositionId);
            paras.Add("ProductId", product.ProductId);
            sqlmapper.Update("Stock.incrementjc", paras);
        }

        public void DecrementJR(Book.Model.DepotPosition depotPosition, Book.Model.Product product, double quantity)
        {
            Hashtable paras = new Hashtable();
            paras.Add("Quantity", quantity);
            paras.Add("positionId", depotPosition.DepotPositionId);
            paras.Add("ProductId", product.ProductId);
            sqlmapper.Update("Stock.decrementjr", paras);
        }

        public void DecrementJC(Book.Model.DepotPosition depotPosition, Book.Model.Product product, double quantity)
        {
            Hashtable paras = new Hashtable();
            paras.Add("Quantity", quantity);
            paras.Add("positionId", depotPosition.DepotPositionId);
            paras.Add("ProductId", product.ProductId);
            sqlmapper.Update("Stock.decrementjc", paras);
        }

        public IList<Book.Model.Stock> Select(string id)
        {
            return sqlmapper.QueryForList<Model.Stock>("Stock.select_byProductID", id);
        }

        public IList<Book.Model.Stock> Select(Model.Depot depot)
        {
            return sqlmapper.QueryForList<Model.Stock>("Stock.select_byDepotID", depot.DepotId);
        }

        public IList<Book.Model.Stock> Select(Model.Stock stock)
        {
            Hashtable paras = new Hashtable();
            paras.Add("depotId", stock.Depot.DepotId);
            paras.Add("productId", stock.ProductId);
            return sqlmapper.QueryForList<Model.Stock>("GetTheCountOfProductByProductId", paras);

        }

        public Model.Stock GetStockByPidAndDid(Model.Stock stock)
        {
            Hashtable ht = new Hashtable();
            ht.Add("pid", stock.ProductId);
            ht.Add("did", stock.DepotId);
            return sqlmapper.QueryForObject<Model.Stock>("Stock.select_by_productidAndDepotId", ht);

        }

        public IList<Model.Stock> SelectNotZeroByPidAndDid(string productId, string depotId)
        {
            Hashtable ht = new Hashtable();
            ht.Add("pid", productId);
            ht.Add("did", depotId); ;
            return sqlmapper.QueryForList<Model.Stock>("Stock.selectNotZeroByPidAndDid", ht);
        }

        public IList<Model.Stock> GetStockByPidAndDid(string productId, string depotId)
        {
            Hashtable ht = new Hashtable();
            ht.Add("pid", productId);
            ht.Add("did", depotId); ;
            return sqlmapper.QueryForList<Model.Stock>("Stock.select_by_productidAndDepotId", ht);
        }

        public double GetTheCount1OfProductByProductId(Model.Product product, Model.Depot depot)
        {
            Hashtable ht = new Hashtable();
            ht.Add("productId", product == null ? null : product.ProductId);
            ht.Add("depotId", depot.DepotId);
            return sqlmapper.QueryForObject<double>("Stock.GetTheCount1OfProductByProductId", ht);
        }

        public double GetTheCount0OfProductByProductId(Model.Product product, Model.Depot depot)
        {
            Hashtable ht = new Hashtable();
            ht.Add("productId", product == null ? null : product.ProductId);
            ht.Add("depotId", depot.DepotId);
            return sqlmapper.QueryForObject<double>("Stock.GetTheCount0OfProductByProductId", ht);
        }

        public double GetTheCountByProduct(Model.Product product)
        {
            return sqlmapper.QueryForObject<double>("Stock.GetTheCountByProduct", product.ProductId);
        }

        public DataSet SelectDataSet()
        {
            string strSql = "SELECT DepotPosition.Id as postid ,DepotPosition.DepotPositionId, Product.ProductName,Product.CustomerProductName,Product.id proId, Stock.*,isnull( Stock.StockQuantityOld,0) stocknums,Depot.*,ProductUnit.* FROM ((((Product INNER JOIN Stock ON Product.ProductId = Stock.ProductId) INNER JOIN DepotPosition ON Stock.DepotPositionId = DepotPosition.DepotPositionId) INNER JOIN Depot ON Depot.depotid=DepotPosition.depotid) INNER JOIN ProductUnit ON product.DepotUnitId = ProductUnit.ProductUnitId and product.productid = stock.productid) order by  proId";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(strSql, sqlmapper.DataSource.ConnectionString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds;
        }

        public void UpdateDataTable1(DataTable stocks)
        {
            SqlConnection conn = new SqlConnection(sqlmapper.DataSource.ConnectionString);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.UpdateCommand = new SqlCommand("update dbo.Stock set stockquantity1=@stockquantity1 where stockid=@stockid", conn);
            dataAdapter.UpdateCommand.Parameters.Add(new SqlParameter("@stockid", SqlDbType.VarChar, 50, "StockId"));

            dataAdapter.UpdateCommand.Parameters.Add(new SqlParameter("@stockquantity1", SqlDbType.Float, 32, "StockQuantity1"));

            dataAdapter.Update(stocks);
        }

        public Model.Stock GetStockByProductIdAndDepotPositionId(string productid, string depotpositionId)
        {
            Hashtable ht = new Hashtable();
            ht.Add("productid", productid);
            ht.Add("depotPositionId", depotpositionId);
            return sqlmapper.QueryForObject<Model.Stock>("Stock.GetStockByProductIdAndDepotPositionId", ht);
        }

        public DataTable SelectDataTableProName(string proName)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new System.Data.SqlClient.SqlCommand();
            da.SelectCommand.Connection = new SqlConnection(sqlmapper.DataSource.ConnectionString);
            da.SelectCommand.CommandText = "select (select DepotName from Depot where DepotId =(select DepotId from depotposition where depotpositionId = stock.depotpositionId)) as DepotName,(select productName from product where productid = stock.productid)  productName,(select ProductDescription from product where productid = stock.productid)  ProductDescription,(select id from product where productid = stock.productid) spid, (select CnName from ProductUnit INNER JOIN product ON  product.DepotUnitId = ProductUnit.ProductUnitId and product.productid = stock.productid) CnName,  (select Id from depotposition where depotpositionId = stock.depotpositionId) as DepotPositionId,StockQuantity1   as Quantity from stock WHERE ProductId IN(SELECT ProductId FROM product WHERE ProductName LIKE '%" + proName + "%')";
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        //商品窗体库存历史记录
        public IList<Model.StockSeach> SelectReaderByPro(string productId, DateTime startDate, DateTime endDate)
        {
            IList<Model.StockSeach> list = new List<Model.StockSeach>();
            string[] sqls ={"SELECT '出倉單' as InvoiceType,DepotOutId   as InvoiceNO,(select DepotOutDate  FROM DepotOut where DepotOut.DepotOutId = DepotOutDetail.DepotOutId) as InvoiceDate ,DepotOutDetail.DepotOutDetailQuantity AS InvoiceQuantity,ProductUnit AS  InvoiceUnit,(SELECT DepotName FROM Depot WHERE Depot.DepotId=(SELECT DepotId FROM DepotOut WHERE DepotOut.DepotOutId=DepotOutDetail.DepotOutId )) AS DepotName,(SELECT id FROM DepotPosition WHERE DepotPosition.DepotPositionId=DepotOutDetail.DepotPositionId) AS PositionName,(SELECT StocksQuantity FROM product WHERE   product.ProductId=DepotOutDetail.ProductId) AS Stock1,'' AS WorkHouseName,(SELECT InvioiceId FROM DepotOut WHERE DepotOut.DepotOutId = DepotOutDetail.DepotOutId) AS InvioiceId, (SELECT Description FROM DepotOut WHERE DepotOut.DepotOutId=DepotOutDetail.DepotOutId) as Description,isnull((SELECT InvoiceCusId FROM ProduceOtherMaterial WHERE ProduceOtherMaterialId IN (SELECT InvioiceId FROM DepotOut WHERE DepotOut.DepotOutId=DepotOutDetail.DepotOutId)),'')+isnull((SELECT CustomerInvoiceXOId FROM InvoiceXO WHERE InvoiceId=(SELECT InvoiceXOId FROM ProduceMaterial WHERE ProduceMaterial.ProduceMaterialID IN (SELECT InvioiceId FROM DepotOut WHERE DepotOut.DepotOutId=DepotOutDetail.DepotOutId))),'') as CusXOId,(0-DepotOutDetail.DepotOutDetailQuantity) AS StockCheckBookQuantity  FROM DepotOutDetail WHERE ProductId='"+productId+"' and DepotOutId in (select DepotOutId from DepotOut where (DepotOutDate between '"+startDate.ToString("yyyy-MM-dd")+"' and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"') or ('"+startDate.ToString("yyyy-MM-dd")+"' is null and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"' is null))",
                            "SELECT '入倉單' as InvoiceType,DepotInId as InvoiceNO,(select DepotInDate  FROM depotIn where depotIn.DepotInId = DepotInDetail.DepotInId) as InvoiceDate ,DepotInDetail.DepotInQuantity AS InvoiceQuantity,ProductUnit AS  InvoiceUnit,(SELECT DepotName FROM Depot WHERE Depot.DepotId=(SELECT DepotId FROM depotIn WHERE depotIn.DepotInId=DepotInDetail.DepotInId )) AS DepotName,(SELECT id FROM DepotPosition WHERE DepotPosition.DepotPositionId=DepotInDetail.DepotPositionId) AS PositionName,(SELECT StocksQuantity FROM product WHERE   product.ProductId=DepotInDetail.ProductId) AS Stock1,'' AS WorkHouseName,'' AS InvioiceId, Descriptions as Description,'' as CusXOId,DepotInDetail.DepotInQuantity AS  StockCheckBookQuantity FROM DepotInDetail WHERE ProductId='"+productId+"' and DepotInId in (select DepotInId from DepotIn where (DepotInDate between '"+startDate.ToString("yyyy-MM-dd")+"' and '"+endDate.ToString("yyyy-MM-dd HH:mm:dd")+"') or ('"+startDate.ToString("yyyy-MM-dd")+"' is null and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"' is null )) ",
                            "SELECT '盤點核准單' as InvoiceType,StockCheckId as InvoiceNO,(select StockCheckDate  FROM StockCheck where StockCheck.StockCheckId = StockCheckDetail.StockCheckId) as InvoiceDate ,StockCheckDetail.StockCheckQuantity AS InvoiceQuantity,ProductUnitName AS  InvoiceUnit,(SELECT DepotName FROM Depot WHERE Depot.DepotId=(SELECT DepotId FROM StockCheck WHERE StockCheck.StockCheckId=StockCheckDetail.StockCheckId )) AS DepotName,(SELECT id FROM DepotPosition WHERE DepotPosition.DepotPositionId=StockCheckDetail.DepotPositionId) AS PositionName,(SELECT StocksQuantity FROM product WHERE   product.ProductId=StockCheckDetail.ProductId) AS Stock1,'' AS WorkHouseName,'' AS InvioiceId,Directions as Description,'' as CusXOId,(StockCheckQuantity-StockCheckBookQuantity) as StockCheckBookQuantity  FROM StockCheckDetail WHERE ProductId='"+productId+"' and StockCheckId in (select StockCheckId from StockCheck where (StockCheckDate between '"+startDate.ToString("yyyy-MM-dd")+"' and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"') or ('"+startDate.ToString("yyyy-MM-dd")+"' is null and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"' is null ))",
                            "SELECT '庫存調撥單' as InvoiceType,InvoiceId as InvoiceNO,(select InvoiceDate  FROM InvoicePT where InvoicePT.InvoiceId = InvoicePTdetail.InvoiceId) as InvoiceDate ,InvoicePTdetail.InvoicePTDetailQuantity AS InvoiceQuantity,InvoiceProductUnit AS  InvoiceUnit,(SELECT DepotName FROM Depot WHERE Depot.DepotId=(SELECT DepotInId FROM InvoicePT WHERE InvoicePT.InvoiceId=InvoicePTdetail.InvoiceId )) AS DepotName,(SELECT DepotName FROM Depot WHERE Depot.DepotId=(SELECT DepotId FROM InvoicePT WHERE InvoicePT.InvoiceId=InvoicePTdetail.InvoiceId )) AS OutDepotName,(SELECT id FROM DepotPosition WHERE DepotPosition.DepotPositionId=InvoicePTdetail.DepotPositionInId) AS PositionName,(SELECT id FROM DepotPosition WHERE DepotPosition.DepotPositionId=InvoicePTdetail.DepotPositionId) AS OutPositionName,(SELECT StocksQuantity FROM product WHERE product.ProductId=InvoicePTdetail.ProductId) AS Stock1,'' AS WorkHouseName,'' AS InvioiceId,InvoicePTDetailNote as Description,'' as CusXOId FROM InvoicePTdetail WHERE ProductId='"+productId+"' and InvoiceId in (select InvoiceId from InvoicePT where (InvoiceDate between '"+startDate.ToString("yyyy-MM-dd")+"' and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"') or ('"+startDate.ToString("yyyy-MM-dd")+"' is null and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"' is null ))",
                            "SELECT '生產入庫單' as InvoiceType,ProduceInDepotId as InvoiceNO,(select ProduceInDepotDate  FROM ProduceInDepot where ProduceInDepot.ProduceInDepotId = ProduceInDepotDetail.ProduceInDepotId) as InvoiceDate ,ProduceInDepotDetail.ProduceQuantity AS InvoiceQuantity,ProductUnit AS  InvoiceUnit,(SELECT DepotName FROM Depot WHERE Depot.DepotId=(SELECT DepotId FROM ProduceInDepot WHERE ProduceInDepot.ProduceInDepotId=ProduceInDepotDetail.ProduceInDepotId )) AS DepotName,(SELECT id FROM DepotPosition WHERE DepotPosition.DepotPositionId=ProduceInDepotDetail.DepotPositionId) AS PositionName,(SELECT StocksQuantity FROM product WHERE   product.ProductId=ProduceInDepotDetail.ProductId) AS Stock1,(SELECT Workhousename FROM WorkHouse WHERE WorkHouse.WorkHouseId = (SELECT ProduceInDepot.WorkHouseId FROM ProduceInDepot WHERE ProduceInDepot.ProduceInDepotId = ProduceInDepotDetail.ProduceInDepotId)) AS WorkHouseName,'' AS InvioiceId,DetailDesc as Description,(select CustomerInvoiceXOId from invoicexo where invoiceid = (SELECT InvoiceXOId FROM PronoteHeader p WHERE p.PronoteHeaderID = ProduceInDepotDetail.PronoteHeaderId)) as CusXOId,ProduceInDepotDetail.ProduceQuantity AS StockCheckBookQuantity,ProduceTransferQuantity FROM ProduceInDepotDetail WHERE ProduceQuantity <> 0 and  ProductId='"+productId+"' and ProduceInDepotId in (select ProduceInDepotId from ProduceInDepot where (ProduceInDepotDate between '"+startDate.ToString("yyyy-MM-dd")+"' and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"') or ('"+startDate.ToString("yyyy-MM-dd")+"' is null and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"' is null )) ",
                            "SELECT '委外入庫單' as InvoiceType,ProduceOtherInDepotDetail.ProduceOtherInDepotId as InvoiceNO,(SELECT ProduceOtherInDepot.ProduceOtherInDepotDate FROM ProduceOtherInDepot WHERE ProduceOtherInDepot.ProduceOtherInDepotId = ProduceOtherInDepotDetail.ProduceOtherInDepotId) AS InvoiceDate,ProduceOtherInDepotDetail.ProduceInDepotQuantity AS InvoiceQuantity,ProduceOtherInDepotDetail.ProductUnit AS InvoiceUnit,(SELECT DepotName FROM Depot WHERE Depot.DepotId = (SELECT produceotherindepot.DepotId FROM ProduceOtherInDepot WHERE ProduceOtherInDepot.ProduceOtherInDepotId = ProduceOtherInDepotDetail.ProduceOtherInDepotId)) AS DepotName,(SELECT Id FROM DepotPosition WHERE DepotPosition.DepotPositionId = ProduceOtherInDepotDetail.DepotPositionId) AS PositionName,(SELECT product.StocksQuantity FROM Product WHERE product.ProductId = ProduceOtherInDepotDetail.ProductId) AS Stock1,'' AS WorkHouseName,'' AS InvioiceId,Description AS Description,InvoiceCusId as CusXOId ,ProduceOtherInDepotDetail.ProduceInDepotQuantity AS StockCheckBookQuantity,ProduceTransferQuantity FROM ProduceOtherInDepotDetail WHERE ProductId='"+productId+"' AND ProduceOtherInDepotId IN (SELECT ProduceOtherInDepotId FROM ProduceOtherInDepot WHERE (ProduceOtherInDepotDate BETWEEN '"+startDate.ToString("yyyy-MM-dd")+"' AND '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"') OR ('"+startDate.ToString("yyyy-MM-dd")+"' is null and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"' is null ))",
                            "SELECT '銷售出貨單' as InvoiceType,InvoiceId as InvoiceNO,(SELECT InvoiceXS.InvoiceDate FROM InvoiceXS WHERE InvoiceXS.InvoiceId = InvoiceXSDetail.InvoiceId) AS InvoiceDate,InvoiceXSDetailQuantity AS InvoiceQuantity,InvoiceProductUnit AS InvoiceUnit,(SELECT DepotName FROM Depot WHERE depot.DepotId = (SELECT invoicexs.DepotId  FROM InvoiceXS WHERE invoicexs.InvoiceId = InvoiceXSDetail.InvoiceId)) AS DepotName,(SELECT Id FROM DepotPosition WHERE DepotPosition.DepotPositionId = invoicexsdetail.DepotPositionId) AS PositionName,(SELECT product.StocksQuantity FROM Product WHERE Product.ProductId = invoicexsdetail.ProductId) AS Stock1,'' AS WorkHouseName,'' AS InvioiceId,InvoiceXSDetailNote AS Description,(SELECT CustomerInvoiceXOId FROM InvoiceXO WHERE InvoiceId = InvoiceXOId) as CusXOId ,(0-InvoiceXSDetailQuantity) as StockCheckBookQuantity FROM InvoiceXSDetail WHERE ProductId = '"+productId+"' AND InvoiceId IN (SELECT InvoiceXS.InvoiceId FROM InvoiceXS WHERE (InvoiceDate BETWEEN '"+startDate.ToString("yyyy-MM-dd")+"' AND '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"') OR ('"+startDate.ToString("yyyy-MM-dd")+"' is null and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"' is null ))",
                            "SELECT '採購入庫單' as InvoiceType,InvoiceId as InvoiceNO,(SELECT InvoiceCG.InvoiceDate FROM InvoiceCG WHERE invoicecg.InvoiceId = InvoiceCGDetail.InvoiceId) AS InvoiceDate,InvoiceCGDetail.InvoiceCGDetaiInQuantity AS InvoiceQuantity,InvoiceCGUnit AS InvoiceUnit,(SELECT DepotName FROM Depot WHERE depot.DepotId = (SELECT InvoiceCG.DepotId FROM InvoiceCG WHERE InvoiceCG.InvoiceId = InvoiceCGDetail.InvoiceId)) AS DepotName,(SELECT Id FROM DepotPosition WHERE DepotPosition.DepotPositionId = InvoiceCGDetail.DepotPositionId) AS PositionName,(SELECT Product.StocksQuantity FROM Product WHERE Product.ProductId = InvoiceCGDetail.ProductId) AS Stock1,'' AS WorkHouseName,InvoiceCOId AS InvioiceId,InvoiceCGDetail.InvoiceCGDetailNote AS Description,(select CustomerInvoiceXOId from invoicexo where InvoiceId=(select InvoiceXOId from InvoiceCO where InvoiceId=InvoiceCGDetail.InvoiceCOId)) as CusXOId,InvoiceCGDetaiInQuantity as StockCheckBookQuantity,ProduceTransferQuantity FROM InvoiceCGDetail WHERE ProductId = '"+productId+"' AND InvoiceId IN (SELECT InvoiceCG.InvoiceId FROM InvoiceCG WHERE (InvoiceDate BETWEEN '"+startDate.ToString("yyyy-MM-dd")+"' AND '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"') OR ('"+startDate.ToString("yyyy-MM-dd")+"' is null and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"' is null ))",
                            "SELECT '銷售退貨' as InvoiceType,InvoiceId as InvoiceNO,(SELECT InvoiceXT.InvoiceDate FROM InvoiceXT WHERE InvoiceXT.InvoiceId = InvoiceXTDetail.InvoiceId) AS InvoiceDate, InvoiceXTDetail.InvoiceXTDetailQuantity AS InvoiceQuantity, InvoiceXTDetail.InvoiceProductUnit AS InvoiceUnit, (SELECT  DepotName FROM Depot WHERE depot.DepotId = (SELECT InvoiceXT.DepotId FROM InvoiceXT WHERE InvoiceXT.InvoiceId=InvoiceXTDetail.InvoiceId)) AS DepotName,(SELECT Id FROM DepotPosition WHERE DepotPosition.DepotPositionId = InvoiceXTDetail.DepotPositionId) AS PositionName, (SELECT Product.StocksQuantity FROM Product WHERE Product.ProductId = InvoiceXTDetail.ProductId) AS Stock1, '' AS WorkHouseName,'' AS InvioiceId,(SELECT InvoiceXT.InvoiceNote FROM InvoiceXT WHERE InvoiceXT.InvoiceId = InvoiceXTDetail.InvoiceId) AS Description,(SELECT CustomerInvoiceXOId FROM InvoiceXO WHERE InvoiceXO.InvoiceId = InvoiceXTDetail.InvoiceXOId ) as CusXOId,InvoiceXTDetail.InvoiceXTDetailQuantity AS  StockCheckBookQuantity FROM InvoiceXTDetail WHERE ProductId = '"+productId+"' AND InvoiceId IN (SELECT InvoiceId FROM InvoiceXT WHERE (InvoiceDate BETWEEN '"+startDate.ToString("yyyy-MM-dd")+"' AND '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"') OR ('"+startDate.ToString("yyyy-MM-dd")+"' is null and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"' is null ))",
                            "SELECT '採購退貨' as InvoiceType,InvoiceId as InvoiceNO, (SELECT InvoiceCT.InvoiceDate FROM InvoiceCT WHERE InvoiceCT.InvoiceId = InvoiceCTDetail.InvoiceId) AS InvoiceDate, InvoiceCTDetail.InvoiceCTDetailQuantity AS InvoiceQuantity, InvoiceCTDetail.InvoiceProductUnit AS InvoiceUnit,(SELECT  DepotName FROM Depot WHERE depot.DepotId = (SELECT InvoiceCT.DepotId FROM InvoiceCT WHERE InvoiceCT.InvoiceId=InvoiceCTDetail.InvoiceId)) AS DepotName, (SELECT Id FROM DepotPosition WHERE DepotPosition.DepotPositionId = InvoiceCTDetail.DepotPositionId) AS PositionName, (SELECT Product.StocksQuantity FROM Product WHERE Product.ProductId = InvoiceCTDetail.ProductId) AS Stock1,'' AS WorkHouseName,(SELECT InvoiceCustomXOId FROM InvoiceCO WHERE InvoiceCO.InvoiceId = InvoiceCTDetail.InvoiceCOId) as CusXOId,(SELECT InvoiceCT.InvoiceNote FROM InvoiceCT WHERE InvoiceCT.InvoiceId = InvoiceCTDetail.InvoiceId) AS Description,'' as CusXOId ,(0-InvoiceCTDetail.InvoiceCTDetailQuantity) AS StockCheckBookQuantity FROM InvoiceCTDetail WHERE ProductId = '"+productId+"' AND InvoiceId IN (SELECT InvoiceId FROM InvoiceCT WHERE (InvoiceDate BETWEEN '"+startDate.ToString("yyyy-MM-dd")+"' AND '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"') OR ('"+startDate.ToString("yyyy-MM-dd")+"' is null and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"' is null ))",
                            "SELECT '生产退料' as InvoiceType,ProduceMaterialExitId as InvoiceNO,(SELECT	ProduceMaterialExit.ProduceExitMaterialDate FROM ProduceMaterialExit WHERE ProduceMaterialExit.ProduceMaterialExitId=ProduceMaterialExitDetail.ProduceMaterialExitId) AS InvoiceDate,ProduceMaterialExitDetail.ProduceQuantity AS InvoiceQuantity,ProduceMaterialExitDetail.ProductUnit AS InvoiceUnit,(SELECT DepotName FROM Depot WHERE Depot.DepotId=(SELECT ProduceMaterialExit.DepotId FROM ProduceMaterialExit WHERE ProduceMaterialExit.ProduceMaterialExitId=ProduceMaterialExitDetail.ProduceMaterialExitId)) AS DepotName,(SELECT Id FROM DepotPosition WHERE DepotPosition.DepotPositionId=ProduceMaterialExitDetail.DepotPositionId ) AS PositionName,(SELECT Product.StocksQuantity FROM Product WHERE Product.ProductId=ProduceMaterialExitDetail.ProductId) AS Stock1,(SELECT Workhousename FROM WorkHouse WHERE WorkHouse.WorkHouseId = (SELECT ProduceMaterialExit.WorkHouseId FROM ProduceMaterialExit WHERE ProduceMaterialExit.ProduceMaterialExitId=ProduceMaterialExitDetail.ProduceMaterialExitId)) AS WorkHouseName,'' AS InvioiceId,(SELECT ProduceMaterialExit.ProduceExitMaterialDesc FROM ProduceMaterialExit WHERE ProduceMaterialExit.ProduceMaterialExitId=ProduceMaterialExitDetail.ProduceMaterialExitId) AS Description,(SELECT InvoiceCusId FROM PronoteHeader WHERE PronoteHeader.PronoteHeaderID = (SELECT TOP 1 ProduceMaterialExit.PronoteHeaderID FROM ProduceMaterialExit WHERE ProduceMaterialExit.ProduceMaterialExitId = ProduceMaterialExitDetail.ProduceMaterialExitId)) as CusXOId,ProduceMaterialExitDetail.ProduceQuantity as StockCheckBookQuantity FROM ProduceMaterialExitDetail WHERE ProductId='"+productId+"' AND ProduceMaterialExitId IN (SELECT ProduceMaterialExit.ProduceMaterialExitId FROM ProduceMaterialExit WHERE (ProduceExitMaterialDate BETWEEN '"+startDate.ToString("yyyy-MM-dd")+"' AND '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"') OR('"+startDate.ToString("yyyy-MM-dd")+"' IS NULL AND '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"' IS NULL))"
                           };
            for (int m = 0; m < sqls.Length; m++)
            {
                #region
                Model.StockSeach stockSeach;
                using (SqlDataReader dataReader = SQLDB.SqlHelper.ExecuteReader(SQLDB.SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sqls[m], null))
                {
                    while (dataReader.Read())
                    {
                        stockSeach = new Model.StockSeach();
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            foreach (var item in stockSeach.GetType().GetProperties())
                            {
                                string fieldName = item.Name;//属性名
                                //判断当前迭代出的属性名称是否和迭代出的dataReader的列名称一致
                                if (item.Name.ToLower().Equals(dataReader.GetName(i).ToLower()))
                                {
                                    //从DataReader中读取值
                                    object _value = dataReader[fieldName];
                                    //将当前dataReader的单列值赋予相匹配的属性,否则赋予一个null值.
                                    if (_value != null && _value != DBNull.Value)
                                        item.SetValue(stockSeach, _value, null);
                                    else
                                        item.SetValue(stockSeach, null, null);
                                }
                            }
                        }
                        list.Add(stockSeach);

                    }
                }
                #endregion
            }
            return list;

        }

        public DataTable SelectDepotDistributedByproduct(string productid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT StockQuantity1,");
            sb.Append("(SELECT Depot.DepotName FROM Depot WHERE Depot.DepotId = Stock.DepotId) AS Depotname,");
            sb.Append("(SELECT Id FROM DepotPosition WHERE DepotPosition.DepotPositionId = Stock.DepotPositionId) AS Depot_IdasName");
            sb.Append(" FROM Stock WHERE ProductId = '" + productid + "' AND Stock.StockQuantity1 >0  ORDER BY Depotname");

            SqlDataAdapter sda = new SqlDataAdapter(sb.ToString(), sqlmapper.DataSource.ConnectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public double SelectStockQuantity0(string productid)
        {
            return sqlmapper.QueryForObject<double>("Stock.SelectStockQuantity0", productid);
        }

        public DataTable SelectProductNoDepotout(double years)
        {
            double Years = 365 * years;
            string sql = "SELECT p.productid,p.ProductName,p.Id,sum(s.StockQuantity1) AS StocksQuantity FROM product p LEFT JOIN Stock s ON s.ProductId = p.ProductId WHERE p.ProductId in(SELECT a.productid FROM (SELECT productid FROM stock  GROUP BY ProductId) a WHERE not EXISTS (SELECT 1 FROM DepotOutDetail WHERE ProductId=a.productid AND DepotOutId IN (SELECT DepotOutId FROM DepotOut WHERE datediff(d,DepotOutDate,getdate())<" + Years + ")))GROUP by p.productid,p.ProductName,p.Id ";
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(sql, sqlmapper.DataSource.ConnectionString);
            sda.Fill(dt);
            return dt;
        }

        public string GetLastDepotoutDate(string productid)
        {
            return sqlmapper.QueryForObject<string>("Stock.GetLastDepotoutDate", productid);
        }

        public double GetQuantityByStockAndProduct(string ProductId)
        {
            return sqlmapper.QueryForObject<double>("Stock.GetQuantityByStockAndProduct", ProductId);
        }

        public IList<Model.StockSeach> SelectJiShi(string productId, DateTime startDate, DateTime endDate)
        {
            //0出 1 入 2调拨 3盘点
            IList<Model.StockSeach> list = new List<Model.StockSeach>();
            string[] sqls ={"SELECT 0 as InvoiceTypeIndex, '出倉單' as InvoiceType,DepotOutId   as InvoiceNO,(select inserttime  FROM DepotOut where DepotOut.DepotOutId = DepotOutDetail.DepotOutId) as InsertTime,(select DepotOutDate  FROM DepotOut where DepotOut.DepotOutId = DepotOutDetail.DepotOutId) as InvoiceDate ,DepotOutDetail.DepotOutDetailQuantity AS InvoiceQuantity, DepotOutDetail.DepotPositionId  AS PositionName  FROM DepotOutDetail WHERE ProductId='"+productId+"' and DepotOutId in (select DepotOutId from DepotOut where (DepotOutDate between '"+startDate.ToString("yyyy-MM-dd")+"' and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"') or ('"+startDate.ToString("yyyy-MM-dd")+"' is null and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"' is null))",
                            "SELECT 1 as InvoiceTypeIndex,'入倉單' as InvoiceType,DepotInId as InvoiceNO,(select InsertTime  FROM depotIn where depotIn.DepotInId = DepotInDetail.DepotInId) as InsertTime ,(select DepotInDate  FROM depotIn where depotIn.DepotInId = DepotInDetail.DepotInId) as InvoiceDate ,DepotInDetail.DepotInQuantity AS InvoiceQuantity,DepotPositionId PositionName FROM DepotInDetail WHERE ProductId='"+productId+"' and DepotInId in (select DepotInId from DepotIn where (DepotInDate between '"+startDate.ToString("yyyy-MM-dd")+"' and '"+endDate.ToString("yyyy-MM-dd HH:mm:dd")+"') or ('"+startDate.ToString("yyyy-MM-dd")+"' is null and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"' is null )) ",
                            "SELECT 3 as InvoiceTypeIndex,'盤點核准單' as InvoiceType,StockCheckId as InvoiceNO,(select InsertTime  FROM StockCheck where StockCheck.StockCheckId = StockCheckDetail.StockCheckId) as InsertTime ,(select StockCheckDate  FROM StockCheck where StockCheck.StockCheckId = StockCheckDetail.StockCheckId) as InvoiceDate ,StockCheckDetail.StockCheckQuantity AS InvoiceQuantity,DepotPositionId AS PositionName,(StockCheckBookQuantity-StockCheckQuantity) as StockCheckBookQuantity FROM StockCheckDetail WHERE ProductId='"+productId+"' and StockCheckId in (select StockCheckId from StockCheck where (StockCheckDate between '"+startDate.ToString("yyyy-MM-dd")+"' and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"') or ('"+startDate.ToString("yyyy-MM-dd")+"' is null and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"' is null ))",
                            //"SELECT 2 as InvoiceTypeIndex,'庫存調撥單' as InvoiceType,InvoiceId as InvoiceNO,(select InsertTime  FROM InvoicePT where InvoicePT.InvoiceId = InvoicePTdetail.InvoiceId) as InsertTime ,(select InvoiceDate  FROM InvoicePT where InvoicePT.InvoiceId = InvoicePTdetail.InvoiceId) as InvoiceDate ,InvoicePTdetail.InvoicePTDetailQuantity AS InvoiceQuantity,DepotPositionInId AS PositionName,DepotPositionId AS OutPositionName FROM InvoicePTdetail WHERE ProductId='"+productId+"' and InvoiceId in (select InvoiceId from InvoicePT where (InvoiceDate between '"+startDate.ToString("yyyy-MM-dd")+"' and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"') or ('"+startDate.ToString("yyyy-MM-dd")+"' is null and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"' is null ))",
                            "SELECT 1 as InvoiceTypeIndex,'生產入庫單' as InvoiceType,ProduceInDepotId as InvoiceNO,(select InsertTime  FROM ProduceInDepot where ProduceInDepot.ProduceInDepotId = ProduceInDepotDetail.ProduceInDepotId) as InsertTime ,(select ProduceInDepotDate  FROM ProduceInDepot where ProduceInDepot.ProduceInDepotId = ProduceInDepotDetail.ProduceInDepotId) as InvoiceDate ,ProduceInDepotDetail.ProduceQuantity AS InvoiceQuantity,DepotPositionId AS PositionName FROM ProduceInDepotDetail WHERE ProduceQuantity <> 0 and  ProductId='"+productId+"' and ProduceInDepotId in (select ProduceInDepotId from ProduceInDepot where (ProduceInDepotDate between '"+startDate.ToString("yyyy-MM-dd")+"' and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"') or ('"+startDate.ToString("yyyy-MM-dd")+"' is null and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"' is null )) ",

                            "SELECT 1 as InvoiceTypeIndex,'委外入庫單' as InvoiceType,ProduceOtherInDepotDetail.ProduceOtherInDepotId as InvoiceNO,(SELECT ProduceOtherInDepot.InsertTime FROM ProduceOtherInDepot WHERE ProduceOtherInDepot.ProduceOtherInDepotId = ProduceOtherInDepotDetail.ProduceOtherInDepotId) AS InsertTime,(SELECT ProduceOtherInDepot.ProduceOtherInDepotDate FROM ProduceOtherInDepot WHERE ProduceOtherInDepot.ProduceOtherInDepotId = ProduceOtherInDepotDetail.ProduceOtherInDepotId) AS InvoiceDate,ProduceOtherInDepotDetail.ProduceInDepotQuantity AS InvoiceQuantity,DepotPositionId AS PositionName FROM ProduceOtherInDepotDetail WHERE ProductId='"+productId+"' AND ProduceOtherInDepotId IN (SELECT ProduceOtherInDepotId FROM ProduceOtherInDepot WHERE (ProduceOtherInDepotDate BETWEEN '"+startDate.ToString("yyyy-MM-dd")+"' AND '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"') OR ('"+startDate.ToString("yyyy-MM-dd")+"' is null and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"' is null ))",
                            "SELECT 0 as InvoiceTypeIndex,'銷售出貨單' as InvoiceType,InvoiceId as InvoiceNO,(SELECT InvoiceXS.InsertTime FROM InvoiceXS WHERE InvoiceXS.InvoiceId = InvoiceXSDetail.InvoiceId) AS InsertTime,(SELECT InvoiceXS.InvoiceDate FROM InvoiceXS WHERE InvoiceXS.InvoiceId = InvoiceXSDetail.InvoiceId) AS InvoiceDate,InvoiceXSDetailQuantity AS InvoiceQuantity,DepotPositionId AS PositionName FROM InvoiceXSDetail WHERE ProductId = '"+productId+"' AND InvoiceId IN (SELECT InvoiceXS.InvoiceId FROM InvoiceXS WHERE (InvoiceDate BETWEEN '"+startDate.ToString("yyyy-MM-dd")+"' AND '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"') OR ('"+startDate.ToString("yyyy-MM-dd")+"' is null and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"' is null ))",
                            "SELECT 1 as InvoiceTypeIndex,'採購入庫單' as InvoiceType,InvoiceId as InvoiceNO,(SELECT InvoiceCG.InsertTime FROM InvoiceCG WHERE invoicecg.InvoiceId = InvoiceCGDetail.InvoiceId) AS InsertTime,(SELECT InvoiceCG.InvoiceDate FROM InvoiceCG WHERE invoicecg.InvoiceId = InvoiceCGDetail.InvoiceId) AS InvoiceDate,InvoiceCGDetail.InvoiceCGDetaiInQuantity AS InvoiceQuantity,DepotPositionId AS PositionName FROM InvoiceCGDetail WHERE ProductId = '"+productId+"' AND InvoiceId IN (SELECT InvoiceCG.InvoiceId FROM InvoiceCG WHERE (InvoiceDate BETWEEN '"+startDate.ToString("yyyy-MM-dd")+"' AND '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"') OR ('"+startDate.ToString("yyyy-MM-dd")+"' is null and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"' is null ))",
                            "SELECT 1 as InvoiceTypeIndex,'銷售退貨' as InvoiceType,InvoiceId as InvoiceNO,(SELECT InvoiceXT.InsertTime FROM InvoiceXT WHERE InvoiceXT.InvoiceId = InvoiceXTDetail.InvoiceId) AS InsertTime,(SELECT InvoiceXT.InvoiceDate FROM InvoiceXT WHERE InvoiceXT.InvoiceId = InvoiceXTDetail.InvoiceId) AS InvoiceDate, InvoiceXTDetail.InvoiceXTDetailQuantity AS InvoiceQuantity, InvoiceXTDetail.DepotPositionId AS PositionName FROM InvoiceXTDetail WHERE ProductId = '"+productId+"' AND InvoiceId IN (SELECT InvoiceId FROM InvoiceXT WHERE (InvoiceDate BETWEEN '"+startDate.ToString("yyyy-MM-dd")+"' AND '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"') OR ('"+startDate.ToString("yyyy-MM-dd")+"' is null and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"' is null ))",
                            "SELECT 0 as InvoiceTypeIndex,'採購退貨' as InvoiceType,InvoiceId as InvoiceNO,(SELECT InvoiceCT.InsertTime FROM InvoiceCT WHERE InvoiceCT.InvoiceId = InvoiceCTDetail.InvoiceId) AS InsertTime, (SELECT InvoiceCT.InvoiceDate FROM InvoiceCT WHERE InvoiceCT.InvoiceId = InvoiceCTDetail.InvoiceId) AS InvoiceDate, InvoiceCTDetail.InvoiceCTDetailQuantity AS InvoiceQuantity, InvoiceCTDetail.DepotPositionId AS PositionName  FROM InvoiceCTDetail WHERE ProductId = '"+productId+"' AND InvoiceId IN (SELECT InvoiceId FROM InvoiceCT WHERE (InvoiceDate BETWEEN '"+startDate.ToString("yyyy-MM-dd")+"' AND '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"') OR ('"+startDate.ToString("yyyy-MM-dd")+"' is null and '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"' is null ))",
                            "SELECT 1 as InvoiceTypeIndex,'生产退料' as InvoiceType,ProduceMaterialExitId as InvoiceNO,(SELECT	ProduceMaterialExit.InsertTime FROM ProduceMaterialExit WHERE ProduceMaterialExit.ProduceMaterialExitId=ProduceMaterialExitDetail.ProduceMaterialExitId) AS InsertTime,(SELECT	ProduceMaterialExit.ProduceExitMaterialDate FROM ProduceMaterialExit WHERE ProduceMaterialExit.ProduceMaterialExitId=ProduceMaterialExitDetail.ProduceMaterialExitId) AS InvoiceDate,ProduceMaterialExitDetail.ProduceQuantity AS InvoiceQuantity,ProduceMaterialExitDetail.DepotPositionId  AS PositionName FROM ProduceMaterialExitDetail WHERE ProductId='"+productId+"' AND ProduceMaterialExitId IN (SELECT ProduceMaterialExit.ProduceMaterialExitId FROM ProduceMaterialExit WHERE (ProduceExitMaterialDate BETWEEN '"+startDate.ToString("yyyy-MM-dd")+"' AND '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"') OR('"+startDate.ToString("yyyy-MM-dd")+"' IS NULL AND '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+"' IS NULL))"
                           };
            for (int m = 0; m < sqls.Length; m++)
            {
                #region
                Model.StockSeach stockSeach;
                using (SqlDataReader dataReader = SQLDB.SqlHelper.ExecuteReader(SQLDB.SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sqls[m], null))
                {
                    while (dataReader.Read())
                    {
                        stockSeach = new Model.StockSeach();
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            foreach (var item in stockSeach.GetType().GetProperties())
                            {
                                string fieldName = item.Name;//属性名
                                //判断当前迭代出的属性名称是否和迭代出的dataReader的列名称一致
                                if (item.Name.ToLower().Equals(dataReader.GetName(i).ToLower()))
                                {
                                    //从DataReader中读取值
                                    object _value = dataReader[fieldName];
                                    //将当前dataReader的单列值赋予相匹配的属性,否则赋予一个null值.
                                    if (_value != null && _value != DBNull.Value)
                                        item.SetValue(stockSeach, _value, null);
                                    else
                                        item.SetValue(stockSeach, null, null);
                                }
                            }
                        }
                        list.Add(stockSeach);

                    }
                }
                #endregion
            }
            return list;

        }

        public double SelectJiShidistributioned(string productId, DateTime startDate, DateTime endDate)
        {
            Hashtable ht = new Hashtable();
            ht.Add("ProductId", productId);
            ht.Add("StartDate", startDate);
            ht.Add("EndDate", endDate);
            return sqlmapper.QueryForObject<double>("Stock.SelectJiShidistributioned", ht);
        }
    }
}