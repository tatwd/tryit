class basic
{
    // static System.Data.SqlClient.SqlConnection conn = null;
    static MySql.Data.MySqlClient.MySqlConnection conn = null;
    static string connStr = "server=localhost;user id=root;database=mytest;pwd=test123;";
    static basic()
    {
        // 获取数据库连接对象
        conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
        System.Console.WriteLine("inited!");
    }

    public static void run()
    {
        try
        {
            // 手动连接
            conn.ConnectionString = connStr;
            conn.Open();

            string tab = "tusers";
            string sql3 = $"INSERT INTO {tab} VALUES(default, @str)";
            var cmd3 = new MySql.Data.MySqlClient.MySqlCommand(sql3, conn);
            cmd3.Parameters.AddWithValue("@str", "👏");
            using(cmd3)
            {
                int rows = cmd3.ExecuteNonQuery();
                System.Console.WriteLine(rows);
            }

            string sql1 = $"select * from {tab}";
            var cmd1 = new MySql.Data.MySqlClient.MySqlCommand(sql1, conn);
            MySql.Data.MySqlClient.MySqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                // 此时 reader 为当前行
                for (int col = 0; col < reader.FieldCount; col++)
                {
                    var fieldName = reader.GetName(col);
                    var val = reader[col];
                    System.Console.Write("{0}: {1}\n", fieldName, val);
                }
            }
            reader.Close();
            cmd1.Dispose();
/*
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
                // GetOrdinal 获取对应列的序号
                int index = reader.GetOrdinal("login");
                System.Console.WriteLine("\n[login] index: {0}", index);

                // 此时 reader 为当前行
                for (int col = 0; col < reader.FieldCount; col++)
                {
                    var fieldName = reader.GetName(col);
                    var val = reader[col];
                    var dtype = reader.GetDataTypeName(col);
                    if (dtype == "datetime")
                    {
                        // https://docs.microsoft.com/zh-cn/dotnet/standard/base-types/standard-date-and-time-format-strings?view=netcore-2.2
                        var utc = System.DateTime.SpecifyKind(reader.GetDateTime(col), System.DateTimeKind.Utc);
                        val = string.Format("\"{0:O}\"", utc);
                    }
                    System.Console.Write("{0}: {1} ", fieldName, val);
                    System.Console.WriteLine(dtype);
                }
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
            string sql3 = string.Format(@"INSERT INTO [TUser]
                                          VALUES('d@test.com', 'David', 'david123', '{0}', '{0}')", System.DateTime.UtcNow);
            var cmd3 = new System.Data.SqlClient.SqlCommand(sql3, conn);
            using(cmd3)
            {
                int rows = cmd3.ExecuteNonQuery();
                System.Console.WriteLine(rows);
            }

            // 修改
            var sql4 = @"UPDATE [TUser]
                         SET [Password] = @Password, [UpdatedAt] = @UpdatedAt
                         WHERE [Id] = @Id";
            using(var cmd4 = conn.CreateCommand())
            {
                cmd4.CommandText = sql4;
                cmd4.CommandType = System.Data.CommandType.Text;
                cmd4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@Password", "hello_world"),
                    new System.Data.SqlClient.SqlParameter("@UpdatedAt", System.DateTime.UtcNow),
                    new System.Data.SqlClient.SqlParameter("@Id", 5),
                });

                // SqlCommand.Prepare method requires all parameters to have an explicitly set type.
                // cmd4.Prepare();

                // var r = cmd1.ExecuteNonQuery();
                var r = cmd4.ExecuteReader();
                System.Console.WriteLine(r.RecordsAffected);
            }
*/
        }
        catch(MySql.Data.MySqlClient.MySqlException ex)
        {
            System.Console.WriteLine("MySqlException: {0}", ex.Message);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Exception: {0}", ex.Message);
        }
        finally
        {
            System.Console.WriteLine("正在关闭连接...Done!");
            conn.Close();
            conn.Dispose();
        }
    }
}