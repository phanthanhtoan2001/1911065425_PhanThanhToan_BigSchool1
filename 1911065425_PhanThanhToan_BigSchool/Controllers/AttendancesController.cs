using _1911065425_PhanThanhToan_BigSchool.DTOs;
using _1911065425_PhanThanhToan_BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1911065425_PhanThanhToan_BigSchool.Controllers
{
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend ([FromBody ] int courseID)
        {
            
            var attendance = new Attendance
            
            {
                CourseId = courseID,
                AttendeeId = User.Identity.GetUserId()
            };
            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();
            return Ok();
        }
        
        
        
    }
}
