using System.Collections.Generic;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Snake {
    class Renderer {
        private DispatcherTimer timer;
        private Rectangle[][] blocks;

        public Renderer(DispatcherTimer timer, Rectangle[][] blocks) {
            this.timer = timer;
            this.blocks = blocks;
        }

        public void render(List<Command> commands) {
            foreach (Command c in commands) {
                if (c.GetType() == typeof(DrawCommand)) {
                    DrawCommand com = (DrawCommand) c;
                    blocks[((DrawCommand) c).location.x][((DrawCommand)c).location.y].Fill = ((DrawCommand) c).type;
                } else if (c.GetType() == typeof(PauseCommand)) {
                    timer.Stop();
                }
            }
        }
    }
}
