# Innodb Locking

## S 锁和 X 锁

即 `Shared and Exclusive Locks`

```
如果事务 T1 在行 r 持有 S 锁 (T1 对行 r 可 read)
  a) 事务 T2 若对行 r 申请 S 锁, 则立即获取
  b) 事务 T2 若对行 r 申请 X 锁, 则无法立即获取

如果事务 T1 在行 r 持有X 锁 (T1 对行 r 可 update/delete)
  事务 T2 不管申请 S 锁还是 X 锁, 都无法立即获取, 需要等待 T1 释放行 r 的 X 锁
```
故 X 锁是**排他**的，S 锁**对读是共享**的
