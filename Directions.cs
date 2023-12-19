﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboToyTable
{
    public static class Directions
    {
        public const string North = "NORTH";
        public const string East = "EAST";
        public const string South = "SOUTH";
        public const string West = "WEST";

        private static readonly LinkedList<string> _directions
            = new LinkedList<string>(new[] { North, East, South, West });

        public static bool IsValidDirection(this string direction)
            => _directions.Contains(direction);

        public static string RotateLeft(this string direction)
        {
            var current = _directions.Find(direction);

            if (current == null)
                return null;

            return (current.Previous ?? _directions.Last).Value;
        }

        public static string RotateRight(this string direction)
        {
            var current = _directions.Find(direction);

            if (current == null)
                return null;

            return (current.Next ?? _directions.First).Value;
        }
    }
}
