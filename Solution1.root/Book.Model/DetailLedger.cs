using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Model
{
    /// <summary>
    /// 會計：明細分類賬，日記賬
    /// </summary>
    public class DetailLedger
    {
        public DateTime? SummonDate { get; set; }

        public string Id { get; set; }

        public string Summary { get; set; }

        public string Lending { get; set; }

        public decimal AMoney { get; set; }

        public decimal TheBalance { get; set; }

        public string Subject_Id { get; set; }

        public string SubjectName { get; set; }

        public string SummonCategory { get; set; }

        public decimal JMoney { get; set; }

        public decimal DMoney { get; set; }

        public decimal Total { get; set; }

    }
}
