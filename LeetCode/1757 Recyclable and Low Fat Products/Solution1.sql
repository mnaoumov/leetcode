-- https://leetcode.com/submissions/detail/923921864/

SELECT product_id
FROM Products
WHERE
    low_fats = 'Y'
    AND recyclable = 'Y';
