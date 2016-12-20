using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Book.UI.produceManager.PCExportReportANSI
{
    public partial class ListForm : Settings.BasicData.BaseListForm
    {
        public ListForm()
        {
            InitializeComponent();
            this.manager = new BL.PCExportReportANSIManager();
        }

        public ListForm(string FormText)
            : this()
        {
            this.Text = FormText + "選擇";
        }

        public string etype = string.Empty;
        public string Etype
        {
            set { etype = value; }
            get { return etype; }
        }

        protected override void RefreshData()
        {
            this.bindingSource1.DataSource = (this.manager as BL.PCExportReportANSIManager).SelectByDateRage(etype, DateTime.Now.AddDays(-15), global::Helper.DateTimeParse.EndDate, null, null, "");
            this.gridView1.GroupPanelText = "默認顯示半个月内的記錄";
        }

        private void barBtnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Query.ConditionPronoteHeaderChooseForm f = new Query.ConditionPronoteHeaderChooseForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                Query.ConditionPronoteHeader condition = f.Condition as Query.ConditionPronoteHeader;
                this.bindingSource1.DataSource = (this.manager as BL.PCExportReportANSIManager).SelectByDateRage(etype, condition.StartDate, condition.EndDate, condition.Product, condition.Customer, condition.CusXOId);
                this.barStaticItem1.Caption = string.Format("{0}项", this.bindingSource1.Count);
                this.gridControl1.RefreshDataSource();
            }
        }

        /// <summary>
        /// 重写父类方法
        /// </summary>
        /// <returns></returns>
        protected override Book.UI.Settings.BasicData.BaseEditForm GetEditForm()
        {
            if (this.Text.Contains("AS"))
                return new ASEditForm();
            else if (this.Text.Contains("CEEN"))
                return new CEENEditsForm();
            else if (this.Text.Contains("CSA"))
                return new CSAEditForm();
            else if (this.Text.Contains("JIS"))
                return new JISEditForm();
            else
                return new EditForm();
        }

        /// <summary>
        /// 重写父类方法
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected override Book.UI.Settings.BasicData.BaseEditForm GetEditForm(object[] args)
        {
            Type type;
            if (this.Text.Contains("AS"))
            {
                type = typeof(ASEditForm);
                return (ASEditForm)type.Assembly.CreateInstance(type.FullName, false, System.Reflection.BindingFlags.CreateInstance, null, args, null, null);
            }
            else if (this.Text.Contains("CEEN"))
            {
                type = typeof(CEENEditsForm);
                return (CEENEditsForm)type.Assembly.CreateInstance(type.FullName, false, System.Reflection.BindingFlags.CreateInstance, null, args, null, null);
            }
            else if (this.Text.Contains("CSA"))
            {
                type = typeof(CSAEditForm);
                return (CSAEditForm)type.Assembly.CreateInstance(type.FullName, false, System.Reflection.BindingFlags.CreateInstance, null, args, null, null);
            }
            else if (this.Text.Contains("JIS"))
            {
                type = typeof(JISEditForm);
                return (JISEditForm)type.Assembly.CreateInstance(type.FullName, false, System.Reflection.BindingFlags.CreateInstance, null, args, null, null);
            }
            else
            {
                type = typeof(EditForm);
                return (EditForm)type.Assembly.CreateInstance(type.FullName, false, System.Reflection.BindingFlags.CreateInstance, null, args, null, null);
            }
        }
    }
}