/* --------
 * 复杂查询 Complex Query
 * --------
 */

-- USE S_T
-- USE company

-- GO

-- SELECT * FROM 
--     -- tables from company
--     dbo.customer
--     dbo.employee
--     dbo.product
--     dbo.sales
--     dbo.sale_item

--     -- tables from S_T
--     dbo.student
--     dbo.course
--     dbo.sc

-- GO

/* 针对`S_T`数据库 */

USE S_T

GO

-- 1.

SELECT DISTINCT sdept AS '院系',
    '院系规模' = CASE
        WHEN COUNT(sdept) >= 5 THEN '规模很大'
        WHEN COUNT(sdept) >= 4 AND COUNT(sdept) < 5 THEN '规模一般'
        WHEN COUNT(sdept) >= 2 AND COUNT(sdept) < 4 THEN '规模稍小'
        ELSE '规模很小'
    END
FROM student
WHERE sdept is not NULL
GROUP BY sdept

GO

-- 2.

SELECT COUNT(sno) AS '学生总人数',
    AVG(sage) AS '平均年龄'
FROM student

GO

-- 3.

SELECT sno,
    COUNT(cno) AS '选修课程数'
FROM sc
GROUP BY sno
HAVING COUNT(cno) > 3

-- 4.

SELECT cno,
    COUNT(sno) AS '总人数',
    MAX(grade) AS '最大成绩',
    MIN(grade) AS '最小成绩',
    AVG(grade) AS '平均成绩' 
FROM sc
GROUP BY cno
ORDER BY cno DESC

-- 5.

SELECT sno AS '学号',
    COUNT(cno) AS '不及格门数'
FROM sc
WHERE grade < 60
GROUP BY sno
HAVING COUNT(cno) >= 2 


/* 针对`company`数据库 */

USE company

GO

-- 1.

SELECT COUNT(*) as '员工总数'
FROM employee

GO

-- 2.

SELECT DISTINCT dept AS '部门',
    COUNT(dept) AS '人数',
    AVG(salary) AS '平均薪水'
FROM employee 
GROUP BY dept

GO

-- 3.

SELECT sale_id, tot_amt
FROM sales
WHERE tot_amt > 10000

GO

-- 4.

SELECT DISTINCT prod_id,
    SUM(qty) AS '销售总量',
    AVG(unit_price) AS '平均售价'
FROM sale_item
GROUP BY prod_id

GO

-- 5.

SELECT dept, sex,
    AVG(salary) AS '平均薪水'
FROM employee
GROUP BY
    CUBE(sex, dept)

GO

-- 6.

SELECT dept, sex,
    AVG(salary) AS '平均薪水'
FROM employee
GROUP BY
    ROLLUP(dept, sex)

GO

-- 7.

SELECT COUNT(*) AS '产品类型总数'
FROM product

GO

-- 8.

SELECT prod_id,
    SUM(unit_price) AS '订购金额总和',
    SUM(qty * unit_price) AS '销售金额总和'
FROM sale_item
GROUP BY prod_id
ORDER BY SUM(unit_price) DESC

GO

-- 9.

SELECT prod_id,
    SUM(unit_price * qty) AS '销售金额',
    MONTH(order_date) AS '月份' -- 取出月份
    -- DATEPART(MONTH, order_date) AS '月份' 
FROM sale_item
GROUP BY prod_id, DATEPART(MONTH, order_date)
ORDER BY  '月份', prod_id

GO

-- 10.

SELECT sale_id,
    SUM(tot_amt) AS '销售业绩',
    MONTH(order_date) AS '月份' -- 取出月份    
    -- DATEPART(MONTH, order_date) AS '月份' -- 取出月份
FROM sales
GROUP BY sale_id, MONTH(order_date)
ORDER BY  sale_id, '月份' DESC

/* --------
 * END!!!
 * --------
 */