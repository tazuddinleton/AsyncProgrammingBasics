using System;
using System.Collections.Generic;
using System.Text;

namespace AsynchrounousProgrammingBasics.UsingAsyncAwait
{
    public class TimeoutException : Exception
    {
        public TimeoutException(string msg) : base(msg) { }
    }
}
