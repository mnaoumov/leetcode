using JetBrains.Annotations;

namespace LeetCode._0443_String_Compression;

/// <summary>
/// https://leetcode.com/submissions/detail/907426488/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int Compress(char[] chars)
    {
        var lastChar = default(char);
        var count = 0;
        var resultIndex = 0;

        for (var i = 0; i <= chars.Length; i++)
        {
            var @char = i < chars.Length ? chars[i] : default;

            if (@char == lastChar)
            {
                count++;
            }
            else
            {
                if (lastChar != default)
                {
                    chars[resultIndex] = lastChar;
                    resultIndex++;

                    if (count > 1)
                    {
                        var countDigitsCount = 0;
                        var temp = count;

                        while (temp > 0)
                        {
                            temp /= 10;
                            countDigitsCount++;
                        }

                        temp = count;

                        for (var j = resultIndex + countDigitsCount - 1; j >= resultIndex; j--)
                        {
                            var digit = temp % 10;
                            chars[j] = (char) ('0' + digit);
                            temp /= 10;
                        }

                        resultIndex += countDigitsCount;
                    }
                }

                lastChar = @char;
                count = 1;
            }
        }

        return resultIndex;
    }
}
