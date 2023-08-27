namespace Faker;

public class Helper
{
    public static string GenerateRandomCnpj()
    {
        var rnd = new Random();
        var sum = 0;
        int[] initialMultiplier = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 },
            finalMultiplier = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        string result = $"{rnd.Next(10000000, 99999999)}0001";

        for (int i = 0; i < 12; i++)
            sum += int.Parse(result[i].ToString()) * initialMultiplier[i];

        var difference = sum % 11;
        if (difference < 2)
            difference = 0;
        else
            difference = 11 - difference;

        result += difference;

        sum = 0;
        for (int i = 0; i < 13; i++)
            sum += int.Parse(result[i].ToString()) * finalMultiplier[i];

        difference = sum % 11;

        if (difference < 2)
            difference = 0;
        else
            difference = 11 - difference;

        result += difference;

        return result;
    }
}