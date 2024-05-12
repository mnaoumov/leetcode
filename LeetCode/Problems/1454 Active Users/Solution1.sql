-- SkipSolution: WrongAnswer
-- https://leetcode.com/submissions/detail/940905436/

WITH cte AS
(
    SELECT DISTINCT
        id,
        login_date
    FROM Logins
),
cte2 AS
(
    SELECT
        id,
        date_sequence_start = DATEADD(day, -ROW_NUMBER() over(order by id, login_date), login_date)
    FROM cte
)
select
    a.id,
    a.name
FROM cte2
JOIN Accounts AS a ON a.id = cte2.id
GROUP BY
    a.id,
    a.name,
    cte2.date_sequence_start
HAVING COUNT(1) >= 5
ORDER BY a.id;
