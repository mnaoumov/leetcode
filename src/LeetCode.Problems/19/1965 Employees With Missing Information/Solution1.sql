-- https://leetcode.com/submissions/detail/925196565/

SELECT employee_id = COALESCE(e.employee_id, s.employee_id)
FROM Employees AS e
FULL JOIN Salaries AS s ON s.employee_id = e.employee_id
WHERE
    s.employee_id IS NULL
    OR e.employee_id IS NULL
ORDER BY COALESCE(e.employee_id, s.employee_id);
