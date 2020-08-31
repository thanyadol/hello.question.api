using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using hello.question.api.Models;

namespace hello.question.api.Exceptions
{
    public class SubQuestionNotFoundException : Exception
    {

        private const string DEFAULT_MESSAGE = "SubQuestionNotFoundException";
        public string rev { get; }
        public string value { get; }

        public SubQuestionNotFoundException()
           : base(DEFAULT_MESSAGE)
        {
        }

        public SubQuestionNotFoundException(Guid id)
            : base(string.Format("SubQuestion with id = {0} not found", id))
        {
        }

        public SubQuestionNotFoundException(string message, SubQuestion subquestion)
            : base(message)
        {
        }

        public SubQuestionNotFoundException(string message, Exception inner)
       : base(message, inner)
        {
        }

    }

    public class SubQuestionNotCreatedException : Exception
    {

        private const string DEFAULT_MESSAGE = "SubQuestionNotCreatedException";

        public SubQuestionNotCreatedException()
           : base(DEFAULT_MESSAGE)
        {
        }
    }
}