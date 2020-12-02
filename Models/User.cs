using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.Models
{
    public partial class User
    {
        public User()
        {
            RefreshTokens = new HashSet<RefreshToken>();
        }

        [Key]
        public int UserID { get; set; }
        [Required]
        public string Username { get; set; }
        
        public string LastName { get; set; }
        
        public string FirstMidName { get; set; }

        
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string password { get; set; }
        public string Phone { get; set; }


        public ICollection<StockU> StockU { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}