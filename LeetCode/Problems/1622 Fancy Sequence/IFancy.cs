namespace LeetCode.Problems._1622_Fancy_Sequence;

[PublicAPI]
public interface IFancy
{
    public void Append(int val);
    public void AddAll(int inc);
    public void MultAll(int m);
    public int GetIndex(int idx);
}
