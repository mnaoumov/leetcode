using System.Reflection;
using System.Text.Json.Serialization.Metadata;

namespace LeetCode.Base;

public static class AllPropertiesRequiredModifier
{
    public static void MakePropertiesRequired(JsonTypeInfo typeInfo)
    {
        if (typeInfo.Kind != JsonTypeInfoKind.Object)
        {
            return;
        }

        foreach (var property in typeInfo.Properties)
        {
            if (property.AttributeProvider is MemberInfo member &&
                member.DeclaringType == typeInfo.Type &&
                !member.GetCustomAttributes<JsonOptionalPropertyAttribute>().Any())
            {
                property.IsRequired = true;
            }
        }
    }
}
