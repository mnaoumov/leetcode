-- https://leetcode.com/submissions/detail/935498719/

WITH cte AS (
    SELECT
        u.user_id,
        count = COUNT(mr.user_id)
    FROM Users AS u
    LEFT JOIN MovieRating AS mr ON mr.user_id = u.user_id
    GROUP BY u.user_id
),
cte2 AS (
    SELECT
        movie_id,
        average = AVG(1.0 * rating)
    FROM MovieRating AS mr
    WHERE mr.created_at BETWEEN '2020-02-01' AND '2020-02-29'
    GROUP BY movie_id
)
SELECT results = MIN(u.name)
FROM cte
JOIN Users AS u on u.user_id = cte.user_id
WHERE cte.count = (SELECT MAX(count) FROM cte)

UNION ALL

SELECT results = MIN(m.title)
FROM cte2
JOIN Movies AS m on m.movie_id = cte2.movie_id
WHERE cte2.average = (SELECT MAX(average) FROM cte2);
