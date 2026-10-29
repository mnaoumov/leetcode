namespace LeetCode.Problems._2502_Design_Memory_Allocator;

/// <summary>
/// https://leetcode.com/submissions/detail/859016671/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public IAllocator Create(int n) => new Allocator(n);

    private class Allocator : IAllocator
    {
        private readonly SortedList<int, (int size, int id)> _memoryBlocks;

        public Allocator(int n) => _memoryBlocks = new SortedList<int, (int size, int id)> { { 0, (n, 0) } };

        public int Allocate(int size, int mID)
        {
            foreach (var (blockStart, (blockSize, blockId)) in _memoryBlocks)
            {
                if (blockId != 0 || blockSize < size)
                {
                    continue;
                }

                _memoryBlocks.Remove(blockStart);
                _memoryBlocks.Add(blockStart, (size, mID));

                if (blockSize > size)
                {
                    _memoryBlocks.Add(blockStart + size, (blockSize - size, 0));
                }

                return blockStart;
            }

            return -1;
        }

        public int Free(int mID)
        {
            int? lastFreeBlockStart = null;
            var blocksCount = 0;
            foreach (var (blockStart, (blockSize, blockId)) in _memoryBlocks.ToArray())
            {
                if (blockId != mID && blockId != 0)
                {
                    lastFreeBlockStart = null;
                    continue;
                }

                int lastFreeBlockSize;

                if (lastFreeBlockStart == null)
                {
                    lastFreeBlockStart = blockStart;

                    if (blockId == 0)
                    {
                        continue;
                    }

                    lastFreeBlockSize = 0;
                }
                else
                {
                    lastFreeBlockSize = _memoryBlocks[lastFreeBlockStart.Value].size;
                }

                _memoryBlocks.Remove(blockStart);
                _memoryBlocks.Remove(lastFreeBlockStart.Value);
                _memoryBlocks.Add(lastFreeBlockStart.Value, (lastFreeBlockSize + blockSize, 0));

                if (blockId == mID)
                {
                    blocksCount++;
                }
            }

            return blocksCount;
        }
    }
}
