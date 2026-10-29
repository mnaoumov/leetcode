namespace LeetCode.Problems._0278_First_Bad_Version;

public abstract class VersionControl
{
    private int _firstBadVersion;
    public abstract int FirstBadVersion(int n);
    public void SetFirstBadVersion(int version) => _firstBadVersion = version;
    protected bool IsBadVersion(int version) => version >= _firstBadVersion;
}
