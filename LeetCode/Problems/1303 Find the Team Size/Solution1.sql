-- https://leetcode.com/submissions/detail/931477023/

SELECT
    e.employee_id,
    team_size = COUNT(1)
FROM Employee AS e
JOIN Employee AS e2 ON e2.team_id = e.team_id
GROUP BY e.employee_id;
