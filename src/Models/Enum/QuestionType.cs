using System;

using System.ComponentModel;

namespace hello.question.api.Models
{
    // Add the attribute Flags or FlagsAttribute.
    [Flags]
    public enum QuestionType
    {

        [Description("WRITTEN")]
        WRITTEN,


        [Description("CHOISE")]
        CHOISE,
    }
}