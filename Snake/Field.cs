using System;

namespace Snake {
    public class Field {
        public int width { get; private set; }
        public int height { get; private set; }

        Snake snake { get; set; }
        public Coordinate apple { get; private set; }
        internal Random seed;

        public Field(int width, int height, Snake snake) {
            this.width = width;
            this.height = height;
            this.snake = snake;
            seed = new Random();
        }

        private void MakeApple() {
            do {
                Coordinate c = new Coordinate(seed.Next(width), seed.Next(height));
            } while (false);
        }
    }
}
