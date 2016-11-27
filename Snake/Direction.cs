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

        public Direction(Key k) : this(fromKey(k)) {

        }

        private static int fromKey(Key s) {
            switch (s) {
                case Key.Up:
                    return UP.ordinal;
                case Key.Down:
                    return DOWN.ordinal;
                case Key.Left:
                    return LEFT.ordinal;
                case Key.Right:
                    return RIGHT.ordinal;
                default:
                    return DEFAULT_DIRECTION.ordinal;
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
