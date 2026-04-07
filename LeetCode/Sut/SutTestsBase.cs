using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.Json;

namespace LeetCode.Sut;

public abstract class SutTestsBase<TSolution, TSut> : TestsBase<TSolution, SutTestCase>
{
    protected override void TestCore(TSolution solution, SutTestCase testCase)
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

            var assertMessage = $"Command #{i + 1}: {command} {JsonSerializer.Serialize(parameters)}";

            if (expected is JsonElement { ValueKind: JsonValueKind.Object } expectedJson)
            {
                if (expectedJson.TryGetProperty("isAnyOf", out var isAnyOfJson))
                {
                    var values = DeserializeJsonElement(isAnyOfJson) as object?[];
                    Assert.That(actual, Is.AnyOf(values), assertMessage);
                }
                else if (expectedJson.TryGetProperty("isEquivalentTo", out var isEquivalentToJson))
                {
                    var values = (DeserializeJsonElement(isEquivalentToJson) as object?[])!;
                    Assert.That(actual, Is.EquivalentTo(values), assertMessage);
                }
                else
                {
                    Assert.Fail($"Unsupported json command type {expectedJson}");
                }
            }
            else
            {
                if (expected is double)
                {
                    Assert.That(actual, Is.EqualTo(expected).Within(1e-5), assertMessage);
                }
                else
                {
                    if (actual is IEnumerable actualEnumerable && expected is IEnumerable expectedEnumerable)
                    {
                        AssertCollectionEqualWithDetails(actualEnumerable.Cast<object>(), expectedEnumerable.Cast<object>(), assertMessage);
                    }
                    else
                    {
                        Assert.That(actual, Is.EqualTo(expected), assertMessage);
                    }
                }

                Assert.That(actual,
                    expected is double
                        ? Is.EqualTo(expected).Within(1e-5)
                        : Is.EqualTo(expected),
                    assertMessage);
            }
        }
    }

    private static object? DeserializeJsonElement(JsonElement element)
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Array:
                return element.EnumerateArray().Select(DeserializeJsonElement).ToArray();
            case JsonValueKind.Number:
                if (element.TryGetInt32(out var intVal))
                {
                    return intVal;
                }

                if (element.TryGetInt64(out var longVal))
                {
                    return longVal;
                }

                return element.GetDouble();
            case JsonValueKind.String:
                return element.GetString();
            case JsonValueKind.True:
                return true;
            case JsonValueKind.False:
                return false;
            case JsonValueKind.Null:
                return null;
            default:
                return element;
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
                return Convert.ChangeType(value, conversionType, CultureInfo.InvariantCulture);
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
        sb[0] = char.ToUpper(sb[0], CultureInfo.InvariantCulture);
        return sb.ToString();
    }
}
