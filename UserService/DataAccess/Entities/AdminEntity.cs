using System.ComponentModel.DataAnnotations;

namespace UserService.DataAccess.Entities
{
    public class AdminEntity
    {
        [Key]
        public Guid AdminId { get; set; }

        public string Name { get; set; }

        public string Surename { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}