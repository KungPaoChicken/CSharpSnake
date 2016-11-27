using System;

namespace Snake {
    public class Field {
        public int width { get; private set; }
        public int height { get; private set; }

        public Snek snake { get; set; }
        public Coordinate apple { get; protected set; }
        internal Random seed;

        public Field(int width, int height, Snek snake) {
            this.width = width;
            this.height = height;
            this.snake = snake;
            seed = new Random();
            makeApple();
        }

        public void makeApple() {
            do {
                apple = new Coordinate(seed.Next(width), seed.Next(height));
            } while (snake.contains(apple));
        }
    }
}
