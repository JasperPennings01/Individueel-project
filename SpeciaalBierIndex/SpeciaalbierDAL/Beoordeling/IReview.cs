using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_InterfaceLibrary.Beoordeling
{
    public interface IReview
    {
        void Create(ReviewDTO dto);
        void Update(ReviewDTO dto);
        void Delete(int id);
        List<ReviewDTO> GetAll();
        ReviewDTO GetById(int id);
    }
}
