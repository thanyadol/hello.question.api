using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using hello.question.api.Models;

namespace hello.question.api.Exceptions
{
    public class ParticipantNotFoundException : Exception
    {

        private const string DEFAULT_MESSAGE = "ParticipantNotFoundException";
        public string rev { get; }
        public string value { get; }

        public ParticipantNotFoundException()
           : base(DEFAULT_MESSAGE)
        {
        }

        public ParticipantNotFoundException(Guid id)
            : base(string.Format("Participant with id = {0} not found", id))
        {
        }

        public ParticipantNotFoundException(string message, Participant answer)
            : base(message)
        {
        }

        public ParticipantNotFoundException(string message, Exception inner)
       : base(message, inner)
        {
        }

    }

    public class ParticipantNotCreatedException : Exception
    {

        private const string DEFAULT_MESSAGE = "ParticipantNotCreatedException";

        public ParticipantNotCreatedException()
           : base(DEFAULT_MESSAGE)
        {
        }
    }
}