-- https://leetcode.com/submissions/detail/898834299/

SELECT e.name AS Employee
FROM Employee AS e
JOIN Employee AS m ON m.id = e.managerId
WHERE e.salary > m.salary;
