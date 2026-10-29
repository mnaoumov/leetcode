namespace LeetCode.Problems._1533_Find_the_Index_of_the_Large_Integer;

public class ArrayReader
{
    private readonly int[] _array;

    public ArrayReader(int[] array)
    {
        _array = array;
    }

    public int CompareSub(int l, int r, int x, int y)
    {
        if (!ValidateIndex(l) || !ValidateIndex(r) || !ValidateIndex(x) || !ValidateIndex(y) || l > r || x > y)
        {
            throw new ArgumentException("");
        }

        var sum1 = GetSum(l, r);
        var sum2 = GetSum(x, y);

        if (sum1 > sum2)
        {
            return 1;
        }

        if (sum1 == sum2)
        {
            return 0;
        }

        return -1;
    }

    private bool ValidateIndex(int index) => 0 <= index && index < Length();

    private int GetSum(int a, int b)
    {
        var sum = 0;

        for (var i = a; i <= b; i++)
        {
            sum += _array[i];
        }

        return sum;
    }

    public int Length() => _array.Length;
}
