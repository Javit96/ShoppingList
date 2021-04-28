namespace ShoppingList.Settings
{
    public class JWTSettings
    {
        public string Issuer { get; set; }
        public string SecretKey { get; set; }
        public int ExpirationInDays { get; set; }
    }
}
