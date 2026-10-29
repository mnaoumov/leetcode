namespace LeetCode.Problems._0362_Design_Hit_Counter;

[PublicAPI]
public interface IHitCounter
{
    void Hit(int timestamp);
    int GetHits(int timestamp);
}
