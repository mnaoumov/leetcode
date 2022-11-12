using JetBrains.Annotations;

namespace LeetCode._2468_Split_Message_Based_on_Limit;

/// <summary>
/// 
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string[] SplitMessage(string message, int limit)
    {
        var partsCount = 1;
        var index = 1;
        var length = message.Length;

        while (index <= partsCount)
        {
            var suffix = $"<{index}/{partsCount}>";

            if (suffix.Length <= limit)
            {
                return Array.Empty<string>();
            }

            var newPartsCount = length / (limit - suffix.Length);

            //if (newPartsCount.To)

            partsCount = length / (limit - suffix.Length);
            index *= 10;
        }

        return null;
    }
}
