using System;
using System.Collections.Generic;
using System.Text;

namespace stock_api.Domain.Entities
{
    public class History : BaseEntity
    {
        public int IdStock { get; set; }
        public float Openning { get; set; }
        public float Closing { get; set; }
        public float Min { get; set; }
        public float Max { get; set; }
        String Timestamp { get; set; }
    }
}
