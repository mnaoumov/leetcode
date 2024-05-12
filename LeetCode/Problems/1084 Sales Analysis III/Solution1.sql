-- https://leetcode.com/submissions/detail/927649035/

SELECT DISTINCT
    p.product_id,
    p.product_name
FROM Product AS p
JOIN Sales AS s ON
    s.product_id = p.product_id
    AND s.sale_date BETWEEN '2019-01-01' AND '2019-03-31'
LEFT JOIN Sales AS s2 ON
    s2.product_id = p.product_id
    AND s2.sale_date NOT BETWEEN '2019-01-01' AND '2019-03-31'
WHERE s2.product_id IS NULL;
