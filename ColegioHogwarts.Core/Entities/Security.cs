using ColegioHogwarts.Core.Enumerations;

namespace ColegioHogwarts.Core.Entities
{
    public class Security
    {
        public string UserSecurity { get; set; }
        public string UserName { get; set; }
        public string PasswordUser { get; set; }
        public RoleType RoleUser { get; set; } 
    }
}
