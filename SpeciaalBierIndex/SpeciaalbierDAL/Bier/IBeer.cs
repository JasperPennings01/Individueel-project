using _2_InterfaceLibrary.Beoordeling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_InterfaceLibrary.Bier
{
    public interface IBeer
    {
        void Create(BeerDTO dto);
        void Update(BeerDTO dto);
        void Delete(int id);
        List<BeerDTO> GetAll();
        BeerDTO GetById(int id);
    }
}
