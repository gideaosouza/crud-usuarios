using Application.Interfaces;
using Domain.Entities;
using Domain.Validations;
using Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository Usuariorepository;

        public UsuarioService(IUsuarioRepository Usuariorepository)
        {
            this.Usuariorepository = Usuariorepository;
        }

        public Task<Usuario> Find(int id)
        {
            return Usuariorepository.Find(id);
        }

        public Task<IEnumerable<Usuario>> GetAll()
        {
            return Usuariorepository.GetAll();
        }

        public Task<Usuario> Insert(Usuario obj)
        {
            return Usuariorepository.Insert(obj);
        }

     
        public async Task Update(int id, Usuario obj)
        {
            var objOri = Usuariorepository.Find(id).Result;

            await Usuariorepository.Update(objOri);
        }

        public async Task<IEnumerable<Usuario>> Where(Expression<Func<Usuario, bool>> predicate)
        {
            return await Usuariorepository.Where(predicate);
        }
    }
}