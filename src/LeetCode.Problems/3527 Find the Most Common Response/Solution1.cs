namespace LeetCode.Problems._3527_Find_the_Most_Common_Response;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-155/problems/find-the-most-common-response/submissions/1618436965/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string FindCommonResponse(IList<IList<string>> responses)
    {
        var counts = new Dictionary<string, int>();

        foreach (var responseList in responses)
        {
            foreach (var response in responseList.Distinct())
            {
                counts.TryAdd(response, 0);
                counts[response]++;
            }
        }

        var maxCount = counts.Values.Max();
        var mostCommonResponses = counts
            .Where(kvp => kvp.Value == maxCount)
            .Select(kvp => kvp.Key)
            .ToArray();
        return mostCommonResponses.Min()!;
    }
}
