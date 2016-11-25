using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
