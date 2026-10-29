-- https://leetcode.com/submissions/detail/931634230/

WITH cte AS (
    SELECT
        d.dept_name,
        student_number = SUM(IIF(s.dept_id IS NULL, 0, 1))
    FROM Department AS d
    LEFT JOIN Student AS s ON s.dept_id = d.dept_id
    GROUP BY d.dept_name
)
SELECT
    dept_name,
    student_number
FROM cte
ORDER BY
    student_number DESC,
    dept_name;
