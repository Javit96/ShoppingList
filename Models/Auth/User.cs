using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ShoppingList.Models.Auth
{
    public class User : IdentityUser<Guid>
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public User()
        {
            RefreshTokens = new HashSet<RefreshToken>();
        }


        //public ICollection<Groups> Groups { get; set; }
        public ICollection<StockU> StockU { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}