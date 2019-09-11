namespace CoreCrud.Models
{


    public class Manufacturer
    {
        public int ID { get; set; }
        public int CollectibleID { get; set; }

        public string ManufacturerName { get; set; }

        public virtual Collectible Collectible { get; set; }
    }
}