using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class Snake {
        private List<Coordinate> body;
        private Direction direction;

        Snake(List<Coordinate> body, Direction direction) {
            this.body = body;
            this.direction = direction;
        }

        void updateHead(Coordinate newHead) {
            for (int i = body.Count - 1; i > 0; i--) {
                body[i] = body[i - 1];
            }
            body[0] = newHead;
        }

        void grow(Coordinate position) {
            body.Add(new Coordinate(position.x, position.y));
        }
    }
}
