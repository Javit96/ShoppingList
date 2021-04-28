using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using ShoppingList.Models.Auth;

namespace ShoppingList.Models
{
    public class Groups
    {
        public Guid Id { get; set; }
        public string GroupName { get; set; }


        public ICollection<StockU> StockU { get; set; }

        public ICollection<User> User { get; set; }

    }

}
