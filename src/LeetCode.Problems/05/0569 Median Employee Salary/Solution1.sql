-- https://leetcode.com/submissions/detail/940396474/

WITH cte AS (
    SELECT
        rn = ROW_NUMBER() OVER(ORDER BY e.company, e.salary, e.id),
        e.id,
        e.company,
        e.salary
    FROM Employee AS e
),
cte2 AS (
    SELECT
        min_rn = MIN(rn),
        max_rn = MAX(rn)
    FROM cte
    GROUP BY company
)
SELECT
    cte.id,
    cte.company,
    cte.salary
FROM cte2
JOIN cte ON cte.rn BETWEEN (cte2.min_rn + cte2.max_rn) / 2 AND (cte2.min_rn + cte2.max_rn + 1) / 2;
