using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using hello.question.api.Models;

namespace hello.question.api.Exceptions
{
    public class AnswerNotFoundException : Exception
    {

        private const string DEFAULT_MESSAGE = "AnswerNotFoundException";
        public string rev { get; }
        public string value { get; }

        public AnswerNotFoundException()
           : base(DEFAULT_MESSAGE)
        {
        }

        public AnswerNotFoundException(Guid id)
            : base(string.Format("Answer with id = {0} not found", id))
        {
        }

        public AnswerNotFoundException(string message, Answer answer)
            : base(message)
        {
        }

        public AnswerNotFoundException(string message, Exception inner)
       : base(message, inner)
        {
        }

    }

    public class AnswerNotCreatedException : Exception
    {

        private const string DEFAULT_MESSAGE = "AnswerNotCreatedException";

        public AnswerNotCreatedException()
           : base(DEFAULT_MESSAGE)
        {
        }
    }
}