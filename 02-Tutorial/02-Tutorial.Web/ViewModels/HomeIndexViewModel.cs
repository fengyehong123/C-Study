using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_Tutorial.Web.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<StudentViewModel> Students { get; set; }
    }
}
