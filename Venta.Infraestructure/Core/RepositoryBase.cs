using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Venta.Domain.Core;
using Venta.Infraestructure.Context;

namespace Venta.Infraestructure.Core
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        // Atributos
        private readonly VentaContext _context;
        private readonly DbSet<TEntity> _entities;

        // Constructor
        public RepositoryBase(VentaContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        // Metodos
        public async virtual Task Save(TEntity entity)
        {
            _entities.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async virtual Task Delete(TEntity entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async virtual Task<bool> Exists(Expression<Func<TEntity, bool>> filter)
        {
            return await _entities.AnyAsync(filter);
        }

        public async virtual Task<List<TEntity>> Get()
        {
            return await _entities.ToListAsync();
        }

        public async virtual Task<TEntity> GetByID(int entityID)
        {
            return await _entities.FindAsync(entityID);
        }

        public async virtual Task Update(TEntity entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }







    }
}
