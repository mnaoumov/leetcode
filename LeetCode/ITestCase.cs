using System.Collections;

namespace LeetCode;

public interface ITestCase
{
    IEnumerable<TestCaseBase> TestCases { get; }
}