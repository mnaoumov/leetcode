-- https://leetcode.com/submissions/detail/938768930/

WITH maxId AS (
    SELECT maxId = MAX(customer_id)
    FROM Customers
),
cte AS (
    SELECT id = 1

    UNION ALL

    SELECT id = cte.id + 1
    FROM cte
    WHERE cte.id < (SELECT maxId FROM maxId)
)
SELECT ids = cte.id
FROM cte
LEFT JOIN Customers AS c ON c.customer_id = cte.id
WHERE c.customer_id IS NULL;
