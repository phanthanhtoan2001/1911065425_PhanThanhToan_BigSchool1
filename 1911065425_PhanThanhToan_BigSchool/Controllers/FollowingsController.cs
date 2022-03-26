using _1911065425_PhanThanhToan_BigSchool.DTOs;
using _1911065425_PhanThanhToan_BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace _1911065425_PhanThanhToan_BigSchool.Controllers
{
    public class FollowingsController : Controller
    {
        // GET: Followings
        private readonly ApplicationDbContext _dbContext;
        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext(); 
        }
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FolloweeId == userId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Following already exists!");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
            };



            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();
            return Ok();
        }

        private IHttpActionResult BadRequest(string v)
        {
            throw new NotImplementedException();
        }

        private IHttpActionResult Ok()
        {
            throw new NotImplementedException();
        }
    }
}