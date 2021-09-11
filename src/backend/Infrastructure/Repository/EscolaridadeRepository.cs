using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repository.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EscolaridadeRepository : BaseRepository<Escolaridade>, IEscolaridadeRepository
    {
        private readonly ApplicationDbContext efContext;
        public EscolaridadeRepository(ApplicationDbContext efContext) : base(efContext)
        {
            this.efContext = efContext;
        }  
    }
}