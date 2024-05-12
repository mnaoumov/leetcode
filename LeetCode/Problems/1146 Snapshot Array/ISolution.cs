using JetBrains.Annotations;

namespace LeetCode.Problems._1146_Snapshot_Array;

[PublicAPI]
public interface ISolution
{
    public ISnapshotArray Create(int length);
}
