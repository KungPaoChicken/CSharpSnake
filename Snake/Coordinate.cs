namespace Snake {
    public class Coordinate {
        public int x { get; private set; }
        public int y { get; private set; }

        public Coordinate(int x, int y) {
            set(x, y);
        }

        private void set(int x, int y) {
            this.x = x;
            this.y = y;
        }

    }
}
