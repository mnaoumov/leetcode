-- https://leetcode.com/submissions/detail/927542796/

SELECT
    day = event_day,
    emp_id,
    total_time = SUM(out_time - in_time)
FROM Employees
GROUP BY
    event_day,
    emp_id;
