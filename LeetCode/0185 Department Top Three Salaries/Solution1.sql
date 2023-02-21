-- https://leetcode.com/submissions/detail/901900255/

;WITH cte AS
(
    SELECT
        d.name AS Department,
        e.name AS Employee,
        e.salary AS Salary,
        DENSE_RANK() OVER(PARTITION BY d.id ORDER BY e.salary DESC) AS rn
    FROM Employee AS e
    JOIN Department AS d ON
        d.id = e.departmentId
)
SELECT
    Department,
    Employee,
    Salary
FROM cte
WHERE rn <= 3;
