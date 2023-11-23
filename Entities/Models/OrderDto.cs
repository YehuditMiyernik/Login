using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class OrderDto : Profile
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public int OrderSum { get; set; }

        public int UserId { get; set; }
    }
}
