-- https://leetcode.com/submissions/detail/923930221/

SELECT
    employee_id,
    bonus = IIF(
        employee_id % 2 = 1
            AND LEFT(name, 1) <> 'M',
        salary,
        0)
FROM Employees
ORDER BY employee_id;
