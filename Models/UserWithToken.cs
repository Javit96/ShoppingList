using ShoppingList.Models.Auth;

namespace ShoppingList.Models
{
    public class UserWithToken : User
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public UserWithToken(User user)
        {
            this.Id = user.Id;
            this.Email = user.Email;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.UserName = user.UserName;
            this.PhoneNumber = user.PhoneNumber;


            this.StockU = user.StockU;
        }
    }
}
