﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01_Tutorial.Web.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<StudentViewModel> Students { get; set; }
    }
}
