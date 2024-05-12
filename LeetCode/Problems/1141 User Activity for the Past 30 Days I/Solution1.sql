-- SkipSolution: WrongAnswer
-- https://leetcode.com/submissions/detail/926918514/

SELECT
    day = activity_date,
    active_users = COUNT(DISTINCT user_id)
FROM Activity
WHERE activity_date BETWEEN DATEADD(day, -30, '2019-07-27') AND '2019-07-27'
GROUP BY activity_date;
