using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HiddenLotus;

namespace HiddenLotus.Data
{
    public class HiddenLotusContext : DbContext
    {
        public HiddenLotusContext (DbContextOptions<HiddenLotusContext> options)
            : base(options)
        {
        }

        public DbSet<HiddenLotus.Fighter> Fighter { get; set; } = default!;
    }
}
