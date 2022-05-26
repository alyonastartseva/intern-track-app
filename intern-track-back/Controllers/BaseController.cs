using System;
using intern_track_back.Data;
using intern_track_back.Models;
using intern_track_back.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace intern_track_back.Controllers
{
    /// <summary>
    /// Базовый контроллер, от него должны быть отнаследованы все Api контроллеры
    /// Предоставляет доступ к редактировунию данных и текущему пользователю
    /// </summary>
    public class BaseController : Controller
    {
        protected readonly UnitOfWork UnitOfWork;
        protected readonly ICurrentUserService CurrentUserService;
        
        protected User Current { get; set; }
        
        protected BaseController(IServiceProvider serviceProvider)
        {
            CurrentUserService = serviceProvider.GetRequiredService<ICurrentUserService>();
            UnitOfWork = serviceProvider.GetRequiredService<UnitOfWork>();
            Current = CurrentUserService.GetCurrent();
        }
    }
}