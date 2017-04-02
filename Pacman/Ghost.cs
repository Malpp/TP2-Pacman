using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Pacman
{
    class Ghost
    {
        /// <summary>
        /// Indicates the state ghosts are in.
        /// </summary>
        private GhostNames names = GhostNames.blinky;
        private static CircleShape body;

        private static bool GotPacman;

        public const float UPDATE_TICKRATE = 0.3f;

        private int iPos;
        private int jPos;
        private float totalTime;
        private int[,] distances;
        private Direction nextMove;

        public Direction direction = Direction.Down;

        static Ghost()
        {
            body = new CircleShape(Grid.TILE_SIZE / 2f);
            GotPacman = false;
        }

		public Ghost(int jPos = 13, int iPos = 14)
		{

            distances = new int[Grid.GRID_WIDTH, Grid.GRID_HEIGHT];
            GotPacman = false;

			this.iPos = iPos;
			this.jPos = jPos;
			nextMove = Direction.None;
            switch (names)
            {
                case GhostNames.blinky:
                    iPos = 00;
                    jPos = 00;
                    body.FillColor = Color.Red;
                    break;
                case GhostNames.clyde:
                    iPos = 01;
                    jPos = 01;
                    body.FillColor = Color.Green;
                    break;
                case GhostNames.inky:
                    iPos = 02;
                    jPos = 02;
                    body.FillColor = Color.Cyan;
                    break;
                case GhostNames.pinky:
                    iPos = 03;
                    jPos = 03;
                    body.FillColor = Color.Magenta;
                    break;

            }
            nextMove = Direction.None;

        }

        public void Draw(RenderWindow window)
        {
            if (!GotPacman)
            {
                body.Position = new Vector2f(iPos * Grid.TILE_SIZE, jPos * Grid.TILE_SIZE + Grid.DRAW_OFFSET);
                window.Draw(body);
            }
        }

        public void Update(float time, Grid grid, Pacman pacman)
        {

            totalTime += time;

            //Frightened
            if (grid.IsPelletActive)
            {
                if(iPos == pacman.iPos && jPos == pacman.jPos)
                {
                    switch (names)
                    {
                        case GhostNames.blinky:
                            iPos = 00;
                            jPos = 00;
                            break;
                        case GhostNames.clyde:
                            iPos = 01;
                            jPos = 01;
                            break;
                        case GhostNames.inky:
                            iPos = 02;
                            jPos = 02;
                            break;
                        case GhostNames.pinky:
                            iPos = 03;
                            jPos = 03;
                            break;

                    }
                }
                ChangeToFrightenedMode();
                ManagePathfinding(grid, pacman);
                SuddenlyChangeDirection();

            }

            //distances = PathFinding.InitMoves(distances, iPos, jPos);
            //PathFinding.CalculateMoves(grid, iPos, jPos, pacman.iPos, pacman.jPos, ref distances);
            //for (int i = 0; i < distances.GetLength(1); i++)
            //{
            //	for (int j = 0; j < distances.GetLength(0); j++)
            //	{
            //		if (distances[j, i] != int.MaxValue)
            //			Console.Write(((distances[j, i] <= 9) ? "0" + distances[j, i] : distances[j, i] + "") + " ");
            //		else
            //		{
            //			Console.Write("XX ");
            //		}
            //	}
            //	Console.WriteLine();
            //}

            else
            {

                ManagePathfinding(grid, pacman);

                if (iPos == pacman.iPos && jPos == pacman.jPos && !GotPacman)
                {

                    GotPacman = true;
                    pacman.Caught();
                }
            }

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
                        jPos--;
                        break;
                }
            }
        }

        /// <summary>
        /// Changes the ghost to frightened mode
        /// </summary>
		private void ChangeToFrightenedMode()
        {
            body.FillColor = Color.Blue;
            SuddenlyChangeDirection();
        }

        /// <summary>
        /// 180 degree direction switch
        /// </summary>
        private void SuddenlyChangeDirection()
        {
            if (nextMove == Direction.Up)
                nextMove = Direction.Down;
            else if (nextMove == Direction.Down)
                nextMove = Direction.Up;
            else if (nextMove == Direction.Left)
                nextMove = Direction.Right;
            else if (nextMove == Direction.Right)
                nextMove = Direction.Left;
        }

        /// <summary>
        /// Manages the pathfinding so that it only applies at intersection and cover other possibilities
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="pacman"></param>
		private void ManagePathfinding(Grid grid, Pacman pacman)
        {
            int compteur = 0;
            bool upMovePossible = false;
            bool downMovePossible = false;
            bool leftMovePossible = false;
            bool rightMovePossible = false;

            //Check if move is possible and how many moves are possible
            if (iPos + 1 < distances.GetLength(0) && distances[iPos + 1, jPos] != int.MaxValue)
            {
                compteur++;
                downMovePossible = true;
            }
            if (iPos -1 >= 0 && distances[iPos - 1, jPos] != int.MaxValue)
            {
                compteur++;
                upMovePossible = true;
            }
            if (jPos + 1 < distances.GetLength(1) && distances[iPos, jPos + 1] != int.MaxValue)
            {
                compteur++;
                rightMovePossible = true;
            }
            if (jPos - 1 >= 0 && distances[iPos, jPos - 1] != int.MaxValue )
            {
                compteur++;
                leftMovePossible = true;
            }

            Direction lastMove = nextMove;

            if (lastMove == Direction.None)
            {
                return;
            }

            if (compteur > 2)
            {

                distances = PathFinding.InitMoves(distances, iPos, jPos);
                PathFinding.CalculateMoves(grid, iPos, jPos, pacman.iPos, pacman.jPos, ref distances);
                nextMove = PathFinding.FindFirstMove(distances, pacman.iPos, pacman.jPos, pacman.iPos, pacman.jPos, nextMove);

                //might be prone to bugs but don't have time to fix it.
                if (lastMove == nextMove) 
                {
                    SuddenlyChangeDirection();
                }
            }

            else if (compteur > 1)
            {
                //Check if path is straightforward ( can't go back from where it(ghost) was going)
                if (lastMove == Direction.Up || lastMove == Direction.Down && !leftMovePossible && !rightMovePossible)
                {
                    nextMove = lastMove;
                }

                else if (lastMove == Direction.Left || lastMove == Direction.Right && !upMovePossible && !downMovePossible)
                {
                    nextMove = lastMove;
                }
                //Assume that there is an intersection so 90 degree turn.
                else if (lastMove == Direction.Up || lastMove == Direction.Down)
                {
                    if (leftMovePossible)
                    {
                        nextMove = Direction.Left;
                    }

                    else if (rightMovePossible)
                    {
                        nextMove = Direction.Right;
                    }

                    else if (lastMove == Direction.Left || lastMove == Direction.Right)
                    {
                        if (upMovePossible)
                        {
                            nextMove = Direction.Up;
                        }

                        else if (downMovePossible)
                        {
                            nextMove = Direction.Down;
                        }
                    }
                }
            }

            else
            {
                nextMove = lastMove;
            }

        }

        private void DoRandomMove()
        {
            
            Random rnd = new Random();
            
        }



    }
}

