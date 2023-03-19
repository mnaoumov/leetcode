using JetBrains.Annotations;

namespace LeetCode._1472_Design_Browser_History;

[PublicAPI]
public interface IBrowserHistory
{
    public void Visit(string url);
    public string Back(int steps);
    public string Forward(int steps);
}
