-- https://leetcode.com/submissions/detail/933448381/

SELECT DISTINCT l.account_id
FROM LogInfo AS l
JOIN LogInfo AS l2 ON
    l2.account_id = l.account_id
    AND l2.ip_address != l.ip_address
    AND IIF(l.login < l2.login, l2.login, l.login) <= IIF(l.logout < l2.logout, l.logout, l2.logout);
