-- https://leetcode.com/submissions/detail/930255282/

SELECT
    warehouse_name = w.name,
    volume = SUM(w.units * p.Width * p.Length * p.Height)
FROM Warehouse AS w
JOIN Products AS p ON p.product_id = w.product_id
GROUP BY w.name;
