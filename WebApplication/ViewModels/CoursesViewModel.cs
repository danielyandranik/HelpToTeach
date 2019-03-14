﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.ViewModels;

namespace WebApplication.ViewModels
{
    public class CoursesViewModel : DashboradLayoutViewModel
    {
        public IEnumerable<Course> Courses { get; set; }
    }
}
