using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models
{
    public class Admin
    {
        public const int MAX_LENGTH_NAME_SURENAME = 50;
        public const int MAX_LENGTH_PASSWORD = 50;

        public Admin(Guid adminId, string name, string surename, string contactNumber, string email, string password)
        {
            AdminId = adminId;
            Name = name;
            Surename = surename;
            ContactNumber = contactNumber;
            Email = email;
            Password = password;
        }

        public Guid AdminId { get; }

        public string Name { get; }

        public string Surename { get; }

        public string ContactNumber { get; }

        public string Email { get; }

        public string Password { get; }
    }
}
