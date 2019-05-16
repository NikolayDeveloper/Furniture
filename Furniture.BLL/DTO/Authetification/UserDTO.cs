using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Furniture.DAL;
namespace Furniture.BLL
{
    /// <summary>
    /// Наследник класса User
    /// </summary>
    public class UserDTO:User
    {
        public UserDTO()
        {}
        public UserDTO(string userName, string email, string password, string role) :base(userName,email,password,role)
        { }
       
        //public new string UserName { get; set; }

        //public new string Role { get; set; }
    }
}
