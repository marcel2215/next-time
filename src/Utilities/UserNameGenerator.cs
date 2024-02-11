using System.Security.Cryptography;

namespace NextTime.Utilities;

public static class UserNameGenerator
{
    public static string GenerateUserName()
    {
        return RandomNumberGenerator.GetString("abcdefghijklmnopqrstuvwxyz0123456789", 16);
    }
}
