using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public class HandlerExceptions : Exception
    {
        public HandlerExceptions(string message) : base(message)
        {
        }

    }
}
