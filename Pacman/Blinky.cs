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

	    private float totalTime;

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

        override public void Draw(RenderWindow window)
        {
            body.Position = new Vector2f(iPos * Grid.TILE_SIZE, jPos * Grid.TILE_SIZE + Grid.DRAW_OFFSET);
            window.Draw(body);

        }

        override public void Update(float time, Grid grid)
        {
	        totalTime += time;

            distances = PathFinding.InitMoves(distances, iPos, jPos);
            PathFinding.CalculateMoves(grid, iPos, jPos, pacman.iPos, pacman.jPos, ref distances);
	        for (int i = 0; i < distances.GetLength(1); i++)
	        {
		        for (int j = 0; j < distances.GetLength(0); j++)
		        {
					//if(distances[j, i] != int.MaxValue)
					//	Console.Write(distances[j,i]);
					//else
					//{
					//	Console.Write("X");
					//}
		        }
				//Console.WriteLine();
	        }
            nextMove = PathFinding.FindFirstMove(distances, pacman.iPos, pacman.jPos, pacman.iPos, pacman.jPos, nextMove);
            Console.WriteLine(nextMove);
	        if (totalTime > 0.2f)
	        {
		        totalTime = 0;
		        switch (nextMove)
		        {
			        case Direction.Down:
				        jPos++;
				        break;

			        case Direction.Left:
				        iPos--;
				        break;

			        case Direction.Right:
				        iPos++;
				        break;

			        case Direction.Up:
				        jPos++;
				        break;

		        }
	        }
        }
    }
}
