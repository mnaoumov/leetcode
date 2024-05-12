-- https://leetcode.com/submissions/detail/933445330/

SELECT
    m.employee_id,
    m.name,
    reports_count = COUNT(1),
    average_age = ROUND(AVG(1.0 * e.age), 0)
FROM Employees AS m
JOIN Employees AS e ON e.reports_to = m.employee_id
GROUP BY
    m.employee_id,
    m.name
ORDER BY m.employee_id;
