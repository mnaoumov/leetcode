namespace LeetCode.Problems._0383_Ransom_Note;

/// <seealso href="https://leetcode.com/problems/ransom-note/submissions/845906888/"/>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        var magazineLettersCountMap = magazine.GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());

        foreach (var letter in ransomNote)
        {
            if (!magazineLettersCountMap.ContainsKey(letter))
            {
                return false;
            }

            magazineLettersCountMap[letter]--;

            if (magazineLettersCountMap[letter] == 0)
            {
                magazineLettersCountMap.Remove(letter);
            }
        }

        return true;
    }
}
