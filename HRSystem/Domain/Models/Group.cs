

namespace Domain.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
        public ICollection<Permissions> Permissions { get; set; }
    }
}
