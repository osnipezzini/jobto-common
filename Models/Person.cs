using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobTo.Common.Models
{
    public class Person
    {
        [Key]
        public long Grid { get; set; }
        public string Doc { get; set; }
        public int? Code { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
        public string Type { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public virtual IEnumerable<User> Users { get; set; }

    }
}
