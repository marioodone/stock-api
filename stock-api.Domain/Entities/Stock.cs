using System;
using System.Collections.Generic;
using System.Text;

namespace stock_api.Domain.Entities
{
    public class Stock : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
