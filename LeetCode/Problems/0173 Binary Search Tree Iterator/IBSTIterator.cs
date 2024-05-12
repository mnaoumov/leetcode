using JetBrains.Annotations;

namespace LeetCode.Problems._0173_Binary_Search_Tree_Iterator;

[PublicAPI]
public interface IBSTIterator
{
    public int Next();
    public bool HasNext();
}
