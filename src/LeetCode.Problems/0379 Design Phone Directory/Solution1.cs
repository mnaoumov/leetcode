namespace LeetCode.Problems._0379_Design_Phone_Directory;

/// <summary>
/// https://leetcode.com/problems/design-phone-directory/submissions/1964355130/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IPhoneDirectory Create(int maxNumbers) => new PhoneDirectory(maxNumbers);

    private sealed class PhoneDirectory : IPhoneDirectory
    {
        private readonly SortedSet<int> _set;

        public PhoneDirectory(int maxNumbers)
        {
            _set = new SortedSet<int>(Enumerable.Range(0, maxNumbers));
        }
    
        public int Get()
        {
            if (_set.Count == 0)
            {
                return -1;
            }

            var ans = _set.Min;
            _set.Remove(ans);
            return ans;
        }

        public bool Check(int number) => _set.Contains(number);

        public void Release(int number) => _set.Add(number);
    }
}
