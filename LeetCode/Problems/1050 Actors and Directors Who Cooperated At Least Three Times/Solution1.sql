-- https://leetcode.com/submissions/detail/927642534/

SELECT
    actor_id,
    director_id
FROM ActorDirector
GROUP BY
    actor_id,
    director_id
HAVING COUNT(1) >= 3;
