namespace LeetCode.Problems._1346_Check_If_N_and_Its_Double_Exist;

/// <summary>
/// https://leetcode.com/submissions/detail/928130601/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CheckIfExist(int[] arr)
    {
        var set = new HashSet<int>();

        foreach (var num in arr)
        {
            if (set.Contains(2 * num) || num % 2 == 0 && set.Contains(num / 2))
            {
                return true;
            }

            set.Add(num);
        }

        return false;
    }
}
