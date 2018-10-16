using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
using Dal.Dao;

namespace Bll
{
    public class StudentService
    {
        private static IDao idao = (IDao)DaoFactory.Get("Student");

        public static List<Student> GetStudent(int id)
        {
            return (List<Student>)idao.Select(id);
        }
    }
}
