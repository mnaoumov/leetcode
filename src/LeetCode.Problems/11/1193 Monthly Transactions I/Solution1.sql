-- https://leetcode.com/submissions/detail/930372859/

WITH cte AS (
    SELECT
        month = FORMAT(trans_date, 'yyyy-MM'),
        country,
        isApproved = IIF(state = 'approved', 1, 0),
        amount
    FROM Transactions
)
SELECT
    month,
    country,
    trans_count = COUNT(1),
    approved_count = SUM(isApproved),
    trans_total_amount = SUM(amount),
    approved_total_amount = SUM(isApproved * amount)
FROM cte
GROUP BY
    month,
    country;

