using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.exception
{
    public class DatabaseConnectionHandlingException : Exception
    {
        public DatabaseConnectionHandlingException(string message) : base(message)
        {
        }
    }
}
