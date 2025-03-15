namespace LeetCode.Problems._3484_Design_Spreadsheet;

[PublicAPI]
public interface ISpreadsheet
{
    public void SetCell(string cell, int value);
    public void ResetCell(string cell);
    public int GetValue(string formula);
}
