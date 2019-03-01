class basic
{
    static System.Data.SqlClient.SqlConnection conn = null;
    static basic()
    {
        // 获取数据库连接对象
        string connStr = "server=localhost;user id=sa;database=TestDb;pwd=root123;";
        conn = new System.Data.SqlClient.SqlConnection(connStr);
        System.Console.WriteLine("inited!");
    }

    public static void run()
    {
        try
        {
            // 手动连接
            // conn.ConnectionString = "server=localhost;user id=sa;database=TestDb;pwd=root123;";
            conn.Open();

            // 创建数据库执行对象
            string sql1 = "SELECT * FROM [TUser]";
            var cmd1 = new System.Data.SqlClient.SqlCommand(sql1, conn);

            // 执行查询命令
            // 写操作: ExecuteNonQuery
            // 读操作: ExecuteReader, ExecuteScalar
            System.Data.SqlClient.SqlDataReader reader = cmd1.ExecuteReader();
            System.Console.WriteLine("HasRows: {0}", reader.HasRows);
            System.Console.WriteLine("FieldCount: {0}", reader.FieldCount);
            System.Console.WriteLine("Depth: {0}", reader.Depth);
            System.Console.WriteLine("RecordsAffected: {0}", reader.RecordsAffected); // -1 for select

            // 手动去调用 Read() 方法之后, DataReader 对象才会移动到结果集的第一行
            // 同时此方法也返回一个 Bool 值, 表明下一行是否可用, True 则可用, False 则到达结果集末尾
            while (reader.Read())
            {
                // 此时 reader 为当前行
                for (int col = 0; col < reader.FieldCount; col++)
                {
                    var fieldName = reader.GetName(col);
                    var val = reader[col];
                    System.Console.Write("{0}: {1} ", fieldName, val);
                }

                // GetOrdinal 获取对应列的序号
                int index = reader.GetOrdinal("login");
                System.Console.WriteLine("\n[login] index: {0}", index);
            }
            reader.Close();
            cmd1.Dispose();

            // ExecuteScalar: 获取一行一列值
            string sql2 = "SELECT COUNT([Id]) FROM [TUser]";
            var cmd2 = new System.Data.SqlClient.SqlCommand(sql2, conn);
            int count = (int) cmd2.ExecuteScalar();
            System.Console.WriteLine("users count: {0}", count);
            cmd2.Dispose();

            // 新增数据
            var now = System.DateTime.UtcNow;
            string sql3 = string.Format(
                @"insert into [TUser]([Login], [Name], [Password], [CreatedAt], [UpdatedAt])
                  values('a@test.com', 'Bob', 'bob123', '{0}', '{0}')", now);
            var cmd3 = new System.Data.SqlClient.SqlCommand(sql3, conn);
            using(cmd3) {
                int rows = cmd3.ExecuteNonQuery();
                System.Console.WriteLine(rows);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        finally
        {
            System.Console.WriteLine("正在关闭连接...Done!");
            conn.Close();
            // conn.Dispose();
        }
    }
}