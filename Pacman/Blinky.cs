using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Pacman
{
    class Blinky : Ghost
    {
        private Pacman pacman = new Pacman();

        private static CircleShape body;

        private int iPos;
        private int jPos;

        public int IPos
        {
            get { return iPos; }
        }

        public int JPOS
        {
            get { return jPos; }
        }

        private int[,] distances = new int[Grid.GRID_HEIGHT, Grid.GRID_WIDTH];
        private Direction nextMove = Direction.None;


        static Blinky()
        {
            body = new CircleShape(Grid.TILE_SIZE / 2f);
            body.FillColor = Color.Red;
        }

        public Blinky()
        {
            iPos = 14;
            jPos = 11;
        }

        public void Draw(RenderWindow window)
        {
            body.Position = new Vector2f(iPos * Grid.TILE_SIZE, jPos * Grid.TILE_SIZE + Grid.DRAW_OFFSET);
            window.Draw(body);

        }

        override public void Update(float time, Grid grid)
        {
            distances = PathFinding.InitMoves(distances, iPos, jPos);
            PathFinding.CalculateMoves(grid, iPos, jPos, pacman.iPos, pacman.jPos, distances);
            nextMove = PathFinding.FindFirstMove(distances, pacman.iPos, pacman.jPos, pacman.iPos, pacman.jPos, nextMove);
            Console.WriteLine(nextMove);
            switch (nextMove)
            {
                case Direction.Down:
                    iPos++;
                    break;

                case Direction.Left:
                    jPos--;
                    break;

                case Direction.Right:
                    jPos++;
                    break;

                case Direction.Up:
                    iPos++;
                    break;

            }
        }
    }
}
