-- https://leetcode.com/submissions/detail/936743362/

WITH cte1 AS (
    SELECT
        o.customer_id,
        o.product_id,
        frequency = COUNT(1)
    FROM Orders AS o
    GROUP BY
        o.customer_id,
        o.product_id
),
cte2 AS (
    SELECT
        customer_id,
        max_frequency = MAX(frequency)
    FROM cte1
    GROUP BY customer_id
)
SELECT
    cte1.customer_id,
    cte1.product_id,
    p.product_name
FROM cte2
JOIN cte1 ON
    cte1.customer_id = cte2.customer_id
    AND cte1.frequency = cte2.max_frequency
JOIN Products AS p ON p.product_id = cte1.product_id;
