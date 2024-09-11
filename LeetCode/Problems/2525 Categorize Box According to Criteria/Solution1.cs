namespace LeetCode.Problems._2525_Categorize_Box_According_to_Criteria;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-95/submissions/detail/873326075/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string CategorizeBox(int length, int width, int height, int mass)
    {
        const int bulkyDimension = 10_000;
        const int bulkyVolume = 1_000_000_000;
        const int heavyMass = 100;

        var isBulky = length >= bulkyDimension || width >= bulkyDimension || height >= bulkyDimension || 1L * length * width * height >= bulkyVolume;
        var isHeavy = mass >= heavyMass;

        return (isBulky, isHeavy) switch
        {
            (true, true) => "Both",
            (false, false) => "Neither",
            (true, false) => "Bulky",
            (false, true) => "Heavy"
        };
    }
}
