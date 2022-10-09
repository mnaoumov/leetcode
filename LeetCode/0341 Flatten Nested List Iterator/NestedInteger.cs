namespace LeetCode._0341_Flatten_Nested_List_Iterator;

// ReSharper disable once InconsistentNaming
public interface NestedInteger
{
    // @return true if this NestedInteger holds a single integer, rather than a nested list.
    bool IsInteger();

    // @return the single integer that this NestedInteger holds, if it holds a single integer
    // Output null if this NestedInteger holds a nested list
    int GetInteger();

    // @return the nested list that this NestedInteger holds, if it holds a nested list
    // Output null if this NestedInteger holds a single integer
    IList<NestedInteger>? GetList();
}