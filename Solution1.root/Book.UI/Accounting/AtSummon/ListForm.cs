using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Book.UI.Accounting.AtSummon
{
    public partial class ListForm : Settings.BasicData.BaseListForm
    {
        public ListForm()
        {
            InitializeComponent();

            this.manager = new BL.AtSummonManager();
        }

        protected override void RefreshData()
        {
            //this.bindingSource1.DataSource = (this.manager as BL.AtSummonManager).SelectByDateRage(DateTime.Now.AddMonths(-1), global::Helper.DateTimeParse.EndDate);
            this.bindingSource1.DataSource = (this.manager as BL.AtSummonManager).SelectByCondition(DateTime.Now.AddMonths(-1), global::Helper.DateTimeParse.EndDate, null, null, null, null);
            this.gridView1.GroupPanelText = "The default display records in a month";
        }

        private void barBtnChangeDate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Query.ConditionAChooseForm f = new Book.UI.Query.ConditionAChooseForm();
            //if (f.ShowDialog(this) == DialogResult.OK)
            //{
            //    Query.ConditionA condition = f.Condition as Query.ConditionA;
            //    this.bindingSource1.DataSource = (this.manager as BL.AtSummonManager).SelectByDateRage(condition.StartDate, condition.EndDate);
            //    this.gridControl1.RefreshDataSource();
            //}

            ConditionForm f = new ConditionForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                this.bindingSource1.DataSource = (this.manager as BL.AtSummonManager).SelectByCondition(f.condition.StartDate, f.condition.EndDate, f.condition.StartId, f.condition.EndId, f.condition.SummonCategory, f.condition.EmployeeId);

                this.gridControl1.RefreshDataSource();
                this.barStaticItem1.Caption = string.Format("{0}項", this.bindingSource1.Count);
            }
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