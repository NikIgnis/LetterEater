using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.DataAccess.Entities
{
    public class AdminEntity
    {
        public AdminEntity(Guid adminId, string name, string surename, string contactNumber, string email, string password)
        {
            AdminId = adminId;
            Name = name;
            Surename = surename;
            ContactNumber = contactNumber;
            Email = email;
            Password = password;
        }
        //Guid
        public Guid AdminId { get; set; }

        public string Name { get; set; }

        public string Surename { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}