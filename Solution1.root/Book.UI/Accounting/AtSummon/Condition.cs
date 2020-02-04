﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Book.UI.Accounting.AtSummon
{
    public class Condition
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string StartId { get; set; }
        public string EndId { get; set; }

        public string StartSubjectId { get; set; }
        public string EndSubjectId { get; set; }

        public string SummonCategory { get; set; }

        public string EmployeeId { get; set; }
    }
}
