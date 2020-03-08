using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stock_api.Model
{
    public class HistoryViewModel
    {
        public float Opening { get; set; }
        public float Closing { get; set; }
        public float Min { get; set; }
        public float Max { get; set; }
        public String Timestamp { get; set; }
    }
}
