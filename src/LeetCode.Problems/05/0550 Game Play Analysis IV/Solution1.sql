-- SkipSolution: WrongAnswer
-- https://leetcode.com/submissions/detail/935915877/

SELECT fraction = ROUND(1.0 * COUNT(DISTINCT a1.player_id) / (SELECT COUNT(DISTINCT player_id) FROM Activity), 2)
FROM Activity AS a1
JOIN Activity AS a2 ON
    a2.player_id = a1.player_id
    AND a2.event_date = DATEADD(day, 1, a1.event_date);
