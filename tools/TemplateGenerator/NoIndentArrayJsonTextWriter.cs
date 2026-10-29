using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace TemplateGenerator;

public static class NoIndentArrayJsonTextWriter
{
    public static string Indent(JsonNode? node)
    {
        var json = node?.ToJsonString(new JsonSerializerOptions { WriteIndented = true }) ?? "null";
        return CollapseArrays(json);
    }

    private static string CollapseArrays(string json)
    {
        var sb = new StringBuilder();
        var inArray = 0;
        var arrayContent = new StringBuilder();

        for (var i = 0; i < json.Length; i++)
        {
            var ch = json[i];

            if (ch == '[')
            {
                inArray++;

                if (inArray == 1)
                {
                    arrayContent.Clear();
                    arrayContent.Append('[');
                    continue;
                }
            }

            if (inArray > 0)
            {
                if (ch == ']')
                {
                    inArray--;

                    if (inArray == 0)
                    {
                        arrayContent.Append(']');
                        sb.Append(CollapseWhitespace(arrayContent.ToString()));
                        continue;
                    }
                }

                arrayContent.Append(ch);
            }
            else
            {
                sb.Append(ch);
            }
        }

        return sb.ToString();
    }

    private static string CollapseWhitespace(string arrayJson)
    {
        var sb = new StringBuilder();
        var inString = false;
        var escaped = false;
        var prevWasSpace = false;

        foreach (var ch in arrayJson)
        {
            if (inString)
            {
                sb.Append(ch);

                if (escaped)
                {
                    escaped = false;
                }
                else if (ch == '\\')
                {
                    escaped = true;
                }
                else if (ch == '"')
                {
                    inString = false;
                }

                continue;
            }

            if (ch == '"')
            {
                inString = true;
                prevWasSpace = false;
                sb.Append(ch);
                continue;
            }

            if (char.IsWhiteSpace(ch))
            {
                if (!prevWasSpace && sb.Length > 0 && sb[^1] != '[' && sb[^1] != ',')
                {
                    prevWasSpace = true;
                }

                continue;
            }

            if (prevWasSpace)
            {
                prevWasSpace = false;
            }

            sb.Append(ch);

            if (ch == ',' || ch == ':')
            {
                sb.Append(' ');
            }
        }

        return sb.ToString();
    }
}
