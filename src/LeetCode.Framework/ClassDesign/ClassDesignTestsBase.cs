using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.Json;

namespace LeetCode.ClassDesign;

public abstract class ClassDesignTestsBase<TSolution, TSut> : TestsBase<TSolution, ClassDesignTestCase>
{
    protected override void TestCore(TSolution solution, ClassDesignTestCase testCase)
    {
        ArgumentNullException.ThrowIfNull(testCase);
        AssertWellFormed(testCase);

        var createMethod = solution!.GetType().GetMethod("Create")!;
        var sut = CastAndInvoke(createMethod, solution, testCase.Parameters[0]);

        for (var i = 1; i < testCase.Commands.Length; i++)
        {
            var command = testCase.Commands[i];
            var methodName = ToPascalCase(command);
            var parameters = testCase.Parameters[i];
            var expected = testCase.Output[i];

            if (!MethodsByName.Value.TryGetValue(methodName, out var overloads))
            {
                Assert.Fail($"Unknown command '{command}'");
            }

            var method = ResolveOverload(overloads!, parameters, command);
            var actual = CastAndInvoke(method, sut, parameters);

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
                if (ContainsFloatingPoint(expected) || ContainsFloatingPoint(actual))
                {
                    Assert.That(actual, IsEqualToWithinTolerance(expected), assertMessage);
                }
                else if (actual is not string && actual is IEnumerable actualEnumerable && expected is IEnumerable expectedEnumerable)
                {
                    AssertCollectionEqualWithDetails(actualEnumerable.Cast<object>(), expectedEnumerable.Cast<object>(),
                        assertMessage);
                }
                else
                {
                    Assert.That(actual, Is.EqualTo(expected), assertMessage);
                }
            }
        }
    }

    // The interface's own methods do not include those of the interfaces it extends, and a class's include object's.
    private static readonly Lazy<IReadOnlyDictionary<string, MethodInfo[]>> MethodsByName = new(() =>
        typeof(TSut).GetInterfaces().Prepend(typeof(TSut))
            .SelectMany(type => type.GetMethods(BindingFlags.Public | BindingFlags.Instance))
            .Where(method => method.DeclaringType != typeof(object) && !method.IsSpecialName)
            .Distinct()
            .GroupBy(method => method.Name, StringComparer.Ordinal)
            .ToDictionary(group => group.Key, group => group.ToArray(), StringComparer.Ordinal));

    /// <summary>
    /// Fails a test case whose three arrays do not line up command for command, whose first command is not the
    /// constructor of <typeparamref name="TSut"/>'s class, or whose constructor has an output.
    /// </summary>
    private static void AssertWellFormed(ClassDesignTestCase testCase)
    {
        if (testCase.Commands.Length == 0 || testCase.Parameters.Length != testCase.Commands.Length ||
            testCase.Output.Length != testCase.Commands.Length)
        {
            Assert.Fail($"The test case has {testCase.Commands.Length} commands, {testCase.Parameters.Length} " +
                $"parameter lists and {testCase.Output.Length} outputs; it needs one of each per command, the first " +
                "being the constructor");
        }

        var classNames = GetClassNames();

        if (!classNames.Contains(testCase.Commands[0], StringComparer.Ordinal))
        {
            Assert.Fail($"The first command is '{testCase.Commands[0]}', not the constructor " +
                $"'{string.Join("' or '", classNames)}'");
        }

        if (testCase.Output[0] != null)
        {
            Assert.Fail($"The constructor's output is {JsonSerializer.Serialize(testCase.Output[0])}, not null");
        }
    }

    /// <summary>
    /// The names LeetCode's class can have: <typeparamref name="TSut"/>'s without its leading I, and without a
    /// trailing Impl as well, since LeetCode's <c>Solution</c> class is <c>ISolutionImpl</c> here.
    /// </summary>
    private static string[] GetClassNames()
    {
        var name = typeof(TSut).Name;

        if (typeof(TSut).IsInterface && name.Length > 1 && name[0] == 'I' && char.IsUpper(name[1]))
        {
            name = name[1..];
        }

        const string implSuffix = "Impl";
        return name.EndsWith(implSuffix, StringComparison.Ordinal) && name.Length > implSuffix.Length
            ? [name, name[..^implSuffix.Length]]
            : [name];
    }

    /// <summary>
    /// The overload taking as many arguments as the command passes and accepting them. Of several, the one taking the
    /// most of them as they are, since a number converts to a string too.
    /// </summary>
    private static MethodInfo ResolveOverload(MethodInfo[] overloads, object[] parameters, string command)
    {
        var candidates = overloads.Where(method => method.GetParameters().Length == parameters.Length).ToArray();

        if (candidates.Length == 0)
        {
            Assert.Fail($"No overload of '{command}' takes {parameters.Length} arguments");
        }

        if (candidates.Length == 1)
        {
            return candidates[0];
        }

        var best = candidates.Where(method => Accepts(method, parameters))
            .OrderByDescending(method => CountTakenAsIs(method, parameters))
            .FirstOrDefault();

        if (best == null)
        {
            Assert.Fail($"No overload of '{command}' accepts {JsonSerializer.Serialize(parameters)}");
        }

        return best!;
    }

    private static int CountTakenAsIs(MethodInfo method, object?[] parameters) =>
        method.GetParameters().Zip(parameters)
            .Count(pair => pair.Second == null || pair.Second.GetType().IsAssignableTo(pair.First.ParameterType));

    private static bool Accepts(MethodInfo method, object[] parameters)
    {
        var parameterTypes = method.GetParameters().Select(p => p.ParameterType).ToArray();

        try
        {
            _ = parameters.Zip(parameterTypes, ChangeType).ToArray();
            return true;
        }
        catch (Exception e) when (e is InvalidCastException or FormatException or OverflowException)
        {
            return false;
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
