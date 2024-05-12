using JetBrains.Annotations;

namespace LeetCode.Problems._1472_Design_Browser_History;

[PublicAPI]
public interface ISolution
{
    public IBrowserHistory Create(string homepage);
}
