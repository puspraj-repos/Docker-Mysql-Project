using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using mysqlwebapp.Models;
using mysqlwebapp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace knighttestproject.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService _course_service;
        private readonly IConfiguration _configuration;

        public CourseController(CourseService _svc, IConfiguration _config)
        {
            _course_service = _svc;
            _configuration = _config;
        }
        public IActionResult Index()
        {
            IEnumerable<Course> _course_list = _course_service.GetCources();
            return View(_course_list);
        }
    }
}
