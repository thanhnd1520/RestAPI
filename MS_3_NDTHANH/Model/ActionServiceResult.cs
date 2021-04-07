using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MS_3_NDTHANH.Model.Enumarations;

namespace MS_3_NDTHANH.Model
{
    public class ActionServiceResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public MISACode MISACode { get; set; }
        public object Data { get; set; }

    }
}
