using BCrypt.Net;

namespace MtnraProvidersManager_BAL.Services
{
    public static class PasswordService
    {
        public static string HashPassword(string password)
            => BCrypt.Net.BCrypt.HashPassword(password);
        public static bool VerifyPassword(string passwordToVerify, string passwordHash)
            => BCrypt.Net.BCrypt.Verify(passwordToVerify, passwordHash);
    }
}
