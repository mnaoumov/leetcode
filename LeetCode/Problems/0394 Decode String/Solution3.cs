using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._0394_Decode_String;

/// <summary>
/// https://leetcode.com/submissions/detail/882189412/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public string DecodeString(string s)
    {
        var counters = new Stack<int>();
        var stringBuilders = new Stack<StringBuilder>();
        stringBuilders.Push(new StringBuilder());
        var shouldStartNewCounter = true;

        foreach (var symbol in s)
        {
            switch (symbol)
            {
                case { } when char.IsDigit(symbol):
                    {
                        if (shouldStartNewCounter)
                        {
                            counters.Push(0);
                            shouldStartNewCounter = false;
                        }

                        var counter = counters.Pop();
                        counter = counter * 10 + (symbol - '0');
                        counters.Push(counter);
                        break;
                    }
                case '[':
                    stringBuilders.Push(new StringBuilder());
                    shouldStartNewCounter = true;
                    break;
                case ']':
                    {
                        var stringBuilder = stringBuilders.Pop();
                        var counter = counters.Pop();
                        var combinedStringBuilder = stringBuilders.Peek();

                        for (var i = 0; i < counter; i++)
                        {
                            combinedStringBuilder.Append(stringBuilder);
                        }

                        shouldStartNewCounter = true;
                        break;
                    }
                default:
                    stringBuilders.Peek().Append(symbol);
                    break;
            }
        }

        return stringBuilders.Pop().ToString();
    }
}
