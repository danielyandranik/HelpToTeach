﻿using HelpToTeach.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpToTeach.Data.Models
{
    class Lesson : EntityBase<Lesson>
    {
        public LessonType LessonType { get; set; }
        public DateTime Date { get; set; }
        public string GroupCourseId { get; set; }
    }
}