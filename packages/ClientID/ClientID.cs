namespace ClientID
{
  public class ClientId
  {
    private const int Length = 12;
    private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    private static readonly Random Random = new Random();

    public static string GetClientId()
    {
      return Environment.GetEnvironmentVariable("CLIENT_ID") ?? new string(Enumerable
        .Repeat(Chars, Length).Select(s => s[Random.Next(s.Length)]).ToArray());
    }
  }
}