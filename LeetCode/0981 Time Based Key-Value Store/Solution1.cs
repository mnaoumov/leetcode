namespace LeetCode._0981_Time_Based_Key_Value_Store;

/// <summary>
/// https://leetcode.com/submissions/detail/816620559/
/// </summary>
public class Solution1 : ISolution
{
    public ITimeMap Create()
    {
        return new TimeMap1();
    }
}