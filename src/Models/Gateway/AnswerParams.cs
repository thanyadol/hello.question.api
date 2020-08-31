using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hello.question.api.Models
{
    public class AnswerParams
    {
           public Guid Id { get; set; }

        public Guid ParticipantId { get; set; }

        public Guid QuestionId { get; set; }
        public Guid SubQuestionId { get; set; }
        public string QuestionTitle { get; set; }


        public Guid AnswerId { get; set; }

        public Guid ChoiseId { get; set; }


        public string SubQuestionValue { get; set; }
        
        public string SubQuestionType { get; set; }

        public int SubQuestionOrder { get; set; }


        public Guid AnswerValue { get; set; }


        public string AnswerText { get; set; }


        [Column(TypeName = "datetime")]
        public Nullable<DateTime> AnswerDate { get; set; }


        public List<Answer> Answers { get; set; }


    }
}