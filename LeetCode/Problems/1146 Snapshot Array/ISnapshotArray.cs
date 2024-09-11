namespace LeetCode.Problems._1146_Snapshot_Array;

[PublicAPI]
public interface ISnapshotArray
{
    public void Set(int index, int val);
    public int Snap();
    // ReSharper disable once InconsistentNaming
    public int Get(int index, int snap_id);
}
