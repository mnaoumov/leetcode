-- https://leetcode.com/submissions/detail/930384969/

SELECT
    query_name,
    quality = CAST(AVG(1.0 * rating / position) AS numeric(36, 2)),
    poor_query_percentage = CAST(AVG(IIF(rating < 3, 100.0, 0)) AS numeric(36, 2))
FROM Queries
GROUP BY query_name;
