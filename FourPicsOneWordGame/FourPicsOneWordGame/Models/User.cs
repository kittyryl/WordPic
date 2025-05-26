namespace FourPicsOneWordGame.Models
{
    public enum UserRole
    {
        User = 0,
        Admin = 1
    }

    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; }
    }
}