using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ducker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ducker.Data
{
    public interface IRepository
    {
        DbSet<Duck> Ducks { get; }

        Task SaveChangesAsync();
    }
}
