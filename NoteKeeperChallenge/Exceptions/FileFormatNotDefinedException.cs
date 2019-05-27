using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteKeeperChallenge.Exceptions
{
    public class FileFormatNotDefinedException : Exception
    {
        public FileFormatNotDefinedException(string message): base(message)
        {
        }
    }
}
