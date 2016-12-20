using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Book.UI.Settings.BasicData.Employees;
using DevExpress.XtraEditors;
using Book.UI.Invoices;

namespace Book.UI.produceManager.PCOtherCheck
{
    public partial class EditForm : Book.UI.Settings.BasicData.BaseEditForm
    {

        private Model.PCOtherCheck _PCOtherCheck = null;
        private BL.PCOtherCheckManager _PCOtherCM = new Book.BL.PCOtherCheckManager();

        private BL.PCOtherCheckDetailManager _PCOCDM = new Book.BL.PCOtherCheckDetailManager();
        private BL.ProduceOtherCompactDetailManager OtherCompactDetailManager = new Book.BL.ProduceOtherCompactDetailManager();

        public EditForm()
        {
            InitializeComponent();

            this.requireValueExceptions.Add(Model.PCOtherCheck.PRO_PCOtherCheckId, new AA(Properties.Resources.PCOtherCheckID, this.textPCOtherCheckId));
            this.requireValueExceptions.Add(Model.PCOtherCheck.PRO_PCOtherCheckDate, new AA(Properties.Resources.DateIsNull, this.dateEdit_PCOtherCheckDate));
            this.requireValueExceptions.Add(Model.PCOtherCheck.PRO_Employee0Id, new AA(Properties.Resources.EmployeeIdNotNull, this.Ncc_Employee0));
            this.invalidValueExceptions.Add(Model.PCOtherCheckDetail.PRO_PCOtherCheckDetailQuantity, new AA("合格數量不能大於進場數量！", this.gridControl1));
            this.action = "view";
            this.Ncc_Employee0.Choose = new ChooseEmployee(EmployeeParameters.ALL);
            this.Ncc_Employee1.Choose = new ChooseEmployee();
            this.Ncc_Supplier.Choose = new Book.UI.Settings.BasicData.Supplier.ChooseSupplier();
            this.newChooseContorlAuditEmp.Choose = new ChooseEmployee();
        }

        int LastFlag = 0;
        public EditForm(string invoiceId)
            : this()
        {
            this._PCOtherCheck = this._PCOtherCM.GetDetails(invoiceId);
            if (this._PCOtherCheck == null)
                throw new ArithmeticException("invoiceid");
            this.action = "view";
            if (this.action == "view")
                LastFlag = 1;
        }

        public EditForm(Model.PCOtherCheck mPCOtherCheck)
            : this()
        {
            if (mPCOtherCheck == null)
                throw new ArithmeticException("invoiceid");
            this._PCOtherCheck = mPCOtherCheck;
            this.action = "view";
            if (this.action == "view")
                LastFlag = 1;
        }

        public EditForm(Model.PCOtherCheck mPCOtherCheck, string action)
            : this()
        {
            this._PCOtherCheck = mPCOtherCheck;
            this.action = action;
            if (this.action == "view")
                LastFlag = 1;
        }

        public override void Refresh()
        {
            if (this._PCOtherCheck == null)
            {
                this.AddNew();
                this.action = "insert";
            }
            else
            {
                if (this.action == "view")
                {
                    this._PCOtherCheck = this._PCOtherCM.GetDetails(_PCOtherCheck.PCOtherCheckId);
                }
            }

            this.textPCOtherCheckId.Text = this._PCOtherCheck.PCOtherCheckId;
            if (global::Helper.DateTimeParse.DateTimeEquls(this._PCOtherCheck.PCOtherCheckDate, global::Helper.DateTimeParse.NullDate))
            {
                this.dateEdit_PCOtherCheckDate.EditValue = null;
            }
            else
            {
                this.dateEdit_PCOtherCheckDate.EditValue = this._PCOtherCheck.PCOtherCheckDate;
            }
            //this.textInvoiceCusXOId.Text = this._PCOtherCheck.InvoiceCusXOId;
            this.textPCOtherCheckDesc.Text = this._PCOtherCheck.PCOtherCheckDesc;
            this.Ncc_Employee0.EditValue = this._PCOtherCheck.Employee0;
            this.Ncc_Employee1.EditValue = this._PCOtherCheck.Employee1;
            this.Ncc_Supplier.EditValue = this._PCOtherCheck.Supplier;

            this.newChooseContorlAuditEmp.EditValue = this._PCOtherCheck.AuditEmp;
            this.txt_AuditState.EditValue = this.GetAuditName(this._PCOtherCheck.AuditState);

            #region LookUpEdit
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("id", typeof(string));
            DataColumn dc1 = new DataColumn("name", typeof(string));
            dt.Columns.Add(dc);
            dt.Columns.Add(dc1);
            DataRow dr;
            dr = dt.NewRow();
            dr[0] = "-1";
            dr[1] = string.Empty;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "0";
            dr[1] = "√";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "1";
            dr[1] = "△";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "2";
            dr[1] = "X";
            dt.Rows.Add(dr);

            for (int i = 0; i < this.gridView1.Columns.Count - 1; i++)
            {
                if (this.gridView1.Columns[i].ColumnEdit is DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)
                {
                    ((DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)this.gridView1.Columns[i].ColumnEdit).DataSource = dt;
                    ((DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)this.gridView1.Columns[i].ColumnEdit).Columns.Clear();
                    ((DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)this.gridView1.Columns[i].ColumnEdit).Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                    new DevExpress.XtraEditors.Controls.LookUpColumnInfo("name",25, "标识"),
                     });
                    ((DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)this.gridView1.Columns[i].ColumnEdit).DisplayMember = "name";
                    ((DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)this.gridView1.Columns[i].ColumnEdit).ValueMember = "id";
                }
            }
            #endregion

            this.bindingSourceDetails.DataSource = this._PCOtherCheck.Detail;

            base.Refresh();

            switch (this.action)
            {
                case "insert":
                    this.gridView1.OptionsBehavior.Editable = true;
                    break;
                case "update":
                    this.gridView1.OptionsBehavior.Editable = true;
                    break;
                case "view":
                    this.gridView1.OptionsBehavior.Editable = false;
                    break;
            }

            this.textPCOtherCheckId.Properties.ReadOnly = true;

            //if (this._PCOtherCheck.FromPCType < 0)
            //{
            //    this.lcDanJuId.Text = "委外單編號:";
            //}
            //else
            //{
            //    this.lcDanJuId.Text = "採購單編號:";
            //}
        }

        protected override void Save()
        {
            this._PCOtherCheck.PCOtherCheckId = this.textPCOtherCheckId.Text;
            this._PCOtherCheck.PCOtherCheckDesc = this.textPCOtherCheckDesc.Text;
            this._PCOtherCheck.Supplier = (this.Ncc_Supplier.EditValue as Model.Supplier);
            if (this._PCOtherCheck.Supplier != null)
            {
                this._PCOtherCheck.SupplierId = this._PCOtherCheck.Supplier.SupplierId;
            }
            //this._PCOtherCheck.InvoiceCusXOId = this.textInvoiceCusXOId.Text;
            this._PCOtherCheck.Employee0 = (this.Ncc_Employee0.EditValue as Model.Employee);
            if (this._PCOtherCheck.Employee0 != null)
            {
                this._PCOtherCheck.Employee0Id = this._PCOtherCheck.Employee0.EmployeeId;
            }
            this._PCOtherCheck.Employee1 = (this.Ncc_Employee1.EditValue as Model.Employee);
            if (this._PCOtherCheck.Employee1 != null)
            {
                this._PCOtherCheck.Employee1Id = this._PCOtherCheck.Employee1.EmployeeId;
            }
            this._PCOtherCheck.PCOtherCheckDate = this.dateEdit_PCOtherCheckDate.DateTime;
            if (!this.gridView1.PostEditor() || !this.gridView1.UpdateCurrentRow())
                return;
            switch (this.action)
            {
                case "insert":
                    this._PCOtherCM.Insert(this._PCOtherCheck);
                    break;

                case "update":
                    this._PCOtherCM.Update(this._PCOtherCheck);
                    break;
            }
        }

        protected override void Delete()
        {
            if (this._PCOtherCM == null)
                return;
            if (MessageBox.Show(Properties.Resources.ConfirmToDelete, this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this._PCOtherCM.Delete(this._PCOtherCheck);
            this._PCOtherCheck = this._PCOtherCM.GetNext(this._PCOtherCheck);
            if (this._PCOtherCheck == null)
            {
                this._PCOtherCheck = this._PCOtherCM.GetLast();
            }
        }

        protected override void MoveNext()
        {
            Model.PCOtherCheck mPCOC = this._PCOtherCM.GetNext(this._PCOtherCheck);
            if (mPCOC == null)
                throw new InvalidOperationException(Properties.Resources.ErrorNoMoreRows);
            this._PCOtherCheck = this._PCOtherCM.Get(mPCOC.PCOtherCheckId);
        }

        protected override void MovePrev()
        {
            Model.PCOtherCheck mPCOC = this._PCOtherCM.GetPrev(this._PCOtherCheck);
            if (mPCOC == null)
                throw new InvalidOperationException(Properties.Resources.ErrorNoMoreRows);
            this._PCOtherCheck = this._PCOtherCM.Get(mPCOC.PCOtherCheckId);
        }

        protected override void MoveFirst()
        {
            this._PCOtherCheck = this._PCOtherCM.Get(this._PCOtherCM.GetFirst() == null ? "" : this._PCOtherCM.GetFirst().PCOtherCheckId);
        }

        protected override void MoveLast()
        {
            if (this.LastFlag == 1)
            {
                this.LastFlag = 0;
                return;
            }
            this._PCOtherCheck = this._PCOtherCM.Get(this._PCOtherCM.GetLast() == null ? "" : this._PCOtherCM.GetLast().PCOtherCheckId);
        }

        protected override bool HasRows()
        {
            return this._PCOtherCM.HasRows();
        }

        protected override bool HasRowsNext()
        {
            return this._PCOtherCM.HasRowsAfter(this._PCOtherCheck);
        }

        protected override bool HasRowsPrev()
        {
            return this._PCOtherCM.HasRowsBefore(this._PCOtherCheck);
        }

        protected override void AddNew()
        {
            this._PCOtherCheck = new Model.PCOtherCheck();
            this._PCOtherCheck.PCOtherCheckDate = DateTime.Now;
            this._PCOtherCheck.PCOtherCheckId = this._PCOtherCM.GetId();
            //this._PCOtherCheck.Employee0 = BL.V.ActiveOperator.Employee;
            this._PCOtherCheck.FromPCType = -1;
            this._PCOtherCheck.Detail = new List<Model.PCOtherCheckDetail>();
            this._PCOtherCheck.Employee0 = BL.V.ActiveOperator.Employee;
        }

        protected override DevExpress.XtraReports.UI.XtraReport GetReport()
        {
            return new Ro(this._PCOtherCheck);
        }

        private void barBtn_Search_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ListForm lf = new ListForm();
            if (lf.ShowDialog(this) == DialogResult.OK)
            {
                this._PCOtherCheck = lf.SelectItem as Model.PCOtherCheck;
                this.action = "view";
                this.Refresh();
            }
        }

        //删除行
        private void btn_del_Click(object sender, EventArgs e)
        {
            if (this.bindingSourceDetails.Current != null)
            {
                this._PCOtherCheck.Detail.Remove(this.bindingSourceDetails.Current as Model.PCOtherCheckDetail);
                this.gridControl1.RefreshDataSource();
            }
        }

        #region @添加行
        //private void AddDataRows()
        //{
        //    Model.PCOtherCheckDetail pcocDetail = new Book.Model.PCOtherCheckDetail();
        //    pcocDetail.PCOtherCheckDetailId = Guid.NewGuid().ToString();
        //    pcocDetail.PCOtherCheckId = this._PCOtherCheck.PCOtherCheckId;
        //    this._PCOtherCheck.Detail.Add(pcocDetail);

        //    this.bindingSourceDetails.Position = this.bindingSourceDetails.IndexOf(pcocDetail);
        //}
        #endregion

        //选择采购单据    2016-1-6 将数据来源从采购入库单改为采购单
        private void btnSelectCaiGou_Click(object sender, EventArgs e)
        {
            #region 原版 采购入库单
            //Book.UI.Invoices.CG.SearchCGDetail cgform = new Book.UI.Invoices.CG.SearchCGDetail();
            //if (cgform.ShowDialog() == DialogResult.OK)
            //{
            //    if (cgform.selectItems.Count > 0)
            //    {
            //        BL.InvoiceCOManager mCOM = new Book.BL.InvoiceCOManager();
            //        //Model.InvoiceCO co = cgform.Invoice;
            //        //清空数据
            //        if (this._PCOtherCheck.FromPCType < 0)
            //        {
            //            this._PCOtherCheck.Detail.Clear();
            //        }
            //        this._PCOtherCheck.FromPCType = 1;

            //        this.Ncc_Supplier.EditValue = cgform.selectItems[0].Invoice == null ? null : cgform.selectItems[0].Invoice.Supplier;//厂商
            //        Model.InvoiceCO co = new Book.Model.InvoiceCO();
            //        foreach (Model.InvoiceCGDetail item in cgform.selectItems)
            //        {
            //            Model.PCOtherCheckDetail detail = new Model.PCOtherCheckDetail();       //详细
            //            detail.PCOtherCheckDetailId = Guid.NewGuid().ToString();                //详细本身编号
            //            detail.PCOtherCheckId = this._PCOtherCheck.PCOtherCheckId;              //头编号
            //            detail.FromInvoiceDetailID = item.InvoiceCGDetailId;                    //来源详细本身编号
            //            detail.FromInvoiceID = item.InvoiceId;                                  //来源详细头编号
            //            detail.ProceduresId = null;                                             //工序编号
            //            detail.Procedures = null;                                               //加工
            //            detail.ProductId = item.ProductId;                                      //商品编号
            //            detail.Product = item.Product;                                          //品名
            //            detail.PCOtherCheckDetailDesc = item.Product == null ? "" : item.Product.ProductDescription;//说明
            //            detail.PCOtherCheckDetailQuantity = 0;                                  //数量
            //            detail.ProductUnit = detail.Product.ProduceUnit == null ? null : detail.Product.ProduceUnit.CnName;                        //单位

            //            co = mCOM.Get(item.InvoiceCOId);
            //            if (co == null)
            //            {
            //                detail.PerspectiveRate = "";
            //                detail.DeliveryDate = null;
            //            }
            //            else
            //            {
            //                try
            //                {
            //                    detail.PerspectiveRate = co.Customer == null ? "" : mCOM.Get(cgform.selectItems[0].InvoiceCOId).Customer.CheckedStandard;//透视率
            //                }
            //                catch
            //                {
            //                    detail.PerspectiveRate = "";
            //                }
            //                detail.DeliveryDate = co.InvoiceYjrq;//交期
            //            }

            //            detail.InQuantity = item.InvoiceCGDetailQuantity;                       //进厂数量
            //            detail.OutQuantity = 0;                                                 //出厂数量
            //            detail.Determinant = "";                                                //判定
            //            detail.PCOtherCheckDetailFromPC = "1";                                  //来源于 采购入库订单

            //            //客户订单编号
            //            detail.InvoiceCusXOId = co == null ? "" : co.InvoiceCustomXOId;
            //            this._PCOtherCheck.Detail.Add(detail);
            //        }
            //        this.gridControl1.RefreshDataSource();
            //    }
            //}
            //cgform.Dispose();
            //GC.Collect();
            #endregion

            Invoices.CG.CGForm f = new Book.UI.Invoices.CG.CGForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                if (f.key != null && f.key.Count > 0)
                {
                    if (this._PCOtherCheck.FromPCType < 0)
                    {
                        this._PCOtherCheck.Detail.Clear();
                    }
                    this._PCOtherCheck.FromPCType = 1;

                    Model.InvoiceCO co = f.key[0].Invoice;
                    this.Ncc_Supplier.EditValue = co == null ? null : co.Supplier;

                    foreach (var item in f.key)
                    {
                        Model.PCOtherCheckDetail detail = new Model.PCOtherCheckDetail();
                        detail.PCOtherCheckDetailId = Guid.NewGuid().ToString();
                        detail.PCOtherCheckId = this._PCOtherCheck.PCOtherCheckId;
                        detail.FromInvoiceDetailID = item.InvoiceCODetailId;
                        detail.FromInvoiceID = item.InvoiceId;
                        detail.ProceduresId = null;
                        detail.Procedures = null;
                        detail.ProductId = item.ProductId;
                        detail.Product = item.Product;
                        if (item.Product != null)
                        {
                            detail.PCOtherCheckDetailDesc = item.Product == null ? "" : item.Product.ProductDescription;
                            detail.ProductUnit = item.Product.ProduceUnit == null ? null : item.Product.ProduceUnit.CnName;
                        }
                        detail.PCOtherCheckDetailQuantity = 0;                   //数量以后改为合格数量，进场数量即为检验数量
                        detail.InQuantity = item.OrderQuantity - Convert.ToDouble(item.HasCheckQuantity);
                        detail.InQuantity = detail.InQuantity < 0 ? 0 : detail.InQuantity;
                        detail.OutQuantity = 0;
                        detail.Determinant = "";
                        detail.PCOtherCheckDetailFromPC = "1";


                        if (co != null)
                        {
                            try
                            {
                                detail.PerspectiveRate = co.Customer == null ? "" : co.Customer.CheckedStandard;//透视率
                            }
                            catch
                            {
                                detail.PerspectiveRate = "";
                            }
                            detail.DeliveryDate = co.InvoiceYjrq;//交期
                            detail.InvoiceCusXOId = co.InvoiceCustomXOId;
                        }
                        else
                        {
                            detail.PerspectiveRate = "";
                            detail.DeliveryDate = null;
                            detail.InvoiceCusXOId = "";
                        }

                        this._PCOtherCheck.Detail.Add(detail);
                    }
                    this.gridControl1.RefreshDataSource();
                }
            }
            f.Dispose();
            GC.Collect();
        }

        //选择委外入库单据       2016-1-6 将数据来源从委外入库单改为委外加工单
        private void btnSelectWeiWai_Click(object sender, EventArgs e)
        {
            #region 原版委外入库单
            //ProduceOtherInDepot.ChooseProduceOtherInDepotForPCO f = new Book.UI.produceManager.ProduceOtherInDepot.ChooseProduceOtherInDepotForPCO();
            //if (f.ShowDialog(this) != DialogResult.OK) return;

            //if (f.SelectItems.Count > 0)
            //{
            //    //清空数据
            //    if (this._PCOtherCheck.FromPCType > 0)
            //    {
            //        this._PCOtherCheck.Detail.Clear();
            //    }
            //    this._PCOtherCheck.FromPCType = -1;
            //    //this.lcDanJuId.Text = "委外入库單編號:";
            //    //this.textInvoiceCusXOId.Text = f.SelectItems[0].ProduceOtherInDepot == null ? "" : f.SelectItems[0].ProduceOtherInDepot.InvoiceCusId;
            //    #region 对控件进行赋值
            //    //if (!string.IsNullOrEmpty(OtherCompact.MRSHeaderId))                    //客户订单编号
            //    //{
            //    //    Model.MRSHeader mrsHeader = new BL.MRSHeaderManager().Get(OtherCompact.MRSHeaderId);
            //    //    if (mrsHeader != null)
            //    //    {
            //    //        Model.MPSheader mPSheader = new BL.MPSheaderManager().Get(mrsHeader.MPSheaderId);
            //    //        if (mPSheader != null)
            //    //        {
            //    //            Model.InvoiceXO invoiceXo = new BL.InvoiceXOManager().Get(mPSheader.InvoiceXOId);
            //    //            this.textInvoiceCusXOId.Text = invoiceXo == null ? string.Empty : invoiceXo.CustomerInvoiceXOId;
            //    //        }
            //    //    }
            //    //}
            //    #endregion
            //    this.Ncc_Supplier.EditValue = f.SelectItems[0].ProduceOtherInDepot.Supplier; //厂商

            //    foreach (Model.ProduceOtherInDepotDetail item in f.SelectItems)
            //    {
            //        Model.PCOtherCheckDetail detail = new Model.PCOtherCheckDetail();       //详细
            //        detail.PCOtherCheckDetailId = Guid.NewGuid().ToString();                //详细本身编号
            //        detail.PCOtherCheckId = this._PCOtherCheck.PCOtherCheckId;              //头编号
            //        detail.FromInvoiceDetailID = item.ProduceOtherInDepotDetailId;          //来源详细本身编号
            //        detail.FromInvoiceID = item.ProduceOtherInDepotId;                      //来源详细头编号
            //        //detail.ProceduresId = item.ProceduresId;                              //工序编号
            //        //detail.Procedures = item.Procedures;                                  //加工
            //        detail.ProductId = item.ProductId;                                      //商品编号
            //        detail.Product = item.Product;                                          //品名
            //        detail.PCOtherCheckDetailDesc = item.Product.ProductDescription;        //说明
            //        detail.PCOtherCheckDetailQuantity = 0;                                  //数量
            //        detail.ProductUnit = detail.Product.ProduceUnit == null ? null : detail.Product.ProduceUnit.CnName;                        //单位
            //        detail.PerspectiveRate = item.Customer == null ? "" : item.Customer.CheckedStandard;//透视率
            //        detail.DeliveryDate = this.OtherCompactDetailManager.Get(item.ProduceOtherCompactDetailId) == null ? null : this.OtherCompactDetailManager.Get(item.ProduceOtherCompactDetailId).JiaoQi;//交期
            //        detail.InQuantity = item.ProduceQuantity;                               //进厂数量
            //        detail.OutQuantity = 0;                                                 //出厂数量
            //        detail.Determinant = "";                                                //判定
            //        detail.PCOtherCheckDetailFromPC = "0";                                  //来源于 委外入库单

            //        //客户订单编号
            //        detail.InvoiceCusXOId = item.InvoiceCusId;
            //        this._PCOtherCheck.Detail.Add(detail);
            //    }
            //    this.gridControl1.RefreshDataSource();
            //}
            //f.Dispose();
            //GC.Collect();
            #endregion

            ProduceOtherCompact.ChooseOutContract f = new Book.UI.produceManager.ProduceOtherCompact.ChooseOutContract();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                if (f.key != null && f.key.Count > 0)
                {
                    //清空数据
                    if (this._PCOtherCheck.FromPCType > 0)
                    {
                        this._PCOtherCheck.Detail.Clear();
                    }
                    this._PCOtherCheck.FromPCType = -1;
                    Model.ProduceOtherCompact poc = f.key[0].ProduceOtherCompact;
                    this.Ncc_Supplier.EditValue = poc == null ? null : poc.Supplier;
                    foreach (var item in f.key)
                    {
                        Model.PCOtherCheckDetail detail = new Book.Model.PCOtherCheckDetail();
                        detail.PCOtherCheckDetailId = Guid.NewGuid().ToString();
                        detail.PCOtherCheckId = this._PCOtherCheck.PCOtherCheckId;
                        detail.FromInvoiceDetailID = item.OtherCompactDetailId;
                        detail.FromInvoiceID = item.ProduceOtherCompactId;
                        detail.ProductId = item.ProductId;
                        detail.Product = item.Product;
                        detail.PCOtherCheckDetailDesc = item.Product.ProductDescription;
                        detail.ProductUnit = detail.Product.ProduceUnit == null ? null : detail.Product.ProduceUnit.CnName;

                        if (poc != null)
                        {
                            detail.PerspectiveRate = poc.Customer == null ? "" : poc.Customer.CheckedStandard;
                        }

                        detail.PCOtherCheckDetailQuantity = 0;
                        detail.DeliveryDate = item.JiaoQi;
                        detail.InQuantity = item.OtherCompactCount - Convert.ToDouble(item.HasCheckQuantity);
                        detail.InQuantity = detail.InQuantity < 0 ? 0 : detail.InQuantity;
                        detail.OutQuantity = 0;
                        detail.Determinant = "";
                        detail.PCOtherCheckDetailFromPC = "0";
                        detail.InvoiceCusXOId = item.InvoiceCusId;
                        this._PCOtherCheck.Detail.Add(detail);
                    }
                    this.gridControl1.RefreshDataSource();
                }
                f.Dispose();
                GC.Collect();
            }
        }

        private void textPCOtherCheckDesc_DoubleClick(object sender, EventArgs e)
        {
            PCParameterSet.ChooseParameter cp = new Book.UI.produceManager.PCParameterSet.ChooseParameter("BeiZhuShuoMing");
            if (cp.ShowDialog(this) != DialogResult.OK) return;
            if (cp.SelectedItem != null)
            {
                Model.Setting setParam = cp.SelectedItem as Model.Setting;
                this.textPCOtherCheckDesc.Text += setParam.SettingCurrentValue;
            }
            cp.Dispose();
            GC.Collect();
        }

        #region 审核

        protected override string AuditKeyId()
        {
            return Model.PCOtherCheck.PRO_PCOtherCheckId;
        }

        protected override int AuditState()
        {
            return this._PCOtherCheck.AuditState.HasValue ? this._PCOtherCheck.AuditState.Value : 0;
        }

        protected override string tableCode()
        {
            return "PCOtherCheck" + "," + this._PCOtherCheck.PCOtherCheckId;
        }

        #endregion
    }
}
