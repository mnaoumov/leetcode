using JetBrains.Annotations;

namespace LeetCode._0223_Rectangle_Area;

[PublicAPI]
public interface ISolution
{
    public int ComputeArea(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2);
}
