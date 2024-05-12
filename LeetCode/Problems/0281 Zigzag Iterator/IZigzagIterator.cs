using JetBrains.Annotations;

namespace LeetCode.Problems._0281_Zigzag_Iterator;

[PublicAPI]
public interface IZigzagIterator
{
    public bool HasNext();
    public int Next();
}
