namespace LeetCode.Problems._3516_Find_Closest_Person;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-445/problems/find-closest-person/submissions/1605117387/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindClosest(int x, int y, int z)
    {
        var distance1 = Math.Abs(x - z);
        var distance2 = Math.Abs(y - z);

        if (distance1 < distance2)
        {
            return 1;
        }

        if (distance1 > distance2)
        {
            return 2;
        }

        return 0;
    }
}
