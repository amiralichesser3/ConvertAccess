namespace MadarshoX.Model.Models.Product
{
    public class FeatureItem
    { 
        public long FeatureId { get; set; } 
        public long ItemId { get; set; } 
        public string Value { get; set; } 
        public int FeatureItemType { get; set; } 
    }
}