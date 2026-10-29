namespace LeetCode.Problems._2349_Design_a_Number_Container_System;

[PublicAPI]
public interface INumberContainers
{
    void Change(int index, int number);
    int Find(int number);
}
