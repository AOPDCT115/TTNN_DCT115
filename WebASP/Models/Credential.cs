using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebASP.Models
{
    [Table("Credential")]
    [Serializable]
    public class Credential
    {
        [Key]
        [StringLength(20)]
        public string UserGroupID { set; get; }

        [StringLength(50)]
        public string RoleID { set; get; }

        public virtual UserGroup UserGroup { get; set; }
        public virtual Role Role { get; set; }
    }
}
