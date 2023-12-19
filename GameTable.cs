using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RoboToyTable
{
    public class GameTable
    {
        private static readonly Regex _placeCommand = new Regex(@"PLACE (\d+),(\d+),(\w+)");

        private readonly RoboToy robotoy;

        public GameTable(RoboToy _robotoy)
        {
            robotoy = _robotoy;
        }

        public void ProcessCommand(string commandText)
        {
            if (string.IsNullOrWhiteSpace(commandText))
                return;

            if (commandText == Commands.MoveCommandText) robotoy.ExecuteMoveCommand();
            if (commandText == Commands.LeftCommandText) robotoy.ExecuteRotateLeftCommand();
            if (commandText == Commands.RightCommandText) robotoy.ExecuteRotateRightCommand();
            if (commandText == Commands.ReportCommandText) Console.WriteLine(robotoy.ExecuteReportCommand());

            var match = _placeCommand.Match(commandText);
            if (match.Success)
            {
                var xIsValid = int.TryParse(match.Groups[1].Value, out var x);
                var yIsValid = int.TryParse(match.Groups[2].Value, out var y);
                var direction = match.Groups[3].Value;
                if (xIsValid && yIsValid)
                {
                    robotoy.ExecutePlaceCommand(x, y, direction);
                }
            }
        }
    }
}
