using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoreproject.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int BannerCount { get; set; }
        public int CategoryCount { get; set; }
        public int StudentCount { get; set; }
        public int GroupCount { get; set; }

    }
}
