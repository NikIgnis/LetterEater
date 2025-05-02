using LetterEater.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.DataAccess.Entities
{
    public class OrderEntity
    {
        [Key]
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Guid>? OrderItemsId { get; set; } = new List<Guid>();

        //Dependencies
        public List<OrderItemEntity> OrderItems { get; set; }
        public UserEntity User { get; set; }
    }
}