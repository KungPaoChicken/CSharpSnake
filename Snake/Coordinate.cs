using System;

namespace Snake {
    public class Coordinate : IEquatable<Coordinate> {
        public int x { get; private set; }
        public int y { get; private set; }

        public Coordinate(int x, int y) {
            set(x, y);
        }

        private void set(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public bool Equals(Coordinate other) {
            return x == other.x && y == other.y;
        }
    }
}
