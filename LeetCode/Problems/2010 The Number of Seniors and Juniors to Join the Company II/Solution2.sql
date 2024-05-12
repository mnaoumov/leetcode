-- https://leetcode.com/submissions/detail/940926638/

WITH cte AS
(
    SELECT
        employee_id,
        experience,
        salary,
        rn = ROW_NUMBER() OVER(PARTITION BY experience ORDER BY salary)
    FROM Candidates
),
cte2 AS
(
    SELECT
        cte.rn,
        cte.employee_id,
        total_senior_salary = SUM(cte_2.salary)
    FROM cte
    JOIN cte AS cte_2 ON
        cte_2.rn <= cte.rn
        AND cte_2.experience = 'Senior'
    WHERE cte.experience = 'Senior'
    GROUP BY
        cte.rn,
        cte.employee_id
    HAVING SUM(cte_2.salary) <= 70000
),
cte3 AS
(
    SELECT max_total_senior_salary = COALESCE(MAX(total_senior_salary), 0)
    FROM cte2
),
cte4 AS
(
    SELECT
        cte.rn,
        cte.employee_id
    FROM cte
    JOIN cte AS cte_2 ON
        cte_2.rn <= cte.rn
        AND cte_2.experience = 'Junior'
    WHERE cte.experience = 'Junior'
    GROUP BY
        cte.rn,
        cte.employee_id
    HAVING SUM(cte_2.salary) <= (SELECT 70000 - max_total_senior_salary FROM cte3)
),
cte5 AS
(
    SELECT
        type = 1,
        rn,
        employee_id
    FROM cte2

    UNION ALL

    SELECT
        type = 2,
        rn,
        employee_id
    FROM cte4
)
SELECT employee_id
FROM cte5
ORDER BY
    type,
    rn;
