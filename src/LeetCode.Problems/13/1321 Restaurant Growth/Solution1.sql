-- https://leetcode.com/submissions/detail/934950797/

WITH cte AS (
    SELECT DISTINCT visited_on
    FROM Customer
    WHERE visited_on >= (SELECT DATEADD(day, 6, MIN(visited_on)) FROM Customer)
)
SELECT
    cte.visited_on,
    amount = SUM(c.amount),
    average_amount = ROUND(SUM(c.amount) / 7.00, 2)
FROM cte
JOIN Customer AS c ON c.visited_on BETWEEN DATEADD(day, -6, cte.visited_on) AND cte.visited_on
GROUP BY cte.visited_on;
