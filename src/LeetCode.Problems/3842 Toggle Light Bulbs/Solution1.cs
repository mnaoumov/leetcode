namespace LeetCode.Problems._3842_Toggle_Light_Bulbs;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> ToggleLightBulbs(IList<int> bulbs) =>
        bulbs
            .GroupBy(bulb => bulb)
            .Select(g => (bulb: g.Key, count: g.Count()))
            .Where(x => x.count % 2 == 1)
            .Select(x => x.bulb)
            .OrderBy(x => x)
            .ToArray();
}
