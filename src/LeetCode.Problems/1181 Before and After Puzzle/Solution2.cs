namespace LeetCode.Problems._1181_Before_and_After_Puzzle;

/// <summary>
/// https://leetcode.com/problems/before-and-after-puzzle/submissions/1743967983/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<string> BeforeAndAfterPuzzles(string[] phrases)
    {
        var firstWordToTails = new Dictionary<string, List<(string tail, int index)>>();
        var lastWords = new List<string>();

        for (var i = 0; i < phrases.Length; i++)
        {
            var phrase = phrases[i];
            var index = phrase.IndexOf(' ');

            if (index == -1)
            {
                lastWords.Add(phrase);
                firstWordToTails.TryAdd(phrase, new List<(string tail, int index)>());
                firstWordToTails[phrase].Add(("", i));
            }
            else
            {
                var lastIndex = phrase.LastIndexOf(' ');
                var firstWord = phrase[..index];
                var tail = phrase[index..];
                var lastWord = phrase[(lastIndex + 1)..];
                firstWordToTails.TryAdd(firstWord, new List<(string tail, int index)>());
                firstWordToTails[firstWord].Add((tail, i));
                lastWords.Add(lastWord);
            }
        }

        var set = new HashSet<string>();

        var n = phrases.Length;

        for (var i = 0; i < n; i++)
        {
            var phrase = phrases[i];
            var lastWord = lastWords[i];

            foreach (var (tail, index) in firstWordToTails.GetValueOrDefault(lastWord, new List<(string tail, int index)>()))
            {
                if (index != i)
                {
                    set.Add(phrase + tail);
                }
            }
        }

        return set.OrderBy(x => x).ToArray();
    }
}
