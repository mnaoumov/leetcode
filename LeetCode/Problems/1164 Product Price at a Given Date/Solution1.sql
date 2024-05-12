-- https://leetcode.com/submissions/detail/933227971/

WITH cte AS (
    SELECT
        product_id,
        max_change_date = MAX(change_date)
    FROM Products
    WHERE change_date <= '2019-08-16'
    GROUP BY product_id
)
SELECT DISTINCT
    p.product_id,
    price = IIF(COUNT(cte.max_change_date) = 0, 10, MIN(p.new_price))
FROM Products AS p
LEFT JOIN cte ON cte.product_id = p.product_id
WHERE
    cte.max_change_date IS NULL
    or p.change_date = cte.max_change_date
GROUP BY
    p.product_id;
