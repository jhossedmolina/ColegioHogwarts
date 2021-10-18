﻿using ColegioHogwarts.Core.Enumerations;

namespace ColegioHogwarts.Core.Entities
{
    public class Security : BaseEntity
    {
        public string User { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public RoleType Role { get; set; } 
    }
}
