-- https://leetcode.com/submissions/detail/923934114/

UPDATE Salary
SET sex =
    CASE sex
        WHEN 'm'
            THEN 'f'
        ELSE
            'm'
    END;
