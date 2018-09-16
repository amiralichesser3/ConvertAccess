using System.ComponentModel.DataAnnotations;

namespace MadarshoX.Model.Models.Product
{
    public class Link
    {
        [Key]
        public long LinkId { get; set; }
        public string Url { get; set; }
        public long ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}