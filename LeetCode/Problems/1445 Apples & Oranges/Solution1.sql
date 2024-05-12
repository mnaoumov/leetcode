-- https://leetcode.com/submissions/detail/930289472/

SELECT
    s.sale_date,
    diff = apples.sold_num - oranges.sold_num
FROM Sales AS s
JOIN Sales AS apples ON
    apples.sale_date = s.sale_date
    AND apples.fruit = 'apples'
JOIN Sales AS oranges ON
    oranges.sale_date = s.sale_date
    AND oranges.fruit = 'oranges'
GROUP BY
    s.sale_date,
    apples.sold_num,
    oranges.sold_num;
