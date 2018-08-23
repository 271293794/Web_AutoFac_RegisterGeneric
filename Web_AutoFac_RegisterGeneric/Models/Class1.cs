using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Web_AutoFac_RegisterGeneric.Models
{
    public class UserApp : BaseApp<User>
    {
        public int AddList()
        {
            for (int i = 0; i < 5; i++)
            {
                Repository.Add();

            }
            return 5;

        }
    }
    public class RoleApp : BaseApp<Role>
    {

    }

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }

    }
    public class Role
    {
        public string Name { get; set; }
        /// <summary>
        /// 此角色可访问模块 id 数组
        /// </summary>
        public int[] AuthModel { get; set; }

    }
    public class BaseApp<T> 
    {
        public IRepository<T> Repository { get; set; }
        public void DeleteList(int[]  arrID)
        {
            foreach (var item in arrID)
            {
                Repository.Delete(item);
            }

        }



    }
    public class BaseRepository<T> : IRepository<T>
    {
        public bool Add()
        {
            Debug.WriteLine("向sqlserver 添加成功"); return true;
        }

        public void Delete(int id)
        {
            Debug.WriteLine("sqlserver 删除成功");
        }
    }
    public interface IRepository<T>
    {
        bool Add();
        void Delete(int id);
    }
}