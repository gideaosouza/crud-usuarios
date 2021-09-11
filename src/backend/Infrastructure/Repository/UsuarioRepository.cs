using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repository.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly ApplicationDbContext efContext;
        public UsuarioRepository(ApplicationDbContext efContext) : base(efContext)
        {
            this.efContext = efContext;
        }

        public virtual async Task<IEnumerable<Usuario>> GetAll() =>
            await _efContext.Usuarios.Include(c=>c.Escolaridade).Where(c => c.Habilitado).ToListAsync().ConfigureAwait(false);

         public virtual async Task<Usuario> Find(int id)
        {
            return await _efContext.Usuarios.Include(c=>c.Escolaridade).FirstOrDefaultAsync(c => c.Id == id).ConfigureAwait(false);
        }   
    }
}