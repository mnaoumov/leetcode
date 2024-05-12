-- https://leetcode.com/submissions/detail/925199166/

SELECT
    product_id,
    store = 'store1',
    price = store1
FROM Products
WHERE store1 IS NOT NULL

UNION

SELECT
    product_id,
    store = 'store2',
    price = store2
FROM Products
WHERE store2 IS NOT NULL

UNION

SELECT
    product_id,
    store = 'store3',
    price = store3
FROM Products
WHERE store3 IS NOT NULL;
