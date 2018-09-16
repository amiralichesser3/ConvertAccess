using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
namespace MadarshoX.Model.Models.Product
{
    public class Item
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; } 
        public virtual ICollection<Link> Links { get; set; }
        public long BrandId { get; set; } 
        public virtual ICollection<SuitableForItem> SuitableForItems { get; set; }
        public long? FeaturedImageId { get; set; } 
        public virtual ICollection<ImageItem> ImageItems { get; set; }
        public virtual ICollection<FeatureItem> FeatureItems { get; set; } 
        public int HowToSell { get; set; }
        public int EconomicClass { get; set; }
        public long? ColorId { get; set; }  
        public long? ParentId { get; set; }   
    }
}