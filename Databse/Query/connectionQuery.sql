-- ===============
-- 连接查询 Connection Query
-- ===============

-- ===============
-- 针对`S_T`数据库
-- ===============

USE S_T

GO

SELECT * FROM student
SELECT * FROM course
SELECT * FROM sc

-- SELECT * FROM student, course, sc
-- WHERE student.sno = sc.sno AND course.cno = sc.cno

-- SELECT * FROM student CROSS JOIN course,sc
-- WHERE student.sno = sc.sno AND sc.cno = course.cno

-- SELECT * FROM student inner JOIN sc
-- ON student.sno = sc.sno

-- 1.

-- SELECT student.sname, student.sno, course.cno, course.cname
-- FROM student, course, sc
-- WHERE student.sname LIKE '%勇%'
--     AND student.sno = sc.sno
--     AND sc.cno = course.cno

-- GO

-- 2.

-- SELECT student.sname, student.sno, student.sdept, course.cno, sc.grade
-- FROM student, course, sc
-- WHERE (course.cname = '数据库' OR course.cname = '数学')
--     AND student.sno = sc.sno
--     AND course.cno = sc.cno

-- GO

-- 3.

-- SELECT *
-- FROM student, course, sc
-- WHERE student.sage != (
--         SELECT sage FROM student WHERE sname = '张立'
--     )
--     AND student.sno = sc.sno 
--     AND sc.cno = course.cno

-- GO

-- 4.

SELECT student.sno AS '学号',
    student.sname AS '姓名',
    student.sdept AS '所在院系',
    SUM(course.ccredit) AS '已修学分'
FROM student, sc, course
WHERE sc.grade >= 60
    AND student.sno = sc.sno 
    AND sc.cno = course.cno
GROUP BY student.sno, student.sname, student.sdept

-- 5

SELECT course.cno, course.cname, student.sno, student.sname, sc.grade
FROM student, course, sc
WHERE student.sno = sc.sno 
    AND sc.cno = course.cno

-- 7.

-- SELECT student.sno
-- FROM student INNER JOIN sc 
-- ON student.sno = sc.sno
--     AND sc.cno = '1' AND sc.cno = '2'

-- SELECT sc.sno
-- FROM sc
-- WHERE sc.cno = '1' AND sc.cno = '2'
