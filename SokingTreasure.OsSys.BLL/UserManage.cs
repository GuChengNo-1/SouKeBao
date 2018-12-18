using SokingTreasure.OsSys.DAL;
using SokingTreasure.OsSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokingTreasure.OsSys.BLL
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public class UserManage
    {
        /// <summary>
        /// 检查用户(登录)
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns></returns>
        public static bool CheckUser(UserLogin user)
        {
            return UserCRUD.CheckUser(user);
        }
        public static UserLogin GetWhereByUser(UserLogin user)
        {
            return UserCRUD.GetWhereByUser(user);
        }
    }
}
