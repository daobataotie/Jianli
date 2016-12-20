using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Book.UI
{
    public partial class InformationForm : DevExpress.XtraEditors.XtraForm
    {
        BL.InformationManager informationManager = new Book.BL.InformationManager();
        BL.InformationStateManager informationStateManager = new Book.BL.InformationStateManager();
        IList<Model.Information> informationList;
        int btntag = 0;
        string invoiceType = string.Empty;

        public InformationForm()
        {
            InitializeComponent();
        }

        private void InformationForm_Load(object sender, EventArgs e)
        {
            Location = new Point(this.Parent.Width - this.Width - 5, this.Parent.Height - this.Height - 5);

            BindSource();
        }

        private void InformationForm_LocationChanged(object sender, EventArgs e)
        {
            this.Size = new Size(366, 332);
            Location = new Point(this.Parent.Width - this.Width - 5, this.Parent.Height - this.Height - 5);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BindSource();
        }

        private void BindSource()
        {
            if (this.btntag == 0)
            {
                this.invoiceType = string.Empty;
                if (MainForm.co_Jurisdiction)
                    this.invoiceType += ",'採購單'";
                if (MainForm.cg_Jurisdiction)
                    this.invoiceType += ",'進庫單'";
                if (MainForm.xo_Jurisdiction)
                    this.invoiceType += ",'客戶訂單'";
                if (MainForm.xs_Jurisdiction)
                    this.invoiceType += ",'出貨單'";
                if (MainForm.mps_Jurisdiction)
                    this.invoiceType += ",'生產計劃'";
                if (MainForm.mrs_Jurisdiction)
                    this.invoiceType += ",'物料需求'";
                if (MainForm.pnt_Jurisdiction)
                    this.invoiceType += ",'加工單'";
                if (MainForm.pdm_Jurisdiction)
                    this.invoiceType += ",'生產領料'";
                if (MainForm.pid_Jurisdiction)
                    this.invoiceType += ",'生產入庫'";
                if (MainForm.poc_Jurisdiction)
                    this.invoiceType += ",'委外合同'";
                if (MainForm.pom_Jurisdiction)
                    this.invoiceType += ",'委外領料'";
                if (MainForm.pod_Jurisdiction)
                    this.invoiceType += ",'委外入庫'";
                if (MainForm.cc_Jurisdiction)
                    this.invoiceType += ",'出倉單'";

                this.invoiceType = string.IsNullOrEmpty(this.invoiceType) ? "and InvoiceType in ('')" : " and InvoiceType in (" + this.invoiceType.Substring(1) + ")";
            }
            else
            {
                this.invoiceType = string.Empty;
            }
            this.informationList = informationManager.SelectByEmployee(BL.V.ActiveOperator.EmployeeId, this.invoiceType);
            this.bindingSource1.DataSource = this.informationList;
            this.gridView1.MoveFirst();
            this.gridView1.MoveLast();
            if (this.bindingSource1.Count > 0)
                this.gridView1.FocusedRowHandle = this.bindingSource1.Position = this.bindingSource1.Count - 1;
        }


        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            if (this.bindingSource1.Current != null)
            {
                Model.Information mode = this.bindingSource1.Current as Model.Information;

                try
                {
                    string sql = "insert into InformationState values(NEWID(),GETDATE(),'" + BL.V.ActiveOperator.EmployeeId + "','" + mode.InformationId + "',1)";
                    BL.V.BeginTransaction();
                    this.informationStateManager.UpdateSql(sql);
                    BL.V.CommitTransaction();
                }
                catch (Exception ex)
                {
                    BL.V.RollbackTransaction();
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK);
                    return;
                }
            }

            this.informationList = informationManager.SelectByEmployee(BL.V.ActiveOperator.EmployeeId, this.invoiceType);
            this.bindingSource1.DataSource = this.informationList;
            int a = this.bindingSource1.Position;
            this.gridView1.MoveFirst();
            this.gridView1.FocusedRowHandle = a;
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            BindSource();
        }

        private void btn_InformationDifferent_Click(object sender, EventArgs e)
        {
            if (this.btntag == 0)
            {
                this.btntag = 1;
                this.btn_InformationDifferent.Text = "顯示權責消息";
            }
            else
            {
                this.btntag = 0;
                this.btn_InformationDifferent.Text = "顯示全部消息";
            }
            this.BindSource();
        }


    }
}