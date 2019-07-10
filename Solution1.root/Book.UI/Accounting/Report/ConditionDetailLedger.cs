using System;
using System.Collections.Generic;
using System.Text;
using Book.UI.Query;

namespace Book.UI.Accounting.Report
{
    /// <summary>
    /// 明细分类账，日记账
    /// </summary>
    public class ConditionDetailLedger : Condition
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        //會計科目編號
        public string StartSubId { get; set; }
        public string EndSubId { get; set; }

        //傳票編號
        public string StartId { get; set; }
        public string EndId { get; set; }
        public string Category { get; set; }
    }
}
