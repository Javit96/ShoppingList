using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.Models
{ 
    public class StockU
    {
        
        public int ID { get; set; }
        public int stock { get; set; }
        public DateTime BuyDate { get; set; }


        public int UserID { get; set; }
        public User User { get; set; }

        public int ProductID { get; set; }
        public Products Products { get; set; }

    }
}