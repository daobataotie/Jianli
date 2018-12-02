﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Book.UI.Settings.BasicData.Employees;
using System.Linq;

namespace Book.UI.Invoices.IP
{
    public partial class EditFormInvoice : BaseEditForm
    {
        Model.PackingInvoiceHeader packingInvoiceHeader = new Model.PackingInvoiceHeader();
        BL.PackingInvoiceHeaderManager packingInvoiceHeaderManager = new Book.BL.PackingInvoiceHeaderManager();
        BL.PortManager portManager = new Book.BL.PortManager();

        public EditFormInvoice()
        {
            InitializeComponent();

            this.ncc_Customer.Choose = new Settings.BasicData.Customs.ChooseCustoms();
            this.requireValueExceptions.Add(Model.PackingInvoiceHeader.PRO_InvoiceNo, new AA("InvoiceNo 不能為空！", this.txt_InvoiceNo));
            this.requireValueExceptions.Add(Model.PackingInvoiceHeader.PRO_InvoiceDate, new AA("Date 不能為空！", this.Date_InvoiceDate));

            this.requireValueExceptions.Add(Model.PackingInvoiceDetail.PRO_Number, new AA("No 不能為空！", this.gridControl3));

            this.action = "view";

            this.bindingSourcePort.DataSource = portManager.Select();
        }

        int LastFlag = 0; //页面载 入时是否执行 last方法
        public EditFormInvoice(string invoiceId)
            : this()
        {
            this.packingInvoiceHeader = this.packingInvoiceHeaderManager.Get(invoiceId);
            if (this.packingInvoiceHeader == null)
                throw new ArithmeticException("invoiceid");
            this.action = "view";
            if (this.action == "view")
                LastFlag = 1;
        }

        public EditFormInvoice(Model.PackingInvoiceHeader invoice)
            : this()
        {
            if (invoice == null)
                throw new ArithmeticException("invoiceid");
            this.packingInvoiceHeader = invoice;
            this.action = "view";
            if (this.action == "view")
                LastFlag = 1;
        }


        //public override BaseListForm GetListForm()
        //{
        //    return new ListForm();
        //}

        public override Book.Model.Invoice Invoice
        {
            get
            {
                return packingInvoiceHeader;
            }
            set
            {
                if (value is Model.InvoiceXO)
                {
                    packingInvoiceHeader = packingInvoiceHeaderManager.Get((value as Model.PackingInvoiceHeader).InvoiceNo);
                }
            }
        }


        protected override void AddNew()
        {
            this.packingInvoiceHeader = new Book.Model.PackingInvoiceHeader();
            packingInvoiceHeader.InvoiceDate = DateTime.Now;


            this.action = "insert";
        }

        public override void Refresh()
        {
            if (this.packingInvoiceHeader == null)
                this.AddNew();
            else
            {
                if (this.action == "view")  //打印時去掉PLTNO，修改時刷新一下顯示出來
                {
                    this.packingInvoiceHeader = this.packingInvoiceHeaderManager.GetDetail(this.packingInvoiceHeader.InvoiceNo);
                }
            }

            this.txt_InvoiceNo.Text = this.packingInvoiceHeader.InvoiceNo;
            this.Date_InvoiceDate.EditValue = this.packingInvoiceHeader.InvoiceDate;
            this.ncc_Customer.EditValue = this.packingInvoiceHeader.Customer;
            if (this.packingInvoiceHeader.Customer != null)
            {
                this.txt_CustomerName.EditValue = this.packingInvoiceHeader.Customer.CustomerFullName;
                this.txt_ADDRESS.EditValue = this.packingInvoiceHeader.Customer.CustomerAddress;
            }
            else
            {
                this.txt_CustomerName.EditValue = "";
                this.txt_ADDRESS.EditValue = "";
            }
            this.txt_PerSS.Text = this.packingInvoiceHeader.PerSS;
            this.date_Sailing.EditValue = this.packingInvoiceHeader.SailingOnOrAbout;
            this.lue_From.EditValue = this.packingInvoiceHeader.FromPortId;
            this.lue_TO.EditValue = this.packingInvoiceHeader.ToPortId;
            this.txt_MarkNos.Text = this.packingInvoiceHeader.MarkNos;

            switch (this.action)
            {
                case "insert":
                    this.gridView3.OptionsBehavior.Editable = true;
                    break;
                case "update":
                    this.gridView3.OptionsBehavior.Editable = true;
                    break;
                default:
                    this.gridView3.OptionsBehavior.Editable = false;
                    break;
            }

            this.bindingSourceDetail.DataSource = this.packingInvoiceHeader.Details;

            base.Refresh();

            this.txt_CustomerName.Properties.ReadOnly = true;
            this.txt_ADDRESS.Properties.ReadOnly = true;
            this.txt_PerSS.Properties.ReadOnly = true;
            this.txt_MarkNos.Properties.ReadOnly = true;
            this.date_Sailing.Properties.ReadOnly = true;
            this.lue_From.Properties.ReadOnly = true;
            this.lue_TO.Properties.ReadOnly = true;

            if (this.action == "update")
                this.txt_InvoiceNo.Properties.ReadOnly = true;
        }

        protected override void Save(Helper.InvoiceStatus status)
        {
            if (!this.gridView3.PostEditor() || !this.gridView3.UpdateCurrentRow())
                return;

            this.packingInvoiceHeader.InvoiceNo = this.txt_InvoiceNo.Text.Trim();
            if (this.Date_InvoiceDate.EditValue != null)
                this.packingInvoiceHeader.InvoiceDate = this.Date_InvoiceDate.DateTime;
            if (this.ncc_Customer.EditValue != null)
            {
                this.packingInvoiceHeader.CustomerId = (this.ncc_Customer.EditValue as Model.Customer).CustomerId;
                this.packingInvoiceHeader.Customer = this.ncc_Customer.EditValue as Model.Customer;
            }
            this.packingInvoiceHeader.PerSS = this.txt_PerSS.Text;
            if (this.date_Sailing.EditValue != null)
                this.packingInvoiceHeader.SailingOnOrAbout = this.date_Sailing.DateTime;
            this.packingInvoiceHeader.FromPortId = this.lue_From.EditValue == null ? null : this.lue_From.EditValue.ToString();
            this.packingInvoiceHeader.ToPortId = this.lue_TO.EditValue == null ? null : this.lue_TO.EditValue.ToString();
            this.packingInvoiceHeader.MarkNos = this.txt_MarkNos.Text;

            if (this.action == "insert")
                this.packingInvoiceHeaderManager.Insert(this.packingInvoiceHeader);
            if (this.action == "update")
                this.packingInvoiceHeaderManager.Update(this.packingInvoiceHeader);
        }

        protected override void MoveLast()
        {
            if (this.LastFlag == 1)
            {
                this.LastFlag = 0;
                return;
            }
            this.packingInvoiceHeader = this.packingInvoiceHeaderManager.GetLast();
        }

        protected override void MoveFirst()
        {
            this.packingInvoiceHeader = this.packingInvoiceHeaderManager.GetFirst();
        }

        protected override void MovePrev()
        {
            Model.PackingInvoiceHeader model = this.packingInvoiceHeaderManager.GetPrev(this.packingInvoiceHeader);
            if (model == null)
                throw new InvalidOperationException(Properties.Resources.ErrorNoMoreRows);
            this.packingInvoiceHeader = model;
        }

        protected override void MoveNext()
        {
            Model.PackingInvoiceHeader model = this.packingInvoiceHeaderManager.GetNext(this.packingInvoiceHeader);
            if (model == null)
                throw new InvalidOperationException(Properties.Resources.ErrorNoMoreRows);
            this.packingInvoiceHeader = model;
        }

        protected override bool HasRows()
        {
            return this.packingInvoiceHeaderManager.HasRows();
        }

        protected override bool HasRowsPrev()
        {
            return this.packingInvoiceHeaderManager.HasRowsBefore(this.packingInvoiceHeader);
        }

        protected override bool HasRowsNext()
        {
            return this.packingInvoiceHeaderManager.HasRowsAfter(this.packingInvoiceHeader);
        }

        protected override void Delete()
        {
            //if (this._invoicePacking == null)
            //    return;
            //if (MessageBox.Show(Properties.Resources.ConfirmToDelete, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    this._invoicePackingManager.Delete(this._invoicePacking.InvoicePackingId);
            //    this._invoicePacking = this._invoicePackingManager.GetNext(this._invoicePacking);
            //    if (this._invoicePacking == null)
            //        this._invoicePacking = this._invoicePackingManager.GetLast();
            //}
        }

        protected override void TurnNull()
        {
            if (this.packingInvoiceHeader == null)
                return;
            if (MessageBox.Show(Properties.Resources.ConfirmToDelete, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.packingInvoiceHeaderManager.Delete(this.packingInvoiceHeader.InvoiceNo);
                this.packingInvoiceHeader = this.packingInvoiceHeaderManager.GetNext(this.packingInvoiceHeader);
                if (this.packingInvoiceHeader == null)
                    this.packingInvoiceHeader = this.packingInvoiceHeaderManager.GetLast();
            }
        }

        public override BaseListForm GetListForm()
        {
            return new ListFormInvoice();
        }

        protected override DevExpress.XtraReports.UI.XtraReport GetReport()
        {
            return new ROInvoice(this.packingInvoiceHeader);
        }

        /// <summary>
        /// 添加客户订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string tableCode()
        {
            return "PackingInvoice";
        }

        protected override int AuditState()
        {
            return this.packingInvoiceHeader.AuditState.HasValue ? this.packingInvoiceHeader.AuditState.Value : 0;
        }

        private void gridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "gridColumn10")
            {
                Model.PackingInvoiceDetail detail = this.bindingSourceDetail.Current as Model.PackingInvoiceDetail;
                if (detail != null)
                {
                    decimal price = 0;
                    decimal.TryParse((e.Value == null ? "0" : e.Value.ToString()), out price);
                    detail.Amount = detail.Quantity * price;

                    this.gridControl3.RefreshDataSource();
                }
            }
        }

        private void bar_ChoosePackingList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.action != "view")
            {
                ChoosePackingListForm f = new ChoosePackingListForm();
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    this.ncc_Customer.EditValue = this.packingInvoiceHeader.Customer = f.SelectItem.Customer = new BL.CustomerManager().Get(f.SelectItem.CustomerId);
                    this.txt_CustomerName.Text = f.SelectItem.Customer.CustomerFullName;
                    this.txt_ADDRESS.Text = f.SelectItem.Customer.CustomerAddress;
                    this.txt_PerSS.Text = f.SelectItem.PerSS;
                    this.date_Sailing.EditValue = f.SelectItem.SailingOnOrAbout;
                    this.lue_From.EditValue = f.SelectItem.FromPortId;
                    this.lue_TO.EditValue = f.SelectItem.ToPortId;
                    this.txt_MarkNos.Text = f.SelectItem.MarkNos;

                    this.packingInvoiceHeader.Details = new List<Model.PackingInvoiceDetail>();
                    Model.PackingInvoiceDetail detail;
                    foreach (var item in f.SelectItem.Details)
                    {
                        detail = new Book.Model.PackingInvoiceDetail();
                        detail.PackingInvoiceDetailId = Guid.NewGuid().ToString();
                        detail.PackingInvoiceHeader = this.packingInvoiceHeader;
                        detail.ProductId = item.ProductId;
                        detail.Product = item.Product;
                        detail.PONo = item.PONo;
                        detail.Quantity = item.Quantity;

                        this.packingInvoiceHeader.Details.Add(detail);
                    }

                    this.bindingSourceDetail.DataSource = this.packingInvoiceHeader.Details;
                    this.gridControl3.RefreshDataSource();
                }
            }
        }
    }
}
