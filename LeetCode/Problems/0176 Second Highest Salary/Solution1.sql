-- https://leetcode.com/submissions/detail/890412537/

;WITH cte AS
(
    SELECT
        e.salary,
        x.countOfRecordsWithGreaterSalary
    FROM Employee AS e
    CROSS APPLY
    (
        SELECT COUNT(DISTINCT e2.salary) as countOfRecordsWithGreaterSalary
        FROM Employee AS e2
        WHERE e2.salary > e.salary
    ) x
)
SELECT cte.salary AS SecondHighestSalary
FROM cte
WHERE cte.countOfRecordsWithGreaterSalary = 1

UNION

SELECT NULL AS SecondHighestSalary
WHERE
    NOT EXISTS
    (
        SELECT cte.salary
        FROM cte
        WHERE cte.countOfRecordsWithGreaterSalary = 1
    );