-- https://leetcode.com/submissions/detail/931450592/

SELECT DISTINCT recommended_page = l.page_id
FROM Friendship AS f
JOIN Likes AS l ON l.user_id = f.user2_id
LEFT JOIN Likes AS lUser1 ON
    lUser1.user_id = 1
    AND lUser1.page_id = l.page_id
WHERE
    f.user1_id = 1
    AND lUser1.page_id IS NULL

UNION ALL

SELECT DISTINCT recommended_page = l.page_id
FROM Friendship AS f
JOIN Likes AS l ON l.user_id = f.user1_id
LEFT JOIN Likes AS lUser1 ON
    lUser1.user_id = 1
    AND lUser1.page_id = l.page_id
WHERE
    f.user2_id = 1
    AND lUser1.page_id IS NULL;
