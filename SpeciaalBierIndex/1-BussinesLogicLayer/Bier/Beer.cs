using _2_InterfaceLibrary.Bier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_BussinesLogicLayer.Bier
{
    public class Beer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string BierType { get; set; }
        public string Brouwerij { get; set; }

        public Beer()
        {

        }

        public Beer(int iD, string name, string bierType, string brouwerij)
        {
            ID = iD;
            Name = name;
            BierType = bierType;
            Brouwerij = brouwerij;
        }

        public Beer(BeerDTO beerDTO)
        {
            this.ID = beerDTO.ID;
            this.Name = beerDTO.Name;
            this.BierType = beerDTO.BierType;
            this.Brouwerij = beerDTO.Brouwerij;
        }

        public BeerDTO GetBeerDTO()
        {
            return new BeerDTO(ID, Name, BierType, Brouwerij);
        }
    }
}
