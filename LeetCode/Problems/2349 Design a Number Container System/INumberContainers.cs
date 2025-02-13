namespace LeetCode.Problems._2349_Design_a_Number_Container_System;

[PublicAPI]
public interface INumberContainers
{
    public void Change(int index, int number);
    public int Find(int number);
}
