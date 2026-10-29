-- SkipSolution: TimeLimitExceeded
-- https://leetcode.com/submissions/detail/938098785/

WITH cte AS (
    SELECT
        user1_id = u1.user1_id,
        user2_id = u1.user2_id,
        common_friend = COUNT(1)
    FROM Friendship AS u1
    JOIN Friendship AS f1 ON
        f1.user1_id = u1.user1_id
        OR f1.user2_id = u1.user1_id
    JOIN Friendship AS f2 ON
        (
            f2.user1_id = u1.user2_id
            OR f2.user2_id = u1.user2_id
        )
        AND IIF(f1.user1_id = u1.user1_id, f1.user2_id, f1.user1_id) = IIF(f2.user1_id = u1.user2_id, f2.user2_id, f2.user1_id)
    GROUP BY
        u1.user1_id,
        u1.user2_id
)
SELECT
    user1_id,
    user2_id,
    common_friend
FROM cte
WHERE common_friend >= 3;
