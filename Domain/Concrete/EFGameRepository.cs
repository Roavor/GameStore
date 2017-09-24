using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Abstract;

namespace Domain.Concrete
{
   public class EFGameRepository:IGameRepository
    {
        EFDbContext contxt = new EFDbContext();

        public IEnumerable<Game> Games
        {
            get { return contxt.Games; }
        }
    }
}
