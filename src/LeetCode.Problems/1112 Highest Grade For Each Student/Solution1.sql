-- https://leetcode.com/submissions/detail/930953172/

WITH cte AS (
    SELECT
        student_id,
        grade = MAX(grade)
    FROM Enrollments
    GROUP BY student_id
)
SELECT
    cte.student_id,
    course_id = MIN(e.course_id),
    cte.grade
FROM cte
JOIN Enrollments AS e ON
    e.student_id = cte.student_id
    AND e.grade = cte.grade
GROUP BY
    cte.student_id,
    cte.grade
ORDER BY student_id;
