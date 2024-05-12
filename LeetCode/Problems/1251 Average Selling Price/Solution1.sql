-- https://leetcode.com/submissions/detail/930249544/

SELECT
    u.product_id,
    average_price = CAST(1.0 * SUM(u.units * p.price) / SUM(u.units) AS numeric(36, 2))
FROM UnitsSold AS u
JOIN Prices AS p ON
    p.product_id = u.product_id
    AND u.purchase_date BETWEEN p.start_date AND p.end_date
GROUP BY u.product_id;
