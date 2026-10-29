namespace LeetCode.Problems._3501_Maximize_Active_Section_with_Trade_II;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    public IList<int> MaxActiveSectionsAfterTrade(string s, int[][] queries)
    {
        const char active = '1';
        var sectionBlocks = new List<SectionBlock> { new(0, 0, true) };

        foreach (var state in s)
        {
            var isActive = state == active;

            var lastBlock = sectionBlocks[^1];

            if (lastBlock.IsActive == isActive)
            {
                sectionBlocks[^1] = lastBlock with
                {
                    Length = lastBlock.Length + 1,
                    EndIndex = lastBlock.EndIndex + 1
                };
            }
            else
            {
                sectionBlocks.Add(new SectionBlock(lastBlock.EndIndex + 1, 1, isActive));
            }
        }

        return queries.Select(_ => 0).ToArray();
    }

    private record SectionBlock(int EndIndex, int Length, bool IsActive);
}
