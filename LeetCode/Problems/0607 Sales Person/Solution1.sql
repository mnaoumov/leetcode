-- https://leetcode.com/submissions/detail/926244163/

SELECT sp.name
FROM SalesPerson AS sp
WHERE NOT EXISTS(
    SELECT 1
    FROM Orders AS o
    JOIN Company AS c ON c.com_id = o.com_id
    WHERE
        o.sales_id = sp.sales_id
        AND c.name = 'RED'
);
