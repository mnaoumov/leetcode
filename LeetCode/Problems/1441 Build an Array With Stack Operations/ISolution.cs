using JetBrains.Annotations;

namespace LeetCode.Problems._1441_Build_an_Array_With_Stack_Operations;

[PublicAPI]
public interface ISolution
{
    public IList<string> BuildArray(int[] target, int n);
}
