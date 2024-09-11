namespace LeetCode.Problems._0752_Open_the_Lock;

/// <summary>
/// https://leetcode.com/submissions/detail/904863665/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int OpenLock(string[] deadends, string target)
    {
        var queue = new Queue<(string code, int turnsCount)>();
        queue.Enqueue(("0000", 0));

        var seen = deadends.ToHashSet();

        var deltas = new[] { -1, 1 };

        while (queue.Count > 0)
        {
            var (code, turnsCount) = queue.Dequeue();

            if (code == target)
            {
                return turnsCount;
            }

            if (!seen.Add(code))
            {
                continue;
            }

            var digits = code.Select(symbol => symbol - '0').ToArray();

            const int digitsCount = 4;

            for (var i = 0; i < digitsCount; i++)
            {
                foreach (var delta in deltas)
                {
                    var digit = digits[i];
                    digits[i] = (digit + delta + 10) % 10;
                    queue.Enqueue((string.Concat(digits), turnsCount + 1));
                    digits[i] = digit;
                }
            }
        }

        const int impossible = -1;
        return impossible;
    }
}
