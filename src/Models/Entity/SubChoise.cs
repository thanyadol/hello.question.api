using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hello.question.api.Models
{
    public class SubChoise
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Choise")]
        public Guid ChoiseId { get; set; }


        [StringLength(500)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }


        public int Order { get; set; }
        public bool AllowSelect { get; set; }


    }
}