﻿using JetBrains.Annotations;

namespace LeetCode._0040_Combination_Sum_II;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> CombinationSum2(int[] candidates, int target);
}