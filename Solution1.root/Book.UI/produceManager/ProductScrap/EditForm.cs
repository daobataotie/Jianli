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
    public partial class EditForm : Book.UI.Settings.BasicData.BaseEditForm
    {
        BL.DepotPositionManager _depotPositionManager = new Book.BL.DepotPositionManager();
        public EditForm()
        {
            InitializeComponent();

            this.ncc_Employee.Choose = new Settings.BasicData.Employees.ChooseEmployee();
        }

        private void nccDepot_EditValueChanged(object sender, EventArgs e)
        {
            this.bindingSourceDepotPosition.DataSource = this._depotPositionManager.Select(nccDepot.EditValue.ToString());
        }
    }
}