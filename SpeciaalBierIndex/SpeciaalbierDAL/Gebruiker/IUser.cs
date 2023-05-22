using _2_InterfaceLibrary.Beoordeling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_InterfaceLibrary.Gebruiker
{
    public interface IUser
    {
        void Create(UserDTO dto);
        void Update(UserDTO dto);
        void Delete(int id);
        List<UserDTO> GetAll();
        UserDTO GetById(int id);
    }
}
