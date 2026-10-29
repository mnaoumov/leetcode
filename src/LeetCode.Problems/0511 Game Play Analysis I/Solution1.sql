-- https://leetcode.com/submissions/detail/927539875/

SELECT
    player_id,
    first_login = MIN(event_date)
FROM Activity
GROUP BY player_id;
