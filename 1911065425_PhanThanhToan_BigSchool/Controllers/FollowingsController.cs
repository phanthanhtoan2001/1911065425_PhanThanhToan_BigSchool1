using _1911065425_PhanThanhToan_BigSchool.DTOs;
using _1911065425_PhanThanhToan_BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace _1911065425_PhanThanhToan_BigSchool.Controllers
{
    [Authorize]
    public class FollowingsController : ApiController
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

            following = _dbContext.Followings
                .Where(x => x.FolloweeId == followingDto.FolloweeId && x.FollowerId == userId)
                .Include(x => x.Followee)
                .Include(x => x.Follower).SingleOrDefault();

            return Ok();
        }
       
       


    }
}