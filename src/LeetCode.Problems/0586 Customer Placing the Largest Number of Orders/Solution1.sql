-- https://leetcode.com/submissions/detail/927531201/

WITH cte1 AS
(
    SELECT
        customer_number,
        count = COUNT(1)
    FROM Orders
    GROUP BY customer_number
),
cte2 AS
(
    SELECT maxCount = MAX(count)
    FROM cte1
)
SELECT customer_number
FROM cte1
WHERE count = (SELECT maxCount FROM cte2);
