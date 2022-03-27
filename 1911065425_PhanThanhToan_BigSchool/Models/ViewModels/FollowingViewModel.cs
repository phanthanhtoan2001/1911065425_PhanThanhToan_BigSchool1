using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1911065425_PhanThanhToan_BigSchool.Models.ViewModels
{
    public class FollowingViewModel
    {
        public IEnumerable<ApplicationUser> Followings { get; set; }
        public bool ShowAction { get; set; }
    }
}