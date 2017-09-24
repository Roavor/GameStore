using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.Data.Entity;

namespace Domain.Concrete
{
    class EFDbContext : DbContext
    {
        public DbSet<Game> Games {get; set;}
    }
}
