using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Book.UI.Settings.BasicData;

namespace Book.UI.produceManager.ProduceMaterial
{
    public partial class ListForm : BaseListForm
    {
        BL.InvoiceXOManager invoiceXOManager = new Book.BL.InvoiceXOManager();
        BL.PronoteHeaderManager PronoteHeaderManager = new BL.PronoteHeaderManager();
        int tag = 0;
        public ListForm()
        {
            InitializeComponent();
            this.manager = new BL.ProduceMaterialManager();
        }

        public ListForm(string InvoiceCusId)
            : this()
        {
            this.tag = 1;
            this.bindingSource1.DataSource = (this.manager as BL.ProduceMaterialManager).SelectBycondition(global::Helper.DateTimeParse.NullDate, global::Helper.DateTimeParse.EndDate, null, null, null, null, null, null, null, null, InvoiceCusId);

            this.gridControl1.RefreshDataSource();
        }

        protected override void RefreshData()
        {
            if (this.tag == 1)
            {
                this.tag = 0;
                return;
            }
            this.bindingSource1.DataSource = (this.manager as BL.ProduceMaterialManager).SelectBycondition(DateTime.Now.AddDays(-15), DateTime.Now, null, null, null, null, null, null, null, null, null);
            this.gridView1.GroupPanelText = "默認顯示半个月内的記錄";

        }

        protected override Book.UI.Settings.BasicData.BaseEditForm GetEditForm()
        {
            return new EditForm();
        }

        protected override Book.UI.Settings.BasicData.BaseEditForm GetEditForm(object[] args)
        {
            Type type = typeof(EditForm);
            string produceMaterialId = (args[0] as Model.ProduceMaterialdetails).ProduceMaterialID;
            args[0] = produceMaterialId;
            return (EditForm)type.Assembly.CreateInstance(type.FullName, false, System.Reflection.BindingFlags.CreateInstance, null, args, null, null);
        }

        private void simple_Search_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Query.ConditionMaterialChooseForm form = new Query.ConditionMaterialChooseForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Query.ConditionMaterial condition = form.Condition as Query.ConditionMaterial;
                //  if (IsDisposed ) return;
                //gridControl1.Invoke((System.Action)delegate()
                //  {
                //  gridControl1.DataSource = (this.manager as BL.ProduceMaterialManager).SelectBycondition(condition.StartDate, condition.EndDate, condition.ProduceMaterialId0, condition.ProduceMaterialId1, condition.Product0, condition.Product1, condition.DepartmentId0, condition.DepartmentId1, condition.PronoteHeaderId0, condition.PronoteHeaderId1);


                // });
                //this.bindingSource1.DataSource = (this.manager as BL.ProduceMaterialManager).SelectBycondition(condition.StartDate, condition.EndDate, condition.ProduceMaterialId0, condition.ProduceMaterialId1, condition.Product0, condition.Product1, condition.DepartmentId0, condition.DepartmentId1, condition.PronoteHeaderId0, condition.PronoteHeaderId1, condition.CusInvoiceXOId);

                this.bindingSource1.DataSource = new BL.ProduceMaterialdetailsManager().SelectBycondition(condition.StartDate, condition.EndDate, condition.ProduceMaterialId0, condition.ProduceMaterialId1, (condition.Product0 == null ? null : condition.Product0.Id), (condition.Product1 == null ? null : condition.Product1.Id), condition.DepartmentId0, condition.DepartmentId1, condition.PronoteHeaderId0, condition.PronoteHeaderId1, condition.CusInvoiceXOId);

                this.barStaticItem1.Caption = string.Format("{0}项", this.bindingSource1.Count);

                this.gridControl1.RefreshDataSource();
            }
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            //if (e.ListSourceRowIndex < 0) return;
            //IList<Model.ProduceMaterial> details = this.bindingSource1.DataSource as IList<Model.ProduceMaterial>;
            //if (details == null || details.Count < 1) return;
            //Model.ProduceMaterial detail = details[e.ListSourceRowIndex];
            ////IList<Model.MPSheader> mpsHeader = new BL.MPSheaderManager().Select(details[e.ListSourceRowIndex]);
            //switch (e.Column.Name)
            //{
            //    case "gridColumnXO":
            //        if (details == null) return;
            //        if (!string.IsNullOrEmpty(detail.InvoiceXOId))
            //        {
            //            //Model.PronoteHeader pronoteHeader = this.PronoteHeaderManager.Get(detail.PronoteHeaderID);
            //            //if (pronoteHeader != null)
            //            //{
            //            Model.InvoiceXO invoiceXO = invoiceXOManager.Get(detail.InvoiceXOId);
            //            e.DisplayText = invoiceXO == null ? string.Empty : invoiceXO.CustomerInvoiceXOId;

            //            // }
            //        }


            //        break;
            //}
        }

        public override void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Form f = this.GetEditForm(new object[] { this.bindingSource1.Current });
            if (f != null)
                f.ShowDialog();
        }
    }
}