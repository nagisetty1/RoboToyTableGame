using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboToyTable
{
    public interface IGameTable
    {
        void ProcessCommand(string commandText);
    }
}
