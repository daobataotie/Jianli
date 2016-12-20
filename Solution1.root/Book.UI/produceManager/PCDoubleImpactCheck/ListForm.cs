using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Book.UI.produceManager.PCDoubleImpactCheck
{
    public partial class ListForm : Book.UI.Settings.BasicData.BaseListForm
    {
        private int _pcFlag = 0;     //表示检测单据类型

        public ListForm(int pcFlag)
        {
            InitializeComponent();
            this._pcFlag = pcFlag;
            this.manager = new BL.PCDoubleImpactCheckManager();
        }

        protected override void RefreshData()
        {
            this.bindingSource1.DataSource = (this.manager as BL.PCDoubleImpactCheckManager).SelectByDateRage(DateTime.Now.AddMonths(-1), global::Helper.DateTimeParse.EndDate, this._pcFlag, null, null, "");
            this.gridView1.GroupPanelText = "默認顯示半个月内的記錄";
        }

        private void barBtnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Query.ConditionPronoteHeaderChooseForm f = new Query.ConditionPronoteHeaderChooseForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                Query.ConditionPronoteHeader condition = f.Condition as Query.ConditionPronoteHeader;
                this.bindingSource1.DataSource = (this.manager as BL.PCDoubleImpactCheckManager).SelectByDateRage(condition.StartDate, condition.EndDate, this._pcFlag, condition.Product, condition.Customer, condition.CusXOId);
                this.barStaticItem1.Caption = string.Format("{0}项", this.bindingSource1.Count);
                this.gridControl1.RefreshDataSource();
            }
        }

        private void ListForm_Load(object sender, EventArgs e)
        {
            this.bindingSource1.DataSource = (this.manager as BL.PCDoubleImpactCheckManager).SelectByDateRage(DateTime.Now.AddMonths(-1), global::Helper.DateTimeParse.EndDate, this._pcFlag, null, null, "");
            this.gridView1.GroupPanelText = "默認顯示半个月内的記錄";
        }

        /// <summary>
        /// 重写父类方法
        /// </summary>
        /// <returns></returns>
        protected override Book.UI.Settings.BasicData.BaseEditForm GetEditForm()
        {
            return new EditForm();
        }

        /// <summary>
        /// 重写父类方法
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected override Book.UI.Settings.BasicData.BaseEditForm GetEditForm(object[] args)
        {
            Type type = typeof(EditForm);
            return (EditForm)type.Assembly.CreateInstance(type.FullName, false, System.Reflection.BindingFlags.CreateInstance, null, args, null, null);
        }
    }
}
