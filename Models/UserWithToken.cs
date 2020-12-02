using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Models
{
    public class UserWithToken : User
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public UserWithToken(User user)
        {
            this.UserID = user.UserID;
            this.Email = user.Email;
            this.FirstMidName = user.FirstMidName;
            this.LastName = user.LastName;
            this.Username = user.Username;
            this.Phone = user.Phone;


            this.StockU = user.StockU;
        }
    }
}
