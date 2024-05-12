-- https://leetcode.com/submissions/detail/934953108/

SELECT c.customer_id
FROM Customer AS c
GROUP BY c.customer_id
HAVING COUNT(DISTINCT c.product_key) = (SELECT COUNT(1) FROM Product);
