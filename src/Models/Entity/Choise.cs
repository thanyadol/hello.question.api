using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hello.question.api.Models
{
    public class Choise
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }


        [StringLength(20)]
        public string Status { get; set; }

        [StringLength(50)]
        public string By { get; set; }


        [Column(TypeName = "datetime")]
        public Nullable<DateTime> Date { get; set; }


    }
}