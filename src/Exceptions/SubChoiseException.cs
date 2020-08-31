using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using hello.question.api.Models;

namespace hello.question.api.Exceptions
{
    public class SubChoiseNotFoundException : Exception
    {

        private const string DEFAULT_MESSAGE = "SubChoiseNotFoundException";
        public string rev { get; }
        public string value { get; }

        public SubChoiseNotFoundException()
           : base(DEFAULT_MESSAGE)
        {
        }

        public SubChoiseNotFoundException(Guid id)
            : base(string.Format("SubChoise with id = {0} not found", id))
        {
        }

        public SubChoiseNotFoundException(string message, SubChoise choise)
            : base(message)
        {
        }

        public SubChoiseNotFoundException(string message, Exception inner)
       : base(message, inner)
        {
        }

    }

    public class SubChoiseNotCreatedException : Exception
    {

        private const string DEFAULT_MESSAGE = "SubChoiseNotCreatedException";

        public SubChoiseNotCreatedException()
           : base(DEFAULT_MESSAGE)
        {
        }
    }
}