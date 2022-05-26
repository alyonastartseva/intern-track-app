using System;
using Microsoft.AspNetCore.Mvc;

namespace intern_track_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InterviewController : BaseController
    {
        public InterviewController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}