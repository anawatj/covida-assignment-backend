using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Error
{
    public class FieldValueException : Exception
    {
        public FieldValueException(string message) : base(message)
        {

        }

       
    }
}
