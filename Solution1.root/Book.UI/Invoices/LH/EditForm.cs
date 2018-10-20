using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Book.UI.Invoices.LH
{
    public partial class EditForm : BaseEditForm
    {
        protected BL.InvoiceLHManager invoiceLHManager = new Book.BL.InvoiceLHManager();
        protected BL.InvoiceLHDetailManager invoiceLHDetailManager = new Book.BL.InvoiceLHDetailManager();

        protected Model.InvoiceLH invoice;
        int LastFlag = 0; //页面载入时是否执行 last方法

        #region Constructors

        public EditForm()
        {
            InitializeComponent();

            this.requireValueExceptions.Add("Id", new AA(Properties.Resources.RequireDataForId, this.textEditInvoiceId));
            this.requireValueExceptions.Add("Date", new AA(Properties.Resources.RequireDataOfInvoiceDate, this.dateEditInvoiceDate));
            this.requireValueExceptions.Add("Employee0", new AA(Properties.Resources.RequiredDataOfEmployee0, this.buttonEditEmployee));
            this.requireValueExceptions.Add("Details0", new AA(Properties.Resources.RequireDataForDetails, this.gridControlOut));
            this.requireValueExceptions.Add("Details1", new AA(Properties.Resources.RequireDataForDetails, this.gridControlIn));

            this.invalidValueExceptions.Add(Model.InvoiceLH.PROPERTY_INVOICEID, new AA(Properties.Resources.EntityExists, this.textEditInvoiceId));

            this.action = "view";
            this.buttonEditEmployee.Choose = new ChooseEmployee();
            this.EmpAudit.Choose = new ChooseEmployee();
        }

        public EditForm(string invoiceId)
            : this()
        {
            this.invoice = this.invoiceLHManager.Get(invoiceId);
            if (this.invoice == null)
                throw new ArithmeticException("invoiceid");
            this.action = "view";
            if (this.action == "view")
                LastFlag = 1;
        }

        public EditForm(Model.InvoiceLH invoiceLH)
            : this()
        {
            if (invoiceLH == null)
                throw new ArithmeticException("invoiceid");
            this.invoice = invoiceLH;
            this.action = "view";
            if (this.action == "view")
                LastFlag = 1;
        }

        #endregion

        private void EditForm_Load(object sender, EventArgs e)
        {
            this.bindingSourceConveyanceMethod.DataSource = new BL.ConveyanceMethodManager().Select();

            string sql = "select CnName from ProductUnit group by CnName";
            this.bindingSourceProductUnit.DataSource = invoiceLHManager.Query(sql, 100, "").Tables[0];
        }

        protected override string tableCode()
        {
            return "InvoiceLH";
        }

        protected override int AuditState()
        {
            return this.invoice.AuditState.HasValue ? this.invoice.AuditState.Value : 0;
        }

        protected override string getName()
        {
            string formName = this.GetType().FullName;
            formName = formName.Substring(formName.IndexOf('.') + 1).Substring(formName.Substring(formName.IndexOf('.') + 1).IndexOf('.') + 1);
            return formName;
        }

        private void update()
        {
            this.invoice.DetailsIn = invoiceLHDetailManager.Select("I", this.invoice);
            this.invoice.DetailsOut = invoiceLHDetailManager.Select("O", this.invoice);


        }

        private void simpleButtonAppendIn_Click(object sender, EventArgs e)
        {
            ChooseProductForm f = new ChooseProductForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                Model.InvoiceLHDetail detail = new Book.Model.InvoiceLHDetail();
                detail.InvoiceLHDetailId = Guid.NewGuid().ToString();
                detail.Invoice = this.invoice;
                detail.Product = f.SelectedItem as Model.Product;
                detail.ProductId = (f.SelectedItem as Model.Product).ProductId;
            }
        }

        private void simpleButtonRemoveIn_Click(object sender, EventArgs e)
        {
            if (this.bindingSourceIn.Current != null)
            {
                this.invoice.DetailsIn.Remove(this.bindingSourceIn.Current as Model.InvoiceLHDetail);
                if (this.invoice.DetailsIn.Count == 0)
                {
                    Model.InvoiceLHDetail detail = new Model.InvoiceLHDetail();
                    detail.InvoiceLHDetailId = Guid.NewGuid().ToString();
                }
            }
        }

        public override BaseListForm GetListForm()
        {
            return new ListForm();
        }

        public override Book.Model.Invoice Invoice
        {
            get
            {
                return invoice;
            }
            set
            {
                if (value is Model.InvoiceLH)
                {
                    invoice = invoiceLHManager.Get((value as Model.InvoiceLH).InvoiceId);
                }
            }
        }

        private void simpleButtonAppendOut_Click(object sender, EventArgs e)
        {
            ChooseProductForm f = new ChooseProductForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                Model.InvoiceLHDetail detail = new Book.Model.InvoiceLHDetail();
                detail.InvoiceLHDetailId = Guid.NewGuid().ToString();
                detail.Invoice = this.invoice;
                detail.Product = f.SelectedItem as Model.Product;
                detail.ProductId = (f.SelectedItem as Model.Product).ProductId;

            }
        }

        private void simpleButtonRemoveOut_Click(object sender, EventArgs e)
        {
            if (this.bindingSourceOut.Current != null)
            {
                this.invoice.DetailsOut.Remove(this.bindingSourceOut.Current as Model.InvoiceLHDetail);
                if (this.invoice.DetailsOut.Count == 0)
                {
                    Model.InvoiceLHDetail detail = new Model.InvoiceLHDetail();
                    detail.InvoiceLHDetailId = Guid.NewGuid().ToString();

                }
                //this.gridControlOut.RefreshDataSource();
            }
        }

        protected override void AddNew()
        {
            this.invoice = new Model.InvoiceLH();

            this.invoice.InvoiceId = this.invoiceLHManager.GetNewId();
            this.invoice.InvoiceDate = DateTime.Now;


            if (this.action == "insert")
            {
                Model.InvoiceLHDetail detailOut = new Model.InvoiceLHDetail();
                detailOut.InvoiceLHDetailId = Guid.NewGuid().ToString();

            }
        }

        protected override void MoveNext()
        {
            Model.InvoiceLH invoice = this.invoiceLHManager.GetNext(this.invoice);
            if (invoice == null)
                throw new InvalidOperationException(Properties.Resources.ErrorNoMoreRows);

            this.invoice = this.invoiceLHManager.Get(invoice.InvoiceId);
        }

        protected override void MovePrev()
        {
            Model.InvoiceLH invoice = this.invoiceLHManager.GetPrev(this.invoice);
            if (invoice == null)
                throw new InvalidOperationException(Properties.Resources.ErrorNoMoreRows);

            this.invoice = this.invoiceLHManager.Get(invoice.InvoiceId);
        }

        protected override void MoveFirst()
        {
            this.invoice = this.invoiceLHManager.Get(this.invoiceLHManager.GetFirst() == null ? "" : this.invoiceLHManager.GetFirst().InvoiceId);
        }

        protected override void MoveLast()
        {
            if (LastFlag == 1) { LastFlag = 0; return; }
            this.invoice = this.invoiceLHManager.Get(this.invoiceLHManager.GetLast() == null ? "" : this.invoiceLHManager.GetLast().InvoiceId);
        }

        protected override bool HasRows()
        {
            return this.invoiceLHManager.HasRows();
        }

        protected override bool HasRowsNext()
        {
            return this.invoiceLHManager.HasRowsAfter(this.invoice);
        }

        protected override bool HasRowsPrev()
        {
            return this.invoiceLHManager.HasRowsBefore(this.invoice);
        }

        public override void Refresh()
        {
            if (this.invoice == null)
            {
                this.invoice = new Book.Model.InvoiceLH();
                this.action = "insert";
            }
            else
            {
                if (this.action == "view")
                    this.invoice = this.invoiceLHManager.Get(invoice.InvoiceId);
            }

            this.EmpAudit.EditValue = this.invoice.AuditEmp;
            this.textEditAuditState.Text = this.invoice.AuditStateName;

            switch (this.action)
            {
                case "insert":

                    //this.gridViewIn.OptionsBehavior.Editable = true;
                    //this.gridViewOut.OptionsBehavior.Editable = true;
                    break;

                case "update":

                    //this.gridViewIn.OptionsBehavior.Editable = true;
                    //this.gridViewOut.OptionsBehavior.Editable = true;

                    break;
                case "view":

                    //this.gridViewIn.OptionsBehavior.Editable = false;
                    //this.gridViewOut.OptionsBehavior.Editable = false;
                    break;
                default:
                    break;
            }
            base.Refresh();
        }

        protected override void Save(Helper.InvoiceStatus status)
        {
            this.invoice.InvoiceStatus = (int)status;

            //if (!this.gridViewIn.PostEditor() || !this.gridViewIn.UpdateCurrentRow())
            //    return;
            //if (!this.gridViewOut.PostEditor() || !this.gridViewOut.UpdateCurrentRow())
            //    return;

            switch (this.action)
            {
                case "insert":
                    this.invoiceLHManager.Insert(this.invoice);
                    break;

                case "update":
                    this.invoiceLHManager.Update(this.invoice);
                    break;
            }
        }

        protected override void Delete()
        {
            this.invoiceLHManager.Delete(this.invoice.InvoiceId);
        }

        protected override void TurnNull()
        {
            if (this.invoice == null)
                return;
            if (MessageBox.Show(Properties.Resources.ConfirmToDelete, this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            this.invoiceLHManager.TurnNull(this.invoice.InvoiceId);
            this.invoice = this.invoiceLHManager.GetNext(this.invoice);
            if (this.invoice == null)
            {
                this.invoice = this.invoiceLHManager.GetLast();
            }
        }

        protected override DevExpress.XtraReports.UI.XtraReport GetReport()
        {
            return new R01(this.invoice.InvoiceId);
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {

        }

        //選取客戶訂單
        private void barInvoiceXO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}