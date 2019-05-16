using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.DAL
{
    public interface IUser<T> where T : User
    {
        void CreateUser(T user);
        T GetUser(string email);
        T GetUser(string email, string password);
    }
}
