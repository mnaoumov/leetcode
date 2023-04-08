using JetBrains.Annotations;

namespace LeetCode._0299_Bulls_and_Cows;

/// <summary>
/// https://leetcode.com/submissions/detail/930348811/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string GetHint(string secret, string guess)
    {
        var secretMap = new Dictionary<char, int>();
        var guessMap = new Dictionary<char, int>();

        var n = secret.Length;

        for (var i = 0; i < n; i++)
        {
            var secretDigit = secret[i];
            secretMap[secretDigit] = secretMap.GetValueOrDefault(secretDigit) + 1;

            var guessDigit = guess[i];
            guessMap[guessDigit] = guessMap.GetValueOrDefault(guessDigit) + 1;
        }

        var bullsCount = 0;

        for (var i = 0; i < n; i++)
        {
            if (guess[i] == secret[i])
            {
                secretMap[guess[i]]--;
                guessMap[guess[i]]--;
                bullsCount++;
            }
        }

        var cowsCount = 0;

        foreach (var (guessDigit, guessDigitCount) in guessMap)
        {
            cowsCount += Math.Min(guessDigitCount, secretMap.GetValueOrDefault(guessDigit));
        }

        return $"{bullsCount}A{cowsCount}B";
    }
}
