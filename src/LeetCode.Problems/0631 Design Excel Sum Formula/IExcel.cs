namespace LeetCode.Problems._0631_Design_Excel_Sum_Formula;

[PublicAPI]
public interface IExcel
{
#pragma warning disable CA1716
    void Set(int row, char column, int val);
#pragma warning restore CA1716
#pragma warning disable CA1716
    int Get(int row, char column);
#pragma warning restore CA1716
    int Sum(int row, char column, string[] numbers);
}
