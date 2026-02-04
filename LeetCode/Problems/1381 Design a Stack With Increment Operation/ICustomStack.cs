namespace LeetCode.Problems._1381_Design_a_Stack_With_Increment_Operation;

[PublicAPI]
public interface ICustomStack
{
    void Push(int x);
    int Pop();
    void Increment(int k, int val);
}
