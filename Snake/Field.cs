using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    public class Field {
        public int width { get; private set; }
        public int height { get; private set; }

        Coordinate[] snake { get; set; }
        public Coordinate apple { get; private set; }
        internal Random seed;

        public Field(int width, int height) {
            this.width = width;
            this.height = height;
            snake = new Coordinate[width * height];
            seed = new Random();
        }

        private void MakeApple() {
            do {
                Coordinate c = new Coordinate(seed.Next(width), seed.Next(height));
            } while (false);
        }
    }
}
