using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboToyTable
{
    public class RoboToy : IRoboToy
    {
        private readonly int _maxX;
        private readonly int _maxY;

        public RoboToy(int maxX = 5, int maxY = 5)
        {
            _maxX = maxX;
            _maxY = maxY;
        }

        public int? X { get; private set; }
        public int? Y { get; private set; }
        public string Facing { get; private set; }

        public virtual void ExecutePlaceCommand(int x, int y, string direction)
        {
            if (IsValidCheck(x, y, direction))
            {
                X = x;
                Y = y;
                Facing = direction;
            }
        }

        public virtual void ExecuteMoveCommand()
        {
            if (Facing == Directions.North && IsValidCheck(X, Y + 1, Facing)) Y += 1;
            if (Facing == Directions.East && IsValidCheck(X + 1, Y, Facing)) X += 1;
            if (Facing == Directions.South && IsValidCheck(X, Y - 1, Facing)) Y -= 1;
            if (Facing == Directions.West && IsValidCheck(X - 1, Y, Facing)) X -= 1;
        }

        public virtual void ExecuteRotateLeftCommand()
        {
            Facing = Facing.IsValid() ? Facing.RotateLeft() : null;
        }

        public virtual void ExecuteRotateRightCommand()
        {
            Facing = Facing.IsValid() ? Facing.RotateRight() : null;
        }

        public virtual string? ExecuteReportCommand()
        { 
            return IsValidCheck(X, Y, Facing) ? $"{X},{Y},{Facing}" : null; 
        }

        private bool IsValidCheck(int? x, int? y, string direction)
        {
            var xIsValid = x >= 0 && x < _maxX;
            var yIsValid = y >= 0 && y < _maxY;
            return xIsValid && yIsValid && direction.IsValid();
        }
    }
}
