using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;

namespace Book.UI.Accounting.AtSummon
{
    public partial class ROTransferAccounts_Sub : DevExpress.XtraReports.UI.XtraReport
    {
        public ROTransferAccounts_Sub(IList<Model.AtSummonDetail> Details)
        {
            InitializeComponent();

            //一页补足12条数据
            //int pageCount = (int)(atSummon.Details.Count / 12);
            //int remainder = atSummon.Details.Count % 12;
            //if (remainder != 0)
            //{
            //    int needCount = (pageCount + 1) * 12 - atSummon.Details.Count;
            //    for (int i = 0; i < needCount; i++)
            //    {
            //        atSummon.Details.Add(new Book.Model.AtSummonDetail());
            //    }
            //}

            this.DataSource = Details;

            this.TC_Jiedai.DataBindings.Add("Text", this.DataSource, Model.AtSummonDetail.PRO_Lending);
            this.TCSubId.DataBindings.Add("Text", this.DataSource, "Subject." + Model.AtAccountSubject.PRO_Id);
            this.TC_SubName.DataBindings.Add("Text", this.DataSource, "Subject." + Model.AtAccountSubject.PRO_SubjectName);
            this.TC_Note.DataBindings.Add("Text", this.DataSource, Model.AtSummonDetail.PRO_Summary);
            this.TC_JMoney.DataBindings.Add("Text", this.DataSource, "JMoney", "{0:N0}");
            this.TC_DMoney.DataBindings.Add("Text", this.DataSource, "DMoney", "{0:N0}");
        }

    }
}
