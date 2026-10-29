namespace LeetCode.Problems._3484_Design_Spreadsheet;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-152/problems/design-spreadsheet/submissions/1574569955/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ISpreadsheet Create(int rows) => new Spreadsheet(rows);

    private class Spreadsheet : ISpreadsheet
    {
        private readonly Dictionary<string, int> _dict = new();

        // ReSharper disable once UnusedParameter.Local
        public Spreadsheet(int rows)
        {
        }
    
        public void SetCell(string cell, int value) => _dict[cell] = value;

        public void ResetCell(string cell) => SetCell(cell, 0);

        public int GetValue(string formula)
        {
            var subFormulas = formula[1..].Split('+');
            return subFormulas.Select(GetCellOrConstantValue).Sum();
        }

        private int GetCellOrConstantValue(string formula) =>
            char.IsLetter(formula[0]) ? _dict.GetValueOrDefault(formula) : int.Parse(formula);
    }
}
