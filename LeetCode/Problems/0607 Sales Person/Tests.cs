using JetBrains.Annotations;
using LeetCode.Sql;

namespace LeetCode.Problems._0607_Sales_Person;

[UsedImplicitly]
public class Tests : SelectSqlTestsBase<Tests>
{
    protected override bool IgnoreRowOrder => true;
}
