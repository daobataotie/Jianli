using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Book.UI.produceManager.ProductScrap
{
    public partial class List : Settings.BasicData.BaseListForm
    {
        BL.ProductScrapDetailManager detailManager = new BL.ProductScrapDetailManager();
        int tag = 0;
        public List()
        {
            InitializeComponent();
            this.manager = new BL.ProductScrapManager();
        }


        protected override void RefreshData()
        {
            if (this.tag == 1)
            {
                this.tag = 0;
                return;
            }
            this.bindingSource1.DataSource = detailManager.SelectByCondition(DateTime.Now.AddDays(-30), DateTime.Now, null);
        }

        protected override Book.UI.Settings.BasicData.BaseEditForm GetEditForm()
        {
            return new EditForm();
        }

        protected override Book.UI.Settings.BasicData.BaseEditForm GetEditForm(object[] args)
        {
            Type type = typeof(EditForm);
            //return (EditForm)type.Assembly.CreateInstance(type.FullName, false, System.Reflection.BindingFlags.CreateInstance, null, args, null, null);
            Model.ProductScrapDetail model = this.bindingSource1.Current as Model.ProductScrapDetail;
            args[0] = model.ProductScrap;
            return (EditForm)type.Assembly.CreateInstance(type.FullName, false, System.Reflection.BindingFlags.CreateInstance, null, args, null, null);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ConditionForm f = new ConditionForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                this.bindingSource1.DataSource = detailManager.SelectByCondition(f.StartDate, f.EndDate, f.ProductId);

                this.barStaticItem1.Caption = string.Format("{0}项", this.bindingSource1.Count);
                this.gridControl1.RefreshDataSource();
            }
        }

        public override void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.bindingSource1.Current != null)
            {
                Model.ProductScrapDetail model = this.bindingSource1.Current as Model.ProductScrapDetail;
                EditForm f = new EditForm(model.ProductScrap);
                f.ShowDialog(this);
            }
        }
    }
}