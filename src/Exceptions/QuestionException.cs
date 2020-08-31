using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using hello.question.api.Models;

namespace hello.question.api.Exceptions
{
    public class QuestionNotFoundException : Exception
    {

        private const string DEFAULT_MESSAGE = "QuestionNotFoundException";
        public string rev { get; }
        public string value { get; }

        public QuestionNotFoundException()
           : base(DEFAULT_MESSAGE)
        {
        }

        public QuestionNotFoundException(Guid id)
            : base(string.Format("Question with id = {0} not found", id))
        {
        }

        public QuestionNotFoundException(string message, Question question)
            : base(message)
        {
        }

        public QuestionNotFoundException(string message, Exception inner)
       : base(message, inner)
        {
        }

    }

    public class QuestionNotCreatedException : Exception
    {

        private const string DEFAULT_MESSAGE = "QuestionNotCreatedException";

        public QuestionNotCreatedException()
           : base(DEFAULT_MESSAGE)
        {
        }
    }
}