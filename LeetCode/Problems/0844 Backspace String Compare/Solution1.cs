using JetBrains.Annotations;

namespace LeetCode.Problems._0844_Backspace_String_Compare;

/// <summary>
/// https://leetcode.com/submissions/detail/899441371/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool BackspaceCompare(string s, string t)
    {
        var stackS = new Stack<char>();
        var stackT = new Stack<char>();

        FillSymbolsStack(s, stackS);
        FillSymbolsStack(t, stackT);

        return stackS.SequenceEqual(stackT);
    }

    private static void FillSymbolsStack(string str, Stack<char> symbolsStack)
    {
        foreach (var symbol in str)
        {
            if (symbol == '#')
            {
                if (symbolsStack.Count > 0)
                {
                    symbolsStack.Pop();
                }
            }
            else
            {
                symbolsStack.Push(symbol);
            }
        }
    }
}
