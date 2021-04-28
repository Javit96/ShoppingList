using ShoppingList.Models.Auth;
using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Models
{
    public partial class RefreshToken
    {
        [Key]
        public int TokenId { get; set; }
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }

        public virtual User User { get; set; }
    }
}