-- https://leetcode.com/submissions/detail/926923426/

SELECT
    user_id,
    followers_count = COUNT(user_id)
FROM Followers
GROUP BY user_id;
