-- https://leetcode.com/submissions/detail/938772159/

WITH cte AS (
    SELECT
        recursion_level = 0,
        employee_id = 1

    UNION ALL

    SELECT
        recursion_level = cte.recursion_level + 1,
        e.employee_id
    FROM Employees AS e
    JOIN cte ON cte.employee_id = e.manager_id
    WHERE cte.recursion_level < 3
)
SELECT DISTINCT employee_id
FROM cte
WHERE employee_id <> 1;
