namespace LeetCode.Problems._1298_Maximum_Candies_You_Can_Get_from_Boxes;

/// <summary>
/// https://leetcode.com/problems/maximum-candies-you-can-get-from-boxes/submissions/1652240265/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MaxCandies(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes)
    {
        var n = status.Length;
        var boxes = new Box[n];

        for (var i = 0; i < n; i++)
        {
            boxes[i] = new Box
            {
                Index = i,
                IsOpen = status[i] == 1,
                Candies = candies[i],
            };
        }

        for (var i = 0; i < n; i++)
        {
            foreach (var key in keys[i])
            {
                boxes[i].KeyBoxes.Add(boxes[key]);
            }
            foreach (var containedBox in containedBoxes[i])
            {
                boxes[i].ContainedBoxes.Add(boxes[containedBox]);
            }
        }


        var processingBoxes = new Queue<Box>();
        var ans = 0;

        foreach (var boxIndex in initialBoxes)
        {
            var box = boxes[boxIndex];
            box.IsAvailable = true;
            processingBoxes.Enqueue(box);
        }

        while (processingBoxes.Count > 0)
        {
            var box = processingBoxes.Dequeue();

            if (!box.IsAvailable || box.IsProcessed)
            {
                continue;
            }

            if (!box.IsOpen)
            {
                continue;
            }

            box.IsProcessed = true;
            ans += box.Candies;
            foreach (var containedBox in box.ContainedBoxes)
            {
                containedBox.IsAvailable = true;
                processingBoxes.Enqueue(containedBox);
            }
            foreach (var keyBox in box.KeyBoxes.Where(keyBox => keyBox is { IsProcessed: false, IsOpen: false }))
            {
                keyBox.IsOpen = true;
                if (keyBox.IsAvailable)
                {
                    processingBoxes.Enqueue(keyBox);
                }
            }
        }

        return ans;
    }

    private class Box
    {
        public int Index { get; init; }
        public bool IsOpen { get; set; }
        public int Candies { get; init; }
        public List<Box> ContainedBoxes { get; } = new();
        public List<Box> KeyBoxes { get; } = new();
        public bool IsProcessed { get; set; }
        public bool IsAvailable { get; set; }

        public override string ToString() => $"Box {Index}";
    }
}
