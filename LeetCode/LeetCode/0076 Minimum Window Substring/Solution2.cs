namespace LeetCode._0076_Minimum_Window_Substring;

/// <summary>
/// https://leetcode.com/submissions/detail/200377014/
/// </summary>
public class Solution2 : ISolution
{
    public string MinWindow(string s, string t)
    {
        if (t == "")
        {
            return "";
        }

        var symbolCounts = new Dictionary<char, int>();
        var targetSymbolCounts = new Dictionary<char, int>();
        foreach (var symbol in t)
        {
            symbolCounts[symbol] = 0;
            if (!targetSymbolCounts.ContainsKey(symbol))
            {
                targetSymbolCounts[symbol] = 0;
            }

            targetSymbolCounts[symbol]++;
        }

        var missingSymbolsCount = symbolCounts.Count;
        var startIndex = 0;
        const int notFound = -1;
        var minWindowStartIndex = notFound;
        var minWindowLength = int.MaxValue;

        for (int i = 0; i < s.Length; i++)
        {
            var symbol = s[i];
            if (!symbolCounts.ContainsKey(symbol))
            {
                continue;
            }

            symbolCounts[symbol]++;

            if (symbolCounts[symbol] == targetSymbolCounts[symbol])
            {
                missingSymbolsCount--;
            }

            if (missingSymbolsCount == 0)
            {
                while (true)
                {
                    var startSymbol = s[startIndex];
                    if (symbolCounts.ContainsKey(startSymbol))
                    {
                        if (symbolCounts[startSymbol] == targetSymbolCounts[startSymbol])
                        {
                            break;
                        }

                        symbolCounts[startSymbol]--;
                    }

                    startIndex++;
                }
            }

            var length = i - startIndex + 1;
            if (length < minWindowLength && missingSymbolsCount == 0)
            {
                minWindowLength = length;
                minWindowStartIndex = startIndex;
            }

            while (length >= minWindowLength)
            {
                var startSymbol = s[startIndex];
                if (symbolCounts.ContainsKey(startSymbol))
                {
                    if (symbolCounts[startSymbol] == targetSymbolCounts[startSymbol])
                    {
                        missingSymbolsCount++;
                    }

                    symbolCounts[startSymbol]--;
                }

                startIndex++;
                length--;
            }
        }

        if (minWindowStartIndex == notFound)
        {
            return "";
        }

        return s.Substring(minWindowStartIndex, minWindowLength);
    }
}
