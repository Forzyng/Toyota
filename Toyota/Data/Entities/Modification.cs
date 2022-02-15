using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Toyota.Data.Entities
{
    public class Modification
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Slug { get; set; }
        [Display(Name = "Навание модификации")]
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public Model Model { get; set; }
        public Guid ModelId { get; set; }
        public List<ModificationColors> ModificationColors { get; set; }
    }
}
