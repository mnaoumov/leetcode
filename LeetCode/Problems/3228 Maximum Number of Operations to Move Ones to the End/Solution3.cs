namespace LeetCode.Problems._3228_Maximum_Number_of_Operations_to_Move_Ones_to_the_End;

/// <summary>
/// https://leetcode.com/problems/maximum-number-of-operations-to-move-ones-to-the-end/submissions/1828873053/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MaxOperations(string s)
    {
        var oneCounts = new List<int>();
        var oneCount = 0;

        foreach (var symbol in s)
        {
            if (symbol == '1')
            {
                oneCount++;
            }
            else if (oneCount > 0)
            {
                oneCounts.Add(oneCount);
                oneCount = 0;
            }
        }

        return oneCounts.Select((count, index) => count * (oneCounts.Count - index)).Sum();
    }
}
