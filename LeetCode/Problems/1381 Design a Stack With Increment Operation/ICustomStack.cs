namespace LeetCode.Problems._1381_Design_a_Stack_With_Increment_Operation;

[PublicAPI]
public interface ICustomStack
{
    public void Push(int x);
    public int Pop();
    public void Increment(int k, int val);
}
