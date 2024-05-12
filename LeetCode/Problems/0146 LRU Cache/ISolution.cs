using JetBrains.Annotations;

namespace LeetCode.Problems._0146_LRU_Cache;

[PublicAPI]
public interface ISolution
{
    ILRUCache Create(int capacity);
}
