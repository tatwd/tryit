
### SQL 中 `char`、`varchar`、`nvarchar` 的区别？

`char` 为定长，`varchar`、`nvarchar` 为变长。`char`、`varchar` 只支持非 Unicode 编码的字符，而 `nvarchar` 支持 Unicode 编码字符，其单个字符为 2 字节。另：`char` 的检索效率高，`varchar` 实际存储大小为字符串长度加 1，以存储字符串长度。