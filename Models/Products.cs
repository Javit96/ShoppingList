using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;


namespace ShoppingList.Models
{
    public class Products
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public string Barcode { get; set; }

        public ICollection<StockU> StockU { get; set; }
    }
}
