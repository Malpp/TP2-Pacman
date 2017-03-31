using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Pacman
{
    class Inky : Ghost
    {
        private Pacman pacman = new Pacman();
        private Blinky blinky = new Blinky();
        private static CircleShape body;

        private int iPos;
        private int jPos;

        private int iDest;
        private int jDest;

        private int[,] distances = new int[Grid.GRID_HEIGHT, Grid.GRID_WIDTH];
        private Direction nextMove = Direction.None;

        static Inky()
        {
            body = new CircleShape(Grid.TILE_SIZE / 2f);
            body.FillColor = Color.Cyan;
        }

        public Inky()
        {
            iPos = 11;
            jPos = 14;
        }

        public void Draw(RenderWindow window)
        {
            body.Position = new Vector2f(iPos * Grid.TILE_SIZE, jPos * Grid.TILE_SIZE + Grid.DRAW_OFFSET);
            window.Draw(body);

        }

        override public void Update(float time, Grid grid)
        {
            iDest = (blinky.IPos + pacman.iPos) / 2;
            jDest = (blinky.JPOS + pacman.jPos) / 2;
            distances = PathFinding.InitMoves(distances, iPos, iPos);
            PathFinding.CalculateMoves(grid, iPos, jPos, iDest, jDest, distances);
            nextMove = PathFinding.FindFirstMove(distances, iPos, jPos, iDest, jDest, nextMove);
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
