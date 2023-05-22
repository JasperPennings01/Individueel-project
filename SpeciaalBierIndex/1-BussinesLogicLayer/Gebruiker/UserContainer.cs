using _2_InterfaceLibrary.Gebruiker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_BussinesLogicLayer.Gebruiker
{
    public class UserContainer
    {
        public IUser Interface { get; set; }
        
        public UserContainer(IUser context)
        {
            Interface = context;
        }

        public void Create(User user)
        {
            UserDTO dto = user.GetDTO();
            Interface.Create(dto);
        }

        public void Delete(int id)
        {
            Interface.Delete(id);
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            Interface.GetAll().ForEach(userDTO => users.Add(new User(userDTO)));
            return users;
        }

        public User GetById(int id)
        {
            return new User(Interface.GetById(id));
        }
    }
}
