namespace LeetCode.Problems._2011_Final_Value_of_Variable_After_Performing_Operations;

/// <summary>
/// https://leetcode.com/problems/final-value-of-variable-after-performing-operations/submissions/1806331713/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FinalValueAfterOperations(string[] operations)
    {
        var ans = 0;

        foreach (var operation in operations)
        {
            switch (operation)
            {
                case "X++":
                case "++X":
                    ans++;
                    break;
                case "X--":
                case "--X":
                    ans--;
                    break;
            }
        }

        return ans;
    }
}
