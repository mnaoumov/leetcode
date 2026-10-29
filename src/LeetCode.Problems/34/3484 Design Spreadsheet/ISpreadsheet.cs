namespace LeetCode.Problems._3484_Design_Spreadsheet;

[PublicAPI]
public interface ISpreadsheet
{
    void SetCell(string cell, int value);
    void ResetCell(string cell);
    int GetValue(string formula);
}
