-- https://leetcode.com/submissions/detail/925625347/

SELECT DISTINCT id = author_id
FROM Views
WHERE viewer_id = author_id
ORDER BY author_id;
