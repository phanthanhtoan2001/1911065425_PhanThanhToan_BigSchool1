using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1911065425_PhanThanhToan_BigSchool.Models.ViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable<Course> UpcommingCourses { get; set; }
        public IEnumerable<Following> Followings { get; set; }
        public IEnumerable<Attendance> Attendances { get; set; }
        public bool ShowAction { get; set; }
    }
}