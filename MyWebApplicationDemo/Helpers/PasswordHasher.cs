//namespace MyWebApplicationDemo.Helpers
//{
//    public class PasswordHasher
//    {
//    }
//}



using BCrypt.Net;

public class PasswordHasher
{
    // Hash the password before storing it
    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    // Verify the password during login
    public static bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}


