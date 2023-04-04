-- https://leetcode.com/submissions/detail/927637781/

SELECT
    buyer_id = u.user_id,
    join_date = u.join_date,
    orders_in_2019 = orders_in_2019.value
FROM Users AS u
CROSS APPLY
(
    SELECT value = COUNT(1)
    FROM Orders
    WHERE
        DATEPART(year, order_date) = 2019
        AND buyer_id = u.user_id
) AS orders_in_2019;
