using JetBrains.Annotations;

namespace LeetCode._1472_Design_Browser_History;

/// <summary>
/// https://leetcode.com/submissions/detail/917631234/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IBrowserHistory Create(string homepage)
    {
        return new BrowserHistory1(homepage);
    }
}
