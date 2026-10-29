-- https://leetcode.com/submissions/detail/934400208/

SELECT
    s.school_id,
    score = COALESCE(MIN(e.score), -1)
FROM Schools AS s
LEFT JOIN Exam e ON e.student_count <= s.capacity
GROUP BY s.school_id;
