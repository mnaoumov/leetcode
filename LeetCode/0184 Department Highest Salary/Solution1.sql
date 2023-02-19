-- https://leetcode.com/submissions/detail/899804210/

SELECT
    d.name AS Department,
    e.name AS Employee,
    e.salary AS Salary
FROM Employee AS e
JOIN Department AS d ON
    d.id = e.departmentId
LEFT JOIN Employee AS e2 ON
    e2.departmentId = d.id
    AND e2.salary > e.salary
WHERE e2.salary IS NULL;
