-- https://leetcode.com/submissions/detail/936121824/

SELECT
    gender,
    day,
    total = SUM(score_points) OVER(PARTITION BY gender ORDER BY day)
FROM Scores AS s
ORDER BY
    gender,
    day;
