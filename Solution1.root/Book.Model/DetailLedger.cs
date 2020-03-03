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

        /// <summary>
        /// 前期餘額（截止到本單據開始日期所有該會計科目的累計餘額）
        /// </summary>
        public decimal TheBalance { get; set; }

        public string Subject_Id { get; set; }

        public string SubjectName { get; set; }

        public string SummonCategory { get; set; }

        public decimal JMoney { get; set; }

        public decimal DMoney { get; set; }

        public decimal Total { get; set; }


        private string _theLending;


        /// <summary>
        /// 会计科目的期初借贷
        /// </summary>
        public string TheLending
        {
            get
            {
                if (_theLending == "Borrow")
                    return "借";
                else
                    return "貸";
            }
            set { _theLending = value; }
        }

        private string _sd;

        public string Sd
        {
            get { return _sd; }
            set { _sd = value; }
        }

    }
}
