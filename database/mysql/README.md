**MySQL 中的 `utf8` 和 `utf8mb4` 编码的区别**

`utf8mb4` 才是真正的符合现行标准的 UTF-8 编码，支持单个字符的最多 3 字节的存储；`utf8` 是旧版本的遗留编码，它只支持单字符最多 3 字节的存储。

*MySQL 的事务隔离性**

- READ UNCOMMITTED（未提交读）

  事务之间透明化，能看见未提交的修改。易发生脏读（Dirty Read）。性能好，但实际应用少。不是加锁读。

- READ COMMITTED （提交读）

  只能看见已提交事务的更改。又名不可重复读（norepeatable read），因为两次执行同样的查询可能造成不一样的结果。大多数数据库系统使用。不发生脏读，不是加锁读。

- REPEATABLE READ（可重复读）

  同一事务中多次读取同一记录结果一致。无法解决幻读（Phantom Read），即某事务在读取一定范围内的数据时，另一事务在该范围内插入了新数据，之前的事务再次读取时出现幻行（Phantom Row）。InnoDB 和 XtraDB 储存引擎通过多版本并发控制（MVCC，Multiversion Concurrency Control）解决了幻读问题。可重复读是 MySQL 默认事务隔离级别。不是加锁读。

- SERIALIZABLE（可串行化）

  最该隔离级别。强制事务串行执行。避免了幻读问题。读取每行数据时加锁，可能造成大量的超时和锁争用问题。实际应用少。


**什么是死锁？**

指两个或多个事务在对同一资源上互相占用，并请求锁定对方占用的资源，从而导致恶性循环的现象。

```
事务 1
	START TRANSACTION;
	UPDATE StockPrice SET close = 45.60 WHERE stock_id = 4 AND date = '2002-05-01';
	UPDATE StockPrice SET close = 19.80 WHERE stock_id = 3 AND date = '2002-05-02';

事务 2
	UPDATE StockPrice SET high = 20.12 WHERE stock_id = 3 AND date = '2002-05-02';
	UPDATE StockPrice SET high = 47.20 WHERE stock_id = 4 AND date = '2002-05-01';
```

两个事务执行完第一句都会锁定该行数据，然后执行第二句时都等待对方释放锁，同时又持有对方需要的锁，则陷入死循环。

解决方案常见的有死锁检测和死锁超时机制。InnoDB 采用的是将持有最少行级排他锁的事务进行回滚。死锁有时因数据冲突，有时也因储存引擎的实现方式的不同导致。大多数情况下只需要处理因死锁而发生回滚的事务即可。

**MySQL 中的事务**

有两种事务引擎：InnoDB 和 NDB Cluster。另外还有第三方的事务引擎：XtraDB、PBXT 等。

MySQL 中默认启用 `AUTOCIMMIT`，即若不是显示的开始一个事务（`START TRANSACTION;`），则默认将每条语句当成一个事务并自动提交。

例如，查看 `AUTOCOMMIT` 值并关闭自动提交：
 
```
mysql> show variables where variable_name like 'autocommit';
+---------------+-------+
| Variable_name | Value |
+---------------+-------+
| autocommit    | ON    |
+---------------+-------+
1 row in set (0.01 sec)

mysql> set autocommit = 0;
```

关闭自动提交后要显示的进行提交（`COMMIT;`）或回滚（`ROLLBACK`）。

设置事务隔离级别可在在配置文件中，也可以只改变当前会话的隔离级别：

```
mysql> set session transaction isolatton level read committed;
```

**多版本并发控制**

不同数据库引擎可能有不同的实现。非阻塞的读操作，写操作只锁定必要的行。实际上行级锁的变种。保存数据在某个时间点的快照。

乐观（optimistic）并发控制和悲观（pessimistic）并发控制。

InnoDB 的 MVCC：每行记录隐含两个字段——创建时间和过期时间（或删除时间）。这里的时间是指系统版本号（system version number）。每开始一个事务，版本号自动递增。

会对 CRUD 多版本号的设置和检查操作。

MVCC 只在 REPEATABLE READ 和 READ COMMITTED 两个隔离级别下工作。

TODO

参考资料

- Baron Schwartz, Peter Zaitsev, Vadim Tkachenko. 高性能 MySQL（第 3 版）. 电子工业出版社, 2013.
