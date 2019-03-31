﻿using HelpToTeach.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpToTeach.Core.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> Get(string id);
        Task<IEnumerable<Student>> GetByLecturer(string id);
        Task<Student> Create(Student student);
        Task<Student> Update(Student student);
        Task<Student> Upsert(Student student);
        Task Delete(string id);
    }
}