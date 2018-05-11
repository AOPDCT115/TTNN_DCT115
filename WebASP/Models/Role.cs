using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebASP.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        [StringLength(50)]
        public string ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public virtual ICollection<Credential> Credential { get; set; }
    }
}
