namespace LeetCode.Problems._1700_Number_of_Students_Unable_to_Eat_Lunch;

/// <summary>
/// https://leetcode.com/submissions/detail/1227125735/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountStudents(int[] students, int[] sandwiches)
    {
        var studentsQueue = new Queue<int>();

        foreach (var student in students)
        {
            studentsQueue.Enqueue(student);
        }

        foreach (var sandwich in sandwiches)
        {
            var unmatchedStudentsCount = 0;

            while (true)
            {
                var student = studentsQueue.Dequeue();

                if (student == sandwich)
                {
                    break;
                }

                studentsQueue.Enqueue(student);
                unmatchedStudentsCount++;

                if (unmatchedStudentsCount == studentsQueue.Count)
                {
                    return unmatchedStudentsCount;
                }
            }
        }

        return 0;
    }
}
