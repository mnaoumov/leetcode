namespace LeetCode.Problems._1298_Maximum_Candies_You_Can_Get_from_Boxes;

/// <summary>
/// https://leetcode.com/problems/maximum-candies-you-can-get-from-boxes/submissions/1652230995/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaxCandies(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes)
    {
        var n = status.Length;
        var boxes = new Box[n];

        for (var i = 0; i < n; i++)
        {
            boxes[i] = new Box
            {
                IsOpen = status[i] == 1,
                Candies = candies[i]
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
        var availableKeyBoxes = new HashSet<Box>();

        foreach (var boxIndex in initialBoxes)
        {
            processingBoxes.Enqueue(boxes[boxIndex]);
        }

        while (processingBoxes.Count > 0)
        {
            var box = processingBoxes.Dequeue();

            if (box.IsProcessed)
            {
                continue;
            }

            if (!box.IsOpen && !availableKeyBoxes.Contains(box))
            {
                continue;
            }

            box.IsProcessed = true;
            ans += box.Candies;
            foreach (var containedBox in box.ContainedBoxes)
            {
                processingBoxes.Enqueue(containedBox);
            }
            foreach (var keyBox in box.KeyBoxes.Where(keyBox => !keyBox.IsProcessed))
            {
                if (availableKeyBoxes.Add(keyBox))
                {
                    processingBoxes.Enqueue(keyBox);
                }
            }
        }

        return ans;
    }

    private class Box
    {
        public bool IsOpen { get; init; }
        public int Candies { get; init; }
        public List<Box> ContainedBoxes { get; } = new();
        public List<Box> KeyBoxes { get; } = new();
        public bool IsProcessed { get; set; }
    }
}
