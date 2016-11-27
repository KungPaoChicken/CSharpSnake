namespace Snake {
    public class Snek : CoordinateList {
        public Direction direction { get; private set; }

        public Snek(int maxLength) : base(maxLength) {
            direction = Direction.DEFAULT_DIRECTION;
        }

        public Snek(int maxLength, Direction direction) : base(maxLength) {
            this.direction = direction;
        }

        public void updateHead(Coordinate newHead) {
            shift(0, 1, base.length - 1);
            set(0, newHead);
        }

        public void grow(Coordinate position) {
            add(new Coordinate(position.x, position.y));
        }
    }
}
