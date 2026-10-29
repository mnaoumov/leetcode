-- https://leetcode.com/submissions/detail/938118761/

WITH cte AS (
    SELECT
        user1_id,
        user2_id
    FROM Friendship

    UNION

    SELECT
        user1_id = user2_id,
        user2_id = user1_id
    FROM Friendship
)
SELECT
    user1_id = u1.user1_id,
    user2_id = u1.user2_id,
    common_friend = COUNT(1)
FROM Friendship AS u1
JOIN cte AS f1 ON
    f1.user1_id = u1.user1_id
JOIN cte AS f2 ON
    f2.user1_id = u1.user2_id
    AND f2.user2_id = f1.user2_id
GROUP BY
    u1.user1_id,
    u1.user2_id
HAVING COUNT(1) >= 3;
