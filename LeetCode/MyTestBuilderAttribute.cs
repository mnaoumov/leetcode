using System.Reflection;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Builders;

namespace LeetCode;

public class MyTestBuilderAttribute : Attribute, IFixtureBuilder
{
    public IEnumerable<TestSuite> BuildFrom(ITypeInfo typeInfo)
    {
        var testFixture = new TestFixture(typeInfo);
        var methodInfo = typeInfo.GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .First(m => m.Name == "Test");

        var solutionInterfaceType = typeInfo.BaseType!.Type.GetGenericArguments()[0];
        var solutionTypes = solutionInterfaceType.Assembly.GetTypes().Where(t => t.IsClass && t.IsAssignableTo(solutionInterfaceType));
        var solutions = solutionTypes.Select(t => Activator.CreateInstance(t)!);


        var testCaseType = typeInfo.BaseType!.Type.GetGenericArguments()[1];
        var testCaseBuilder = (ITestCase)Activator.CreateInstance(testCaseType)!;

        var testCases = testCaseBuilder.TestCases.ToArray();

        var nunitBuilder = new NUnitTestCaseBuilder();

        foreach (var solution in solutions)
        {
            foreach (var testCase in testCases)
            {
                var testCaseTestCaseName = testCase.TestCaseName ?? $"Test Case {Array.IndexOf(testCases, testCase) + 1}";
                var testCaseData =
                    new TestCaseData(solution, testCase).SetName(
                        $@"{solution.GetType().Name}: {testCaseTestCaseName}");
                var skipSolutionAttribute =
                    (SkipSolutionAttribute?)GetCustomAttribute(solution.GetType(),
                        typeof(SkipSolutionAttribute));

                if (skipSolutionAttribute != null)
                {
                    testCaseData.Explicit(skipSolutionAttribute.Reason.ToString());
                }

                var testMethod = nunitBuilder.BuildTestMethod(methodInfo, null, testCaseData);
                testMethod.Properties.Add(PropertyNames.Timeout, testCase.TimeoutInMilliseconds);
                testFixture.Tests.Add(testMethod);
            }
        }

        yield return testFixture;
    }
}