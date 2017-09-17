/* --------
 * 嵌套查询 Nested Query
 * --------
 */

/* 针对`S_T`数据库 */

USE S_T

GO

-- SELECT * FROM student
-- SELECT * FROM course
-- SELECT * FROM sc

GO

-- 1.

SELECT student.sno, student.sname,
    AVG(sc.grade) AS '平均成绩'
FROM student
INNER JOIN sc
ON student.sno = sc.sno
GROUP BY student.sno, student.sname
HAVING AVG(sc.grade) > (
    SELECT AVG(sc.grade)
    FROM sc
    JOIN student
    ON sc.sno = student.sno
        AND student.sname = '刘晨'
)

GO

-- 2.

SELECT student.sno, student.sname, student.sdept, sc.grade
FROM student
JOIN sc
ON student.sno = sc.sno
    AND student.sno IN (
        -- 查询选修2门课的学生学号
        SELECT sno
        FROM sc
        GROUP BY sno
        HAVING  count(sc.cno) = 2 
    )

GO

-- 3.

SELECT student.sno, student.sname, sc.cno
FROM student
JOIN sc
ON student.sno = sc.sno
    AND student.sno IN (
        SELECT sno
        FROM sc
        GROUP BY sno
        HAVING COUNT(sc.cno) >= 1
    )
    AND sc.cno IN (
        SELECT cno
        FROM sc
        JOIN student
        ON sc.sno = student.sno
            AND student.sname = '刘晨'
    )
    AND student.sname != '刘晨'

GO

-- 4.

SELECT *
FROM student
WHERE sno IN(
    SELECT a.sno
    FROM sc AS a
    JOIN sc AS b
    ON a.sno = b.sno
        AND a.cno = (
            SELECT cno
            FROM course 
            WHERE cname = '信息系统' 
        )
        AND b.cno = (
            SELECT cno
            FROM course 
            WHERE cname = '数学'
        )
)

GO

-- 5.

SELECT cno, cname
FROM course
WHERE cno IN(
    SELECT cno
    FROM sc
    GROUP BY cno
    HAVING COUNT(sno) = 1
)

GO

-- 6.

SELECT distinct student.sno, student.sname
FROM student
JOIN sc
ON student.sno = sc.sno
WHERE sc.cno IN(    
    SELECT cno
    FROM sc
    JOIN student
    ON sc.sno = student.sno
        AND student.sname = '刘晨'
) AND student.sname != '刘晨'

GO

-- 7.

SELECT student.sno, student.sname
FROM student, sc, course
WHERE student.sno = sc.sno
    AND sc.cno = course.cno
    AND course.cname = '数学'

GO

-- 8.

SELECT sname, sage, sdept
FROM student
WHERE sage < ANY(
    SELECT sage
    FROM student
    WHERE sdept = 'CS'
) AND sdept != 'CS'

GO

-- 9.

SELECT sname, sage, sdept
FROM student
WHERE sage < ALL(
    SELECT sage
    FROM student
    WHERE sdept = 'CS'
) AND sdept != 'CS'

GO

/* 针对`company`数据库 */

USE company

GO

-- SELECT * FROM employee
-- SELECT * FROM customer
-- SELECT * FROM sales
-- SELECT * FROM sale_item

GO

-- 1.

SELECT *
FROM sales
WHERE tot_amt = (
    SELECT MAX(tot_amt)
    FROM sales
)

GO

-- 2.

SELECT employee.emp_name, sales.tot_amt
FROM sales
JOIN employee
ON sales.sale_id = employee.emp_no
    AND sales.order_no IN(
        SELECT order_no
        FROM sales
        WHERE tot_amt > ALL(
            SELECT tot_amt
            FROM sales
            WHERE sale_id = 'E0013'
                AND order_date = '1996/11/10'
        )
    )

GO

-- 3.

SELECT order_no
FROM sales
WHERE sale_id IN(
    SELECT emp_no
    FROM employee
    WHERE sex = '女'
)

GO

-- 4.

SELECT emp_no, emp_name
FROM employee
WHERE emp_no IN(
    SELECT sale_id
    FROM sales
    WHERE tot_amt <= 200000
)

GO

-- 5.

SELECT sale_id, tot_amt
FROM sales
WHERE tot_amt = (
    SELECT MAX(tot_amt)
    FROM sales
)

GO

-- 6.

SELECT emp_no, emp_name
FROM employee
WHERE emp_no IN(
    SELECT sale_id
    FROM sales
    WHERE tot_amt <= 50000
)

GO

-- 7.

SELECT *
FROM sales
JOIN sale_item
ON sales.order_no = sale_item.order_no
WHERE sale_item.prod_id IN(
    SELECT prod_id
    FROM sale_item
    WHERE order_no = '10003'
) AND sales.order_no != '10003'

GO

-- 8.

SELECT *
FROM employee
WHERE NOT EXISTS(
    SELECT sale_id
    FROM sales
    WHERE employee.emp_no = sales.sale_id
)


/* --------
 * END!!!
 * --------
 */