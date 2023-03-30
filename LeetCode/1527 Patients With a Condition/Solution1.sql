-- https://leetcode.com/submissions/detail/924526471/

SELECT
    patient_id,
    patient_name,
    conditions
FROM Patients
WHERE
    EXISTS (
        SELECT value
        FROM STRING_SPLIT(conditions, ' ')
        WHERE value LIKE 'DIAB1%'
    );
