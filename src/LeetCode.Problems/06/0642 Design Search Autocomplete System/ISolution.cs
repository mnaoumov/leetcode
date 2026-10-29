namespace LeetCode.Problems._0642_Design_Search_Autocomplete_System;

[PublicAPI]
public interface ISolution
{
    IAutocompleteSystem Create(string[] sentences, int[] times);
}
