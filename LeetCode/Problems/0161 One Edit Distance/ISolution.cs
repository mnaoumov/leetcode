using JetBrains.Annotations;

namespace LeetCode.Problems._0161_One_Edit_Distance;

[PublicAPI]
public interface ISolution
{
    public bool IsOneEditDistance(string s, string t);
}
