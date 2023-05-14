using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LeetCode;

internal class AllPropertiesRequiredContractResolver : DefaultContractResolver
{
    private Type TestCaseType { get; set; } = null!;

    public override JsonContract ResolveContract(Type type)
    {
        TestCaseType = type;
        return base.ResolveContract(type);
    }

    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        var property = base.CreateProperty(member, memberSerialization);

        if (member.DeclaringType == TestCaseType && !member.GetCustomAttributes(typeof(JsonPropertyAttribute)).Any())
        {
            property.Required = Required.AllowNull;
        }

        return property;
    }
}
