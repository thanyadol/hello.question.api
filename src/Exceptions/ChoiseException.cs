using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using hello.question.api.Models;

namespace hello.question.api.Exceptions
{
    public class ChoiseNotFoundException : Exception
    {

        private const string DEFAULT_MESSAGE = "ChoiseNotFoundException";
        public string rev { get; }
        public string value { get; }

        public ChoiseNotFoundException()
           : base(DEFAULT_MESSAGE)
        {
        }

        public ChoiseNotFoundException(Guid id)
            : base(string.Format("Choise with id = {0} not found", id))
        {
        }

        public ChoiseNotFoundException(string message, Choise choise)
            : base(message)
        {
        }

        public ChoiseNotFoundException(string message, Exception inner)
       : base(message, inner)
        {
        }

    }

    public class ChoiseNotCreatedException : Exception
    {

        private const string DEFAULT_MESSAGE = "ChoiseNotCreatedException";

        public ChoiseNotCreatedException()
           : base(DEFAULT_MESSAGE)
        {
        }
    }
}