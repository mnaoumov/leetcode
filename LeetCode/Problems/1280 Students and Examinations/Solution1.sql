-- https://leetcode.com/submissions/detail/931591693/

SELECT
    st.student_id,
    st.student_name,
    su.subject_name,
    attended_exams = SUM(IIF(e.student_id IS NULL, 0, 1))
FROM Students AS st
CROSS JOIN Subjects AS su
LEFT JOIN Examinations AS e ON
    e.student_id = st.student_id
    AND e.subject_name = su.subject_name
GROUP BY    
	st.student_id,
    st.student_name,
    su.subject_name;
