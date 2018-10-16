using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Configuration;

namespace Dal.Dao
{
    public class DaoFactory
    {
        private static readonly string dbType = ConfigurationManager.AppSettings["DbType"].ToString();

        //public static T Get<T>()
        //{
        //    string type = Type.GetType(T);

        //    //return (T)
        //}

        public static object Get(string modelName)
        {
            string assemblyName = String.Format("Dal.Dao.{0}", dbType);
            string className    = String.Format("{0}.{1}Dao", assemblyName, modelName);

            return Assembly.Load("Dal").CreateInstance(className);
        }
    }
}
