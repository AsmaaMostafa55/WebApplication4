﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.Entities
{
    public class ApplicationUsercs :IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
           public bool IsActive {  get; set; }
    }
}
