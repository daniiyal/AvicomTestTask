using AvicomTestTask.DAL.Entities.Base;
using System.Collections.Generic;

namespace AvicomTestTask.DAL.Entities
{
    public class Client : NamedEntity
    {
        public Manager Manager { get; set; }
        
        public Status Status { get; set; }

    }
}
