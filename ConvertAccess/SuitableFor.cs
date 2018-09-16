using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertAccess
{
    public class SuitableFor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SuitableForId { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
