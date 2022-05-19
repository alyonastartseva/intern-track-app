using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using intern_track_back.Models;
using Microsoft.EntityFrameworkCore;

namespace intern_track_back.Data
{
    /// <summary>
    /// Репозиторий, работает с изменениями сущностей (crud)
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    public class GenericRepository<TEntity> : IQueryable<TEntity>
        where TEntity : BaseEntity, new()
    {
        protected GenericRepository()
        {
        }

        protected ApplicationDbContext Context { get; }
        protected DbSet<TEntity> DbSet { get; }
        protected BaseUnitOfWork UnitOfWork { get; set; }

        public GenericRepository(ApplicationDbContext context, BaseUnitOfWork unitOfWork)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
            UnitOfWork = unitOfWork;
        }
        
        public virtual TEntity CreateNew()
        {
            var now = DateTime.UtcNow;

            var entity = new TEntity();
            entity.CreateDateTime = entity.ModifyDateTime = now;

            DbSet.Add(entity);
            return entity;
        }

        public virtual TEntity? Find(int? id)
        {
            if (id == null)
            {
                return null;
            }
            
            return DbSet.Find(id);
        }
        
        public async Task<TEntity?> FindAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }
        
        public async Task<TEntity?> FindAsync(int? id)
        {
            if (id.HasValue)
            {
                return await FindAsync(id.Value);
            }
            return null;
        }

        /// <summary>
        /// Удалить элемент из базы
        /// </summary>
        /// <param name="entity">Удаляемая сущность</param>
        public virtual void Remove(TEntity entity)
        {
            UnitOfWork.GetContext().Remove(entity);
        }

        /// <summary>
        /// Удалить коллекцию сущностей элементов из базы
        /// </summary>
        /// <param name="entities">Удаляемые сущности</param>
        /// <returns>Удалённые сущности</returns>
        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            // Копируем перечисление элементов.
            // Есть вероятность, что после удаления одного элемента исходное перечисление изменится, и ForEach выкинет исключение.
            // Поэтому мы сначала копируем всё перечисление в отдельный независимый массив, и только после этого их удаляем по одному.
            var removing = entities.ToArray();

            foreach (var entity in removing)
            {
                Remove(entity);
            }
        }

        /// <summary>
        /// Добавить элемент в базу
        /// </summary>
        /// <param name="entity">Добавляемая сущность</param>
        public virtual void Add(TEntity entity)
        {
            UnitOfWork.GetContext().Add(entity);
        }

        /// <summary>
        /// Добавить коллекцию сущностей элементов в базу
        /// </summary>
        /// <param name="entities">Добавляемые сущности</param>
        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        private IQueryable<TEntity> Queryable => DbSet;

        public IEnumerator<TEntity> GetEnumerator()
        {
            return Queryable.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Queryable.GetEnumerator();
        }

        public Expression Expression => Queryable.Expression;

        public Type ElementType => Queryable.ElementType;

        public IQueryProvider Provider => Queryable.Provider;
    }
}