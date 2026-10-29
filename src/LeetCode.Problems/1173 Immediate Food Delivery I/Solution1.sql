-- https://leetcode.com/submissions/detail/930381389/

SELECT immediate_percentage = CAST(100.0 * SUM(IIF(order_date = customer_pref_delivery_date, 1, 0)) / COUNT(1) AS numeric(36, 2))
FROM Delivery;
