namespace BuberDinner.Infrastructure.Authentication
{
    public class JwtSettings
    {
        public static string SectionName = "JwtSettings";
        public string Secret { get; init; } = null!;
        public string Issure { get; init; } = null!;
        public int ExpiryMinutes { get; init; }
        public string Audience { get; init; } = null!;

    }
}