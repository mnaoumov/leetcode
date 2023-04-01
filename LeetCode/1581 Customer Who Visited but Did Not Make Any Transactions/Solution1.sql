-- https://leetcode.com/submissions/detail/925623660/

SELECT
    v.customer_id,
    count_no_trans = COUNT(1)
FROM Visits AS v
LEFT JOIN Transactions AS t ON t.visit_id = v.visit_id
WHERE t.visit_id IS NULL
GROUP BY v.customer_id;
