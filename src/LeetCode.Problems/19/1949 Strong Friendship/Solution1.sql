-- SkipSolution: WrongAnswer
-- https://leetcode.com/submissions/detail/938092467/

WITH userId AS (
    SELECT DISTINCT user_id = user1_id
    FROM Friendship

    UNION

    SELECT DISTINCT user_id = user2_id
    FROM Friendship
),
cte AS (
    SELECT
        user1_id = u1.user_id,
        user2_id = u2.user_id,
        common_friend = COUNT(1)
    FROM userId AS u1
    JOIN userId AS u2 ON u2.user_id > u1.user_id
    JOIN Friendship AS f1 ON
        f1.user1_id = u1.user_id
        OR f1.user2_id = u1.user_id
    JOIN Friendship AS f2 ON
        (
            f2.user1_id = u2.user_id
            OR f2.user2_id = u2.user_id
        )
        AND IIF(f1.user1_id = u1.user_id, f1.user2_id, f1.user1_id) = IIF(f2.user1_id = u2.user_id, f2.user2_id, f2.user1_id)
    GROUP BY
        u1.user_id,
        u2.user_id
)
SELECT
    user1_id,
    user2_id,
    common_friend
FROM cte
WHERE common_friend >= 3;
