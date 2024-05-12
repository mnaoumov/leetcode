-- https://leetcode.com/submissions/detail/935500456/

WITH cte AS (
    SELECT
        order_id,
        average = AVG(1.0 * quantity),
        max = MAX(quantity)
    FROM OrdersDetails
    GROUP BY order_id
)
SELECT cte.order_id
FROM cte
WHERE cte.max > (SELECT MAX(cte.average) FROM cte);
