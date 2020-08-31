using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hello.question.api.Models
{
    public class SubQuestion
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Question")]
        public Guid QuestionId { get; set; }


        [ForeignKey("Choise")]
        public Guid ChoiseId { get; set; }


        [StringLength(500)]
        public string Value { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }


        [StringLength(20)]
        public string Status { get; set; }
        public int Order { get; set; }

        [StringLength(10)]
        public string Type { get; set; }

        [StringLength(50)]
        public string By { get; set; }


        [Column(TypeName = "datetime")]
        public Nullable<DateTime> Date { get; set; }

        [NotMapped]
        public List<Choise> Choises { get; set; }


        [NotMapped]
        public string QuestionTitle { get; set; }

    }
}