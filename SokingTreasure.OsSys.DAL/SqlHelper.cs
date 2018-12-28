using System;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace DAL
{
    /// <summary>
    /// SQLServer访问的工具类
    /// </summary>
    public class SqlHelper
    {
        // 从配置文件App.config引用连接串
        // ConfigurationManager 读取配置文件的节点
        // ConnectionStrings["connString"] ： 在配置文件中的连接串名称
        public static string SqlConnStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
     
        /// <summary>
        /// 执行select获取查询结果集
        /// </summary>
        /// <param name="cmdText">SQL语句 或  过程名</param>
        /// <param name="cmdType">命令对象类型 ： SQL语句 或 存储过程</param>
        /// <param name="paras">参数化</param>
        /// <returns></returns>
        public static SqlDataReader GetDateReader(string cmdText, CommandType cmdType, params SqlParameter[] paras)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(SqlConnStr);    // 初始化连接对象

            // 此处 不能using 连接对象 的原因：
            // 由于方法外部要调用 DataReader，需要继续使用连接，所以 方法里面不能关闭连接
            // 连接对象最后 由 DataReader 负责关闭

            try
            {
                PrepareCommand(conn, cmd, paras, cmdText, cmdType);

                // 由于设置 CommandBehavior.CloseConnection 
                // 所以  DataReader关闭，连接自动关闭
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return dr;
            }
            catch      // 有异常
            {
                conn.Close();    // 关闭连接
                throw;
            }
        }


        /// <summary>
        /// 执行insert、delete、update返回影响行数
        /// </summary>
        /// <param name="cmdText">SQL语句 或 过程名</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="pars">参数化</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string cmdText, CommandType cmdType, params SqlParameter[] pars)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(SqlConnStr))
            {
                PrepareCommand(conn, cmd, pars, cmdText, cmdType);
                int r = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();  // 清空参数
                return r;
            }
        }


        /// <summary>
        /// 调用SQL返回DataTable
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="text"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public static DataTable Execute(CommandType cmdType, string text, params SqlParameter[] pars)
        {
            SqlConnection conn = new SqlConnection(SqlConnStr);
            SqlCommand cmd = new SqlCommand();
            // 辅助方法执行命令对象的设置
            PrepareCommand(conn, cmd, pars, text, cmdType);

            SqlDataAdapter da = new SqlDataAdapter(cmd);     // 创建适配器对象
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds.Tables[0];
           
        }

        /// <summary>
        /// 执行select 返回首行首列的值
        /// </summary>
        /// <param name="cmdType">SQL命令类型： SQL语句 和 存储过程</param>
        /// <param name="cmdText">SQL代码</param>
        /// <param name="paras">params可变长参数列表： 参数化查询</param>
        /// <returns></returns>
        public static object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] paras)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(SqlConnStr))
            {
                PrepareCommand(conn, cmd, paras, cmdText, cmdType);
                object r = cmd.ExecuteScalar();
                cmd.Parameters.Clear();  // 参数清空
                return r;
            }
        }

        // 辅助方法
        // 作用：自动打开连接对象
        //       将命令对象关联到连接对象 ， 省略 SqlCommand cmd = new SqlCommand(sql, conn);
        //       自动附加 参数化， 省略 cmd.Parameters.AddRange(new SqlParameter[] { par1, par2 });
        public static void PrepareCommand(SqlConnection conn, SqlCommand cmd, SqlParameter[] paras, string sql, CommandType cmdType)
        {
            // 连接
            // State ： 连接对象的状态，表示连接是 开 或 关
            if (conn.State != ConnectionState.Open)  // 检查连接对象是否开启
            {
                conn.Open();    // 开启
            }
            // 为命令对象赋值属性：
            cmd.Connection = conn;
            cmd.CommandType = cmdType;  // 自动关联SQL命令类型  SQL语句 或 存储过程
            cmd.CommandText = sql;      // 关联SQL语句  或  过程名

            // 参数化查询 或 存储过程参数的附加
            if (paras == null) return;        // 如果没有参数，直接返回
            cmd.Parameters.AddRange(paras);   // 自动关联 参数集合
        }
    }
}
