using System;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using intern_track_back.Models;
using Microsoft.EntityFrameworkCore;

namespace intern_track_back.Data
{
    public class UnitOfWork : BaseUnitOfWork
    {
        public UnitOfWork()
        {
            throw new NotSupportedException();
        }

        public UnitOfWork(ApplicationDbContext db) : base(db)
        {
        }

        public int Save()
        {
            OnSave();
            var res = Context.SaveChanges();
            OnSuccessSave?.Invoke();
            return res;
        }

        public async Task<int> SaveAsync()
        {
            OnSave();
            var res = await Context.SaveChangesAsync();
            OnSuccessSave?.Invoke();
            return res;
        }

        /// <summary>
        /// Событие, которое происходит после успешного сохранения данных в БД.
        /// Однако, если сохранение происходило внутри транзакции, то эти данные ещё не зафиксированы в БД.
        /// </summary>
        /// <seealso cref="DbTransaction.OnSuccessCommit"/>
        /// <seealso cref="DbTransaction.OnBeforeCommit"/>
        public event Action? OnSuccessSave;

        private void OnSave()
        {
            Context.ChangeTracker.AutoDetectChangesEnabled = true;
            UpdateModifyDateTime();
        }

        private void UpdateModifyDateTime()
        {
            var entityEntries = Context.ChangeTracker.Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Modified);

            foreach (var entity in entityEntries)
            {
                entity.Entity.UpdateModifiedTimestamp();
            }
        }
    }
}