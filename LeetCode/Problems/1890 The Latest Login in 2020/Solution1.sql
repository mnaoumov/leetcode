-- https://leetcode.com/submissions/detail/927541289/

SELECT
    user_id,
    last_stamp = MAX(time_stamp)
FROM Logins
WHERE DATEPART(year, time_stamp) = 2020
GROUP BY user_id;
