using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertAccess
{
    public class Feature
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FeatureId { get; set; }
        public string Name { get; set; }

        public Feature(int featureId, string name)
        {
            this.FeatureId = featureId;
            this.Name = name;
        }
    }
}
