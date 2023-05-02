using System.Text;

namespace TemplateGenerator;

public static class ConsoleHelper
{
    public static string Read(string prompt)
    {
        Console.Write($"Enter {prompt}: ");
        return Console.ReadLine()!;
    }

    public static string ReadMultiline(string prompt)
    {
        var sb = new StringBuilder();

        while (true)
        {
            Console.Write($"Enter multiline {prompt} finishing with Ctrl + Z: ");
            var line = Console.ReadLine();

            if (line == null)
            {
                break;
            }

            if (sb.Length > 0)
            {
                sb.AppendLine();
            }

            sb.Append(line);
        }

        return sb.ToString();
    }
}
