using JetBrains.Annotations;

namespace LeetCode.Problems._0642_Design_Search_Autocomplete_System;

[PublicAPI]
public interface IAutocompleteSystem
{
    public IList<string> Input(char c);
}
