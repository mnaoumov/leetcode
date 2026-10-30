using LeetCode.Base;

[assembly: ProblemDirectory("LeetCode.Framework.Tests.Base.MappedProblem", "07/0712 Minimum ASCII Delete Sum for Two Strings")]
[assembly: ProblemDirectory("LeetCode.Framework.Tests.Base.PunctuatedProblem", "!Unnumbered/A.B C+D! It’s")]

namespace LeetCode.Framework.Tests.Base
{
    public class GetProblemDirectoryTests
    {
        private static readonly string ProblemsRoot = Path.Combine(FindRepoRoot(), "src", "LeetCode.Problems");

        [Test]
        public void MappedNamespace_ResolvesUnderTheProblemsProject()
        {
            Assert.That(ProblemDirectoryAccessor.Get(typeof(MappedProblem.Tests)),
                Is.EqualTo(Path.Combine(ProblemsRoot, "07", "0712 Minimum ASCII Delete Sum for Two Strings")));
        }

        // The folder is read from the attribute, so no character in its name can break the lookup.
        [Test]
        public void PunctuatedFolderName_ResolvesAsRecorded()
        {
            Assert.That(ProblemDirectoryAccessor.Get(typeof(PunctuatedProblem.Tests)),
                Is.EqualTo(Path.Combine(ProblemsRoot, "!Unnumbered", "A.B C+D! It’s")));
        }

        [Test]
        public void UnmappedNamespace_ResolvesToNull()
        {
            Assert.That(ProblemDirectoryAccessor.Get(typeof(GetProblemDirectoryTests)), Is.Null);
        }

        private static string FindRepoRoot()
        {
            for (var dir = new DirectoryInfo(AppContext.BaseDirectory); dir != null; dir = dir.Parent)
            {
                if (File.Exists(Path.Combine(dir.FullName, "LeetCode.slnx")))
                {
                    return dir.FullName;
                }
            }

            throw new DirectoryNotFoundException($"No LeetCode.slnx above {AppContext.BaseDirectory}");
        }

        private abstract class ProblemDirectoryAccessor : TestsBase
        {
            public static string? Get(Type problemRelatedType) => GetProblemDirectory(problemRelatedType);
        }
    }
}

namespace LeetCode.Framework.Tests.Base.MappedProblem
{
    internal sealed class Tests;
}

namespace LeetCode.Framework.Tests.Base.PunctuatedProblem
{
    internal sealed class Tests;
}
