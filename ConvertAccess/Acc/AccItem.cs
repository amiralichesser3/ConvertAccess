using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertAccess
{
    public class AccItem
    {
        public long ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public long CategoryId { get; set; }
        public long BrandId { get; set; }
        public long SuitableForId { get; set; }
        public ICollection<string> ImageNames { get; set; }
    }
}
