using System;
using System.Collections.Generic;

namespace Snake {
    public class Frame : Field{

        public Frame(Field field) : base(field.width, field.height, field.snake) {}

        // Output a list of render commands
        public List<Command> nextFrame(Direction direction) {
            List<Command> commands = new List<Command>();
            Coordinate next_head = nextHead(direction);
            if (snake.contains(next_head) && !snake.get(snake.length -1).Equals(next_head)) {
                commands.Add(new PauseCommand());
            } else {
                if (snake.get(0).Equals(apple)) {
                    snake.grow(next_head);
                    makeApple();
                    commands.Add(new DrawCommand(DrawCommand.APPLE, apple));
                } else {
                    commands.Add(new DrawCommand(DrawCommand.EMPTY, snake.get(snake.length - 1)));
                }
                commands.Add(new DrawCommand(DrawCommand.APPLE, apple));    // should only ran on first loop
                snake.updateHead(next_head);
                commands.Add(new DrawCommand(DrawCommand.SNAKE, next_head));
            }
            return commands;
        }

        private Coordinate nextHead(Direction direction) {
            int x = snake.get(0).x;
            int y = snake.get(0).y;

            if (direction.Equals(Direction.LEFT)) {
                x = x - 1;
                x = (x < 0) ? width + x : x % width;
            } else if (direction.Equals(Direction.UP)) {
                y = y - 1;
                y = (y < 0) ? height + y : y % height;
            } else if (direction.Equals(Direction.RIGHT)) {
                x = (x + 1) % width;
            } else if (direction.Equals(Direction.DOWN)) {
                y = (y + 1) % height;
            } else {
                Console.WriteLine("You messed something up mate");
            }

            return new Coordinate(x, y);
        }
    }
}
