using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Toyota.Data.Entities
{
    public class Model
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        List<Modification> Modifications { get; set; }
    }
}
