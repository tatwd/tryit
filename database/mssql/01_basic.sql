-- 查看当前数据库版本信息
select @@version
go

-- 查看所有数据库名
select name from master..sysdatabases
go

-- 查看所有数据库表名
-- 'U': 用户表; 'S': 系统表
select name from master..sysobjects
where xtype = 'U' or xtype = 'S'
go

-- 查看数据库表的所以列名
select name from master..syscolumns
where id = object_id('sysobjects') -- object_id('表名') 获取表ID
go

-- 获取数据库支持的所有数据类型
select name from systypes
go