namespace LeetCode.Problems._0362_Design_Hit_Counter;

[PublicAPI]
public interface IHitCounter
{
    public void Hit(int timestamp);
    public int GetHits(int timestamp);
}
