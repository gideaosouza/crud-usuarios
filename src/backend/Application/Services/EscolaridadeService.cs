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
    public class EscolaridadeService : IEscolaridadeService
    {
        private readonly IEscolaridadeRepository escolaridaderepository;

        public EscolaridadeService(IEscolaridadeRepository escolaridaderepository)
        {
            this.escolaridaderepository = escolaridaderepository;
        }

        public Task Delete(int id)
        {
           return escolaridaderepository.Delete(id);
        }

        public Task<Escolaridade> Find(int id)
        {
            return escolaridaderepository.Find(id);
        }

        public Task<IEnumerable<Escolaridade>> GetAll()
        {
            return escolaridaderepository.GetAll();
        }

        public Task<Escolaridade> Insert(Escolaridade obj)
        {
            return escolaridaderepository.Insert(obj);
        }

     
        public async Task Update(int id, Escolaridade obj)
        {
            var objOri = escolaridaderepository.Find(id).Result;

            await escolaridaderepository.Update(objOri);
        }

        public async Task<IEnumerable<Escolaridade>> Where(Expression<Func<Escolaridade, bool>> predicate)
        {
            return await escolaridaderepository.Where(predicate);
        }
    }
}