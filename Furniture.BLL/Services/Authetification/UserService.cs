using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Furniture.DAL;
using AutoMapper;
using System.Web.Security;

namespace Furniture.BLL
{
    /// <summary>
    /// Сервис для работы с аутентификацией и авторизацией
    /// </summary>
    public class UserService:IDisposable
    {
        private FurnitureContext db = null;
        private UserRepository repo = null;
        public UserService()
        {
            db = new FurnitureContext();
            repo = new UserRepository(db);
        }
        /// <summary>
        /// Поиск пользавателя в бд
        /// </summary>
        /// <param name="email">логин</param>
        /// <param name="password">пароль</param>
        /// <returns>Возвращает true если пользователь найден</returns>
        public bool FindUser(string email,string password)
        {
            if(repo.GetUser(email,password)!=null)
            {
                FormsAuthentication.SetAuthCookie(email, true);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Регистриция пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Возвращает true если пользователь зарегистрирован</returns>
        public bool CreateUser(UserDTO model)
        {
            bool isCreated = true;
            // если такой email уже существует прерываем создание пользователя
            if (repo.GetUser(model.Email)==null)
            {
                User user = Mapper.Map<User>(model);
                // Регистрируем пользователя
                repo.CreateUser(user);
                // если пользователь удачно добавлен в бд
                if (repo.GetUser(user.Email, user.Password) != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                }
                else
                {
                    throw new NotImplementedException();
                }
                return isCreated;
            }
            else
            {
                isCreated = false;
                return isCreated;
            }
        }

        public Dictionary<string,string> GetNameAdnRoleUser(string email)
        {
            User user = repo.GetUser(email);
            Dictionary<string, string> NameAndRole = new Dictionary<string, string>();
            NameAndRole["Name"] = user.UserName;
            NameAndRole["Role"] = user.Role;
            return NameAndRole;
        }
        /// <summary>
        /// Получение текущей роли пользователя
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public string GetRole(string email)
        {
            return repo.GetRole(email);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
