-- https://leetcode.com/submissions/detail/930946182/

SELECT SELLER_NAME = s.seller_name
FROM Seller AS s
LEFT JOIN Orders AS o ON
    o.seller_id = s.seller_id
    AND DATEPART(year, o.sale_date) = 2020
WHERE o.seller_id IS NULL
ORDER BY s.seller_name;
