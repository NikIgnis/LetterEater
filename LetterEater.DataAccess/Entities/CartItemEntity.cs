using LetterEater.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.DataAccess.Entities
{
    public class CartItemEntity
    {
        public Guid CartItemId { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public BookEntity Book { get; set; }
        public UserEntity User { get; set; }
     }
}
