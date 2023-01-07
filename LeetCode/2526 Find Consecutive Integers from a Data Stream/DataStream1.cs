namespace LeetCode._2526_Find_Consecutive_Integers_from_a_Data_Stream;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-95/submissions/detail/873334371/
/// </summary>
public class DataStream1 : IDataStream
{
    private readonly int _value;
    private readonly int _k;
    private int _count;

    public DataStream1(int value, int k)
    {
        _value = value;
        _k = k;
    }

    public bool Consec(int num)
    {
        if (num == _value)
        {
            _count++;
        }
        else
        {
            _count = 0;
        }

        return _count >= _k;
    }
}
