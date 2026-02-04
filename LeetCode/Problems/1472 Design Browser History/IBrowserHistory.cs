namespace LeetCode.Problems._1472_Design_Browser_History;

[PublicAPI]
public interface IBrowserHistory
{
    void Visit(string url);
    string Back(int steps);
    string Forward(int steps);
}
