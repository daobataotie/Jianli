﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;

namespace Book.UI.Settings.BasicData.Supplier
{
    public partial class RO1 : DevExpress.XtraReports.UI.XtraReport
    {
        private IList<PriceRangeRO> _priceRangeList = new List<PriceRangeRO>();
        public RO1()
        {
            InitializeComponent();

            this.TCPriceStart.DataBindings.Add("Text", this.DataSource, "startRange", "{0:0.####}");
            this.TCPricEnd.DataBindings.Add("Text", this.DataSource, "endRange", "{0:0.####}");
            this.TCPrice.DataBindings.Add("Text", this.DataSource, "RangePrice", "{0:0.####}");
        }

        public string priceR { get; set; }

        private void RO1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (string.IsNullOrEmpty(priceR))
                priceR = "1/999999999999/0/0";
            this._priceRangeList.Clear();
            string[] inPriceR;
            if (priceR.Contains(","))
                inPriceR = priceR.Split(',');
            else
                inPriceR = new string[] { priceR };
            PriceRangeRO pr = null;
            foreach (string s in inPriceR)
            {
                string[] prs = s.Split('/');
                pr = new PriceRangeRO();
                pr.startRange = prs[0];
                pr.endRange = (prs[1] == "999999999999" ? "無限大" : prs[1]);
                pr.RangePrice = prs[2];
                pr.GiveQuantity = prs[3];
                this._priceRangeList.Add(pr);
            }
            this.DataSource = this._priceRangeList;
        }
    }
    public class PriceRangeRO
    {
        /// <summary>
        /// 数量下限
        /// </summary>
        public string startRange { get; set; }

        /// <summary>
        /// 数量上限
        /// </summary>
        public string endRange { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public string RangePrice { get; set; }

        /// <summary>
        /// 赠送
        /// </summary>
        public string GiveQuantity { get; set; }
    }
}