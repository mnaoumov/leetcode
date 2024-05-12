using JetBrains.Annotations;

namespace LeetCode._0281_Zigzag_Iterator;

[PublicAPI]
public interface IZigzagIterator
{
    public bool HasNext();
    public int Next();
}
