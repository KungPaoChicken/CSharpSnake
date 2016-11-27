using System;
using System.Windows.Input;

namespace Snake {
    public class Direction : IEquatable<Direction> {
        public static readonly Direction UP = new Direction(1);
        public static readonly Direction DOWN = new Direction(-1);
        public static readonly Direction LEFT = new Direction(2);
        public static readonly Direction RIGHT = new Direction(-2);
        public static readonly Direction DEFAULT_DIRECTION = RIGHT;

        private readonly int ordinal;

        private Direction(int ord) {
            ordinal = ord;
        }

        public static Direction fromKey(Key s) {
            switch (s) {
                case Key.Up:
                    return UP;
                case Key.Down:
                    return DOWN;
                case Key.Left:
                    return LEFT;
                case Key.Right:
                    return RIGHT;
                default:
                    return DEFAULT_DIRECTION;
            }
        }

        public bool isOpposite(Direction d) {
            return ordinal + d.ordinal == 0;
        }

        public bool Equals(Direction other) {
            return ordinal == other.ordinal;
        }
    }
}
