using JetBrains.Annotations;

namespace LeetCode.Problems._0460_LFU_Cache;

[PublicAPI]
public interface ISolution
{
    public ILFUCache Create(int capacity);
}
