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
        public Guid Id { get; set; }

        public Guid ParticipantId { get; set; }

        public List<Answer> Answers { get; set; }


        public Guid SessionId { get; set; }

        public Nullable<DateTime> Date { get; set; }

    }
}