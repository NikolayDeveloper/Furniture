using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using Furniture.BLL;
using System.Runtime.InteropServices.ComTypes;

namespace Furniture.PL.Filters
{
    /// <summary>
    /// Указывает, доступ пользователям соответствующие требованиям проверки подленности
    /// </summary>
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        private UserService userService = null;
        private Dictionary<string,string> user = null;
        private string[] allowedUsers = new string[] { };
        private string[] allowedRoles = new string[] { };
       /// <summary>
       /// Переопределенный метод для проверки ролей и имен пользователей
       /// </summary>
       /// <param name="httpContext">текущий контекст данных пользователя</param>
       /// <returns>Возвращает true если допуск разрешен к методу или контроллеру</returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // Если пользователь не авторизован перенаправляем на страницу по умолчанию, определенную в Web.config
            if (httpContext.Request.IsAuthenticated)
            {
                using (userService = new UserService())
                {
                    user = userService.GetNameAdnRoleUser(httpContext.User.Identity.Name);
                }
            }
            else
            {
                return false;
            }
                if (!String.IsNullOrEmpty(base.Users))
                {
                    allowedUsers = base.Users.Split(new char[] { ',' });
                    for (int i = 0; i < allowedUsers.Length; i++)
                    {
                        allowedUsers[i] = allowedUsers[i].Trim();
                    }
                }
            if (!String.IsNullOrEmpty(base.Roles))
            {
                allowedRoles = base.Roles.Split(new char[] { ',' });
                for (int i = 0; i < allowedRoles.Length; i++)
                {
                    allowedRoles[i] = allowedRoles[i].Trim();
                }
            }
           
            return httpContext.Request.IsAuthenticated && User(user) && Role(user);
            }
        /// <summary>
        /// Метод для поиска совпадения имени пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Возвращает true если совпадение найдено</returns>
        private bool User(Dictionary<string, string> user)
        {
            if (allowedUsers.Length > 0)
            {
                for (int i = 0; i < allowedUsers.Length; i++)
                {
                    if (allowedUsers[i].Contains(user["Name"]))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Метод для поиска совпадения роли пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Возвращает true если совпадение найдено</returns>
        private bool Role(Dictionary<string, string> user)
        {
            if (allowedRoles.Length > 0)
            {
                for (int i = 0; i < allowedRoles.Length; i++)
                {
                    if (allowedRoles[i].Contains(user["Role"]))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

