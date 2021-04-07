using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS_3_NDTHANH.Model
{
    public class CustomerGroup
    {
        public Guid CustomerGroupId { get; set; }
        public string CustomerGroupName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
