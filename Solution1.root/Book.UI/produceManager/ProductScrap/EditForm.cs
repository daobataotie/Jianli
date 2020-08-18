using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Book.UI.Invoices;
using System.Linq;

namespace Book.UI.produceManager.ProductScrap
{
    public partial class EditForm : Book.UI.Settings.BasicData.BaseEditForm
    {
        BL.DepotPositionManager _depotPositionManager = new Book.BL.DepotPositionManager();
        BL.ProductScrapManager _manager = new Book.BL.ProductScrapManager();
        Model.ProductScrap _productScrap;

        int LastFlag = 0;
        public EditForm()
        {
            InitializeComponent();

            this.invalidValueExceptions.Add(Model.ProductScrap.PRO_ProductScrapDate, new AA(Properties.Resources.DateNotNull, this.date_ProductScarpDate));
            this.invalidValueExceptions.Add(Model.ProductScrapDetail.PRO_DepotPositionId, new AA(Properties.Resources.DepotInStockQuertyIsNull, this.gridControl1));

            this.ncc_Employee.Choose = new Settings.BasicData.Employees.ChooseEmployee();
            this.bindingSourceDepot.DataSource = new BL.DepotManager().Select();
            this.action = "view";
        }

        public EditForm(Model.ProductScrap productScrap)
            : this()
        {
            if (productScrap == null)
                throw new ArithmeticException("invoiceid");
            this._productScrap = productScrap;
            this.action = "view";
            LastFlag = 1;
        }

        public EditForm(Model.ProductScrap productScrap, string action)
            : this()
        {
            this._productScrap = productScrap;
            this.action = action;
            if (this.action == "view")
                LastFlag = 1;
        }


        protected override bool HasRows()
        {
            return this._manager.HasRows();
        }

        protected override bool HasRowsNext()
        {
            return this._manager.HasRowsAfter(this._productScrap);
        }

        protected override bool HasRowsPrev()
        {
            return this._manager.HasRowsBefore(this._productScrap);
        }

        protected override void MoveFirst()
        {
            this._productScrap = this._manager.GetFirst();
        }

        protected override void MoveLast()
        {
            if (this.LastFlag == 1)
            {
                this.LastFlag = 0;
                return;
            }
            this._productScrap = this._manager.GetLast();
        }

        protected override void MovePrev()
        {
            Model.ProductScrap model = this._manager.GetPrev(this._productScrap);
            if (model == null)
                throw new InvalidOperationException(Properties.Resources.ErrorNoMoreRows);
            this._productScrap = model;
        }

        protected override void MoveNext()
        {
            Model.ProductScrap model = this._manager.GetNext(this._productScrap);
            if (model == null)
                throw new InvalidOperationException(Properties.Resources.ErrorNoMoreRows);
            this._productScrap = model;
        }

        protected override void AddNew()
        {
            this._productScrap = new Book.Model.ProductScrap();
            this._productScrap.ProductScrapId = _manager.GetIdSimple(DateTime.Now);
            this._productScrap.Employee = BL.V.ActiveOperator.Employee;
            this._productScrap.ProductScrapDate = DateTime.Now;
        }

        protected override void Delete()
        {
            if (this._productScrap == null)
                return;
            if (MessageBox.Show(Properties.Resources.ConfirmToDelete, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Model.ProductScrap model = this._manager.GetNext(this._productScrap);
                this._manager.Delete(this._productScrap.ProductScrapId);
                if (model == null)
                    this._productScrap = this._manager.GetLast();
                else
                    this._productScrap = model;
            }
        }

        protected override void Save()
        {
            this.gridView1.PostEditor();
            this.gridView1.UpdateCurrentRow();

            this._productScrap.ProductScrapId = this.txt_ProductScrapID.Text;
            if (this.date_ProductScarpDate.EditValue != null)
                this._productScrap.ProductScrapDate = this.date_ProductScarpDate.DateTime;
            this._productScrap.Employee = this.ncc_Employee.EditValue as Model.Employee;
            if (this._productScrap != null)
                this._productScrap.EmployeeId = this._productScrap.Employee.EmployeeId;
            this._productScrap.DepotId = this.lue_Depot.EditValue == null ? null : this.lue_Depot.EditValue.ToString();
            this._productScrap.Note = this.txt_Note.Text;

            switch (this.action)
            {
                case "insert":
                    this._manager.Insert(this._productScrap);
                    break;
                case "update":
                    this._manager.Update(this._productScrap);
                    break;
            }
        }

        public override void Refresh()
        {
            if (this._productScrap == null)
            {
                this.AddNew();
                this.action = "insert";
            }
            else
            {
                if (this.action == "view")
                {
                    this._productScrap = this._manager.GetDetails(_productScrap.ProductScrapId);
                }
            }

            this.txt_ProductScrapID.EditValue = this._productScrap.ProductScrapId;
            this.date_ProductScarpDate.EditValue = this._productScrap.ProductScrapDate;
            this.ncc_Employee.EditValue = this._productScrap.Employee;
            this.lue_Depot.EditValue = this._productScrap.DepotId;
            this.txt_Note.EditValue = this._productScrap.Note;

            this.bindingSource1.DataSource = this._productScrap.Details;

            base.Refresh();

            this.txt_ProductScrapID.Properties.ReadOnly = true;
            switch (this.action)
            {
                case "view":
                    this.gridView1.OptionsBehavior.Editable = false;
                    break;
                default:
                    this.gridView1.OptionsBehavior.Editable = true;
                    break;
            }
        }

        protected override DevExpress.XtraReports.UI.XtraReport GetReport()
        {
            return new RO(this._productScrap);
        }

        private void lue_Depot_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lue_Depot.EditValue != null)
                this.bindingSourceDepotPosition.DataSource = this._depotPositionManager.Select(lue_Depot.EditValue.ToString());
            else
                this.bindingSourceDepotPosition.DataSource = null;

            this._productScrap.Details.ToList().ForEach((D) => D.DepotPositionId = null);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            ChooseProductForm f = new ChooseProductForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                Model.ProductScrapDetail model;
                if (ChooseProductForm.ProductList != null || ChooseProductForm.ProductList.Count > 0)
                {
                    foreach (Model.Product product in ChooseProductForm.ProductList)
                    {
                        model = new Book.Model.ProductScrapDetail();
                        model.ProductScrapDetailId = Guid.NewGuid().ToString();
                        model.ProductScrapId = this._productScrap.ProductScrapId;
                        model.ProductId = product.ProductId;
                        model.Product = product;

                        this._productScrap.Details.Add(model);
                    }
                }
                else if (f.SelectedItem != null)
                {
                    model = new Book.Model.ProductScrapDetail();
                    model.ProductScrapDetailId = Guid.NewGuid().ToString();
                    model.ProductScrapId = this._productScrap.ProductScrapId;
                    model.ProductId = (f.SelectedItem as Model.Product).ProductId;
                    model.Product = f.SelectedItem as Model.Product;

                    this._productScrap.Details.Add(model);
                }
            }

            this.gridControl1.RefreshDataSource();
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            if (this.bindingSource1.Current != null)
                this.bindingSource1.Remove(this.bindingSource1.Current);
            this.gridControl1.RefreshDataSource();
        }

        //搜索
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List f = new List();
            f.ShowDialog(this);
        }

    }
}