-- 1. 使用 GRANT
-- GRANT <privileges> 
-- ON <database_name>.<table_name> 
-- TO 'user_name'@'host_name'
-- IDENTIFIED BY 'user_password';
-- 
-- 2. 在 mysql.user 表中添加一条记录
-- 不同的版的 user 表字段可能不同


-- 赋予名为 jaron 的用户在 localhost 主机上访问 test_db 数据库
-- 并具有 SELECT,INSERT,UPDATE,DELETE,CREATE,DROP 权限

-- 方式一:
GRANT SELECT,INSERT,UPDATE,DELETE,CREATE,DROP -- privileges
ON test_db.* -- all tables of `database_name`
TO 'jaron'@'localhost'
IDENTIFIED BY 'test123';

-- 方式二:
INSERT INTO mysql.user(Host,User,authentication_string,Select_priv,Insert_priv,Update_priv,Delete_priv,Create_priv,Drop_priv)
VALUES('localhost', 'jaron', PASSWORD('test123'), 'Y', 'Y', 'Y', 'Y', 'Y', 'Y');
FLUSH PRIVILEGES; -- 重读授权表

# 查看用户权限
show grants for 'test'@'%'

# 给已存在的用户添加权限
grant ALTER,CREATE Temporary Tables on test_db.* to test

# 撤销用户 test 在 test 数据库上所以的权限
revoke all on test.* from test

