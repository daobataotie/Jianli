using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using Book.UI.Query;

namespace Book.UI.Accounting.Report
{
    public partial class FormDetailLedger : Query.ConditionChooseForm
    {
        IList<Model.AtAccountSubject> SubList;

        public FormDetailLedger()
        {
            InitializeComponent();

            SubList = new BL.AtAccountSubjectManager().Select();
            this.bindingSource1.DataSource = SubList;
        }

        private ConditionDetailLedger _condition;
        public override Condition Condition
        {
            get
            {
                return _condition;
            }
            set
            {
                _condition = value as ConditionDetailLedger;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            OnOK();
            this.DialogResult = DialogResult.OK;
        }

        protected override void OnOK()
        {
            _condition = new ConditionDetailLedger();

            if (this.date_Start.EditValue == null || this.date_End.EditValue == null)
            {
                throw new Exception("日期區間不完整！");
                //MessageBox.Show("日期區間不完整！", this.Text, MessageBoxButtons.OK);
                //return;
            }
            else
            {
                _condition.DateStart = this.date_Start.DateTime;
                _condition.DateEnd = this.date_End.DateTime;
            }

            if (this.lue_StartSubject.EditValue == null || this.lue_EndSubject.EditValue == null)
            {
                throw new Exception("會計科目區間不完整！");
                //MessageBox.Show("會計科目區間不完整", this.Text, MessageBoxButtons.OK);
                //return;
            }
            else
            {
                _condition.StartSubId = lue_StartSubject.Text;
                _condition.EndSubId = lue_EndSubject.Text;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lue_StartSubject_EditValueChanged(object sender, EventArgs e)
        {
            this.lue_EndSubject.EditValue = lue_StartSubject.EditValue;
        }
    }
}