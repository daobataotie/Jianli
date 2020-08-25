using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;

namespace Book.UI.Settings.ProduceManager.Techonlogy
{
    public partial class ChooseSubProcedures : DevExpress.XtraEditors.XtraForm
    {
        BL.TechonlogyHeaderManager techonlogyHeaderManager = new Book.BL.TechonlogyHeaderManager();

        public Model.TechonlogyHeader TechonlogyHeader { get; set; }

        public ChooseSubProcedures(string techonlogyHeaderId)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;

            TechonlogyHeader = techonlogyHeaderManager.GetDetail(techonlogyHeaderId);
            this.bindingSource1.DataSource = TechonlogyHeader.detail;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.gridView1.PostEditor();
            this.gridView1.UpdateCurrentRow();

            var checkDatas = TechonlogyHeader.detail.Where(d => d.IsChecked);

            //原來的工藝全部選中，意思為 直接用原來的，否則按照選中數據新增一筆
            if (checkDatas.Count() != TechonlogyHeader.detail.Count())
            {
                Model.TechonlogyHeader header = new Book.Model.TechonlogyHeader();
                header.TechonlogyHeaderId = Guid.NewGuid().ToString();
                header.Id = this.techonlogyHeaderManager.GetId(DateTime.Now);
                header.Statrdate = global::Helper.DateTimeParse.NullDate;
                header.Enddate = global::Helper.DateTimeParse.EndDate;
                header.detail = new List<Model.Technologydetails>();

                header.TechonlogyHeadername = TechonlogyHeader.TechonlogyHeadername + "-" + techonlogyHeaderManager.GetSameNameCount(TechonlogyHeader.TechonlogyHeadername);

                foreach (var item in checkDatas)
                {
                    item.TechnologydetailsID = Guid.NewGuid().ToString();
                    item.TechonlogyHeaderId = header.TechonlogyHeaderId;
                    item.TechnologydetailsNo = (header.detail.Count() + 1).ToString();

                    header.detail.Add(item);
                }

                techonlogyHeaderManager.Insert(header);
                TechonlogyHeader = header;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            TechonlogyHeader.detail.ToList().ForEach(d => d.IsChecked = this.checkEdit1.Checked);

            this.bindingSource1.DataSource = TechonlogyHeader.detail;
            this.gridControl1.RefreshDataSource();
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.ListSourceRowIndex < 0) return;
            IList<Model.Technologydetails> details = this.bindingSource1.DataSource as IList<Model.Technologydetails>;
            if (details == null || details.Count < 1) return;
            Model.Technologydetails detail = details[e.ListSourceRowIndex];
            if (detail.Procedures == null) return;
            switch (e.Column.Name)
            {
                case "gridWorkhouse":
                    e.DisplayText = detail.Procedures == null ? "" : detail.Procedures.WorkHouse.Workhousename;
                    break;
                case "gridProcedures":
                    e.DisplayText = detail.Procedures == null ? "" : detail.Procedures.Id;
                    break;
                case "gridColumnStartDate":
                    e.DisplayText = detail.Procedures.Startdate.HasValue ? detail.Procedures.Startdate.Value.ToShortDateString() : "";
                    break;
                case "gridColumnEndDate":
                    e.DisplayText = detail.Procedures.Enddate.HasValue ? detail.Procedures.Enddate.Value.ToShortDateString() : "";
                    break;
            }
        }
    }
}