﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoService.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public string test()
        {
            DAL.DalConfiguration d = new DAL.DalConfiguration();
            return d.sqlConnectionString;
        }
    }
}