﻿using Forum.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Model
{
    public class LoginModel : ILoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
