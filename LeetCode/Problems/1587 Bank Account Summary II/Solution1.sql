-- https://leetcode.com/submissions/detail/927645388/

WITH cte AS
(
    SELECT
        u.name,
        balance = SUM(t.amount)
    FROM Users AS u
    JOIN Transactions AS t ON t.account = u.account
    GROUP BY u.name
)
SELECT
    NAME,
    BALANCE
FROM cte
WHERE balance > 10000;
