using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;

namespace Book.UI.Accounting.AtAccountSubject
{
    public partial class RO : DevExpress.XtraReports.UI.XtraReport
    {
        public RO(IList<Model.AtAccountSubject> list)
        {
            InitializeComponent();

            this.DataSource = list;

            this.lbl_CompanyName.Text = BL.Settings.CompanyChineseName;


            this.TCId.DataBindings.Add("Text", this.DataSource, Model.AtAccountSubject.PRO_Id);
            this.TCName.DataBindings.Add("Text", this.DataSource, Model.AtAccountSubject.PRO_SubjectName);
            this.TCCategory.DataBindings.Add("Text", this.DataSource, "AccountingCategory." + Model.AtAccountingCategory.PRO_AccountingCategoryName);
            this.TCJiedai.DataBindings.Add("Text", this.DataSource, Model.AtAccountSubject.PRO_TheLending);
            this.TCBalance.DataBindings.Add("Text", this.DataSource, Model.AtAccountSubject.PRO_TheBalance, "{0:0.00}");
            this.TCIsCash.DataBindings.Add("Text", this.DataSource, Model.AtAccountSubject.PRO_IsCash);
        }

    }
}
