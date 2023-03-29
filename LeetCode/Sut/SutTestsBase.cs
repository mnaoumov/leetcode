using NUnit.Framework;
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
                if (expectedJson["isAnyOf"] is { } isAnyOfJson)
                {
                    var values = isAnyOfJson.ToObject<object[]>();
                    Assert.That(actual, Is.AnyOf(values), assertMessage);
                }
                else if (expectedJson["isEquivalentTo"] is { } isEquivalentToJson)
                {
                    var values = isEquivalentToJson.ToObject<object[]>();
                    Assert.That(actual, Is.EquivalentTo(values), assertMessage);
                }
                else
                {
                    Assert.Fail($"Unsupported json command type {expectedJson}");
                }
            }
            else
            {
                Assert.That(actual,
                    expected is double
                        ? Is.EqualTo(expected).Within(1e-5)
                        : Is.EqualTo(expected),
                    assertMessage);
            }
        }
    }

    private static object? CastAndInvoke(MethodBase methodInfo, object? @this, IEnumerable<object> parameters)
    {
        var parameterTypes = methodInfo.GetParameters().Select(p => p.ParameterType).ToArray();
        var castedParameters = parameters.Zip(parameterTypes, ChangeType).ToArray();

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

    private static object? ChangeType(object? value, Type conversionType)
    {
        if (value == null)
        {
            if (conversionType.IsClass || Nullable.GetUnderlyingType(conversionType) != null)
            {
                return null;
            }

            throw CannotConvert();
        }

        if (value.GetType().IsAssignableTo(conversionType))
        {
            return value;
        }

        var method = conversionType.GetMethod("FromObject", BindingFlags.Public | BindingFlags.Static,
            new[] { typeof(object) });

        if (method != null)
        {
            return method.Invoke(null, new[] { value })!;
        }

        switch (value)
        {
            case IConvertible:
                return Convert.ChangeType(value, conversionType);
            case object[] array:
                {
                    Type elementType;

                    if (conversionType.IsArray)
                    {
                        elementType = conversionType.GetElementType()!;
                    }
                    else if (conversionType.IsGenericType)
                    {
                        var genericArguments = conversionType.GetGenericArguments();

                        if (genericArguments.Length != 1)
                        {
                            throw CannotConvert();
                        }

                        elementType = genericArguments[0];

                        var arrayType = elementType.MakeArrayType();

                        if (!arrayType.IsAssignableTo(conversionType))
                        {
                            throw CannotConvert();
                        }
                    }
                    else
                    {
                        throw CannotConvert();
                    }

                    var resultArray = Array.CreateInstance(elementType, array.Length);

                    for (var i = 0; i < array.Length; i++)
                    {
                        resultArray.SetValue(ChangeType(array[i], elementType), i);
                    }

                    return resultArray;
                }
            default:
                throw CannotConvert();
        }

        Exception CannotConvert()
        {
            var valueType = value == null ? "null" : value.GetType().FullName;
            return new InvalidCastException($"Cannot convert {valueType} to {conversionType}");
        }
    }

    private static string ToPascalCase(string command)
    {
        var sb = new StringBuilder(command);
        sb[0] = char.ToUpper(sb[0]);
        return sb.ToString();
    }
}