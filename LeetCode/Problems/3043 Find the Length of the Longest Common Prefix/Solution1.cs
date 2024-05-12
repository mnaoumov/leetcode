using JetBrains.Annotations;

namespace LeetCode.Problems._3043_Find_the_Length_of_the_Longest_Common_Prefix;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-385/submissions/detail/1178430223/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LongestCommonPrefix(int[] arr1, int[] arr2)
    {
        var root = new TrieNode { IsFirstArrayNumberPrefix = true, IsSecondArrayNumberPrefix = true };

        foreach (var num1 in arr1)
        {
            root.AddNumber(num1, isFirstArray: true);
        }

        foreach (var num2 in arr2)
        {
            root.AddNumber(num2, isFirstArray: false);
        }

        return root.GetMaxLevel();
    }

    private class TrieNode
    {
        private readonly TrieNode?[] _childNodes = new TrieNode?[10];
        public bool IsFirstArrayNumberPrefix { get; set; }
        public bool IsSecondArrayNumberPrefix { get; set; }
        private int Level { get; init; }

        public void AddNumber(int num, bool isFirstArray)
        {
            var node = this;

            foreach (var digit in num.ToString().Select(digitChar => digitChar - '0'))
            {
                node = node._childNodes[digit] ??= new TrieNode { Level = node.Level + 1 };

                if (isFirstArray)
                {
                    node.IsFirstArrayNumberPrefix = true;
                }
                else
                {
                    node.IsSecondArrayNumberPrefix = true;
                }
            }
        }

        public int GetMaxLevel()
        {
            if (!IsFirstArrayNumberPrefix || !IsSecondArrayNumberPrefix)
            {
                return 0;
            }

            return _childNodes.Select(node => node?.GetMaxLevel() ?? 0).Append(Level).Max();
        }
    }
}
