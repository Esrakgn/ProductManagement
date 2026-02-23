using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Exceptions
{
    public class BusinessException : Exception   // iş kuralı ihlali bu sayfada görünür 
    {                            // inheritance 
        public BusinessException(string message ): base (message) { }
    }
}
