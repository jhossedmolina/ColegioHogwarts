namespace ColegioHogwarts.Core.Entities
{
    public class Security : BaseEntity
    {
        public string UserSecurity { get; set; }
        public string UserName { get; set; }
        public string PasswordUser { get; set; }
        public string RoleUser { get; set; } 
    }
}
