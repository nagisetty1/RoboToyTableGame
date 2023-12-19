using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboToyTable
{
    public interface IRoboToy
    {
        int? X { get; }
        int? Y { get; }
        string Facing { get; }

        void ExecutePlaceCommand(int x, int y, string direction);
        void ExecuteMoveCommand();
        void ExecuteRotateLeftCommand();
        void ExecuteRotateRightCommand();
        string? ExecuteReportCommand();
    }
}
