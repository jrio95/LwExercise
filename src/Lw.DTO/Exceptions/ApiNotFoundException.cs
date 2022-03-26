using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw.DTO.Exceptions
{
    public class ApiNotFoundException : Exception
    {   
        public ApiNotFoundException(string message) : base(message)
        {

        }
    }
}
