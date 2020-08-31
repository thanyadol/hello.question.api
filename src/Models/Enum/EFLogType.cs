using System;

using System.ComponentModel;

namespace hello.question.api.Models
{
    // Add the attribute Flags or FlagsAttribute.
    [Flags]
    public enum EFLogType
    {

        [Description("REQUEST")]
        REQUEST,


        [Description("EXCEPTION")]
        EXCEPTION,


        [Description("MIDDLEWARE")]
        MIDDLEWARE,

    }
}