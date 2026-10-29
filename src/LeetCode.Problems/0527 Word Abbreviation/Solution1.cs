namespace LeetCode.Problems._0527_Word_Abbreviation;

/// <summary>
/// https://leetcode.com/problems/word-abbreviation/submissions/1706633204/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<string> WordsAbbreviation(IList<string> words)
    {
        var entries = words.Select((word, index) => new Entry(Word: word, Index: index, Length: word.Length,
            FirstLetter: word[0], LastLetter: word[^1])).ToArray();

        var groups = entries.GroupBy(e => new { e.Length, e.FirstLetter, e.LastLetter });

        foreach (var group in groups)
        {
            var key = group.Key;

            if (key.Length <= 3)
            {
                foreach (var entry in group)
                {
                    entry.Abbreviation = entry.Word;
                }
                continue;
            }

            if (group.Count() == 1)
            {
                var entry = group.First();
                var abbreviation = "" + entry.FirstLetter + (entry.Length - 2) + entry.LastLetter;
                entry.Abbreviation = abbreviation.Length < entry.Length ? abbreviation : entry.Word;
                continue;
            }

            var shortWords = group.Select(w => w.Word[1..]).ToArray();
            var shortAbbreviations = WordsAbbreviation(shortWords);

            foreach (var (entry, shortAbbreviation) in group.Zip(shortAbbreviations))
            {
                entry.Abbreviation = entry.FirstLetter + shortAbbreviation;
            }
        }

        return entries.OrderBy(e => e.Index).Select(e => e.Abbreviation).ToArray();
    }

    private record Entry(string Word, int Index, int Length, char FirstLetter, char LastLetter)
    {
        public string Abbreviation { get; set; } = Word;
    }
}
