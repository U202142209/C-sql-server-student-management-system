using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace scms
{
    class MyDatabase
    {
        SqlConnection con;      // 连接对象
        public MyDatabase() { }
        public SqlConnection connect()
        {
            string str = "server=127.0.0.1;database=scms;uid=sa;pwd=1234;";
            con = new SqlConnection(str);
            con.Open();
            return con;
        }
        public SqlCommand command(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, connect());
            return cmd;
        }
        public int Execute(string sql)
        {
            return command(sql).ExecuteNonQuery();
        }
        public SqlDataReader read(string sql)
        {
            return command(sql).ExecuteReader();
        }
        public void DaoClose()
        {
            con.Close();
        }
    }
}
