using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MadarshoX.Model.Models.Product
{
    [Table("SuitableForItem")]
    public class SuitableForItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SuitableForItemId { get; set; }
        public long SuitableForId { get; set; } 
        public long ItemId { get; set; } 

        public SuitableForItem(long itemId, long suitableForId)
        {
            this.SuitableForId = suitableForId;
            this.ItemId = itemId;
        }
    }
}