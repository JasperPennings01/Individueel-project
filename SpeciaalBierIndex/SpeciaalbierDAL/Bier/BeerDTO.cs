using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_InterfaceLibrary.Bier
{
    public class BeerDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string BierType { get; set; }
        public string Brouwerij { get; set; }

        public BeerDTO()
        {

        }

        public BeerDTO(int iD, string name, string bierType, string brouwerij)
        {
            ID = iD;
            Name = name;
            BierType = bierType;
            Brouwerij = brouwerij;
        }
    }
}
