﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MoneyBankers.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal BankBalance { get; set; }
        public string IPAddress { get; set; }
        public int Age { get; set; }
    }

}
