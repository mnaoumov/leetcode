-- SkipSolution: WrongAnswer
-- https://leetcode.com/submissions/detail/931600108/

WITH cte AS (
    SELECT
        country = co.name,
        duration = ca.duration
    FROM Country AS co
    JOIN Person AS p ON p.phone_number LIKE co.country_code + '%'
    JOIN Calls AS ca ON ca.caller_id = p.id

    UNION

    SELECT
        country = co.name,
        duration = ca.duration
    FROM Country AS co
    JOIN Person AS p ON p.phone_number LIKE co.country_code + '%'
    JOIN Calls AS ca ON ca.callee_id = p.id
),
globalAverage AS (
    SELECT value = AVG(duration)
    FROM cte
)
SELECT country
FROM cte
GROUP BY country
HAVING AVG(duration) > (SELECT value FROM globalAverage);
