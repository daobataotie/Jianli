using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Book.UI.Settings.BasicData.Employees
{
    public partial class AttendanceJJDays : DevExpress.XtraEditors.XtraForm
    {
        public AttendanceJJDays()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public AttendanceJJDays(double value,double value2)
            : this()
        {
            this.spinEdit1.EditValue = value;
            this.spinEdit2.EditValue = value2;
        }
        BL.EmployeeManager employeeManager = new Book.BL.EmployeeManager();

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.spinEdit1.EditValue != null)
            {
                string str = "UPDATE Employee SET AttendanceJJDays='" + Convert.ToDouble(this.spinEdit1.EditValue) + "'";

                if (employeeManager.UpdateSql(str) > 1)
                    MessageBox.Show(Properties.Resources.SuccessfullySaved, this.Text);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (this.spinEdit2.EditValue != null)
            {
                string sql = "update Employee set AttendanceDays='" + Convert.ToDouble(this.spinEdit2.EditValue) + "'";

                if(employeeManager.UpdateSql(sql) > 1)
                    MessageBox.Show(Properties.Resources.SuccessfullySaved, this.Text);
            }
        }
    }
}