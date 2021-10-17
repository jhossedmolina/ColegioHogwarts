using System;
using System.Collections.Generic;
using System.Text;

namespace ColegioHogwarts.Core.Exceptions
{
    public class CandidateException : Exception
    {
        public CandidateException()
        {
        }

        public CandidateException(string message) : base(message)
        {
        }
    }
}
