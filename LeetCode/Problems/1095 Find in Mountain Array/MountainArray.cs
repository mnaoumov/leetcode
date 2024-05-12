namespace LeetCode._1095_Find_in_Mountain_Array
{
    public class MountainArray
    {
        private readonly int[] _array;

        public MountainArray(int[] array) => _array = array;

        public int Get(int index) => _array[index];
        public int Length() => _array.Length;
    }
}
