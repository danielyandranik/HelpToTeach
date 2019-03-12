﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Repository
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAll();
        Task<Course> Get(string id);
        Task<IEnumerable<Course>> GetByLecturer(string id);
        Task<Course> Create(Course course);
        Task<Course> Update(Course course);
        Task<Course> Upsert(Course course);
        Task Delete(string id);
    }
}
