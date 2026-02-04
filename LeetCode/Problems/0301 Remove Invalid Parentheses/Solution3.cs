namespace LeetCode.Problems._0301_Remove_Invalid_Parentheses;

/// <summary>
/// https://leetcode.com/submissions/detail/879295292/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public IList<string> RemoveInvalidParentheses(string s)
    {
        var allValidStrs = new HashSet<string>();

        var n = s.Length;
        var shouldTake = Enumerable.Repeat(true, n).ToArray();
        var maxResultLength = 0;

        Process(0, n);

        return allValidStrs.Where(str => str.Length == maxResultLength).ToArray();

        void Process(int index, int resultLength)
        {
            if (resultLength < maxResultLength)
            {
                return;
            }

            if (index == n)
            {
                var str = Build();

                if (!IsValidParentheses(str))
                {
                    return;
                }

                allValidStrs.Add(str);
                maxResultLength = Math.Max(maxResultLength, str.Length);
                return;
            }

            Process(index + 1, resultLength);

            if (s[index] != '(' && s[index] != ')')
            {
                return;
            }

            shouldTake[index] = false;
            Process(index + 1, resultLength - 1);
            shouldTake[index] = true;
        }

        string Build() => string.Concat(s.Where((_, index) => shouldTake[index]));

        static bool IsValidParentheses(string str)
        {
            var balance = 0;

            foreach (var symbol in str)
            {
                switch (symbol)
                {
                    case '(':
                        balance++;
                        break;
                    case ')':
                        balance--;

                        if (balance < 0)
                        {
                            return false;
                        }

                        break;
                }
            }

            return balance == 0;
        }
    }
}
