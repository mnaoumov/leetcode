namespace LeetCode.Problems._0386_Lexicographical_Numbers;

/// <summary>
/// https://leetcode.com/submissions/detail/1396959669/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> LexicalOrder(int n)
    {
        var ans = new List<int>();
        AddLexicalOrder(0);
        return ans;

        void AddLexicalOrder(int num)
        {
            if (num > n)
            {
                return;
            }

            if (num != 0)
            {
                ans.Add(num);
            }

            for (var i = 0; i < 10; i++)
            {
                var nextNum = num * 10 + i;
                if (nextNum == 0)
                {
                    continue;
                }

                AddLexicalOrder(nextNum);
            }
        }
    }
}
