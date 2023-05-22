using _2_InterfaceLibrary.Bier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_BussinesLogicLayer.Bier
{
    public class BeerContainer
    {
        public IBeer Interface { get; set; }
        
        public BeerContainer(IBeer context)
        {
            Interface = context;
        }

        public void Create(Beer beer)
        {
            BeerDTO dto = beer.GetBeerDTO();
            Interface.Create(dto);
        }

        public void Delete(int id)
        {
            Interface.Delete(id);
        }

        public List<Beer> GetAll()
        {
            List<Beer> Beers = new List<Beer>();
            Interface.GetAll().ForEach(beerDTO => Beers.Add(new Beer(beerDTO)));
            return Beers;
        }

        public Beer GetById(int id)
        {
            return new Beer(Interface.GetById(id));
        }
    }
}
