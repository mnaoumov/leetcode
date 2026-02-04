namespace LeetCode.Problems._1146_Snapshot_Array;

[PublicAPI]
public interface ISnapshotArray
{
    void Set(int index, int val);
    int Snap();
    // ReSharper disable once InconsistentNaming
    int Get(int index, int snap_id);
}
