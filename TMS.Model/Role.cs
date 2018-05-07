namespace TMS.Model
{
    public class Role
    {
        public Role()
        {
        }

        public Role(int id, string roleName)
        {
            this.Id = id;
            this.RoleName = roleName;
        }

        public int Id { get; set; }

        public string RoleName { get; set; }
    }
}