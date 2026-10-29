-- https://leetcode.com/submissions/detail/931474009/

SELECT m.name
FROM Employee AS m
JOIN Employee AS e ON e.managerId = m.id
GROUP BY m.name
HAVING COUNT(1) >= 5;
