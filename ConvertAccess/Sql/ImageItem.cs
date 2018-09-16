using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MadarshoX.Model.Models.Product
{
    public class ImageItem
    { 
        public long ImageId { get; set; }
        public virtual Image Image { get; set; }
        public long ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}