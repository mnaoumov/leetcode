﻿using NUnit.Framework;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.ExceptionServices;
using Newtonsoft.Json.Linq;

namespace LeetCode;

public abstract class SutTestsBase<TSolution, TSut> : TestsBase<TSolution, SutTestCase>
{
    protected override void TestImpl(TSolution solution, SutTestCase testCase)
    {
        var createMethod = solution!.GetType().GetMethod("Create")!;
        var sut = CastAndInvoke(createMethod, solution, testCase.Parameters[0]);

        var methodMap = typeof(TSut).GetMethods().ToDictionary(x => x.Name);

        for (var i = 1; i < testCase.Commands.Length; i++)
        {
            var command = testCase.Commands[i];
            var methodName = ToPascalCase(command);
            var parameters = testCase.Parameters[i];
            var expected = testCase.Output[i];

            if (!methodMap.ContainsKey(methodName))
            {
                Assert.Fail($"Unknown command '{command}'");
            }

            var actual = CastAndInvoke(methodMap[methodName], sut, parameters);

            var assertMessage = $"Command #{i + 1}: {command} {JsonConvert.SerializeObject(parameters)}";

            if (expected is JObject expectedJson)
            {
                var isAnyOfJson = expectedJson["isAnyOf"];
                var values = isAnyOfJson.ToObject<object[]>();
                Assert.That(actual, Is.AnyOf(values), assertMessage);
            }
            else
            {
                Assert.That(actual, Is.EqualTo(expected), assertMessage);
            }
        }
    }

    private static object? CastAndInvoke(MethodBase methodInfo, object? @this, IEnumerable<object> parameters)
    {
        var parameterTypes = methodInfo.GetParameters().Select(p => p.ParameterType).ToArray();
        var castedParameters = parameters.Zip(parameterTypes, Convert.ChangeType).ToArray();

        try
        {
            return methodInfo.Invoke(@this, castedParameters);
        }
        catch (TargetInvocationException e)
        {
            ExceptionDispatchInfo.Capture(e.InnerException!).Throw();
            throw;
        }
    }

    private static string ToPascalCase(string command)
    {
        var sb = new StringBuilder(command);
        sb[0] = char.ToUpper(sb[0]);
        return sb.ToString();
    }
}