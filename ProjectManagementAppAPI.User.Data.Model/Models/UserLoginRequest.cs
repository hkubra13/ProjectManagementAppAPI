﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.User.Data.Model.Models
{
    public class UserLoginRequest
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}
