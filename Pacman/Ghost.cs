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
        private CircleShape body;

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
            GotPacman = false;
        }

        public Ghost(GhostNames name)
        {

			body = new CircleShape(Grid.TILE_SIZE / 2f);

			distances = new int[Grid.GRID_WIDTH, Grid.GRID_HEIGHT];
            GotPacman = false;
            nextMove = Direction.None;
            switch (name)
            {
                case GhostNames.blinky:
                    iPos = 11;
                    jPos = 13;
                    body.FillColor = Color.Red;
                    break;
                case GhostNames.clyde:
                    iPos = 13;
                    jPos = 11;
                    body.FillColor = Color.Green;
                    break;
                case GhostNames.inky:
                    iPos = 13;
                    jPos = 13;
                    body.FillColor = Color.Cyan;
                    break;
                case GhostNames.pinky:
                    iPos = 15;
                    jPos = 13;
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

        public void Update(float time, Grid grid, Pacman pacman, GhostNames name)
        {

            totalTime += time;

            //Frightened
            if (grid.IsPelletActive)
            {
                if (iPos == pacman.iPos && jPos == pacman.jPos)
                {
                    switch (name)
                    {
                        case GhostNames.blinky:
                            iPos = 11;
                            jPos = 13;
                            Score.EatGhost();
                            break;
                        case GhostNames.clyde:
                            iPos = 13;
                            jPos = 11;
                            Score.EatGhost();
                            break;
                        case GhostNames.inky:
                            iPos = 13;
                            jPos = 13;
                            Score.EatGhost();
                            break;
                        case GhostNames.pinky:
                            iPos = 15;
                            jPos = 13;
                            Score.EatGhost();
                            break;

                    }
                }
                ChangeToFrightenedMode();
                distances = PathFinding.InitMoves(distances, iPos, jPos);
                PathFinding.CalculateMoves(grid, iPos, jPos, pacman.iPos, pacman.jPos, ref distances);
                nextMove = PathFinding.FindFirstMove(distances, pacman.iPos, pacman.jPos, pacman.iPos, pacman.jPos, nextMove);
            }

            //chase
            else
            {
                Score.ResetMultipler();
                switch (name)
                {
                    case GhostNames.blinky:
                        body.FillColor = Color.Red;
                        break;
                    case GhostNames.clyde:
                        body.FillColor = Color.Green;
                        break;
                    case GhostNames.inky:
                        body.FillColor = Color.Cyan;
                        break;
                    case GhostNames.pinky:
                        body.FillColor = Color.Magenta;
                        break;
                }

                distances = PathFinding.InitMoves(distances, iPos, jPos);
                PathFinding.CalculateMoves(grid, iPos, jPos, pacman.iPos, pacman.jPos, ref distances);
                nextMove = PathFinding.FindFirstMove(distances, pacman.iPos, pacman.jPos, pacman.iPos, pacman.jPos, nextMove);

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
    }
}

