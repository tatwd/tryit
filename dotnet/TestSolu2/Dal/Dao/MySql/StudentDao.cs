using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
using Dal.Dao;
using Dal.Helper;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace Dal.Dao.MySql
{
    public class StudentDao : IDao
    {
        public List<Student> Select(int id)
        {
            string sql = String.Format("select * from stu where id = {0}", id);

            string connStr = ConfigurationManager.ConnectionStrings["TestDb"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                List<Student> listStu = new List<Student>();

                try
                {
                    //conn.Open();

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();

                        adapter.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            Student student = new Student()
                            {
                                Id    = (int)row["id"],
                                Name  = (string)row["name"],
                                Age   = (int)row["age"],
                                Sex   = (string)row["sex"],
                                Major = (string)row["major"],
                                Grade = (int)row["grade"]
                            };

                            listStu.Add(student);
                        }

                    }
                }
                catch (Exception)
                {
                    throw new Exception("has exception here: List<Student> Select<Student>(int id)!");
                }
                finally
                {
                    //conn.Close();
                }

                return listStu;
            }
        }
    }
}
