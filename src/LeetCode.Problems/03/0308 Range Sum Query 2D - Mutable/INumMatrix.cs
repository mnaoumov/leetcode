namespace LeetCode.Problems._0308_Range_Sum_Query_2D___Mutable;

[PublicAPI]
public interface INumMatrix
{
    void Update(int row, int col, int val);
    int SumRegion(int row1, int col1, int row2, int col2);
}
