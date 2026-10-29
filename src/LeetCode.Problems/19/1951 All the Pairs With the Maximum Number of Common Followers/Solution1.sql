-- https://leetcode.com/submissions/detail/937715977/

WITH cte AS (
    SELECT
        user1_id = u1.user_id,
        user2_id = u2.user_id,
        common_followers_count = COUNT(u1.follower_id)
    FROM Relations AS u1
    JOIN Relations AS u2 ON
        u2.user_id > u1.user_id
        AND u2.follower_id = u1.follower_id
    GROUP BY
        u1.user_id,
        u2.user_id
)
SELECT
    user1_id,
    user2_id
FROM cte
WHERE common_followers_count = (SELECT MAX(common_followers_count) FROM cte);
