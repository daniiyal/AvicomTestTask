using AvicomTestTask.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvicomTestTask.DAL.Entities
{
    public class Order : Entity
    {
        public Client Client { get; set; }
        public Product Product { get; set; }
    }
}
