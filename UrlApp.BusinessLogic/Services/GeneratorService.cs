using UrlApp.BusinessLogic.Interfaces;

namespace UrlApp.BusinessLogic.Services;

public class GeneratorService : IGeneratorService
{
    private const string Chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const int Length = 6;
    
    public string GenerateShortUrl()
    {
        var arrayChars = new char[6];

        var random = new Random();

        for (int i = 0; i < Length; i++)
        {
            var randomIndex = random.Next(Chars.Length - 1);

            arrayChars[i] = Chars[randomIndex];
        }

        return new string(arrayChars);
    }
}