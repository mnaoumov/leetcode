namespace LeetCode.Problems._3306_Count_of_Substrings_Containing_Every_Vowel_and_K_Consonants_II;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    public long CountOfSubstrings(string word, int k)
    {
        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
        const char consonant = 'c';
        var letterToIndexMap = vowels.Append(consonant).Select((letter, index) => (letter, index)).ToDictionary(x => x.letter, x => x.index);
        var n = word.Length;
        var prefixCounts = new int[n + 1, vowels.Count + 1];

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < vowels.Count + 1; j++)
            {
                prefixCounts[i + 1, j] = prefixCounts[i, j];
            }

            var letter = word[i];
            if (!vowels.Contains(letter))
            {
                letter = consonant;
            }
            var letterIndex = letterToIndexMap[letter];

            prefixCounts[i + 1, letterIndex]++;
        }

        var ans = 0L;

        for (var i = 0; i < n; i++)
        {
            var constantCount = GetCounts(0, i, consonant);

            if (constantCount < k)
            {
                continue;
            }

            var vowelCounts = vowels.ToDictionary(vowel => vowel, vowel => GetCounts(0, i, vowel));
            if (vowelCounts.Values.Any(vowelCount => vowelCount == 0))
            {
                continue;
            }

            var to = i;
            var firstIndex = BinarySearchFirst(0, i, from => IsValid(from, to));
            var lastIndex = BinarySearchLast(0, i, from => IsValid(from, to));
            ans += lastIndex - firstIndex + 1;
        }

        return ans;

        int GetCounts(int from, int to, char letter)
        {
            var letterIndex = letterToIndexMap[letter];
            return prefixCounts[to + 1, letterIndex] - prefixCounts[from, letterIndex];
        }

        bool IsValid(int from, int to)
        {
            var constantCount = GetCounts(from, to, consonant);
            if (constantCount != k)
            {
                return false;
            }

            var vowelCounts = vowels.ToDictionary(vowel => vowel, vowel => GetCounts(from, to, vowel));
            return vowelCounts.Values.All(vowelCount => vowelCount > 0);
        }
    }

    private static int BinarySearchFirst(int firstIndex, int lastIndex, Func<int, bool> validatorFunc)
    {
        var low = firstIndex;
        var high = lastIndex;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (validatorFunc(mid))
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;
    }

    private static int BinarySearchLast(int firstIndex, int lastIndex, Func<int, bool> validatorFunc)
    {
        var low = firstIndex;
        var high = lastIndex;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (validatorFunc(mid))
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return high;
    }

}
