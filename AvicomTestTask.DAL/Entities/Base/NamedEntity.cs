using System.ComponentModel.DataAnnotations;

namespace AvicomTestTask.DAL.Entities.Base
{
    public class NamedEntity : Entity
    {
        [Required]
        public string Name { get; set; }
    }

}
