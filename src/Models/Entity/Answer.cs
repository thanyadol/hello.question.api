using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hello.question.api.Models
{
    public class Answer
    {
        [Key]
        public Guid Id { get; set; }


        [ForeignKey("Participant")]
        public Guid ParticipantId { get; set; }


        [ForeignKey("SubQuestion")]
        public Guid SubQuestionId { get; set; }


        public Guid Value { get; set; }


        [StringLength(1000)]
        public string Text { get; set; }


        [NotMapped]
        public Guid SessionId { get; set; }



        [Column(TypeName = "datetime")]
        public Nullable<DateTime> Date { get; set; }


    }
}