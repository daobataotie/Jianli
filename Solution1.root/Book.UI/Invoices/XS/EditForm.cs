using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Book.UI.Settings.BasicData.Employees;
using Book.Model;
using System.Linq;

namespace Book.UI.Invoices.XS
{
    public partial class EditForm : BaseEditForm
    {
        protected BL.InvoiceXSManager invoiceManager = new Book.BL.InvoiceXSManager();
        protected BL.InvoiceXSDetailManager invoiceDetailManager = new Book.BL.InvoiceXSDetailManager();
        protected BL.InvoiceXODetailManager invoicexoDetailManager = new Book.BL.InvoiceXODetailManager();
        protected BL.InvoiceXOManager invoiceXOManager = new Book.BL.InvoiceXOManager();
        protected BL.ProductManager productManager = new Book.BL.ProductManager();
        protected BL.CustomerManager customerManager = new Book.BL.CustomerManager();
        protected BL.DepotPositionManager depotPositionManager = new Book.BL.DepotPositionManager();
        protected BL.ProductUnitManager productUnitManager = new Book.BL.ProductUnitManager();
        protected BL.FreightedCompanyManager freightedCompanyManager = new BL.FreightedCompanyManager();
        protected BL.ConveyanceMethodManager cmethod = new Book.BL.ConveyanceMethodManager();
        protected BL.SupplierProductManager supplierproductmanager = new Book.BL.SupplierProductManager();
        private BL.CustomerProductPriceManager customerProductPriceManager = new Book.BL.CustomerProductPriceManager();
        private BL.ExchangeRateManager exchangeRateManager = new Book.BL.ExchangeRateManager();

        /// <summary>
        /// 被修改的单据
        /// </summary>
        public static Model.InvoiceXS invoice = null;
        private Model.InvoiceXO invoicexo;
        private Model.InvoiceXSDetail xsdetail;
        public static double sum = 0;
        public static Dictionary<string, Model.InvoiceXSDetail> dic = new Dictionary<string, InvoiceXSDetail>();

        /// <summary>
        ///0 免税 1 外加 -1 内含
        /// </summary>
        private int flag = 0;

        #region Constructors

        public EditForm()
        {
            InitializeComponent();

            this.gridControl1.Dock = DockStyle.Fill;

            this.colInvoiceXSDetailPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colInvoiceXSDetailPrice.DisplayFormat.FormatString = this.GetFormat(BL.V.SetDataFormat.XSDJXiao.Value);

            this.requireValueExceptions.Add("Id", new AA(Properties.Resources.RequireDataForId, this.textEditInvoiceId));
            this.requireValueExceptions.Add("Date", new AA(Properties.Resources.RequireDataOfInvoiceDate, this.dateEditInvoiceDate));
            this.requireValueExceptions.Add("Employee0", new AA(Properties.Resources.RequiredDataOfEmployee0, this.buttonEditEmployee));
            this.requireValueExceptions.Add("Depot", new AA(Properties.Resources.RequiredDataOfDepot, this.buttonEditDepot));
            this.requireValueExceptions.Add("Details", new AA(Properties.Resources.RequireDataForDetails, this.gridControl1));
            this.requireValueExceptions.Add("Company", new AA(Properties.Resources.RequireDataForCompany, this.buttonEditCompany));
            this.requireValueExceptions.Add(Model.InvoiceXSDetail.PRO_DepotPositionId, new AA(Properties.Resources.RequireChoosePosition, this.gridControl1));
            this.invalidValueExceptions.Add(Model.InvoiceXS.PROPERTY_INVOICEID, new AA(Properties.Resources.EntityExists, this.textEditInvoiceId));
            this.invalidValueExceptions.Add("XSQgtXOQ", new AA("出貨數量大於未出貨數量！", this.gridControl1));
            this.action = "view";

            this.buttonEditEmployee.Choose = new ChooseEmployee();
            this.buttonEditCompany.Choose = new Settings.BasicData.Customs.ChooseCustoms();
            this.buttonEditDepot.Choose = new ChooseDepot();
            this.newChooseXScustomer.Choose = new Settings.BasicData.Customs.ChooseCustoms();
            IList<Model.ConveyanceMethod> list = cmethod.Select();
            foreach (Model.ConveyanceMethod Method in list)
            {
                this.comboBoxConveyanceMethodId.Properties.Items.Add(Method);
            }
            this.EmpAudit.Choose = new ChooseEmployee();
        }
        private int LastFlag = 0;
        public EditForm(string invoiceid)
            : this()
        {
            invoice = this.invoiceManager.Get(invoiceid);
            invoice.Details = (this.invoiceManager.Get(invoiceid) as Model.InvoiceXS).Details;
            // this.invoicexo = this.invoiceXOManager.Get(invoice.InvoiceXOId);
            if (invoice == null)
                throw new ArgumentNullException();
            this.action = "view";
            if (this.action == "view")
                LastFlag = 1;
        }

        public EditForm(Model.InvoiceXS initInvoicexs)
            : this()
        {
            if (initInvoicexs == null)
                throw new ArgumentNullException();
            invoice = initInvoicexs;
            invoice.Details = initInvoicexs.Details;
            this.action = "view";
            if (this.action == "view")
                LastFlag = 1;
        }

        public EditForm(Model.InvoiceXO invoice1)
            : this()
        {
            this.invoicexo = this.invoiceXOManager.Get(invoice1.InvoiceId);
            this.action = "insert";
            if (this.action == "view")
                LastFlag = 1;
        }

        #endregion

        #region Choose Object

        private void buttonEditEmployee0_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ChooseEmployeeForm f = new ChooseEmployeeForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                (sender as ButtonEdit).EditValue = f.SelectedItem;
            }
        }

        #endregion

        #region Form Load

        private void EditForm_Load(object sender, EventArgs e)
        {
            //string sql = "SELECT productid,id,productname,IsCustomerProduct,CustomerProductName FROM product WHERE (IsProcee IS null OR IsProcee=0) ";
            //this.bindingSourceProduct.DataSource = this.productManager.DataReaderBind<Model.Product>(sql);
            this.bindingSourceCompany.DataSource = freightedCompanyManager.Select();
        }

        protected override string tableCode()
        {
            return "InvoiceXS";
        }

        protected override int AuditState()
        {
            return this.Invoice.AuditState.HasValue ? this.Invoice.AuditState.Value : 0;
        }

        protected override string getName()
        {
            string formName = this.GetType().FullName;
            formName = formName.Substring(formName.IndexOf('.') + 1).Substring(formName.Substring(formName.IndexOf('.') + 1).IndexOf('.') + 1);
            return formName;
        }

        #endregion

        #region simpleButton_Click

        //private void simpleButtonAppend_Click(object sender, EventArgs e)
        //{
        //    ChooseProductForm f = new ChooseProductForm();
        //    if (f.ShowDialog(this) == DialogResult.OK)
        //    {
        //        Model.InvoiceXSDetail detail = new Book.Model.InvoiceXSDetail();
        //        detail.InvoiceXSDetailId = Guid.NewGuid().ToString();
        //        detail.Invoice = invoice;
        //        detail.InvoiceXSDetailNote = "";
        //        detail.InvoiceXSDetailQuantity = 1;
        //        detail.Product = f.SelectedItem as Model.Product;
        //        detail.ProductId = (f.SelectedItem as Model.Product).ProductId;
        //        detail.InvoiceProductUnit = detail.Product.DepotUnit.CnName;
        //        detail.DepotPositionId = detail.Product.DepotPositionId;
        //        invoice.Details.Add(detail);
        //        this.gridControl1.RefreshDataSource();

        //        this.bindingSourceDetail.Position = this.bindingSourceDetail.IndexOf(detail);

        //        this.bindingSourceProduct.DataSource = this.productManager.Select();
        //    }
        //}

        //private void simpleButtonRemove_Click(object sender, EventArgs e)
        //{
        //    if (this.bindingSourceDetail.Current != null)
        //    {
        //        invoice.Details.Remove(this.bindingSourceDetail.Current as Book.Model.InvoiceXSDetail);

        //        if (invoice.Details.Count == 0)
        //        {
        //            Model.InvoiceXSDetail detail = new Model.InvoiceXSDetail();
        //            detail.InvoiceXSDetailId = Guid.NewGuid().ToString();
        //            //detail.InvoiceXSDetailDiscount = 0;
        //            //detail.InvoiceXSDetailDiscountRate = 0;
        //            //detail.InvoiceXSDetailMoney0 = 0;
        //            //detail.InvoiceXSDetailMoney1 = 0;
        //            detail.InvoiceXSDetailNote = "";
        //            //detail.InvoiceXSDetailPrice = 0;
        //            detail.InvoiceXSDetailQuantity = 0;
        //            //detail.InvoiceXSDetailTax = 0;
        //            //detail.InvoiceXSDetailTaxRate = 0;
        //            //detail.InvoiceXSDetailZS = false;
        //            detail.InvoiceProductUnit = "";
        //            detail.Product = new Book.Model.Product();
        //            invoice.Details.Add(detail);
        //            this.bindingSourceDetail.Position = this.bindingSourceDetail.IndexOf(detail);
        //        }
        //        this.gridControl1.RefreshDataSource();
        //    }
        //}

        #endregion

        protected override void Save(Helper.InvoiceStatus status)
        {
            if (!this.gridView1.PostEditor() || !this.gridView1.UpdateCurrentRow())
                return;

            Model.Depot depot = this.buttonEditDepot.EditValue as Model.Depot;
            IList<Model.DepotPosition> DepotPositionList = null;
            if (depot != null)
            {
                this.bindingSourceDepotPosition.DataSource = DepotPositionList = this.depotPositionManager.Select(depot);
            }
            //if (this.action != "view" && invoice.Details.Count > 0 && this.bindingSourceDepotPosition.DataSource != null && !(this.bindingSourceDepotPosition.DataSource as IList<Model.DepotPosition>).Any(d => d.DepotPositionId == invoice.Details[0].DepotPositionId))
            //    foreach (var item in invoice.Details)
            //    {
            //        item.DepotPositionId = null;
            //    }
            if (DepotPositionList != null)
            {
                foreach (var item in invoice.Details)
                {
                    if (!DepotPositionList.Any(d => d.DepotPositionId == item.DepotPositionId))
                    {
                        item.DepotPositionId = null;
                        item.DepotPosition = null;
                    }
                }
            }

            invoice.InvoiceStatus = (int)status;
            invoice.InvoiceId = this.textEditInvoiceId.Text;
            invoice.InvoiceDate = this.dateEditInvoiceDate.DateTime;
            invoice.Employee0 = this.buttonEditEmployee.EditValue as Model.Employee;
            invoice.Depot = this.buttonEditDepot.EditValue as Model.Depot;
            invoice.Customer = this.buttonEditCompany.EditValue as Model.Customer;
            if (invoice.Customer != null)
                invoice.CustomerId = invoice.Customer.CustomerId;
            invoice.XSCustomer = this.newChooseXScustomer.EditValue as Model.Customer;
            if (invoice.XSCustomer != null)
                invoice.XSCustomerId = invoice.XSCustomer.CustomerId;
            invoice.InvoiceNote = this.textEditNote.Text;
            invoice.TransportCompany = this.lookUpEditFreightCompany.Text;
            invoice.InvoiceLRTime = DateTime.Now;
            //invoice.CustomerInvoiceXOId = this.textEditCustomerInvoiceXOId.Text;
            if (this.comboBoxConveyanceMethodId.EditValue != null)
            {
                Model.ConveyanceMethod cm = this.comboBoxConveyanceMethodId.EditValue as Model.ConveyanceMethod;
                invoice.ConveyanceMethodId = cm == null ? null : cm.ConveyanceMethodId;
            }
            invoice.OtherChargeNote = this.textEditOtherChargeNote.Text;
            invoice.OtherChargeMoney = decimal.Parse(this.textEditOtherChargeMoneyset.Text);
            invoice.InvoiceTotal = decimal.Parse(this.calcEditInvoiceTotalset.Text);
            invoice.InvoiceTax = decimal.Parse(this.calcEditInvoiceTaxset.Text);
            invoice.InvoiceHeji = decimal.Parse(this.calcEditInvoiceHejiset.Text);
            invoice.InvoiceTaxrate = Convert.ToDouble(this.spinEditInvoiceTaxRate.Text);
            invoice.InvoiceAllowance = double.Parse(this.calcInvoiceAllowance.Text);
            invoice.TaxCaluType = this.comboBoxEditInvoiceKslb.SelectedIndex;
            this.Invoice.AuditState = this.saveAuditState;
            invoice.Special = this.checkEditSpecial.Checked;
            invoice.InvoiceTaibiTotal = this.spe_TaibiTotal.Value;
            if (this.date_DeclareDate.EditValue != null)
                invoice.DeclareDate = this.date_DeclareDate.DateTime;
            invoice.FapiaoFangshi = this.txt_FapiaoFangshi.Text;
            invoice.FapiaoLianshi = this.cob_FapiaoLianshi.Text;
            invoice.Currency = this.comboBoxEditCurrency.Text;

            switch (this.action)
            {
                case "insert":
                    this.invoiceManager.Insert(invoice);

                    try
                    {
                        BL.V.BeginTransaction();
                        string sqlInformation = "insert into Information values(NEWID(),GETDATE(),'" + invoice.InvoiceId + "','" + "出貨單" + "','0')";
                        this.invoiceManager.UpdateSql(sqlInformation);
                        BL.V.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        BL.V.RollbackTransaction();
                        throw new Helper.MessageValueException(ex.Message);
                    }
                    break;
                case "update":
                    this.invoiceManager.Update(invoice);

                    try
                    {
                        BL.V.BeginTransaction();
                        string sqlInformation = "insert into Information values(NEWID(),GETDATE(),'" + invoice.InvoiceId + "','" + "出貨單" + "','1')";
                        this.invoiceManager.UpdateSql(sqlInformation);
                        BL.V.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        BL.V.RollbackTransaction();
                        throw new Helper.MessageValueException(ex.Message);
                    }
                    break;
            }
        }

        protected override void Delete()
        {
            this.invoiceManager.Delete(invoice.InvoiceId);
        }

        public override BaseListForm GetListForm()
        {
            try
            {
                return new ListForm();
            }
            catch
            {
                return null;
            }
        }

        public override Book.Model.Invoice Invoice
        {
            get
            {
                return invoice;
            }
            set
            {
                if (value is Model.InvoiceXS)
                {
                    invoice = invoiceManager.Get((value as Model.InvoiceXS).InvoiceId);
                }
            }
        }

        protected override void TurnNull()
        {
            if (invoice == null)
                return;
            if (MessageBox.Show(Properties.Resources.ConfirmToDelete, this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                return;

            this.invoiceManager.TurnNull(invoice.InvoiceId);
            invoice = this.invoiceManager.GetNext(invoice);
            if (invoice == null)
            {
                invoice = this.invoiceManager.GetLast();
            }
        }

        protected override void AddNew()
        {
            invoice = new Model.InvoiceXS();
            invoice.InvoiceDate = DateTime.Now;
            //invoice.InvoiceId = this.invoiceManager.GetNewId();
            invoice.InvoiceId = this.invoiceManager.GetIdByMonth(DateTime.Now);
            invoice.Details = new List<Model.InvoiceXSDetail>();
            invoice.Employee0 = BL.V.ActiveOperator.Employee;
            invoice.FapiaoFangshi = "隨單開立";
            invoice.TaxCaluType = 1;
            this.flag = 1;
            invoice.InvoiceTaxrate = 5;
            invoice.Setdetails.Clear();
            invoice.Currency = "美金";
            dic.Clear();
            if (this.invoicexo != null)
            {
                invoice.InvoiceXO = this.invoicexo;
                invoice.InvoiceXOId = invoicexo.InvoiceId;

                invoice.Customer = this.invoicexo.Customer;
                invoice.CustomerId = this.invoicexo.CustomerId;

                invoice.XSCustomer = this.invoicexo.xocustomer;
                if (this.invoicexo.xocustomer != null)
                    invoice.XSCustomerId = this.invoicexo.xocustomer.CustomerId;

                invoice.Employee0 = this.invoicexo.Employee0;
                invoice.Employee0Id = this.invoicexo.Employee0Id;

                invoice.InvoiceAbstract = this.invoicexo.InvoiceAbstract;
                invoice.InvoiceNote = this.invoicexo.InvoiceNote;
                invoice.InvoiceAllowance = 0;
                //invoice.CustomerInvoiceXOId = this.invoicexo.CustomerInvoiceXOId;
                this.invoicexo.Details = this.invoicexoDetailManager.Select(this.invoicexo, false);
                invoice.FapiaoFangshi = "隨單開立";

                foreach (Model.InvoiceXODetail detail in this.invoicexo.Details)
                {
                    this.xsdetail = new Book.Model.InvoiceXSDetail();
                    this.xsdetail.Invoice = invoice;
                    this.xsdetail.Inumber = invoice.Details.Count + 1;
                    this.xsdetail.InvoiceId = invoice.InvoiceId;
                    this.xsdetail.InvoiceXSDetailId = Guid.NewGuid().ToString();
                    this.xsdetail.InvoiceXSDetailNote = detail.InvoiceXODetailNote;
                    this.xsdetail.InvoiceXODetailQuantity = detail.InvoiceXODetailQuantity;
                    this.xsdetail.InvoiceXSDetailQuantity = 0;
                    this.xsdetail.InvoiceXODetailBeenQuantity = detail.InvoiceXODetailBeenQuantity == null ? 0 : detail.InvoiceXODetailBeenQuantity;
                    this.xsdetail.InvoiceXSDetailQuantity0 = detail.InvoiceXODetailQuantity0;
                    this.xsdetail.InvoiceXODetail = detail;
                    this.xsdetail.InvoiceXODetailId = detail.InvoiceXODetailId;


                    //this.xsdetail.PrimaryKey = detail.PrimaryKey;
                    //if (detail.PrimaryKey!=null)
                    //this.xsdetail.PrimaryKeyId = detail.PrimaryKey.PrimaryKeyId;

                    this.xsdetail.Product = detail.Product;
                    if (detail.Product != null)
                    {
                        this.xsdetail.ProductId = detail.Product.ProductId;
                    }
                    this.xsdetail.InvoiceProductUnit = detail.InvoiceProductUnit;
                    invoice.Details.Add(this.xsdetail);
                }
            }
            else
            {
                if (this.action == "insert")
                {
                    Model.InvoiceXSDetail detail = new Model.InvoiceXSDetail();
                    detail.InvoiceXSDetailId = Guid.NewGuid().ToString();
                    detail.Inumber = invoice.Details.Count + 1;
                    detail.InvoiceXSDetailNote = "";
                    detail.InvoiceXSDetailQuantity = 1;
                    // detail.PrimaryKey = new Book.Model.CustomerProducts();
                    detail.Product = new Book.Model.Product();
                    detail.InvoiceProductUnit = "";
                    invoice.Details.Add(detail);
                    this.bindingSourceDetail.Position = this.bindingSourceDetail.IndexOf(detail);
                }
            }
        }

        protected override void MoveNext()
        {
            Model.InvoiceXS invoicexs = this.invoiceManager.GetNext(invoice);
            if (invoicexs == null)
                throw new InvalidOperationException(Properties.Resources.ErrorNoMoreRows);

            invoice = this.invoiceManager.Get(invoicexs.InvoiceId);
        }

        protected override void MovePrev()
        {
            Model.InvoiceXS invoicexs = this.invoiceManager.GetPrev(invoice);
            if (invoicexs == null)
                throw new InvalidOperationException(Properties.Resources.ErrorNoMoreRows);

            invoice = this.invoiceManager.Get(invoicexs.InvoiceId);
        }

        protected override void MoveFirst()
        {
            invoice = this.invoiceManager.Get(this.invoiceManager.GetFirst() == null ? "" : this.invoiceManager.GetFirst().InvoiceId);
        }

        protected override void MoveLast()
        {
            if (LastFlag == 1) { LastFlag = 0; return; }
            invoice = this.invoiceManager.Get(this.invoiceManager.GetLast() == null ? "" : this.invoiceManager.GetLast().InvoiceId);
        }

        public override void Refresh()
        {
            if (invoice == null)
            {
                invoice = new Book.Model.InvoiceXS();
                this.action = "insert";
            }
            else
            {
                if (this.action == "view")
                {
                    invoice = this.invoiceManager.GetDetails(invoice.InvoiceId);
                }
            }

            this.textEditInvoiceId.Text = invoice.InvoiceId;
            // this.textEditiInvoiceXOId.Text = invoice.InvoiceXOId;
            this.dateEditInvoiceDate.EditValue = invoice.InvoiceDate;
            //this.textEditInvoiceId.Text = invoice.InvoiceId;
            this.buttonEditEmployee.EditValue = invoice.Employee0;
            this.textEditNote.EditValue = invoice.InvoiceNote;
            this.buttonEditCompany.EditValue = invoice.Customer;
            this.newChooseXScustomer.EditValue = invoice.XSCustomer;
            this.buttonEditDepot.EditValue = invoice.Depot;
            this.lookUpEditFreightCompany.EditValue = invoice.TransportCompany;
            this.textEditSongHuoAddress.EditValue = invoice.XSCustomer == null ? "" : invoice.XSCustomer.CustomerJinChuAddress;
            if (invoice.ConveyanceMethodId != null)
                this.comboBoxConveyanceMethodId.EditValue = invoice.ConveyanceMethod;
            this.calcEditInvoiceTotalset.EditValue = invoice.InvoiceTotal.HasValue ? invoice.InvoiceTotal.Value : 0;
            this.calcEditInvoiceTaxset.EditValue = invoice.InvoiceTax.HasValue ? invoice.InvoiceTax.Value : 0;
            this.calcEditInvoiceHejiset.EditValue = invoice.InvoiceHeji.HasValue ? invoice.InvoiceHeji.Value : 0;
            this.spinEditInvoiceTaxRate.EditValue = invoice.InvoiceTaxrate.HasValue ? invoice.InvoiceTaxrate.Value : 0;
            this.comboBoxEditInvoiceKslb.SelectedIndex = invoice.TaxCaluType.HasValue ? invoice.TaxCaluType.Value : 0;
            this.calcInvoiceAllowance.EditValue = invoice.InvoiceAllowance.HasValue ? invoice.InvoiceAllowance.Value : 0;
            this.flag = invoice.TaxCaluType.HasValue ? invoice.TaxCaluType.Value : 0;
            this.spinEditInvoiceTaxRate.Properties.Buttons[1].Enabled = flag == 0 ? false : true;
            this.spinEditInvoiceTaxRate.Properties.Buttons[2].Enabled = flag == 1 ? false : true;
            this.spinEditInvoiceTaxRate.Properties.Buttons[3].Enabled = flag == 2 ? false : true;

            this.textEditOtherChargeNote.Text = invoice.OtherChargeNote;
            this.textEditOtherChargeMoneyset.EditValue = invoice.OtherChargeMoney.HasValue ? invoice.OtherChargeMoney.Value : 0;
            this.EmpAudit.EditValue = this.Invoice.AuditEmp;
            this.textEditAuditState.Text = this.Invoice.AuditStateName;
            this.checkEditSpecial.Checked = Convert.ToBoolean(invoice.Special);
            this.bindingSourceDetail.DataSource = invoice.Details;
            this.spe_TaibiTotal.EditValue = invoice.InvoiceTaibiTotal;
            this.date_DeclareDate.EditValue = invoice.DeclareDate;
            this.txt_PayCondition.Text = invoice.Customer == null ? null : invoice.Customer.PayCondition;
            this.txt_FapiaoFangshi.Text = invoice.FapiaoFangshi;
            this.cob_FapiaoLianshi.Text = invoice.FapiaoLianshi;
            this.comboBoxEditCurrency.Text = invoice.Currency;
            //  this.textEditCustomerInvoiceXOId.Text = xo == null ? "" : xo.CustomerInvoiceXOId;
            //this.bindingSourceProduct.DataSource = this.customerProductsManager.Select(this.buttonEditCompany.EditValue as Model.Customer);
            // this.bindingSourceProduct.DataSource = this.productManager.Select(this.newChooseXScustomer.EditValue as Model.Customer);

            base.Refresh();
            switch (this.action)
            {
                case "insert":
                    this.barButtonItem5.Enabled = true;
                    this.gridColumnPosition.OptionsColumn.AllowEdit = true;
                    //this.comboBoxEditCurrency.Enabled = true;
                    break;
                case "update":
                    this.barButtonItem5.Enabled = true;
                    this.gridColumnPosition.OptionsColumn.AllowEdit = true;
                    //this.comboBoxEditCurrency.Enabled = false;
                    break;
                case "view":
                    this.barButtonItem5.Enabled = true;
                    this.gridColumnPosition.OptionsColumn.AllowEdit = false;
                    //this.comboBoxEditCurrency.Enabled = false;
                    break;
            }
            this.buttonEditEmployee.ShowButton = false;
            this.buttonEditEmployee.ButtonReadOnly = true;
            this.textEditInvoiceId.Properties.ReadOnly = true;
            this.textEditSongHuoAddress.Enabled = false;
            this.txt_PayCondition.Properties.ReadOnly = true;
        }

        protected override DevExpress.XtraReports.UI.XtraReport GetReport()
        {
            return new R01(invoice.InvoiceId);
        }

        protected override bool HasRows()
        {
            return this.invoiceManager.HasRows();
        }

        protected override bool HasRowsNext()
        {
            return this.invoiceManager.HasRowsAfter(invoice);
        }

        protected override bool HasRowsPrev()
        {
            return this.invoiceManager.HasRowsBefore(invoice);
        }

        private void dateEditInvoiceDate_Leave(object sender, EventArgs e)
        {
            // if (this.action == "insert") { this.textEditInvoiceId.EditValue = this.invoiceManager.GetNewId(this.dateEditInvoiceDate.DateTime); }
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (this.gridView1.FocusedColumn == this.gridColumnUnit)
            {
                if (this.gridView1.FocusedColumn.ColumnEdit is DevExpress.XtraEditors.Repository.RepositoryItemComboBox)
                {
                    //Model.CustomerProducts p = (this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as Model.InvoiceXSDetail).PrimaryKey;
                    Model.Product p = (this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as Model.InvoiceXSDetail).Product;
                    this.repositoryItemComboBox1.Items.Clear();
                    if (p == null)
                        return;
                    if (!string.IsNullOrEmpty(p.BasedUnitGroupId))
                    {
                        Model.UnitGroup ug = new BL.UnitGroupManager().Get(p.BasedUnitGroupId);
                        IList<Model.ProductUnit> units = productUnitManager.Select(ug);
                        foreach (Model.ProductUnit ut in units)
                        {
                            this.repositoryItemComboBox1.Items.Add(ut.CnName);
                        }
                    }
                }
            }
            else if (this.gridView1.FocusedColumn == this.gridColumnPosition)
            {
                if (this.gridView1.FocusedColumn.ColumnEdit is DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)
                {
                    if (this.buttonEditDepot.EditValue == null)
                    {
                        MessageBox.Show(Properties.Resources.RequireDataForDepotName, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //Model.CustomerProducts p = (this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as Model.InvoiceXSDetail).PrimaryKey;
                    Model.InvoiceXSDetail p = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as Model.InvoiceXSDetail;
                    if (string.IsNullOrEmpty(p.ProductId)) return;
                    this.bindingSourceDepotPosition.DataSource = this.depotPositionManager.GetStockByDepotAndProduct(p.ProductId, (this.buttonEditDepot.EditValue as Model.Depot).DepotId);
                }
            }
        }

        protected override void IMECtrl()
        {
            Book.UI.Tools.IMEControl.IMECtrl(new Control[] { this.gridControl1, this.textEditInvoiceId, this });
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            Model.InvoiceXSDetail detail = this.gridView1.GetRow(e.RowHandle) as Model.InvoiceXSDetail;

            if (detail == null) return;

            if (e.Column == this.colProductId || e.Column == this.colProduct || e.Column == this.gridColumnCusPro)
            {
                //  Model.CustomerProducts p = customerProductsManager.Get(e.Value.ToString());
                Model.Product p = this.productManager.Get(e.Value.ToString());
                detail.InvoiceXSDetailId = Guid.NewGuid().ToString();
                detail.Invoice = invoice;
                detail.InvoiceXSDetailNote = "";
                detail.InvoiceXSDetailQuantity = 1;
                //detail.PrimaryKey = p;
                //detail.PrimaryKeyId = p.PrimaryKeyId;
                detail.Product = p;
                detail.ProductId = p.ProductId;

                this.bindingSourceDetail.Position = this.bindingSourceDetail.IndexOf(detail);

                this.gridControl1.RefreshDataSource();
            }

            if (e.Column == this.gridColumnPosition)
            {
                Model.DepotPosition position = depotPositionManager.Get(e.Value.ToString());
                detail.DepotPosition = position;
                detail.DepotPositionId = position.DepotPositionId;
                this.gridControl1.RefreshDataSource();
            }
        }

        private bool CanAdd(IList<Model.InvoiceXSDetail> list)
        {
            foreach (Model.InvoiceXSDetail detail in list)
            {
                //if (detail.PrimaryKey == null || string.IsNullOrEmpty(detail.PrimaryKey.PrimaryKeyId))
                if (detail.Product == null || string.IsNullOrEmpty(detail.Product.ProductId))
                    return false;
            }
            return true;
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.ListSourceRowIndex < 0) return;
            IList<Model.InvoiceXSDetail> details = this.bindingSourceDetail.DataSource as IList<Model.InvoiceXSDetail>;
            if (details == null || details.Count < 1) return;
            Model.Product detail = details[e.ListSourceRowIndex].Product;
            Model.InvoiceXODetail xodetail = details[e.ListSourceRowIndex].InvoiceXODetail;
            Model.InvoiceXO xo = details[e.ListSourceRowIndex].InvoiceXO;
            switch (e.Column.Name)
            {
                case "Quantity":
                    if (xodetail != null)
                        e.DisplayText = xodetail.InvoiceXODetailQuantity.ToString();
                    break;
                case "colInvoiceXSDetailQuantity0":
                    if (xodetail != null)
                        e.DisplayText = xodetail.InvoiceXODetailQuantity0.Value.ToString();
                    break;
                case "colProductId":
                    e.DisplayText = detail.Id;
                    break;
                case "gridColumnCusPro":
                    e.DisplayText = detail.CustomerProductName;
                    break;
                case "gridColumnCusXOId":
                    if (xo != null)
                        e.DisplayText = xo.CustomerInvoiceXOId;
                    break;
                case "gridColumnVersion":
                    e.DisplayText = detail.ProductVersion;
                    break;

            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == this.BeenQuantity || e.Column == this.colDonatetowards || e.Column == this.colInvoiceAllowance || e.Column == this.colInvoiceXSDetailPrice)
            {
                decimal price = decimal.Zero;
                decimal quantity = decimal.Zero;
                decimal zherang = decimal.Zero;
                //decimal tax = decimal.Zero;
                //decimal money = decimal.Zero;
                //decimal taxmoney = decimal.Zero;
                if (e.Column == this.colInvoiceXSDetailPrice)
                {
                    decimal.TryParse(e.Value == null ? "0" : e.Value == null ? "0" : e.Value.ToString(), out price);
                    decimal.TryParse(this.gridView1.GetRowCellValue(e.RowHandle, this.BeenQuantity) == null ? "0" : this.gridView1.GetRowCellValue(e.RowHandle, this.BeenQuantity).ToString(), out quantity);
                    decimal.TryParse(this.gridView1.GetRowCellValue(e.RowHandle, this.colInvoiceAllowance) == null ? "0" : this.gridView1.GetRowCellValue(e.RowHandle, this.colInvoiceAllowance).ToString(), out zherang);
                }
                if (e.Column == this.BeenQuantity)
                {
                    decimal.TryParse(e.Value == null ? "0" : e.Value == null ? "0" : e.Value.ToString(), out quantity);     //获得数量
                    decimal.TryParse(this.gridView1.GetRowCellValue(e.RowHandle, this.colInvoiceXSDetailPrice) == null ? "0" : this.gridView1.GetRowCellValue(e.RowHandle, this.colInvoiceXSDetailPrice).ToString(), out price);                     // if (price == decimal.Zero)
                    decimal.TryParse(this.gridView1.GetRowCellValue(e.RowHandle, this.colInvoiceAllowance) == null ? "0" : this.gridView1.GetRowCellValue(e.RowHandle, this.colInvoiceAllowance).ToString(), out zherang);
                }
                if (e.Column == this.colInvoiceAllowance)//折让后改变 金额 税额 税价和为0
                {
                    decimal.TryParse(e.Value == null ? "0" : e.Value == null ? "0" : e.Value.ToString(), out zherang);
                    decimal.TryParse(this.gridView1.GetRowCellValue(e.RowHandle, this.colInvoiceXSDetailPrice) == null ? "0" : this.gridView1.GetRowCellValue(e.RowHandle, this.colInvoiceXSDetailPrice).ToString(), out price);
                    decimal.TryParse(this.gridView1.GetRowCellValue(e.RowHandle, this.BeenQuantity) == null ? "0" : this.gridView1.GetRowCellValue(e.RowHandle, this.BeenQuantity).ToString(), out quantity);
                }

                if (e.Column == this.colDonatetowards)
                {
                    //if ((bool)e.Value)
                    //{
                    this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXSDetailMoney, 0);
                    this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXSDetailPrice, 0);
                    this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXSDetailTax, 0);
                    this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXSDetailTaxMoney, 0);
                    this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXSDetailTaxPrice, 0);
                    //}
                }

                if (e.Column != this.colDonatetowards)
                {
                    if (bool.Parse(this.gridView1.GetRowCellValue(e.RowHandle, this.colDonatetowards) == null ? "false" : this.gridView1.GetRowCellValue(e.RowHandle, this.colDonatetowards).ToString()) == true)
                    {
                        this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXSDetailMoney, 0);
                        this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXSDetailTax, 0);
                        this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXSDetailTax, 0);
                    }

                    else
                    {
                        price = this.GetDecimal(price, BL.V.SetDataFormat.XSDJXiao.Value);
                        zherang = this.GetDecimal(zherang, BL.V.SetDataFormat.XSJEXiao.Value);
                        if (flag == 0) //免税
                        {
                            this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXSDetailMoney, this.GetDecimal(price * quantity - zherang, BL.V.SetDataFormat.XSJEXiao.Value));
                            this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXSDetailTax, 0);
                            this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXSDetailTaxMoney, this.GetDecimal(price * quantity - zherang, BL.V.SetDataFormat.XSJEXiao.Value));
                            this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXSDetailTaxPrice, 0);
                        }
                        if (flag == 1) //外加
                        {
                            this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXSDetailMoney, this.GetDecimal(price * quantity - zherang, BL.V.SetDataFormat.XSJEXiao.Value));
                            this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXSDetailTax, this.GetDecimal(price * quantity * this.spinEditInvoiceTaxRate.Value / 100, BL.V.SetDataFormat.XSJEXiao.Value));
                            this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXSDetailTaxMoney, this.GetDecimal(price * quantity - zherang + price * quantity * this.spinEditInvoiceTaxRate.Value / 100, BL.V.SetDataFormat.XSJEXiao.Value));
                            this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXSDetailTaxPrice, 0);
                        }
                        if (flag == 2) //内含
                        {
                            this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXSDetailMoney, this.GetDecimal(price * quantity - zherang, BL.V.SetDataFormat.XSJEXiao.Value));
                            this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXSDetailTax, this.GetDecimal(price * quantity - (price * quantity / (1 + this.spinEditInvoiceTaxRate.Value / 100)), BL.V.SetDataFormat.XSJEXiao.Value));
                            this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXSDetailTaxMoney, this.GetDecimal(price * quantity - zherang, BL.V.SetDataFormat.XSJEXiao.Value));
                            this.gridView1.SetRowCellValue(e.RowHandle, this.colInvoiceXSDetailTaxPrice, 0);
                        }
                    }
                }
                this.gridControl1.RefreshDataSource();
                this.UpdateMoneyFields();
            }
            else if (e.Column == this.gridColumn6)  //新臺幣匯率
            {
                this.UpdateMoneyFields();
            }
        }

        private void buttonEditDepot_EditValueChanged(object sender, EventArgs e)
        {
            Model.Depot depot = this.buttonEditDepot.EditValue as Model.Depot;
            if (depot != null)
            {
                this.bindingSourceDepotPosition.DataSource = this.depotPositionManager.Select(depot);
            }
            else
            {
                this.bindingSourceDepotPosition.Clear();
                foreach (Model.InvoiceXSDetail detail in invoice.Details)
                {
                    detail.DepotPosition = null;
                    detail.DepotPositionId = null;
                }
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (invoice != null)
            {
                RO4 f = new RO4(invoice.InvoiceId);
                f.ShowPreviewDialog();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (invoice != null)
            {
                RO3 f = new RO3(invoice.InvoiceId);
                f.ShowPreviewDialog();
            }
        }

        //选择客戶订单按钮
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Model.Customer customer = new Book.Model.Customer();
            // Model.Employee emp = new Book.Model.Employee();
            //3.SelectByYJRQCustomEmp(customer, global::Helper.DateTimeParse.NullDate.ToString(), System.DateTime.Today.ToString(), emp);
            //if (!invoiceXOManager.HasRows())
            //{
            //    MessageBox.Show("尚沒有訂單。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            SearcharInvoiceXSForm form = new SearcharInvoiceXSForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                if (form.key != null && form.key.Count > 0)
                {
                    if (invoice.Details.Count > 0 && string.IsNullOrEmpty(invoice.Details[0].ProductId))
                        invoice.Details.RemoveAt(0);
                    //string[] str = (from x in xo.Details select "'" + x.ProductId + "'").Distinct().ToArray();
                    //this.bindingSourceProduct.DataSource = this.productManager.SelectByProductIds(str.Aggregate<string>((a, b) => a + "," + b));
                    //this.gridControl1.RefreshDataSource();

                    Model.InvoiceXODetail xo = form.key[0];
                    //invoice.InvoiceXO = xo;
                    invoice.InvoiceXOId = xo.InvoiceId;
                    this.buttonEditCompany.EditValue = xo.Invoice.Customer;
                    this.newChooseXScustomer.EditValue = xo.Invoice.xocustomer;
                    //this.spinEditInvoiceTaxRate.EditValue = xo.Invoice.InvoiceTaxrate;
                    //this.comboBoxEditInvoiceKslb.SelectedIndex=xo.Invoice.TaxCaluType
                    //invoice.CustomerInvoiceXOId = xo.CustomerInvoiceXOId;                                                         
                    //invoice.Customer = xo.Customer;
                    //invoice.XSCustomer = xo.xocustomer;
                    //   textEditiInvoiceXOId.Text = xo.InvoiceId;
                    //this.comboBoxEditCurrency.Enabled = false;
                    this.comboBoxEditCurrency.Text = xo.Invoice.Currency;

                    if (xo.Invoice.Currency.Contains("台币") || xo.Invoice.Currency.Contains("台幣"))
                        spinEditInvoiceTaxRate.EditValue = 5;
                    else
                        spinEditInvoiceTaxRate.EditValue = 0;

                    foreach (Model.InvoiceXODetail xos in form.key)
                    {
                        Model.InvoiceXSDetail xtdetail = new InvoiceXSDetail();
                        xtdetail.Inumber = invoice.Details.Count + 1;
                        xtdetail.Invoice = invoice;
                        xtdetail.InvoiceId = invoice.InvoiceId;
                        xtdetail.InvoiceXOId = xos.InvoiceId;
                        xtdetail.InvoiceXSDetailId = Guid.NewGuid().ToString();
                        xtdetail.InvoiceXSDetailQuantity = 0;
                        xtdetail.InvoiceXODetailId = xos.InvoiceXODetailId;
                        xtdetail.InvoiceXODetail = xos;
                        xtdetail.Product = xos.Product;
                        xtdetail.ProductId = xos.Product.ProductId;
                        xtdetail.InvoiceProductUnit = xos.InvoiceProductUnit;
                        xtdetail.Donatetowards = false;
                        xtdetail.InvoiceXSDetailPrice = xos.InvoiceXODetailPrice;
                        //xtdetail.InvoiceXSDetailPrice = ConvertPrice(xos);
                        ConvertPrice(xos, xtdetail);    //2018年11月26日20:50:52：计算总价时才换算台币
                        xtdetail.InvoiceAllowance = 0;
                        xtdetail.InvoiceXSDetailMoney = 0;
                        xtdetail.InvoiceXSDetailTaxPrice = 0;
                        xtdetail.InvoiceXSDetailTaxMoney = 0;
                        xtdetail.InvoiceXSDetailFPQuantity = 0;
                        xtdetail.InvoiceXSDetailTax = 0;
                        xtdetail.InvoiceXSDetailNote = xos.Remark;
                        invoice.Details.Add(xtdetail);
                    }

                    if (invoice.Details.GroupBy(D => D.Currency).Count() > 1)
                        MessageBox.Show("出貨單包含不同幣別的商品", "提示", MessageBoxButtons.OK);

                    this.gridControl1.RefreshDataSource();
                }
                form.Dispose();
                GC.Collect();

                #region 暂时没用的代码
                //    invoice.InvoiceXO = xo;
                //    invoice.InvoiceXOId = xo.InvoiceId;

                //    invoice.Customer = xo.Customer;
                //    invoice.CustomerId = xo.CustomerId;
                //    //invoice.CustomerInvoiceXOId = xo.CustomerInvoiceXOId;
                //    invoice.XSCustomer = xo.xocustomer;
                //    if (xo.xocustomer != null)
                //        invoice.XSCustomerId = xo.xocustomer.CustomerId;
                //    invoice.Employee0 = xo.Employee0;
                //    invoice.Employee0Id = xo.Employee0Id;

                //    invoice.InvoiceAbstract = xo.InvoiceAbstract;
                //    invoice.InvoiceNote = xo.InvoiceNote;
                //    //invoice.Customer = xo.Customer;
                //    //invoice.XSCustomer = xo.xocustomer;
                //    textEditiInvoiceXOId.Text = xo.InvoiceId;

                //    foreach (Model.InvoiceXODetail detail in xo.Details)
                //    {
                //        this.xsdetail = new Book.Model.InvoiceXSDetail();
                //        this.xsdetail.Invoice = invoice;
                //        this.xsdetail.InvoiceId = invoice.InvoiceId;
                //        this.xsdetail.InvoiceXSDetailId = Guid.NewGuid().ToString();
                //        this.xsdetail.InvoiceXSDetailNote = detail.InvoiceXODetailNote;
                //        this.xsdetail.InvoiceXODetailQuantity = detail.InvoiceXODetailQuantity;
                //        this.xsdetail.InvoiceXSDetailQuantity = 0;
                //        this.xsdetail.InvoiceXODetailBeenQuantity = detail.InvoiceXODetailBeenQuantity == null ? 0 : detail.InvoiceXODetailBeenQuantity;
                //        this.xsdetail.InvoiceXSDetailQuantity0 = detail.InvoiceXODetailQuantity0;
                //        this.xsdetail.InvoiceXODetail = detail;
                //        this.xsdetail.InvoiceXODetailId = detail.InvoiceXODetailId;

                //        this.xsdetail.Product = detail.Product;
                //        if (detail.Product != null)
                //        {
                //            this.xsdetail.ProductId = detail.Product.ProductId;
                //        }
                //        this.xsdetail.InvoiceProductUnit = detail.InvoiceProductUnit;
                //        invoice.Details.Add(this.xsdetail);
                //        this.gridControl1.RefreshDataSource();
                //    }
                //}
                #endregion
            }
            //this.action = "insert";
        }

        // 根据汇率，将不同的币种全部转为台币
        private void ConvertPrice(Model.InvoiceXODetail xodetail, Model.InvoiceXSDetail xsdetail)
        {
            //if (xodetail.InvoiceXODetailPrice == 0 || xodetail.Invoice.Currency == "新台幣")
            //{
            //    xsdetail.InvoiceXSDetailPrice = xodetail.InvoiceXODetailPrice.Value;
            //    return;
            //}
            //else
            //{
            //    decimal price = 0;
            //    int day = this.dateEditInvoiceDate.DateTime.Day;
            //    DateTime date = DateTime.Now;

            //    if (day < 11)
            //        date = DateTime.Parse(string.Format("{0}-{1}-{2}", this.dateEditInvoiceDate.DateTime.Year, this.dateEditInvoiceDate.DateTime.Month, "1"));
            //    else if (day >= 11 && day < 21)
            //        date = DateTime.Parse(string.Format("{0}-{1}-{2}", this.dateEditInvoiceDate.DateTime.Year, this.dateEditInvoiceDate.DateTime.Month, "11"));
            //    else
            //        date = DateTime.Parse(string.Format("{0}-{1}-{2}", this.dateEditInvoiceDate.DateTime.Year, this.dateEditInvoiceDate.DateTime.Month, "21"));

            //    decimal rate = exchangeRateManager.GetRateByDateAndCurrency(date, xodetail.Invoice.Currency);
            //    if (rate != 0)
            //        price = xodetail.InvoiceXODetailPrice.Value * rate;
            //    else
            //        price = xodetail.InvoiceXODetailPrice.Value;

            //    xsdetail.InvoiceXSDetailPrice = price;
            //    xsdetail.Currency = xodetail.Invoice.Currency;
            //    xsdetail.ExchangeRate = rate;
            //}

            //int day = this.dateEditInvoiceDate.DateTime.Day;
            //DateTime date = DateTime.Now;
            //if (day < 11)
            //    date = DateTime.Parse(string.Format("{0}-{1}-{2}", this.dateEditInvoiceDate.DateTime.Year, this.dateEditInvoiceDate.DateTime.Month, "1"));
            //else if (day >= 11 && day < 21)
            //    date = DateTime.Parse(string.Format("{0}-{1}-{2}", this.dateEditInvoiceDate.DateTime.Year, this.dateEditInvoiceDate.DateTime.Month, "11"));
            //else
            //    date = DateTime.Parse(string.Format("{0}-{1}-{2}", this.dateEditInvoiceDate.DateTime.Year, this.dateEditInvoiceDate.DateTime.Month, "21"));

            string currency = "";
            if (xodetail.Invoice != null)
                currency = xodetail.Invoice.Currency;
            else
                currency = invoiceXOManager.GetCurrencyByInvoiceId(xodetail.InvoiceId);

            decimal rate = exchangeRateManager.GetRateByDateAndCurrency(this.dateEditInvoiceDate.DateTime, currency);
            xsdetail.Currency = currency;
            xsdetail.ExchangeRate = rate;
        }

        public static Model.InvoiceXS xs;

        //历史出货记录按钮
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.action = "view";
            //if (!invoiceManager.HasRows())
            //{
            //    MessageBox.Show("尚沒有歷史出貨記錄。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //HisXSInfomationForm hisXS = new HisXSInfomationForm();
            //if (hisXS.ShowDialog(this) == DialogResult.OK)
            //{
            //    if (xs != null)
            //    {
            //        invoice = xs;
            //        this.Refresh();
            //    }
            //}


            try
            {
                ROHistoryXS ro = new ROHistoryXS();
                ro.ShowPreviewDialog();
            }
            catch
            { }
        }

        //private void dateEditInvoiceDate_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (this.action == "insert")
        //    {
        //        this.textEditInvoiceId.EditValue = this.invoiceManager.GetNewId(this.dateEditInvoiceDate.DateTime);
        //    }
        //}



        //private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        //{
        //    if (this.buttonEditDepot.EditValue == null)
        //    {
        //        MessageBox.Show(Properties.Resources.deptNotNull, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        this.buttonEditDepot.Focus();
        //        return;
        //    }

        //    Model.InvoiceXSDetail temp = this.bindingSourceDetail.Current as Model.InvoiceXSDetail;
        //    if (temp.Product.StocksQuantity == null || temp.Product.StocksQuantity == 0)
        //        MessageBox.Show(Properties.Resources.stockquertyIsSmall, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    if (temp.Invoice != null)
        //        temp.Invoice.Depot = this.buttonEditDepot.EditValue as Model.Depot;
        //    else
        //    {
        //        temp.Invoice = new InvoiceXS();
        //        temp.Invoice.Depot = this.buttonEditDepot.EditValue as Model.Depot;
        //    }
        //    SettingDepotPositionNums form = new SettingDepotPositionNums(temp);
        //    if (form.ShowDialog(this) == DialogResult.OK)
        //    {
        //        temp.InvoiceXSDetailQuantity = sum;
        //    }
        //    this.gridControl1.RefreshDataSource();
        //}

        private void simpleButton_Copy_Click(object sender, EventArgs e)
        {
            if (this.bindingSourceDetail.Current == null) return;
            Model.InvoiceXSDetail detail = this.bindingSourceDetail.Current as Model.InvoiceXSDetail;
            Model.InvoiceXSDetail temp = new InvoiceXSDetail();
            temp.Inumber = invoice.Details.Count + 1;
            temp.Invoice = invoice;
            temp.InvoiceId = invoice.InvoiceId;
            temp.InvoiceXSDetailId = Guid.NewGuid().ToString();
            temp.InvoiceXSDetailNote = detail.InvoiceXSDetailNote;
            temp.InvoiceXODetailQuantity = detail.InvoiceXODetailQuantity;
            temp.InvoiceXSDetailQuantity = 0;
            temp.InvoiceXODetailBeenQuantity = detail.InvoiceXODetailBeenQuantity == null ? 0 : detail.InvoiceXODetailBeenQuantity;
            temp.InvoiceXSDetailQuantity0 = detail.InvoiceXSDetailQuantity0;
            temp.InvoiceXODetailId = detail.InvoiceXODetailId;
            temp.Product = detail.Product;
            temp.ProductId = detail.Product.ProductId;
            temp.InvoiceProductUnit = detail.InvoiceProductUnit;
            invoice.Details.Add(temp);
            this.gridControl1.RefreshDataSource();
        }

        private void simpleButton_Remove_Click(object sender, EventArgs e)
        {
            if (this.bindingSourceDetail.Current == null) return;
            Model.InvoiceXSDetail detail = this.bindingSourceDetail.Current as Model.InvoiceXSDetail;
            detail.Inumber = invoice.Details.Count + 1;
            invoice.Details.Remove(detail);
            this.gridControl1.RefreshDataSource();
            UpdateMoneyFields();
        }

        private void TaxMethod()
        {
            string message = "";
            if (flag == 0)
                message = "免稅";// Properties.Resources.WaiJiaShui;
            else if (flag == 1)
                message = Properties.Resources.WaiJiaShui;
            else
                message = Properties.Resources.NeiHanShui;
            if (MessageBox.Show(message, this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                return;
            double taxrate = double.Parse(this.spinEditInvoiceTaxRate.Text); //阭薹
            double ta = (taxrate + 100) / 100;

            foreach (Model.InvoiceXSDetail detail in invoice.Details)
            {
                //this.textEditInvoiceId.Text.Equals(null);
                if (detail.Product == null || string.IsNullOrEmpty(detail.Product.ProductId)) continue;
                if (detail.Donatetowards != null && detail.Donatetowards == true) continue;
                //if (detail.InvoiceXODetailQuantity == 0 || detail.InvoiceXODetailQuantity == 0) continue;
                if (flag == 0)
                {
                    detail.InvoiceXSDetailTaxPrice = 0;
                    detail.InvoiceXSDetailTax = 0;
                    detail.InvoiceXSDetailTaxMoney = detail.InvoiceXSDetailMoney;
                    this.spinEditInvoiceTaxRate.EditValue = 0;
                }
                else if (flag == 1)
                {
                    if (detail.InvoiceXSDetailPrice == null)
                    {
                        detail.InvoiceXSDetailPrice = 0;
                    }
                    detail.InvoiceXSDetailTaxPrice = 0;
                    detail.InvoiceXSDetailTax = detail.InvoiceXSDetailPrice.Value * decimal.Parse(detail.InvoiceXSDetailQuantity.ToString()) * decimal.Parse(this.spinEditInvoiceTaxRate.Text) / 100;

                    detail.InvoiceXSDetailTax = this.GetDecimal(detail.InvoiceXSDetailTax.Value, BL.V.SetDataFormat.XSZJXiao.Value);

                    detail.InvoiceXSDetailTaxMoney = detail.InvoiceXSDetailTax + detail.InvoiceXSDetailMoney;
                }
                else
                {
                    if (detail.InvoiceXSDetailPrice == null)
                    {
                        detail.InvoiceXSDetailPrice = 0;
                    }
                    detail.InvoiceXSDetailTaxPrice = 0;
                    detail.InvoiceXSDetailTax = detail.InvoiceXSDetailMoney - detail.InvoiceXSDetailMoney / (1 + decimal.Parse(this.spinEditInvoiceTaxRate.Text) / 100);
                    detail.InvoiceXSDetailTax = this.GetDecimal(detail.InvoiceXSDetailTax.Value, BL.V.SetDataFormat.XSZJXiao.Value);
                    detail.InvoiceXSDetailTaxMoney = detail.InvoiceXSDetailMoney;
                }

                // detail.InvoiceCODetailMoney = decimal.Parse(detail.OrderQuantity.ToString()) * detail.InvoiceCODetailPrice;
            }
            this.spinEditInvoiceTaxRate.Properties.Buttons[1].Enabled = flag == 0 ? false : true;
            this.spinEditInvoiceTaxRate.Properties.Buttons[2].Enabled = flag == 1 ? false : true;
            this.spinEditInvoiceTaxRate.Properties.Buttons[3].Enabled = flag == 2 ? false : true;
            this.UpdateMoneyFields();
        }

        private void UpdateMoneyFields()
        {
            decimal yse = 0;//合计       
            decimal tol = 0;
            decimal tax = 0;

            decimal totalTaibi = 0;

            foreach (Model.InvoiceXSDetail detail in invoice.Details)
            {

                if (detail.InvoiceXSDetailMoney == null)
                    detail.InvoiceXSDetailMoney = 0;
                yse += detail.InvoiceXSDetailMoney.Value;

                totalTaibi += Convert.ToDecimal(detail.InvoiceXSDetailPrice) * Convert.ToDecimal(detail.InvoiceXSDetailQuantity) * (Convert.ToDecimal(detail.ExchangeRate) == 0 ? 1 : detail.ExchangeRate.Value);
            }

            yse = this.GetDecimal(yse, BL.V.SetDataFormat.XSZJXiao.Value);
            if (this.action != "view")
            {
                if (flag == 0)
                {
                    this.comboBoxEditInvoiceKslb.SelectedIndex = 0;

                    this.calcEditInvoiceHejiset.EditValue = yse;
                    this.calcEditInvoiceTaxset.EditValue = 0;
                    this.calcEditInvoiceTotalset.EditValue = this.GetDecimal(yse + decimal.Parse(this.calcEditInvoiceTaxset.EditValue.ToString()) - this.calcInvoiceAllowance.Value + decimal.Parse(this.textEditOtherChargeMoneyset.Text), BL.V.SetDataFormat.XSZJXiao.Value);

                }
                else if (flag == 1)
                {
                    this.comboBoxEditInvoiceKslb.SelectedIndex = 1;

                    this.calcEditInvoiceHejiset.EditValue = yse;
                    this.calcEditInvoiceTaxset.EditValue = this.GetDecimal(yse * this.spinEditInvoiceTaxRate.Value / 100, BL.V.SetDataFormat.XSZJXiao.Value);
                    this.calcEditInvoiceTotalset.EditValue = this.GetDecimal(yse + decimal.Parse(this.calcEditInvoiceTaxset.EditValue.ToString()) - this.calcInvoiceAllowance.Value + decimal.Parse(this.textEditOtherChargeMoneyset.Text), BL.V.SetDataFormat.XSZJXiao.Value);


                    //this.spe_TaibiTotal.Text = (totalTaibi * (1 + this.spinEditInvoiceTaxRate.Value / 100)).ToString();
                    totalTaibi = totalTaibi * (1 + this.spinEditInvoiceTaxRate.Value / 100);
                }
                else
                {
                    this.comboBoxEditInvoiceKslb.SelectedIndex = 2;
                    this.calcEditInvoiceHejiset.EditValue = this.GetDecimal(yse / (1 + this.spinEditInvoiceTaxRate.Value / 100), BL.V.SetDataFormat.XSZJXiao.Value);
                    this.calcEditInvoiceTaxset.EditValue = this.GetDecimal(yse - (yse / (1 + this.spinEditInvoiceTaxRate.Value / 100)), BL.V.SetDataFormat.XSZJXiao.Value);
                    this.calcEditInvoiceTotalset.EditValue = this.GetDecimal(yse - this.calcInvoiceAllowance.Value + decimal.Parse(this.textEditOtherChargeMoneyset.Text), BL.V.SetDataFormat.XSZJXiao.Value);
                }

                this.spe_TaibiTotal.Text = totalTaibi.ToString();
                //this.calcEditInvoiceHejiset.EditValue = yse;
                //this.calcEditInvoiceTaxset.EditValue = this.GetDecimal(yse * this.spinEditInvoiceTaxRate.Value / 100, BL.V.SetDataFormat.XSZJXiao.Value);
                //this.calcEditInvoiceTotalset.EditValue = this.GetDecimal(yse + decimal.Parse(this.calcEditInvoiceTaxset.EditValue.ToString()) - this.calcInvoiceAllowance.Value + decimal.Parse(this.textEditOtherChargeMoneyset.Text), BL.V.SetDataFormat.XSZJXiao.Value);

            }
        }

        private void textEditOtherChargeMoney_EditValueChanged(object sender, EventArgs e)
        {
            if (this.calcEditInvoiceTaxset.Text == "")
                this.calcEditInvoiceTaxset.Text = "0";
            this.calcEditInvoiceTotalset.EditValue = decimal.Parse(this.calcEditInvoiceHejiset.Text) + decimal.Parse(this.calcEditInvoiceTaxset.Text) + decimal.Parse(this.textEditOtherChargeMoneyset.Text);
        }

        //添加商品
        private void btnPlus_Click(object sender, EventArgs e)
        {
            Book.UI.Invoices.ChooseProductForm f = new Book.UI.Invoices.ChooseProductForm();

            if (f.ShowDialog(this) == DialogResult.OK)
            {
                Model.InvoiceXSDetail detail;
                if (Book.UI.Invoices.ChooseProductForm.ProductList == null || Book.UI.Invoices.ChooseProductForm.ProductList.Count == 0)
                {
                    Model.Product product = f.SelectedItem as Model.Product;
                    if (product != null)
                    {
                        if (invoice.Details.Count > 0 && string.IsNullOrEmpty(invoice.Details[0].ProductId))
                            invoice.Details.RemoveAt(0);
                        detail = new InvoiceXSDetail();
                        detail.Inumber = invoice.Details.Count + 1;
                        detail.Invoice = invoice;                   //出货单头
                        detail.InvoiceId = invoice.InvoiceId;       //出货单头编号
                        //detail.InvoiceXOId = xos.InvoiceId;
                        detail.InvoiceXSDetailId = Guid.NewGuid().ToString();
                        detail.InvoiceXSDetailQuantity = 0;
                        //detail.InvoiceXODetailId = xos.InvoiceXODetailId;
                        //detail.InvoiceXODetail = xos;
                        detail.Product = product;
                        detail.ProductId = product.ProductId;
                        detail.InvoiceProductUnit = product.SellUnit == null ? "" : product.SellUnit.ToString();
                        //detail.InvoiceProductUnit = xos.InvoiceProductUnit;
                        detail.Donatetowards = false;
                        detail.InvoiceXSDetailPrice = 0;
                        //if (product.Supplier != null)
                        //    detail.PriceAndRange = this.supplierproductmanager.GetPriceRangeForSupAndProduct(product.SupplierId, product.ProductId);
                        //detail.InvoiceXSDetailPrice = BL.SupplierProductManager.CountPrice(detail.PriceAndRange, 1);
                        detail.InvoiceAllowance = 0;
                        detail.InvoiceXSDetailMoney = 0;
                        detail.InvoiceXSDetailTaxPrice = 0;
                        detail.InvoiceXSDetailTaxMoney = 0;
                        detail.InvoiceXSDetailFPQuantity = 0;
                        detail.InvoiceXSDetailTax = 0;
                        invoice.Details.Add(detail);
                    }
                }
                else if (ChooseProductForm.ProductList != null || ChooseProductForm.ProductList.Count > 0)
                {
                    foreach (Model.Product product in ChooseProductForm.ProductList)
                    {
                        if (invoice.Details.Count > 0 && string.IsNullOrEmpty(invoice.Details[0].ProductId))
                            invoice.Details.RemoveAt(0);
                        detail = new InvoiceXSDetail();
                        detail.Inumber = invoice.Details.Count + 1;
                        detail.Invoice = invoice;                   //出货单头
                        detail.InvoiceId = invoice.InvoiceId;       //出货单头编号
                        //detail.InvoiceXOId = xos.InvoiceId;
                        detail.InvoiceXSDetailId = Guid.NewGuid().ToString();
                        detail.InvoiceXSDetailQuantity = 0;
                        //detail.InvoiceXODetailId = xos.InvoiceXODetailId;
                        //detail.InvoiceXODetail = xos;
                        detail.Product = product;
                        detail.ProductId = product.ProductId;
                        detail.InvoiceProductUnit = product.SellUnit == null ? "" : product.SellUnit.ToString();
                        //detail.InvoiceProductUnit = xos.InvoiceProductUnit;
                        detail.Donatetowards = false;
                        detail.InvoiceXSDetailPrice = 0;
                        //if (product.Supplier != null)
                        //    detail.PriceAndRange = this.supplierproductmanager.GetPriceRangeForSupAndProduct(product.SupplierId, product.ProductId);
                        //detail.InvoiceXSDetailPrice = BL.SupplierProductManager.CountPrice(detail.PriceAndRange, 1);
                        detail.InvoiceAllowance = 0;
                        detail.InvoiceXSDetailMoney = 0;
                        detail.InvoiceXSDetailTaxPrice = 0;
                        detail.InvoiceXSDetailTaxMoney = 0;
                        detail.InvoiceXSDetailFPQuantity = 0;
                        detail.InvoiceXSDetailTax = 0;
                        invoice.Details.Add(detail);
                    }
                }

                CountExchangeRate();

                this.gridControl1.RefreshDataSource();
                f.Dispose();
            }
        }

        //Invoice
        private void barButtonItemInvoice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region 作廢
            //ZX.ChooseInvoiceForm f = new Book.UI.Invoices.ZX.ChooseInvoiceForm();
            //if (f.ShowDialog() == DialogResult.OK)
            //{
            //    if (f.Key != null && f.Key.Count > 0)
            //    {
            //        if (invoice.Details.Count > 0 && string.IsNullOrEmpty(invoice.Details[0].ProductId))
            //            invoice.Details.RemoveAt(0);
            //        Model.InvoicePackingDetail detail = f.Key[0];
            //        invoice.InvoiceXOId = detail.InvoiceXOId;
            //        if (detail.InvoiceXO != null)
            //        {
            //            this.buttonEditCompany.EditValue = detail.InvoiceXO.Customer;
            //            this.newChooseXScustomer.EditValue = detail.InvoiceXO.xocustomer;
            //        }

            //        foreach (Model.InvoicePackingDetail model in f.Key)
            //        {
            //            Model.InvoiceXSDetail xtdetail = new InvoiceXSDetail();
            //            xtdetail.Inumber = invoice.Details.Count + 1;
            //            xtdetail.Invoice = invoice;
            //            xtdetail.InvoiceId = invoice.InvoiceId;
            //            xtdetail.InvoiceXOId = model.InvoiceXOId;
            //            xtdetail.InvoiceXSDetailId = Guid.NewGuid().ToString();
            //            xtdetail.InvoiceXSDetailQuantity = 0;
            //            xtdetail.InvoiceXODetailId = model.InvoiceXODetailId;
            //            xtdetail.InvoiceXODetail = model.InvoiceXODetail;
            //            xtdetail.Product = model.Product;
            //            xtdetail.ProductId = model.ProductId;
            //            xtdetail.InvoiceProductUnit = model.ProductUnit;
            //            xtdetail.Donatetowards = false;
            //            xtdetail.InvoiceXSDetailPrice = model.UnitPrice;
            //            xtdetail.InvoiceAllowance = 0;
            //            xtdetail.InvoiceXSDetailMoney = 0;
            //            xtdetail.InvoiceXSDetailTaxPrice = 0;
            //            xtdetail.InvoiceXSDetailTaxMoney = 0;
            //            xtdetail.InvoiceXSDetailFPQuantity = 0;
            //            xtdetail.InvoiceXSDetailTax = 0;
            //            invoice.Details.Add(xtdetail);
            //        }
            //        this.gridControl1.RefreshDataSource();
            //    }
            //    f.Dispose();
            //    GC.Collect();
            //} 
            #endregion

            if (this.action == "view") return;

            IP.ChooseInvoiceForm f = new Book.UI.Invoices.IP.ChooseInvoiceForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                if (f.SelectItem != null)
                {
                    if (f.SelectItem.Details.Any(D => D.InvoiceXODetail == null))
                    {
                        MessageBox.Show("Invoice中的一項或多項不包含客戶訂單信息", "", MessageBoxButtons.OK);
                        return;
                    }

                    if (invoice.Details.Count > 0 && string.IsNullOrEmpty(invoice.Details[0].ProductId))
                        invoice.Details.RemoveAt(0);

                    Model.PackingInvoiceHeader ph = f.SelectItem;
                    Model.Customer customer = customerManager.Get(ph.CustomerId);
                    this.buttonEditCompany.EditValue = customer;
                    this.newChooseXScustomer.EditValue = customer;

                    foreach (Model.PackingInvoiceDetail d in ph.Details)
                    {

                        Model.InvoiceXSDetail xtdetail = new InvoiceXSDetail();
                        xtdetail.Inumber = invoice.Details.Count + 1;
                        xtdetail.Invoice = invoice;
                        xtdetail.InvoiceId = invoice.InvoiceId;
                        xtdetail.InvoiceXOId = d.InvoiceXODetail.InvoiceId;
                        xtdetail.InvoiceXSDetailId = Guid.NewGuid().ToString();
                        xtdetail.InvoiceXSDetailQuantity = (double)d.Quantity;
                        xtdetail.InvoiceXODetailId = d.InvoiceXODetail.InvoiceXODetailId;
                        xtdetail.InvoiceXODetail = d.InvoiceXODetail;
                        xtdetail.Product = d.Product;
                        xtdetail.ProductId = d.Product.ProductId;
                        xtdetail.InvoiceProductUnit = d.InvoiceXODetail.InvoiceProductUnit;
                        xtdetail.Donatetowards = false;
                        xtdetail.InvoiceXSDetailPrice = d.UnitPrice;
                        //xtdetail.InvoiceXSDetailPrice = ConvertPrice(xos);
                        ConvertPrice(d.InvoiceXODetail, xtdetail);    //2018年11月26日20:50:52：计算总价时才换算台币
                        xtdetail.InvoiceAllowance = 0;
                        xtdetail.InvoiceXSDetailMoney = d.Amount;
                        xtdetail.InvoiceXSDetailTaxPrice = 0;
                        xtdetail.InvoiceXSDetailTaxMoney = d.Amount;
                        xtdetail.InvoiceXSDetailFPQuantity = 0;
                        xtdetail.InvoiceXSDetailTax = 0;
                        xtdetail.InvoiceXSDetailNote = d.InvoiceXODetail.Remark;
                        xtdetail.InvoiceNO = d.PackingInvoiceHeaderId;
                        invoice.Details.Add(xtdetail);
                    }
                    this.gridControl1.RefreshDataSource();

                    UpdateMoneyFields();
                }
            }
        }

        private void btn_GetNewPrice_Click(object sender, EventArgs e)
        {
            string PriceRange;
            string[] PriAndRange;
            foreach (var item in invoice.Details)
            {
                PriceRange = customerProductPriceManager.SelectPriceByProductId(item.ProductId);
                PriAndRange = (PriceRange != null && PriceRange != "") ? PriceRange.Split(',') : null;
                if (PriAndRange != null)
                    foreach (string str in PriAndRange)
                    {
                        double quantityStart = double.Parse((str.Split('/')[0] != null && str.Split('/')[0] != "") ? str.Split('/')[0] : "0");
                        double quantityEnd = double.Parse((str.Split('/')[1] != null && str.Split('/')[1] != "") ? str.Split('/')[1] : "0");
                        if (item.InvoiceXSDetailQuantity <= 0)
                        {
                            item.InvoiceXSDetailPrice = 0;
                            break;
                        }
                        if (item.InvoiceXSDetailQuantity >= quantityStart && item.InvoiceXSDetailQuantity <= quantityEnd)
                        {
                            item.InvoiceXSDetailPrice = decimal.Parse((str.Split('/')[2] != null && str.Split('/')[2] != "") ? str.Split('/')[2] : "0");
                            item.InvoiceXSDetailMoney = item.InvoiceXSDetailPrice * decimal.Parse(item.InvoiceXSDetailQuantity.ToString());
                            item.InvoiceXSDetailTaxMoney = item.InvoiceXSDetailMoney + item.InvoiceXSDetailTax;
                            break;
                        }
                    }
            }
            this.gridControl1.RefreshDataSource();
            UpdateMoneyFields();
        }

        //稅率變化
        private void spinEditInvoiceTaxRate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int index = e.Button.Index - 1;
            switch (index)
            {
                case 1:
                    flag = 1;
                    TaxMethod();
                    break;
                case 2:
                    flag = 2;
                    TaxMethod();
                    break;
                default:
                    flag = 0;
                    TaxMethod();
                    //this.spinEditInvoiceTaxRate.Properties.Buttons[1].Enabled = false;
                    //this.spinEditInvoiceTaxRate.Properties.Buttons[2].Enabled = true;
                    //this.spinEditInvoiceTaxRate.Properties.Buttons[3].Enabled = true;

                    break;
            }
            this.gridControl1.RefreshDataSource();
        }

        private void spinEditInvoiceTaxRate_EditValueChanged(object sender, EventArgs e)
        {
            if (this.action != "view")
            {
                foreach (Model.InvoiceXSDetail detail in invoice.Details)
                {
                    this.textEditInvoiceId.Text.Equals(null);
                    if (detail.Product == null || string.IsNullOrEmpty(detail.Product.ProductId)) continue;
                    if (detail.Donatetowards != null && detail.Donatetowards == true) continue;
                    //if (detail.InvoiceXODetailQuantity == 0 || detail.InvoiceXODetailQuantity == 0) continue;
                    if (flag == 0)
                    {
                        detail.InvoiceXSDetailTaxPrice = 0;
                        detail.InvoiceXSDetailTax = 0;
                        detail.InvoiceXSDetailTaxMoney = detail.InvoiceXSDetailMoney;
                        this.spinEditInvoiceTaxRate.EditValue = 0;
                    }
                    if (flag == 1)
                    {
                        if (detail.InvoiceXSDetailPrice == null)
                        {
                            detail.InvoiceXSDetailPrice = 0;
                        }
                        detail.InvoiceXSDetailTaxPrice = 0;
                        detail.InvoiceXSDetailTax = detail.InvoiceXSDetailPrice.Value * decimal.Parse(detail.InvoiceXSDetailQuantity.ToString()) * decimal.Parse(this.spinEditInvoiceTaxRate.Text) / 100;

                        detail.InvoiceXSDetailTax = this.GetDecimal(detail.InvoiceXSDetailTax.Value, BL.V.SetDataFormat.XSZJXiao.Value);

                        detail.InvoiceXSDetailTaxMoney = detail.InvoiceXSDetailTax + detail.InvoiceXSDetailMoney;
                    }
                    else
                    {
                        if (detail.InvoiceXSDetailPrice == null)
                        {
                            detail.InvoiceXSDetailPrice = 0;
                        }
                        detail.InvoiceXSDetailTaxPrice = 0;
                        detail.InvoiceXSDetailTax = detail.InvoiceXSDetailMoney - detail.InvoiceXSDetailMoney / (1 + decimal.Parse(this.spinEditInvoiceTaxRate.Text) / 100);
                        detail.InvoiceXSDetailTax = this.GetDecimal(detail.InvoiceXSDetailTax.Value, BL.V.SetDataFormat.XSZJXiao.Value);
                        detail.InvoiceXSDetailTaxMoney = detail.InvoiceXSDetailMoney;
                    }

                }
                this.gridControl1.RefreshDataSource();
                this.spinEditInvoiceTaxRate.Properties.Buttons[1].Enabled = flag == 0 ? false : true;
                this.spinEditInvoiceTaxRate.Properties.Buttons[2].Enabled = flag == 1 ? false : true;
                this.spinEditInvoiceTaxRate.Properties.Buttons[3].Enabled = flag == 2 ? false : true;
                this.UpdateMoneyFields();
            }
        }

        //内销打印
        private void bar_NeixiaoPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            R0_ZZD ro = new R0_ZZD(this.Invoice.InvoiceId);
            ro.ShowPreviewDialog();
        }

        //内销打印无价格
        private void bar_NeixiaoPrintNoPrice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            R0_ZZD_NoPrice ro = new R0_ZZD_NoPrice(this.Invoice.InvoiceId);
            ro.ShowPreviewDialog();
        }

        //日期变化，税率变化
        private void dateEditInvoiceDate_EditValueChanged(object sender, EventArgs e)
        {
            //2019年4月3日18:43:04 改日期，ID也改
            if (this.action == "insert" && dateEditInvoiceDate.EditValue != null)
            {
                this.Invoice.InvoiceId = this.invoiceManager.GetIdByMonth(dateEditInvoiceDate.DateTime);
                this.textEditInvoiceId.Text = this.Invoice.InvoiceId;
            }


            //2018年11月26日20:51:47：计算总价时才换算台币

            if (this.action == "view")
                return;

            string currency = null;

            foreach (var item in invoice.Details)
            {
                if (item.InvoiceXODetail == null)
                    continue;

                currency = invoiceXOManager.GetCurrencyByInvoiceId(item.InvoiceXODetail.InvoiceId);

                if (item.InvoiceXODetail.InvoiceXODetailPrice == 0 || currency == "新台幣")
                    continue;
                else
                {
                    //decimal price = 0;
                    decimal rate = exchangeRateManager.GetRateByDateAndCurrency(this.dateEditInvoiceDate.DateTime, currency);
                    //if (rate != 0)
                    //    price = item.InvoiceXODetail.InvoiceXODetailPrice.Value * rate;
                    //else
                    //    price = item.InvoiceXODetail.InvoiceXODetailPrice.Value;

                    //item.InvoiceXSDetailPrice = price;
                    item.Currency = currency;
                    item.ExchangeRate = rate;


                    //if (flag == 0) //免税
                    //{
                    //    item.InvoiceXSDetailMoney = item.InvoiceXSDetailTaxMoney = this.GetDecimal(price * Convert.ToDecimal(item.InvoiceXSDetailQuantity) - Convert.ToDecimal(item.InvoiceAllowance), BL.V.SetDataFormat.XSJEXiao.Value);
                    //}
                    //if (flag == 1) //外加
                    //{
                    //    item.InvoiceXSDetailMoney = this.GetDecimal(price * Convert.ToDecimal(item.InvoiceXSDetailQuantity) - Convert.ToDecimal(item.InvoiceAllowance), BL.V.SetDataFormat.XSJEXiao.Value);
                    //    item.InvoiceXSDetailTax = this.GetDecimal(price * Convert.ToDecimal(item.InvoiceXSDetailQuantity) * this.spinEditInvoiceTaxRate.Value / 100, BL.V.SetDataFormat.XSJEXiao.Value);
                    //    item.InvoiceXSDetailTaxMoney = item.InvoiceXSDetailMoney + item.InvoiceXSDetailTax;
                    //}
                }
            }

            this.gridControl1.RefreshDataSource();
            this.UpdateMoneyFields();
        }

        //币别变化，税率变化
        private void comboBoxEditCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.action != "view")
            {
                CountExchangeRate();
            }
        }

        private void CountExchangeRate()
        {
            foreach (var item in invoice.Details)
            {
                //只针对手动添加商品，从客户订单来的商品不在这里计算
                if (string.IsNullOrEmpty(item.InvoiceXODetailId))
                {
                    string currency = comboBoxEditCurrency.Text;

                    if (!string.IsNullOrEmpty(currency))
                    {
                        decimal rate = exchangeRateManager.GetRateByDateAndCurrency(this.dateEditInvoiceDate.DateTime, currency);
                        item.Currency = currency;
                        item.ExchangeRate = rate;
                    }
                }
            }

            this.gridControl1.RefreshDataSource();
            this.UpdateMoneyFields();
        }
    }
}