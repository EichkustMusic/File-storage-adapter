using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStorageAdapter.Adapter.Exceptions
{
    public class UnableToLocateProject(string message) : Exception(message)
    {
    }
}
