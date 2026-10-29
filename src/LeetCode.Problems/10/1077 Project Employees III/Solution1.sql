-- https://leetcode.com/submissions/detail/936723428/

WITH cte AS (
    SELECT
        p.project_id,
        max_experience_years = MAX(e.experience_years)
    FROM Project AS p
    JOIN Employee AS e ON e.employee_id = p.employee_id
    GROUP BY p.project_id
)
SELECT
    p.project_id,
    p.employee_id
FROM cte
JOIN Project AS p ON p.project_id = cte.project_id
JOIN Employee AS e ON e.employee_id = p.employee_id
WHERE e.experience_years = cte.max_experience_years;
