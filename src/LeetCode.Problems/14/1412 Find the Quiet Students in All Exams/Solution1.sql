-- SkipSolution: WrongAnswer
-- https://leetcode.com/submissions/detail/938782286/

WITH cte AS (
    SELECT
        exam_id,
        min_score = MIN(score),
        max_score = MAX(score)
    FROM Exam
    GROUP BY exam_id
),
cte2 AS (
    SELECT e.student_id
    FROM Exam AS e
    JOIN cte ON cte.exam_id = e.exam_id
    WHERE
        e.score = cte.min_score
        OR e.score = cte.max_score
) 
SELECT
    s.student_id,
    s.student_name
FROM Student AS s
LEFT JOIN cte2 ON cte2.student_id = s.student_id
WHERE
    cte2.student_id IS NULL
    AND EXISTS(SELECT * FROM Exam WHERE student_id = s.student_id);
