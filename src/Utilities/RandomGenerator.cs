using System.Security.Cryptography;

namespace NextTime.Utilities;

public static class RandomGenerator
{
    public static string GenerateUserName()
    {
        return RandomNumberGenerator.GetString("abcdefghijklmnopqrstuvwxyz0123456789", 16);
    }

    public static string GenerateMeetingCode()
    {
        return RandomNumberGenerator.GetString("abcdefghijklmnopqrstuvwxyz0123456789", 8);
    }
}
