-- https://leetcode.com/submissions/detail/934923044/

WITH cte AS (
    SELECT
        p.product_id,
        maxDate = MAX(o.order_date)
    FROM Products AS p
    JOIN Orders AS o ON o.product_id = p.product_id
    GROUP BY p.product_id
)
SELECT
    p.product_name,
    p.product_id,
    o.order_id,
    o.order_date
FROM Products AS p
JOIN Orders AS o ON o.product_id = p.product_id
JOIN cte ON cte.product_id = p.product_id AND cte.maxDate = o.order_date
ORDER BY
    p.product_name,
    p.product_id,
    o.order_id;
