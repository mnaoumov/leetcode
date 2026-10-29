-- SkipSolution: WrongAnswer
-- https://leetcode.com/submissions/detail/930954628/

SELECT
    c.customer_id,
    c.customer_name
FROM Customers AS c
JOIN Orders AS oa ON
    oa.customer_id = c.customer_id
    AND oa.product_name = 'A'
JOIN Orders AS ob ON
    ob.customer_id = c.customer_id
    AND ob.product_name = 'B'
LEFT JOIN Orders AS oc ON
    oc.customer_id = c.customer_id
    AND oc.product_name = 'C'
WHERE oc.customer_id IS NULL
ORDER BY c.customer_id;
