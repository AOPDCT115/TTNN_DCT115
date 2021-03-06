﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebASP.Models
{
    [Table("UserGroup")]
    public class UserGroup
    {
        [Key]
        [StringLength(20)]
        public string ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public virtual ICollection<Credential> Credential { get; set; }
    }
}
