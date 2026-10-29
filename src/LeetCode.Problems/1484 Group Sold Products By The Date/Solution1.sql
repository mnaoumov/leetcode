-- https://leetcode.com/submissions/detail/924523356/

SELECT
    sell_date,
    num_sold = COUNT(1),
    products = STRING_AGG(product, ',') WITHIN GROUP (ORDER BY product)
FROM (
    SELECT DISTINCT
        sell_date,
        product
    FROM Activities
) AS x
GROUP BY sell_date;
