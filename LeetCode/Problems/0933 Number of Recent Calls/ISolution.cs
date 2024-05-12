using JetBrains.Annotations;

namespace LeetCode._0933_Number_of_Recent_Calls;

[PublicAPI]
public interface ISolution
{
    public IRecentCounter Create();
}
