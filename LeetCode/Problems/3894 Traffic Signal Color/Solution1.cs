namespace LeetCode.Problems._3894_Traffic_Signal_Color;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-180/problems/traffic-signal-color/submissions/1975403404/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string TrafficSignal(int timer)
    {
        return timer switch
        {
            0 => "Green",
            30 => "Orange",
            > 30 and <= 90 => "Red",
            _ => "Invalid"
        };
    }
}
