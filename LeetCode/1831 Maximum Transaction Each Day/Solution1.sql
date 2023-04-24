-- https://leetcode.com/submissions/detail/938765785/

WITH cte AS (
    SELECT
        transaction_id,
        rn = RANK() OVER(PARTITION BY CAST(t.day AS date) ORDER BY amount DESC)
    FROM Transactions AS t
)
SELECT transaction_id
FROM cte
WHERE rn = 1
ORDER BY transaction_id;
