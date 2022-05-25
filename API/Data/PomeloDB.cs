using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace API.Data
{
    public class PomeloDB : DbContext
    {
        public PomeloDB(DbContextOptions<PomeloDB> options)
            : base(options)
        {
        }

        public DbSet<Domain.Contact>? Contact { get; set; }
        public DbSet<Domain.UserDetails>? UserDetails { get; set; }

    }
}
