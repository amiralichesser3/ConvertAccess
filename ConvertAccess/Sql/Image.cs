using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace MadarshoX.Model.Models.Product
{
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ImageId { get; set; }
        public string Url { get; set; }
        public int ImageType { get; set; } 

        public Image()
        {
            
        } 
    }
}