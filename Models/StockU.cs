using ShoppingList.Models.Auth;
using System;

namespace ShoppingList.Models
{
    public class StockU
    {

        public int ID { get; set; }
        public int stock { get; set; }
        public DateTime BuyDate { get; set; }


        public Guid  UserID { get; set; }
        public User  User { get; set; }
        
        public Guid ?  GroupsID { get; set; }
        public Groups Groups { get; set; }
        
        public int ProductID { get; set; }
        public Products Products { get; set; }

    }
}