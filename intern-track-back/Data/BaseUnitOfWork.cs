using System;
using System.Collections.Generic;
using System.Linq;
using intern_track_back.Models;

namespace intern_track_back.Data
{
    public abstract class BaseUnitOfWork : IDisposable
    {
        protected readonly ApplicationDbContext Context;
        
        public ApplicationDbContext GetContext() => Context;
        
        protected BaseUnitOfWork(ApplicationDbContext db)
        {
              Context = db;
        }
        
        protected BaseUnitOfWork()
        {
            throw new NotSupportedException();
        }

        public readonly IDictionary<Type, object> Registry = new Dictionary<Type, object>();

        /// <summary>
        /// Закешированные специальным образом объекты.
        /// Например, здесь хранится текущий пользователь.
        /// </summary>
        public readonly Dictionary<string, object> Dictionary = new Dictionary<string, object>();
        
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        public TRepository GetRepository<TRepository, TEntity>()
            where TEntity : BaseEntity, new()
            where TRepository : GenericRepository<TEntity>
        {
            var type = typeof(TRepository);
            if (!Registry.ContainsKey(type))
            {
                Registry.Add(type, Activator.CreateInstance(typeof(TRepository), Context, this));
            }
            return Registry[type] as TRepository;
        }
        
        #region Репозитории

        public IQueryable<ApplicationUser> IdentityUsers => Context.Users;
        
        public GenericRepository<User> UserRepository =>
            GetRepository<GenericRepository<User>, User>();
        
        public GenericRepository<Announcement> AnnouncementRepository =>
            GetRepository<GenericRepository<Announcement>, Announcement>();
        
        public GenericRepository<Chat> ChatRepository =>
            GetRepository<GenericRepository<Chat>, Chat>();
        
        public GenericRepository<Company> CompanyRepository =>
            GetRepository<GenericRepository<Company>, Company>();
        
        public GenericRepository<Contact> ContactRepository =>
            GetRepository<GenericRepository<Contact>, Contact>();
        
        public GenericRepository<Curator> CuratorRepository =>
            GetRepository<GenericRepository<Curator>, Curator>();
        
        public GenericRepository<Deanery> DeaneryRepository =>
            GetRepository<GenericRepository<Deanery>, Deanery>();
        
        public GenericRepository<Grade> GradeRepository =>
            GetRepository<GenericRepository<Grade>, Grade>();
        
        public GenericRepository<Interview> InterviewRepository =>
            GetRepository<GenericRepository<Interview>, Interview>();
        
        public GenericRepository<Message> MessageRepository =>
            GetRepository<GenericRepository<Message>, Message>();
        
        public GenericRepository<Note> NoteRepository =>
            GetRepository<GenericRepository<Note>, Note>();
        
        public GenericRepository<Project> ProjectRepository =>
            GetRepository<GenericRepository<Project>, Project>();
        
        public GenericRepository<Resume> ResumeRepository =>
            GetRepository<GenericRepository<Resume>, Resume>();

        public GenericRepository<StackForInterviewPlan> StackForInterviewPlans =>
            GetRepository<GenericRepository<StackForInterviewPlan>, StackForInterviewPlan>();
        
        public GenericRepository<Student> StudentRepository =>
            GetRepository<GenericRepository<Student>, Student>();
        
        public GenericRepository<StudentPlanForInterview> StudentPlanForInterviews =>
            GetRepository<GenericRepository<StudentPlanForInterview>, StudentPlanForInterview>();
        
        public GenericRepository<UserChat> UserChatRepository =>
            GetRepository<GenericRepository<UserChat>, UserChat>();
        
        public GenericRepository<Vacancy> VacancyRepository =>
            GetRepository<GenericRepository<Vacancy>, Vacancy>();
        
        #endregion
    }
}