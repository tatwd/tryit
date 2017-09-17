/* --------
 * 连接查询 Connection Query
 * --------
 */

/* 针对`S_T`数据库 */

USE S_T

GO

-- 1.

SELECT student.sname, student.sno, course.cno, course.cname
FROM student, course, sc
WHERE student.sname LIKE '%勇%'
    AND student.sno = sc.sno
    AND sc.cno = course.cno

-- GO

-- 2.

SELECT student.sname, student.sno, student.sdept, course.cno, sc.grade
FROM student, course, sc
WHERE (course.cname = '数据库' OR course.cname = '数学')
    AND student.sno = sc.sno
    AND course.cno = sc.cno

GO

-- 3.

-- SELECT *
-- FROM student
-- WHERE student.sage != (
--         SELECT sage FROM student WHERE sname = '张立'
--     )

SELECT s_b.*
FROM student AS s_a
INNER JOIN student AS s_b
ON s_a.sno != s_b.sno
    AND s_a.sage != s_b.sage
    AND s_a.sname = '张立'

GO

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


-- SELECT student.sno AS '学号',
--     student.sname AS '姓名',
--     student.sdept AS '所在院系',
--     SUM(course.ccredit) AS '已修学分'
-- FROM student
-- JOIN sc
-- JOIN course
-- ON sc.cno = course.cno
-- ON student.sno = sc.sno
-- WHERE sc.grade >= 60
-- GROUP BY student.sno, student.sname, student.sdept

GO

-- 5

SELECT course.cno, course.cname, student.sno, student.sname, sc.grade
FROM student, course, sc
WHERE student.sno = sc.sno 
    AND sc.cno = course.cno

GO

-- 6.

-- SELECT *
-- FROM student
-- WHERE sdept = (
--     SELECT sdept FROM student
--     WHERE sname = '李勇'
-- ) AND sname != '李勇'

SELECT s_a.sname
FROM student AS s_a
INNER JOIN student AS s_b
ON s_a.sno = s_b.sno
    AND s_b.sdept = 'CS'
    AND s_b.sname != '李勇'

GO

-- 7.

SELECT sc_a.sno
FROM sc AS sc_a
INNER JOIN sc AS sc_b
ON sc_a.sno = sc_b.sno
AND sc_a.cno = '1'
    AND sc_b.cno = '2'

GO

-- 8.

SELECT student.sname
FROM student
INNER JOIN sc
INNER JOIN course
ON sc.cno = course.cno
ON student.sno = sc.sno
GROUP BY student.sname, course.cpno
HAVING COUNT(*) >= 1
    AND course.cpno = '5'

GO

-- 9.

-- 左外连接

SELECT student.sname, sc.cno, sc.grade
FROM student 
LEFT JOIN sc
ON student.sno = sc.sno

GO

-- 右外连接

SELECT student.sname, sc.cno, sc.grade
FROM student 
RIGHT JOIN sc
ON student.sno = sc.sno

GO

-- 全外连接

SELECT student.sname, sc.cno, sc.grade
FROM student 
FULL JOIN sc
ON student.sno = sc.sno

GO

/* 针对`company`数据库 */

USE company

GO

-- SELECT * FROM employee
-- SELECT * FROM customer
-- SELECT * FROM product
-- SELECT * FROM sales
-- SELECT * FROM sale_item

-- 1.

SELECT emp_a.emp_name, emp_a.sex, emp_a.title, emp_a.salary, emp_a.addr
FROM employee AS emp_a
INNER JOIN employee AS emp_b
ON emp_a.emp_no != emp_b.emp_no
    AND emp_a.dept = emp_b.dept
    AND emp_a.addr = emp_b.addr
    AND emp_a.sex =  '女'  
    AND emp_b.sex =  '女'

GO

-- 2.

SELECT product.prod_id, product.prod_name, sale_item.qty, sale_item.unit_price
FROM product
INNER JOIN sale_item
ON product.prod_id = sale_item.prod_id

GO

-- 3.

SELECT product.prod_id, product.prod_name, sale_item.qty, sale_item.unit_price
FROM product
INNER JOIN sale_item
ON product.prod_id = sale_item.prod_id
    AND sale_item.unit_price > 2400

GO

-- 4.

SELECT customer.cust_name, customer.addr
FROM sales
INNER JOIN customer
ON sales.cust_id = customer.cust_id
    AND sales.tot_amt > 24000

GO

-- 5.

SELECT customer.cust_id,
    customer.cust_name,
    SUM(sales.tot_amt) AS '订单总额'
FROM sales
INNER JOIN customer
ON sales.cust_id = customer.cust_id
GROUP BY customer.cust_id, customer.cust_name

GO

-- 6.

SELECT sales.cust_id, 
    sale_item.prod_id,
    SUM(sale_item.qty) AS '总数量',
    AVG(sale_item.unit_price) AS '平均单价'
FROM sales
INNER JOIN sale_item
ON sales.order_no = sale_item.order_no
GROUP BY sales.cust_id, sale_item.prod_id
ORDER BY sales.cust_id, sale_item.prod_id

GO

-- 7.

SELECT customer.cust_id,
    customer.cust_name,
    SUM(sales.tot_amt) AS '订单总额'
FROM sales
INNER JOIN customer
ON sales.cust_id = customer.cust_id
    AND YEAR(sales.order_date) = 1996
    -- AND DATEPART(YEAR, sales.order_date) = 1996
GROUP BY customer.cust_id, customer.cust_name

GO

-- 8.

SELECT TOP 5 product.prod_id, product.prod_name, 
    SUM(sale_item.qty)
FROM sale_item
INNER JOIN product
ON sale_item.prod_id = product.prod_id
    AND YEAR(sale_item.order_date) = 1996
GROUP BY product.prod_id, product.prod_name

GO

-- 9.

-- 左外连接

SELECT product.prod_id, product.prod_name, sale_item.qty, sale_item.unit_price
FROM product
LEFT JOIN sale_item
ON product.prod_id = sale_item.prod_id
WHERE sale_item.unit_price > 2400

GO

-- 右外连接

SELECT product.prod_id, product.prod_name, sale_item.qty, sale_item.unit_price
FROM product
RIGHT JOIN sale_item
ON product.prod_id = sale_item.prod_id
WHERE sale_item.unit_price > 2400

GO

-- 全外连接

SELECT product.prod_id, product.prod_name, sale_item.qty, sale_item.unit_price
FROM product
FULL JOIN sale_item
ON product.prod_id = sale_item.prod_id
WHERE sale_item.unit_price > 2400

/* --------
 * END!!!
 * --------
 */