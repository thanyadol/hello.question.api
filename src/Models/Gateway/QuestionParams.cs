using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hello.question.api.Models.Gateway
{
    public class QuestionParams
    {
        public Guid Id { get; set; }


        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
        public int Order { get; set; }


        public string By { get; set; }

        public Nullable<DateTime> Date { get; set; }

        public List<SubQuestion> SubQuestions { get; set; }


    }
}