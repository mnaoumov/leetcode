-- https://leetcode.com/submissions/detail/933168407/

SELECT
    p.player_id,
    p.player_name,
    grand_slams_count = SUM(
        IIF(c1.Wimbledon = p.player_id, 1, 0)
        + IIF(c1.Fr_open = p.player_id, 1, 0)
        + IIF(c1.US_open = p.player_id, 1, 0)
        + IIF(c1.Au_open = p.player_id, 1, 0))
FROM Players AS p
JOIN Championships AS c1 ON p.player_id IN (c1.Wimbledon, c1.Fr_open, c1.US_open, c1.Au_open)
GROUP BY
    p.player_id,
    p.player_name;