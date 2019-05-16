using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.DAL
{
    public class UserRepository : IUser<User>
    {
        private FurnitureContext db = null;
        public UserRepository(FurnitureContext db)
        {
            this.db = db;
        }
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="user"></param>
        public void CreateUser(User user)
        {
            db.Users.Add(new User { UserName = user.UserName, Email = user.Email, Password = user.Password, Role = user.Role });
            db.SaveChanges();
        }
        /// <summary>
        /// Поск пользователя
        /// </summary>
        /// <param name="email">логин</param>
        /// <returns>При удачном исходе возвращает объект User, если пользователь не найден то null</returns>
        /// <see cref="GetUser(string,string)"/>
        public User GetUser(string email)
        {
            User user = null;
            
               user= db.Users.FirstOrDefault(m => m.Email == email);
           
            return user;
        }
        /// <summary>
        /// Поск пользователя
        /// </summary>
        /// <param name="email">логин</param>
        /// <param name="password">пароль</param>
        /// <returns>При удачном исходе возвращает объект User, если пользователь не найден то null</returns>
        /// <see cref="GetUser(string)"/>
        public User GetUser(string email, string password)
        {
            return db.Users.Where(m => m.Email == email && m.Password == password).FirstOrDefault();
        }
        /// <summary>
        /// Получение роли пользователя
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public string GetRole(string email)
        {
           string role = null;
           role= db.Users.Where(m => m.Email == email).FirstOrDefault().Role;
            if(role!=null)
            {
                return role;
            }
            throw new NotImplementedException();
        }
    }
}
