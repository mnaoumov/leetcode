namespace LeetCode.Problems._1429_First_Unique_Number;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IFirstUnique Create(int[] nums) => new FirstUnique(nums);

    private class FirstUnique : IFirstUnique
    {
        private readonly HashSet<int> _allItems = new();
        private readonly HashSet<int> _uniqueItems = new();
        private readonly List<int> _list = new();

        public FirstUnique(int[] nums)
        {
            foreach (var num in nums)
            {
                Add(num);
            }
        }
    
        public int ShowFirstUnique()
        {
            while (_list.Count > 0 && !_uniqueItems.Contains(_list[0]))
            {
                _list.RemoveAt(0);
            }

            return _list.Count > 0 ? _list[0] : -1;
        }
    
        public void Add(int value)
        {
            if (!_allItems.Add(value))
            {
                _uniqueItems.Remove(value);
            }
            else
            {
                _uniqueItems.Add(value);
                _list.Add(value);
            }
        }
    }
}
