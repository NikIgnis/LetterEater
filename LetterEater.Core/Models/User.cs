using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.Core.Models
{
    public class User
    {
        public const int MAX_LENGTH_NAME_SURENAME = 50;
        public const int MAX_LENGTH_LOGIN = 50;
        public const int MAX_LENGTH_PASSWORD = 50;

        public User(Guid userId, string name, string surename, string login, string contactNumber, string email, string password, List<Order> orders)
        {
            UserId = userId;
            Name = name;
            Surename = surename;
            Login = login;
            ContactNumber = contactNumber;
            Email = email;
            Password = password;
            Orders = orders;
        }

        public Guid UserId { get; }

        public string Name { get; }

        public string Surename { get; }

        public string Login { get; }

        public string ContactNumber { get; }

        public string Email { get; }

        public string Password { get; }

        public List<Order>? Orders { get; }

        public static User Create(Guid userId, string name, string surename, string login, string contactNumber, string email, string password, List<Order> orders)
        {
            return new User(userId, name, surename, login, contactNumber, email, password, orders);
        }
    }
}