using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Exceptions
{
    public class NotFoundException : Exception //veri yok
    { 
        public NotFoundException(string message): base (message){ }

    }
}
