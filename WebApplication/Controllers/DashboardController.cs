﻿using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using HelpToTeach.Core.Repository;
using HelpToTeach.Data.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ICourseRepository courseRepository;
        private readonly IGroupRepository groupRepository;
        private readonly IStudentRepository studentRepository;
        

        public DashboardController(ICourseRepository courseRepository, 
            IGroupRepository groupRepository, 
            IStudentRepository studentRepository)
        {
            this.courseRepository = courseRepository;
            this.groupRepository = groupRepository;
            this.studentRepository = studentRepository;
            

            

        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        #region Course
        public async Task<IActionResult> Courses()
        {
            IEnumerable<Course> courses;
            var id = User.FindFirst(ClaimTypes.Sid).Value;
            if (!(User.FindFirst(ClaimTypes.Role).Value == "Lecturer"))
            {
                courses = await courseRepository.GetAll();
            }
            else
            {
                courses = await courseRepository.GetByLecturer(id);
            }            
            return View(new CoursesViewModel { Courses = courses});
        }

        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse([FromForm] string name)
        {
            var course = await this.courseRepository.Create(new Course { Name = name });
            return RedirectToAction("Courses");
        }
        #endregion

        #region Group

        public async Task<IActionResult> Groups()
        {
            IEnumerable<Group> groups;
            var id = User.FindFirst(ClaimTypes.Sid).Value;
            if (!(User.FindFirst(ClaimTypes.Role).Value == "Lecturer"))
            {
                groups = await groupRepository.GetAll();
            }
            else {
                groups = await groupRepository.GetByLecturer(id);
            }

            return View(new GroupsViewModel { Groups = groups });
        }

        public IActionResult AddGroup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGroup([FromForm] string name)
        {
            var group = await this.groupRepository.Create(new Group { Name = name });
            return RedirectToAction("Groups");
        }
        #endregion

        #region Students
        public async Task<IActionResult> Students()
        {
            IEnumerable<Student> students;
            var id = User.FindFirst(ClaimTypes.Sid).Value;
            if (!(User.FindFirst(ClaimTypes.Role).Value == "Lecturer"))
            {
                students = await studentRepository.GetAll();
            }
            else
            {
                students = await studentRepository.GetByLecturer(id);
            }
            return View(new StudentsViewModel { Students = students });
        }

        public async Task<IActionResult> AddStudent()
        {
            var groups = await this.groupRepository.GetAll();
            return View(new AddStudentViewModel { Groups = groups, Student = new Student() });
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromForm] Student student)
        {
            var _student = await this.studentRepository.Create(student);
            return RedirectToAction("Students");
        }

        #endregion  

        public IActionResult Assign([FromQuery] string GroupId)
        {
            if (string.IsNullOrWhiteSpace(GroupId))
            {
                throw new System.ArgumentException("message", nameof(GroupId));
            }

            return View();
        }
    }
}