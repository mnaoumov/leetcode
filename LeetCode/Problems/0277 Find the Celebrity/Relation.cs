namespace LeetCode.Problems._0277_Find_the_Celebrity;

public class Relation
{
    private int[][] _graph = null!;
    public bool Knows(int a, int b) => _graph[a][b] == 1;
    public void Init(int[][] graph) => _graph = graph;
}