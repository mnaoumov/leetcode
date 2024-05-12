-- https://leetcode.com/submissions/detail/926922127/

SELECT
    date_id,
    make_name,
    unique_leads = COUNT(DISTINCT lead_id),
    unique_partners = COUNT(DISTINCT partner_id)
FROM DailySales
GROUP BY
    date_id,
    make_name;
