using JetBrains.Annotations;

namespace LeetCode._0721_Accounts_Merge;

[PublicAPI]
public interface ISolution
{
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts);
}
