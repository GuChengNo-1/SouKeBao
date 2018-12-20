using SokingTreasure.OsSys.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokingTreasure.OsSys.DAL
{
    /// <summary>
    /// 用户(增删查改)
    /// </summary>
    public class UserCRUD
    {
        /// <summary>
        /// 检查用户(登录)
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns></returns>
        public static bool CheckUser(UserLogin user)
        {
            string sql = $"select * from UserLogin where LoginName=@LoginName and LoginPwd=@LoginPwd";
            SqlParameter[] param = {
                 new SqlParameter("@LoginName",user.LoginName),
                 new SqlParameter("@LoginPwd",user.LoginPwd)
             };
            SqlDataReader reader = DbHelper.ExectueReader(sql, false, param);
            while (reader.Read())
            {
                return true;
            }
            return false;
        }

        public static UserLogin GetWhereByUser(UserLogin user)
        {
            string sql = $"select * from UserLogin where LoginName=@LoginName and LoginPwd=@LoginPwd";
            SqlParameter[] param = {
                 new SqlParameter("@LoginName",user.LoginName),
                 new SqlParameter("@LoginPwd",user.LoginPwd)
             };
            DataTable table = DbHelper.GetDataTable(sql, false, param);
            UserLogin ul = new UserLogin();
            foreach (DataRow item in table.Rows)
            {
                ul.Id = (int)item["Id"];
                ul.LoginName = item["LoginName"].ToString();
                ul.LoginPwd = item["LoginPwd"].ToString();
                ul.LoginEmail = item["LoginEmail"].ToString();
                ul.LoginPhone = item["LoginPhone"].ToString();
                ul.StateId = (int)item["StateId"];
            }
            return ul;
        }
        /// <summary>
        /// 用户名是否已存在
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public static bool UserIfExist(string loginName)
        {
            string sql = $"select * from UserLogin where LoginName=@LoginName";
            SqlParameter[] param = {
                 new SqlParameter("@LoginName",loginName)
             };
            SqlDataReader reader = DbHelper.ExectueReader(sql, false, param);
            while (reader.Read())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 重置用户密码
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="secrecyPwd"></param>
        /// <returns></returns>
        public static bool AlterUserPwd(int userId, string secrecyPwd)
        {
            string sql = $"update UserLogin set LoginPwd = '{secrecyPwd}' where Id = {userId}";
            if (DbHelper.ExecuteNonQuery(sql) >= 1)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 验证用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static UserLogin VerifyUser(UserLogin model)
        {
            string sql = $"select * from UserLogin where LoginName=@LoginName and LoginPhone=@LoginPhone and LoginEmail=@LoginEmail";
            SqlParameter[] param = {
                 new SqlParameter("@LoginName",model.LoginName),
                 new SqlParameter("@LoginPhone",model.LoginPhone),
                 new SqlParameter("@LoginEmail",model.LoginEmail)
             };
            DataTable table = DbHelper.GetDataTable(sql, false, param);
            UserLogin ul = new UserLogin();
            foreach (DataRow item in table.Rows)
            {
                ul.Id = (int)item["Id"];
                ul.LoginName = item["LoginName"].ToString();
                ul.LoginPwd = item["LoginPwd"].ToString();
                ul.LoginEmail = item["LoginEmail"].ToString();
                ul.LoginPhone = item["LoginPhone"].ToString();
                ul.StateId = (int)item["StateId"];
            }
            return ul;
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool InsertUser(UserLogin model)
        {
            string sql = $"insert into UserLogin values('{model.LoginName}','{model.LoginPwd}','{model.LoginEmail}','{model.LoginPhone}',1)";
            if (DbHelper.ExecuteNonQuery(sql, false) >= 1)
            {
                return true;
            }
            return false;
        }
    }
}
