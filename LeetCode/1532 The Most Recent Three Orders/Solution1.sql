-- https://leetcode.com/submissions/detail/938747638/

WITH cte AS (
    SELECT
        order_id,
        rn = ROW_NUMBER() OVER(PARTITION BY customer_id ORDER BY order_date DESC)
    FROM Orders
)
SELECT
    customer_name = c.name,
    c.customer_id,
    o.order_id,
    o.order_date
FROM cte
JOIN Orders AS o ON o.order_id = cte.order_id
JOIN Customers AS c on c.customer_id = o.customer_id
WHERE cte.rn <= 3
ORDER BY
    c.name,
    customer_id,
    order_date DESC;
