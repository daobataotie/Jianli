using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Book.UI.Settings.BasicData.SupplierCategory
{
    /*----------------------------------------------------------------
   // Copyright (C) 2008 - 2010  咸陽飛馳軟件有限公司
   //                     版權所有 圍著必究
   // 功能描述: 
   // 文 件 名：EditForm
   // 编 码 人: 茍波濤                   完成时间:2009-11-07
   // 修改原因：
   // 修 改 人:                          修改时间:
   // 修改原因：
   // 修 改 人:                          修改时间:
   //----------------------------------------------------------------*/
    public partial class ProductItemNoForm : BaseEditForm
    {
        private Model.ProductItemNo _productItemNo;
        private string oldId;   //用于修改
        private BL.ProductItemNoManager productItemNoManager = new Book.BL.ProductItemNoManager();

        public ProductItemNoForm()
        {
            InitializeComponent();

            this.requireValueExceptions.Add(Model.ProductItemNo.PRO_ItemNo, new AA("料號不能為空", this.txt_ItemNo));
            this.requireValueExceptions.Add(Model.ProductItemNo.PRO_InternalDescription, new AA("內部描述不能為空", this.txt_InternalDescription));

            this.action = "view";
        }

        #region Override

        protected override void AddNew()
        {
            this._productItemNo = new Model.ProductItemNo();
        }

        protected override void Delete()
        {
            if (this._productItemNo == null)
                return;
            if (MessageBox.Show(Properties.Resources.ConfirmToDelete, this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                return;
            this.productItemNoManager.Delete(this._productItemNo.ItemNo);
            this._productItemNo = this.productItemNoManager.GetNext(this._productItemNo);
            if (this._productItemNo == null)
            {
                this._productItemNo = this.productItemNoManager.GetLast();
            }
        }

        protected override bool HasRows()
        {
            return this.productItemNoManager.HasRows();
        }

        protected override bool HasRowsNext()
        {
            return this.productItemNoManager.HasRowsAfter(this._productItemNo);
        }

        protected override bool HasRowsPrev()
        {
            return this.productItemNoManager.HasRowsBefore(this._productItemNo);
        }

        protected override void IMECtrl()
        {
            Book.UI.Tools.IMEControl.IMECtrl(new Control[] { this, this.txt_ItemNo, this.txt_InternalDescription });
        }

        protected override void MoveFirst()
        {
            this._productItemNo = this.productItemNoManager.GetFirst();
        }

        protected override void MoveLast()
        {
            this._productItemNo = this.productItemNoManager.GetLast();
        }

        protected override void MoveNext()
        {
            Model.ProductItemNo model = this.productItemNoManager.GetNext(this._productItemNo);
            if (model == null)
                throw new InvalidOperationException(Properties.Resources.ErrorNoMoreRows);

            this._productItemNo = model;
        }

        protected override void MovePrev()
        {
            Model.ProductItemNo model = this.productItemNoManager.GetPrev(this._productItemNo);
            if (model == null)
                throw new InvalidOperationException(Properties.Resources.ErrorNoMoreRows);

            this._productItemNo = model;
        }


        public override void Refresh()
        {
            if (this._productItemNo == null)
            {
                this._productItemNo = new Book.Model.ProductItemNo();
                this.action = "insert";
            }
            this.txt_ItemNo.Text = this._productItemNo.ItemNo;
            this.txt_InternalDescription.EditValue = this._productItemNo.InternalDescription;

            this.bindingSourceSupplierCategory.DataSource = this.productItemNoManager.Select();


            if (this.action == "update")
            {
                oldId = this._productItemNo.ItemNo;
            }

            switch (this.action)
            {
                case "insert":
                    this.txt_ItemNo.Properties.ReadOnly = false;
                    this.txt_InternalDescription.Properties.ReadOnly = false;
                    break;

                case "update":
                    this.txt_ItemNo.Properties.ReadOnly = false;
                    this.txt_InternalDescription.Properties.ReadOnly = false;
                    break;

                case "view":
                    this.txt_ItemNo.Properties.ReadOnly = true;
                    this.txt_InternalDescription.Properties.ReadOnly = true;
                    break;
                default:
                    break;
            }
            base.Refresh();
        }

        protected override void Save()
        {
            this._productItemNo.ItemNo = this.txt_ItemNo.Text;
            this._productItemNo.InternalDescription = this.txt_InternalDescription.Text;
            switch (this.action)
            {
                case "insert":
                    this.productItemNoManager.Insert(this._productItemNo);
                    break;
                case "update":
                    this.productItemNoManager.Update(this._productItemNo, oldId);
                    break;
                default:
                    break;
            }
        }

        #endregion

        private void gridView1_Click(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            GridHitInfo hitInfo = view.CalcHitInfo(view.GridControl.PointToClient(Cursor.Position));
            if (hitInfo.InRow && !view.IsGroupRow(hitInfo.RowHandle))
            {
                Model.ProductItemNo model = this.bindingSourceSupplierCategory.Current as Model.ProductItemNo;
                if (model != null)
                {
                    this._productItemNo = model;
                    this.action = "view";
                    this.Refresh();
                }
            }
        }

        private void ProductItemNoForm_Load(object sender, EventArgs e)
        {
            //隐藏上下页，首尾页按钮
            this.Visibles();
        }
    }
}