﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Course : EntityBase<Course>
    {
        public string Name { get; set; }
        //public List<GroupCourse> GroupCourses { get; set; }
    }
}