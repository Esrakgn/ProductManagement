using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Exceptions
{
   public class ValidationException : Exception // kullanıcı yanlış veri girdi
    {
        public ValidationException(string message ): base(message) { }
    }
}
