namespace LeetCode.Problems._3228_Maximum_Number_of_Operations_to_Move_Ones_to_the_End;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-407/submissions/detail/1327952220/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MaxOperations(string s)
    {
        var n = s.Length;
        var ans = 0;

        var oneIndices = new SortedSet<int>(Enumerable.Range(0, n).Where(i => s[i] == '1'));

        while (true)
        {
            var isDone = true;
            foreach (var oneIndex in oneIndices.Where(oneIndex => oneIndex != n - 1 && !oneIndices.Contains(oneIndex + 1)))
            {
                ans++;
                var subset = oneIndices.GetViewBetween(oneIndex + 1, n - 1);
                var nextOneIndex = subset.Count == 0 ? n - 1 : subset.Min - 1;
                oneIndices.Remove(oneIndex);
                oneIndices.Add(nextOneIndex);
                isDone = false;
                break;
            }

            if (isDone)
            {
                return ans;
            }
        }
    }
}
